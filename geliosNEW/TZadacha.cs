using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace geliosNEW
{
    public class TZadacha
    {
        double f_TMax;
        double f_VMax;
        string f_OptB;
        string f_OptT;
        string f_OptV;
        string f_Sostav;
        int f_Cnt_alt;
        int f_CntComm;
        bool f_CheckNud;
        public TPredicateTree f_Tree;
        TDynamicArray f_Equal;
        TPartialDecision f_PartialDecision;
        List<object> f_ListPTI;
        TDischargedMassiv ozenk_t;
        TDischargedMassiv ozenk_v;
        string f_FullPredcateModel;

        void DoEqual()
        {
            int m_id;
            int d = f_Tree.Count;
            TPredicateTreeItem TI;
            TDynamicArray A = new TDynamicArray();
            for (int i = 0; i <= d - 1; i++)
            {
                TI = f_Tree.GetItems(i);
                for (int j = 0; j <= TI.Count - 1; j++)
                {
                    m_id = TI.GetTFE_ID(j);
                    f_Tree.FindByTfeID(m_id, A);
                    if (A.Count > 1)
                        if (f_Equal.Find((object)m_id)==null)
                            f_Equal.Append((object)m_id);
                }
            }
            A = null;
        }
        void SavePredicateModelToTempFile()
        {
            using (FileStream fstream = new FileStream("temp_1.dec", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(f_FullPredcateModel);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }
        }
        bool CheckCanDecision(ref int AID)
        {
            int m_id;
            TBaseShape B;
            TPredicateTreeItem TI, TJ;
            for (int i = 0; i <= f_Tree.Count - 1; i++)
            {
                TI = f_Tree.GetItems(i);
                for (int j = 0; j <= TI.Count - 1; j++)
                {
                    m_id = TI.GetTFE_ID(j);
                    TJ = f_Tree.FindByParentID(m_id);
                    if (TJ==null)
                    {
                        B = TI.GetTFE(j);
                        if (B!=null)
                        {
                            if (B.ParamAlt==null)
                            {
                                AID = m_id;
                                return false;
                            }
                        }
                        else
                        {
                            AID = m_id;
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        bool CheckPLGParamAlternative(TParamAlternative AL)
        {
            int plg;
            int trucnt = 0;
            string Pr;
            TParamAlternativeItem Item;
            for (int i = 0; i <= AL.Count - 1; i++)
            {
                Item = AL.Items[i];
                Item.PREDICAT = Item.PREDICAT.TrimStart(' ');
                Pr = Item.PREDICAT.TrimEnd(' ');
                if (string.Compare(Pr, "1",true) == 0 || string.Compare(Pr, "(нет условия)", true) == 0)
                    Item.CheckPLG = true;
                else if (string.Compare(Pr, "0") == 0)
                    Item.CheckPLG = false;
                else
                {
                    plg = SharedConst.gPieModule.Run1("tell(\"temp.pra\"),reconsult(\"temp_1.dec\")," + Pr);
                    Item.CheckPLG = plg > 0;
                }
            }

            for (int i = 0; i <= AL.Count - 1; i++)
            {
                Item = AL.Items[i];
                if (Item.CheckPLG)
                {
                    trucnt++;
                    break;
                }
            }
            return trucnt > 0;
        }
        bool CheckCanPLGDecision(ref int AID)
        {
            int m_id;
            TBaseShape B;
            TPredicateTreeItem TI, TJ;
            for (int i = 0; i <= f_Tree.Count - 1; i++)
            {
                TI = f_Tree.GetItems(i);
                for (int j = 0; j <= TI.Count - 1; j++)
                {
                    m_id = TI.GetTFE_ID(j);
                    B = TI.GetTFE(j);
                    if (B!=null && B.ParamAlt!=null)
                    {
                        if (!CheckPLGParamAlternative(B.ParamAlt) && (B.TypeShape != 8) && f_Tree.FindByParentID(m_id)==null)
                        {
                            AID = m_id;
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        void ChekDeleted(TPredicateTreeItem AI)
        {
            TPartialDecisionItem DI;
            TDynamicArray D = new TDynamicArray();
            f_Tree.ArrayIDToDelete(AI, ref D);
            for (int i = 0; i <= D.Count - 1; i++)
            {
                int del = (int)D.GetItems(i);
                DI = f_PartialDecision.FindPartialDecisionItemByParentID(del);
                while (DI!=null)
                {
                    f_PartialDecision.FreeItem(DI);
                    DI = f_PartialDecision.FindPartialDecisionItemByParentID(del);
                }
            }
        }
        //отсечение ПА, не подходящих по ограничениям и поиск экстремума
        void get_opt_alt()
        {
            //Алгоритм:
            //1. Просматриваем все ПА
            //2, Учитываем все ограничения и отсекаем все ПА, которые не подходят по ограничениям
            //3, Снова просматриваем все ПА
            //4, Находим экстремум для выбранной функции оптимизации
            string str;
            double b, t, v;
            double Bd, Td, Vd;
            double Bmax = 0, Tmax = 0, Vmax = 0, Bmin = 0, Tmin = 0, Vmin = 0;
            double C1, C2, C3;
            int type_sad, type_ogr;
            TPartialDecisionItem PDI;
            TParamAlternative PA;
            TParamAlternativeItem AI;
            type_sad = SharedConst.opt_sadacha.type_sadacha;
            type_ogr = SharedConst.opt_sadacha.type_ogr;
            Bd = Double.Parse(SharedConst.opt_sadacha.Bd);
            Td = Double.Parse(SharedConst.opt_sadacha.Td);
            Vd = Double.Parse(SharedConst.opt_sadacha.Vd);
            C1 = Double.Parse(SharedConst.opt_sadacha.c1);
            C2 = Double.Parse(SharedConst.opt_sadacha.c2);
            C3 = Double.Parse(SharedConst.opt_sadacha.c3);

            //ищем экстремум , не учитывая те ПА, которые не подходят по ограничениям
            double Max=0, Min=0, Func=0, Func_1;
            int num_extr;

            PDI = f_PartialDecision.GetItems(0);
            PA = PDI.ParamAlt;
            AI = PA.Items[0];
            switch (type_sad)
            {
                case SharedConst.ZAD_1: Max = -1; break;
                case SharedConst.ZAD_2: Min = AI.T; break;
                case SharedConst.ZAD_3: Min = AI.V; break;
                case SharedConst.ZAD_4: Func = -100000000; break;
                case SharedConst.ZAD_5://нужно найти максимальные и минимальные значения для нормировки
                    Bmax = -1; Tmax = -1; Vmax = -1;
                    Bmin = 2; Tmin = 100000000; Vmin = 100000000;
                    for (int i = 0; i <= PA.Count - 1; i++)
                    {
                        AI = PA.Items[i];
                        b = AI.B;
                        t = AI.T;
                        v = AI.V;
                        if (b > Bmax) Bmax = b; if (t > Tmax) Tmax = t; if (v > Vmax) Vmax = v;
                        if (b < Bmin) Bmin = b; if (t < Tmin) Tmin = t; if (v < Vmin) Vmin = v;
                    }
                    if (Bmax == Bmin || Tmax == Tmin || Vmax == Vmin)
                    {
                        MessageBox.Show("Деление на ноль при расчете значения критерия оптимальности!\nРешение неверное!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Func = -10000;
                    break;

                case SharedConst.ZAD_6: Func = -1; break;
            }
            num_extr = 0;
            bool n = false, exist_des = false;
            int cnt_alt = 0;
            for (int i = 0; i <= PA.Count - 1; i++)
            //while(!char_form.Table1.Eof)
            {
                AI = PA.Items[i];
                b = AI.B;
                t = AI.T;
                v = AI.V;
                str = AI.SOSTAV;
                switch (type_sad)//не ищем экстрему среди записей, не подходящих по ограничениям
                {
                    case SharedConst.ZAD_1:
                        switch (type_ogr)//задача по В
                        {
                            case 1:
                                if (v > Vd) n = true;//критерий V
                                else n = false;
                                break;
                            case 2:
                                if (t > Td) n = true;//критерий T
                                else n = false;
                                break;
                            case 3:
                                if (v > Vd || t > Td) n = true;//критерий V и T
                                else n = false;
                                break;
                            case 4:
                                if (unpack_sostav(str) == 0) n = true;
                                else n = false;
                                break;
                            case 5:
                                if (v > Vd || unpack_sostav(str) == 0) n = true;//критерий V
                                else n = false;
                                break;
                            case 6:
                                if (t > Td || unpack_sostav(str) == 0) n = true;//критерий T
                                else n = false;
                                break;
                            case 7:
                                if (v > Vd || t > Td || unpack_sostav(str) == 0) n = true;//критерий V и T
                                else n = false;
                                break;

                        }
                        break;
                    case SharedConst.ZAD_2:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по Т
                        {
                            case 1:
                                if (v > Vd) n = true;//критерий V
                                else n = false;
                                break;
                            case 2:
                                if (b < Bd) n = true;//критерий B
                                else n = false;
                                break;
                            case 3:
                                if (b < Bd || v > Vd) n = true;//критерий V и B
                                else n = false;
                                break;
                            case 4:
                                if (unpack_sostav(str) == 0) n = true;
                                else n = false;
                                break;
                            case 5:
                                if (v > Vd || unpack_sostav(str) == 0) n = true;//критерий V
                                else n = false;
                                break;
                            case 6:
                                if (b < Bd || unpack_sostav(str) == 0) n = true;//критерий B
                                else n = false;
                                break;
                            case 7:
                                if (b < Bd || v > Vd || unpack_sostav(str) == 0) n = true;//критерий V и B
                                else n = false;
                                break;
                        }
                        break;
                    case SharedConst.ZAD_3:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по V
                        {
                            case 1:
                                if (b < Bd) n = true;//критерий B
                                else n = false;
                                break;
                            case 2:
                                if (t > Td) n = true;//критерий T
                                else n = false;
                                break;
                            case 3:
                                if (t > Td || b < Bd) n = true;//критерий T и B
                                else n = false;
                                break;
                            case 4:
                                if (unpack_sostav(str) == 0) n = true;
                                else n = false;
                                break;
                            case 5:
                                if (b < Bd || unpack_sostav(str) == 0) n = true;//критерий B
                                else n = false;
                                break;
                            case 6:
                                if (t > Td || unpack_sostav(str) == 0) n = true;//критерий T
                                else n = false;
                                break;
                            case 7:
                                if (t > Td || b < Bd || unpack_sostav(str) == 0) n = true;//критерий T и B
                                else n = false;
                                break;

                        }
                        break;
                }
                if (!n)//если опдходит по ограничениям
                {
                    AI.Tag = 1;
                    exist_des = true;
                    switch (type_sad)
                    {
                        case SharedConst.ZAD_1:
                            if (Max <= b) { Max = b; num_extr = i; }
                            break;
                        case SharedConst.ZAD_2:
                            if (Min >= t) { Min = t; num_extr = i; }
                            break;
                        case SharedConst.ZAD_3:
                            if (Min >= v) { Min = v; num_extr = i; }
                            break;
                        case SharedConst.ZAD_4:
                            C1 = Double.Parse(SharedConst.opt_sadacha.c1);
                            C2 = Double.Parse(SharedConst.opt_sadacha.c2);
                            C3 = Double.Parse(SharedConst.opt_sadacha.c3);
                            Func_1 = C1 * b - C2 * t - C3 * v;
                            if (Func_1 > Func) { Func = Func_1; num_extr = i; }
                            break;
                        case SharedConst.ZAD_5:
                            C1 = Double.Parse(SharedConst.opt_sadacha.c1);
                            C2 = Double.Parse(SharedConst.opt_sadacha.c2);
                            C3 = Double.Parse(SharedConst.opt_sadacha.c3);
                            Func_1 = C1 * (b - Bmax) / (Bmax - Bmin) + C2 * (t - Tmax) / (Tmax - Tmin) + C3 * (v - Vmax) / (Vmax - Vmin);
                            if (Func_1 > Func) { Func = Func_1; num_extr = i; }
                            break;
                        case SharedConst.ZAD_6:
                            double l, k, m;
                            l = Double.Parse(SharedConst.opt_sadacha.c1);
                            k = Double.Parse(SharedConst.opt_sadacha.c2);
                            m = Double.Parse(SharedConst.opt_sadacha.c3);
                            if (t == 0 || v == 0)
                            {
                                MessageBox.Show("Деление на ноль при расчете значения критерия оптимальности!\nРешение неверное!", "Ошибка!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                                return;
                            }
                            Func_1 = Math.Pow(b, l) / Math.Pow(t, k) / Math.Pow(v, m);
                            if (Func_1 > Func) 
                            { 
                                Func = Func_1; 
                                num_extr = i; 
                            }
                            break;
                    }
                    cnt_alt++;
                }
            }

            //char_form.Table1.First();

            if (exist_des == false)
            {
                f_OptB = "(нет)";
                f_OptT = "(нет)";
                f_OptV = "(нет)";
                f_Sostav = "(нет альтернатив,подходящих по ограничениям)";
                f_Cnt_alt = 0;
            }
            else
            {
                AI = PA.Items[num_extr];
                // оптимальное решение
                f_OptB = AI.B.ToString();
                f_OptT = AI.T.ToString();
                f_OptV = AI.V.ToString();
                f_Sostav = AI.SOSTAV;
                f_Cnt_alt = cnt_alt;
            }
            f_CntComm = PA.Count;
        }
        void get_opt_alt_fuz()
        {
            //Алгоритм:
            //1. Просматриваем все ПА
            //2, Учитываем все ограничения и отсекаем все ПА, которые не подходят по ограничениям
            //3, Снова просматриваем все ПА
            //4, Находим экстремум для выбранной функции оптимизации

            string str;
            double b, t, v;
            double Bd, Td, Vd;
            double Bmax = 0, Tmax = 0, Vmax = 0, Bmin = 0, Tmin = 0, Vmin = 0;
            double C1, C2, C3;
            int type_sad, type_ogr;
            TPartialDecisionItem PDI;
            TParamAlternative PA;
            TParamAlternativeItem AI;
            type_sad = SharedConst.opt_sadacha.type_sadacha;
            type_ogr = SharedConst.opt_sadacha.type_ogr;
            Bd = Double.Parse(SharedConst.opt_sadacha.Bd);
            Td = Double.Parse(SharedConst.opt_sadacha.Td);
            Vd = Double.Parse(SharedConst.opt_sadacha.Vd);
            C1 = Double.Parse(SharedConst.opt_sadacha.c1);
            C2 = Double.Parse(SharedConst.opt_sadacha.c2);
            C3 = Double.Parse(SharedConst.opt_sadacha.c3);


            //ищем экстремум , не учитывая те ПА, которые не подходят по ограничениям
            double Max = 0, Min = 0, Func = 0, Func_1;
            int num_extr;

            PDI = f_PartialDecision.GetItems(0);
            PA = PDI.ParamAlt;
            AI = PA.Items[0];

            switch (type_sad)
            {
                case SharedConst.ZAD_1: Max = -1; break;
                case SharedConst.ZAD_2: Min = 100000000; break;
                case SharedConst.ZAD_3: Min = 100000000; break;
                case SharedConst.ZAD_4: Func = -100000000; break;
                case SharedConst.ZAD_5://нужно найти максимальные и минимальные значения для нормировки
                    Bmax = -1; Tmax = -1; Vmax = -1;
                    Bmin = 2; Tmin = 100000000; Vmin = 100000000;
                    for (int i = 0; i <= PA.Count - 1; i++)
                    {
                        AI = PA.Items[i];
                        b = (AI.B_F1N +
                        AI.B_F1B +
                        AI.B_F2N +
                        AI.B_F2B +
                        AI.B_F3N +
                        AI.B_F3B) / 6.0;

                        t = (AI.T_F1N +
                        AI.T_F1B +
                        AI.T_F2N +
                        AI.T_F2B +
                        AI.T_F3N +
                        AI.T_F3B) / 6.0;

                        v = (AI.V_F1N +
                        AI.V_F1B +
                        AI.V_F2N +
                        AI.V_F2B +
                        AI.V_F3N +
                        AI.V_F3B) / 6.0;

                        if (b > Bmax) Bmax = b; if (t > Tmax) Tmax = t; if (v > Vmax) Vmax = v;
                        if (b < Bmin) Bmin = b; if (t < Tmin) Tmin = t; if (v < Vmin) Vmin = v;

                    }
                    if (Bmax == Bmin || Tmax == Tmin || Vmax == Vmin)
                    {
                        MessageBox.Show("Деление на ноль при расчете значения критерия оптимальности!\nРешение неверное!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Func = -10000;
                    break;

                case SharedConst.ZAD_6: Func = -1; break;
            }
            num_extr = 0;
            bool n = false, exist_des = false;
            int cnt_alt = 0;
            for (int i = 0; i <= PA.Count - 1; i++)
            //while(!char_form.Table1.Eof)
            {
                AI = PA.Items[i];
                b = (AI.B_F1N +
                AI.B_F1B +
                AI.B_F2N +
                AI.B_F2B +
                AI.B_F3N +
                AI.B_F3B) / 6.0;

                t = (AI.T_F1N +
                AI.T_F1B +
                AI.T_F2N +
                AI.T_F2B +
                AI.T_F3N +
                AI.T_F3B) / 6.0;

                v = (AI.V_F1N +
                AI.V_F1B +
                AI.V_F2N +
                AI.V_F2B +
                AI.V_F3N +
                AI.V_F3B) / 6.0;

                str = AI.SOSTAV;
                switch (type_sad)//не ищем экстрему среди записей, не подходящих по ограничениям
                {
                    case SharedConst.ZAD_1:
                        switch (type_ogr)//задача по В
                        {
                            case 1:
                                if (v > Vd) n = true;//критерий V
                                else n = false;
                                break;
                            case 2:
                                if (t > Td) n = true;//критерий T
                                else n = false;
                                break;
                            case 3:
                                if (v > Vd || t > Td) n = true;//критерий V и T
                                else n = false;
                                break;
                            case 4:
                                if (unpack_sostav(str) == 0) n = true;
                                else n = false;
                                break;
                            case 5:
                                if (v > Vd || unpack_sostav(str) == 0) n = true;//критерий V
                                else n = false;
                                break;
                            case 6:
                                if (t > Td || unpack_sostav(str) == 0) n = true;//критерий T
                                else n = false;
                                break;
                            case 7:
                                if (v > Vd || t > Td || unpack_sostav(str) == 0) n = true;//критерий V и T
                                else n = false;
                                break;
                        }
                        break;
                    case SharedConst.ZAD_2:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по Т
                        {
                            case 1:
                                if (v > Vd) n = true;//критерий V
                                else n = false;
                                break;
                            case 2:
                                if (b < Bd) n = true;//критерий B
                                else n = false;
                                break;
                            case 3:
                                if (b < Bd || v > Vd) n = true;//критерий V и B
                                else n = false;
                                break;
                            case 4:
                                if (unpack_sostav(str) == 0) n = true;
                                else n = false;
                                break;
                            case 5:
                                if (v > Vd || unpack_sostav(str) == 0) n = true;//критерий V
                                else n = false;
                                break;
                            case 6:
                                if (b < Bd || unpack_sostav(str) == 0) n = true;//критерий B
                                else n = false;
                                break;
                            case 7:
                                if (b < Bd || v > Vd || unpack_sostav(str) == 0) n = true;//критерий V и B
                                else n = false;
                                break;
                        }
                        break;
                    case SharedConst.ZAD_3:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по V
                        {
                            case 1:
                                if (b < Bd) n = true;//критерий B
                                else n = false;
                                break;
                            case 2:
                                if (t > Td) n = true;//критерий T
                                else n = false;
                                break;
                            case 3:
                                if (t > Td || b < Bd) n = true;//критерий T и B
                                else n = false;
                                break;
                            case 4:
                                if (unpack_sostav(str) == 0) n = true;
                                else n = false;
                                break;
                            case 5:
                                if (b < Bd || unpack_sostav(str) == 0) n = true;//критерий B
                                else n = false;
                                break;
                            case 6:
                                if (t > Td || unpack_sostav(str) == 0) n = true;//критерий T
                                else n = false;
                                break;
                            case 7:
                                if (t > Td || b < Bd || unpack_sostav(str) == 0) n = true;//критерий T и B
                                else n = false;
                                break;

                        }
                        break;
                }
                if (!n)//если опдходит по ограничениям
                {
                    AI.Tag = 1;
                    exist_des = true;
                    switch (type_sad)
                    {
                        case SharedConst.ZAD_1:
                            if (Max <= b) { Max = b; num_extr = i; }
                            break;
                        case SharedConst.ZAD_2:
                            if (Min >= t) { Min = t; num_extr = i; }
                            break;
                        case SharedConst.ZAD_3:
                            if (Min >= v) { Min = v; num_extr = i; }
                            break;
                        case SharedConst.ZAD_4:
                            C1 = Double.Parse(SharedConst.opt_sadacha.c1);
                            C2 = Double.Parse(SharedConst.opt_sadacha.c2);
                            C3 = Double.Parse(SharedConst.opt_sadacha.c3);
                            Func_1 = C1 * b - C2 * t - C3 * v;
                            if (Func_1 > Func) { Func = Func_1; num_extr = i; }
                            break;
                        case SharedConst.ZAD_5:
                            C1 = Double.Parse(SharedConst.opt_sadacha.c1);
                            C2 = Double.Parse(SharedConst.opt_sadacha.c2);
                            C3 = Double.Parse(SharedConst.opt_sadacha.c3);
                            Func_1 = C1 * (b - Bmax) / (Bmax - Bmin) + C2 * (t - Tmax) / (Tmax - Tmin) + C3 * (v - Vmax) / (Vmax - Vmin);
                            if (Func_1 > Func) { Func = Func_1; }
                            break;
                        case SharedConst.ZAD_6:
                            double l, k, m;
                            l = Double.Parse(SharedConst.opt_sadacha.c1);
                            k = Double.Parse(SharedConst.opt_sadacha.c2);
                            m = Double.Parse(SharedConst.opt_sadacha.c3);
                            if (t == 0 || v == 0)
                            {
                                MessageBox.Show("Деление на ноль при расчете значения критерия оптимальности!\nРешение неверное!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            Func_1 = Math.Pow(b, l) / Math.Pow(t, k) / Math.Pow(v, m);
                            if (Func_1 > Func) { Func = Func_1; num_extr = i; }

                            break;
                    }
                    cnt_alt++;
                }
                //      char_form.Table1.Next();
            }

            //char_form.Table1.First();

            if (exist_des == false)
            {
                f_OptB = "(нет)";
                f_OptT = "(нет)";
                f_OptV = "(нет)";
                f_Sostav = "(нет альтернатив,подходящих по ограничениям)";
                f_Cnt_alt = 0;
            }
            else
            {
                AI = PA.Items[num_extr];

                //отображаем оптимальное решение
                f_OptB = "[[" + AI.A1_B_F.ToString() +
                                  "," + AI.B_F1N.ToString() +
                                  "," + AI.B_F1B.ToString() +
                                  "],[" + AI.A2_B_F.ToString() +
                                  "," + AI.B_F2N.ToString() +
                                  "," + AI.B_F2B.ToString() +
                                  "],[" + AI.A3_B_F.ToString() +
                                  "," + AI.B_F3N.ToString() +
                                  "," + AI.B_F3B.ToString() +
                                  "]]";

                f_OptT = "[[" + AI.A1_T_F.ToString() +
                          "," + AI.T_F1N.ToString() +
                          "," + AI.T_F1B.ToString() +
                          "],[" + AI.A2_T_F.ToString() +
                          "," + AI.T_F2N.ToString() +
                          "," + AI.T_F2B.ToString() +
                          "],[" + AI.A3_T_F.ToString() +
                          "," + AI.T_F3N.ToString() +
                          "," + AI.T_F3B.ToString() +
                          "]]";

                f_OptV = "[[" + AI.A1_V_F.ToString() +
                          "," + AI.V_F1N.ToString() +
                          "," + AI.V_F1B.ToString() +
                          "],[" + AI.A2_V_F.ToString() +
                          "," + AI.V_F2N.ToString() +
                          "," + AI.V_F2B.ToString() +
                          "],[" + AI.A3_V_F.ToString() +
                          "," + AI.V_F3N.ToString() +
                          "," + AI.V_F3B.ToString() +
                          "]]";


                f_Sostav = AI.SOSTAV;
                f_Cnt_alt = cnt_alt;
            }

            f_CntComm = PA.Count;

        }
        void Nud_podgot()
        {
            int m_indx;
            TBaseShape B;
            TParamAlternative PA;
            TPredicateTreeItem TI;

            ozenk_t.SetVal(0,0,ozenk_t_min(null));
            ozenk_v.SetVal(0,0,ozenk_v_min(null));

            for (int i = CountPTI - 1; i >= 0; i--)
            {
                TI = (TPredicateTreeItem)f_ListPTI[i];
                for (int j = 0; j <= TI.Count - 1; j++)
                {
                    B = TI.GetTFE(j);
                    m_indx = TI.GetTFE_ID(j);
                    ozenk_t.SetVal(0,m_indx, ozenk_t_min(B));
                    ozenk_v.SetVal(0,m_indx, ozenk_v_min(B));
                }
            }
        }
        double ozenk_t_min(TBaseShape B)
        {
            double t, Tmin;
            double t_n_f1n, t_n_f1b, t_n_f2n, t_n_f2b, t_n_f3n, t_n_f3b;
            //ищем экстремум, не учитывая те ПА, которые не подходят по ограничениям
            Tmin = 100000000;
            if (B!=null && B.ParamAlt!=null)
            {
                TParamAlternative PA = B.ParamAlt;
                for (int i = 0; i <= PA.Count - 1; i++)
                {
                    TParamAlternativeItem PAI = PA.Items[i];
                    if (f_PartialDecision.Type_Char == SharedConst.PROP)
                        t = PAI.T;
                    else
                    {
                        t_n_f1n = PAI.T_F1N;
                        t_n_f1b = PAI.T_F1B;
                        t_n_f2n = PAI.T_F2N;
                        t_n_f2b = PAI.T_F2B;
                        t_n_f3n = PAI.T_F3N;
                        t_n_f3b = PAI.T_F3B;
                        t = (t_n_f1n + t_n_f1b + t_n_f2n + t_n_f2b + t_n_f3n + t_n_f3b) / 6.0;
                    }
                    if (t < Tmin)
                        Tmin = t;
                }
            }
            return Tmin;
        }
        double ozenk_v_min(TBaseShape B)
        {
            double v, Vmin;
            double v_n_f1n, v_n_f1b, v_n_f2n, v_n_f2b, v_n_f3n, v_n_f3b;
            //ищем экстремум, не учитывая те ПА, которые не подходят по ограничениям
            Vmin = 100000000;
            if (B!=null && B.ParamAlt!=null)
            {
                TParamAlternative PA = B.ParamAlt;
                for (int i = 0; i <= PA.Count - 1; i++)
                {
                    TParamAlternativeItem PAI = PA.Items[i];
                    if (f_PartialDecision.Type_Char == SharedConst.PROP)
                        v = PAI.V;
                    else
                    {
                        v_n_f1n = PAI.V_F1N;
                        v_n_f1b = PAI.V_F1B;
                        v_n_f2n = PAI.V_F2N;
                        v_n_f2b = PAI.V_F2B;
                        v_n_f3n = PAI.V_F3N;
                        v_n_f3b = PAI.V_F3B;
                        v = (v_n_f1n + v_n_f1b + v_n_f2n + v_n_f2b + v_n_f3n + v_n_f3b) / 6.0;
                    }
                    if (v < Vmin)
                        Vmin = v;
                }
            }
            return Vmin;
        }
        void ClearPTI()
        {
            f_ListPTI.Clear();
        }
        void AddPTI(TPredicateTreeItem AItem)
        {
            if (f_ListPTI.IndexOf(AItem) < 0)
                f_ListPTI.Add(AItem);
        }
        public TPredicateTreeItem  GetPTI(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_ListPTI.Count - 1)
                return (TPredicateTreeItem)(f_ListPTI.ElementAt(AIndex));
            else
                return null;
        }
        int GetCountPTI() { return f_ListPTI.Count; }
     /*       AnsiString DoCheckEqualTree();
            AnsiString DoCheckLogic();
            AnsiString DoCheckLogicItemUP(TPredicateScannerItemKnot* AKnot, int AID);
            AnsiString DoCheckLogicItemDown(TPredicateScannerItemKnot* AKnot, int AID);
            TPredicateTreeItem* FindToTree(TPredicateScannerItemKnot* AKnot);
            TPredicateScannerItemKnot* FindToScanner(TPredicateTreeItem* AItem);*/
        double Get_V_Min(TPredicateTreeItem ATI, int AIndex)
        {
            int idx = ATI.GetTFE_ID(AIndex);
            if (idx == 0)
                return 100000000.0;
            if (idx < 0)
                return (double)ozenk_v.GetItems(1,idx); //bbb
            double v1 = (double)ozenk_v.GetItems(1,idx); //bbb
            double v2 = (double)ozenk_v.GetVal(idx); //bbb
            return Math.Min(v1, v2);
        }

        double Get_T_Min(TPredicateTreeItem ATI, int AIndex)
        {
            int idx = ATI.GetTFE_ID(AIndex);
            if (idx == 0)
                return 100000000.0;
            if (idx < 0)
                return (double)ozenk_t.GetItems(1,idx); //aaa
            double t1 = (double)ozenk_t.GetItems(1,idx); //aaa
            double t2 = (double)ozenk_t.GetVal(idx); //aaa
            return Math.Min(t1, t2);
        }
        public TPredicateScanner Scanner;
        public TPredicateTrackCreator TrackCreator;
        public TZadacha()
        {
            f_Cnt_alt = 0;
            f_CntComm = 0;
            f_CheckNud = false;
            f_TMax = 100000000.0;
            f_VMax = 100000000.0;
            f_Tree = new TPredicateTree();
            f_Equal = new TDynamicArray();
            f_PartialDecision = new TPartialDecision(this);
            f_ListPTI = new List<object>();
            Scanner = new TPredicateScanner();
            TrackCreator = new TPredicateTrackCreator();
            ozenk_t = new TDischargedMassiv(100000000.0);
            ozenk_v = new TDischargedMassiv(100000000.0);

        }
        ~TZadacha() { }
        public void Clear()
        {
            f_Tree.Clear();
            f_Equal.Clear();
            ClearPTI();
            TrackCreator.ClearTrack();
            TrackCreator.ClearBase();
        }
        public void Init(int AType_Char, bool ACheckNud, string AFullPredcateModel)
        {
            TPredicateTreeItem TI;
            TPredicateScannerItemKnot Knot;
            f_CheckNud = ACheckNud;
            DoEqual();
            ozenk_t.Clear();
            ozenk_v.Clear();
            f_FullPredcateModel = AFullPredcateModel;
            SharedConst.gPieModule.RefreshModule();
            SavePredicateModelToTempFile();
            f_PartialDecision.Clear();
            f_PartialDecision.Type_Char = AType_Char;
            f_PartialDecision.CheckNud = f_CheckNud;
            f_TMax = Int64.Parse(SharedConst.opt_sadacha.Td);
            f_VMax = Int64.Parse(SharedConst.opt_sadacha.Vd);
            for (int i = 0; i <= f_Tree.Count - 1; i++)
                AddPTI(f_Tree.GetItems(i));

            TrackCreator.ClearBase();
            for (int i = 0; i <= f_Tree.Count - 1; i++)
            {
                TI = f_Tree.GetItems(i);
                Knot = TrackCreator.CreateKnotToBase();
                Knot.ParentID = TI.ParentID;
                Knot.NumAlt = TI.NumAlt;
                int m_type = TI.TypeWorkShape;
                if (m_type == 12)
                    m_type = 1;
                Knot.TypeKnot = m_type;
                Knot.TFE_ID1 = TI.GetTFE_ID(0);
                Knot.TFE_ID2 = TI.GetTFE_ID(1);
                Knot.TFE_ID3 = TI.GetTFE_ID(2);
            }
        }
        public void Process()
        {
            string S;
            TPredicateTreeItem TI;
            TPartialDecisionItem P = new TPartialDecisionItem(null);
            Nud_podgot();
            for (int i = CountPTI - 1; i >= 0; i--)
            {
                TI = (TPredicateTreeItem)f_ListPTI[i];
                TI.TReated = true;
                f_PartialDecision.GetNew(ref P,TI);
                f_PartialDecision.FreeItem(f_PartialDecision.PullAlternate(P));
                P.Make();
                ChekDeleted(TI);
            }
            if (f_PartialDecision.Type_Char == SharedConst.PROP) get_opt_alt();
            if (f_PartialDecision.Type_Char == SharedConst.FUZZY) get_opt_alt_fuz();

        }
        public string Check()
        {
            int m_id=0;
            string Res="";
            if (!CheckCanDecision(ref m_id))
                Res = "Для подблока номер " + m_id.ToString() + " не заданы ни параметрические, ни структурные альтернативы.\r\nНахождение решения невозможно!";
            if (Res.Length<=0 && !CheckCanPLGDecision(ref m_id))
                Res = "Для подблока номер " + m_id.ToString() + " нет структурных альтернатив и все параметрические не проходят по заданным в них условиях.\r\nНахождение решения невозможно!";
            return Res;
        }
        /*         AnsiString CheckTrack();
                 AnsiString Track();
                 AnsiString AcceptTrackFromScanner();*/
        public bool CheckOzenk_TFE_v(TPredicateTreeItem ATI, double AValue)
        {
            int num_parent = -1;
            double v1, v2, v_parent;
            TPredicateTreeItem TI;

            for (int i = CountPTI - 1; i >= 0; i--)
            {
                TI = GetPTI(i);
                num_parent = TI.ParentID;
                if (TI == ATI)
                    ozenk_v.SetItems(1,num_parent,AValue);
                else
                {
                    v1 = Get_V_Min(TI, 0);
                    v2 = Get_V_Min(TI, 1);
                    v_parent =(double) ozenk_v.GetItems(1,num_parent); //bbb
                    switch (TI.TypeWorkShape)
                    {
                        case SharedConst.RAB:
                        case SharedConst.RAB_FAKE:
                            ozenk_v.SetItems(1,num_parent,Math.Min(v_parent, v1));
                            break;
                        case SharedConst.RAB_POSL:
                        case SharedConst.RAB_2par_AND:
                        case SharedConst.RAB_2par_OR:
                            ozenk_v.SetItems(1,num_parent,Math.Min(v_parent, (v1 + v2)));
                            break;
                        case SharedConst.DIAGN:
                        case SharedConst.DIAGN_2:
                        case SharedConst.PROV_IF:
                        case SharedConst.WHILE_DO:
                        case SharedConst.WHILE_DO_2:
                        case SharedConst.DO_UNTIL:
                        case SharedConst.DO_UNTIL_2:
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, (v1 + v2)));
                            break;
                        case SharedConst.RASV:
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, Math.Min(v1, v2)));
                            break;
                        case SharedConst.DO_WHILE_DO:
                        case SharedConst.DO_WHILE_DO_2:
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, (v1 + v2)));
                            break;
                        case SharedConst.RASV_SIM:
                            double temp = v1;
                            TBaseShape B = TI.GetTFE(2);
                            if (B!=null && B.ParamAlt!=null)
                            {
                                if (!B.ParamAlt.Items[0].CheckPLG)
                                    temp = v2;
                            }
                            ozenk_v.SetItems(1,num_parent,Math.Min(v_parent, temp));
                            break;

                    }
                }
            }
            return (double)ozenk_v.GetItems(1,num_parent) > f_VMax;
        }
        public bool CheckOzenk_TFE_t(TPredicateTreeItem ATI, double AValue)
        {
            int num_parent=-1;
            double t1, t2, t_parent;
            TPredicateTreeItem TI;

            for (int i = CountPTI - 1; i >= 0; i--)
            {
                TI = GetPTI(i);
                num_parent = TI.ParentID;
                if (TI == ATI)
                    ozenk_t.SetItems(1,num_parent, AValue);
                else
                {
                    t1 = Get_T_Min(TI, 0);
                    t2 = Get_T_Min(TI, 1);
                    t_parent = (double)ozenk_t.GetItems(1,num_parent); //aaa

                    switch (TI.TypeWorkShape)
                    {
                        case SharedConst.RAB:
                        case SharedConst.RAB_FAKE:
                            ozenk_t.SetItems(1,num_parent, Math.Min(t_parent, t1));
                            break;
                        case SharedConst.RAB_POSL:
                            ozenk_t.SetItems(1,num_parent, Math.Min(t_parent, (t1 + t2)));
                            break;
                        case SharedConst.RAB_2par_AND:
                            ozenk_t.SetItems(1,num_parent, Math.Min(t_parent, Math.Max(t1, t2)));
                            break;
                        case SharedConst.RAB_2par_OR:
                            ozenk_t.SetItems(1,num_parent, Math.Min(t_parent, Math.Min(t1, t2)));
                            break;
                        case SharedConst.DIAGN:
                        case SharedConst.DIAGN_2:
                        case SharedConst.PROV_IF:
                        case SharedConst.WHILE_DO:
                        case SharedConst.WHILE_DO_2:
                        case SharedConst.DO_UNTIL:
                        case SharedConst.DO_UNTIL_2:
                            ozenk_t.SetItems(1,num_parent, Math.Min(t_parent, (t1 + t2)));
                            break;

                        case SharedConst.RASV:
                            ozenk_t.SetItems(1,num_parent, Math.Min(t_parent, Math.Min(t1, t2)));
                            break;

                        case SharedConst.DO_WHILE_DO:
                        case SharedConst.DO_WHILE_DO_2:
                            ozenk_t.SetItems(1,num_parent, Math.Min(t_parent, (t1 + t2)));
                            break;

                        case SharedConst.RASV_SIM:
                            double temp = t1;
                            TBaseShape B = TI.GetTFE(2);
                            if (B!=null && B.ParamAlt!=null)
                            {
                                if (!B.ParamAlt.Items[0].CheckPLG)
                                    temp = t2;
                            }
                            ozenk_t.SetItems(1,num_parent,Math.Min(t_parent, temp));
                            break;
                    }
                }
            }
            return (double)ozenk_t.GetItems(1,num_parent) > f_TMax;
        }
        public void ShowDecision(Color AColorAlt, Color AColorBadAlt, Color AColorFont, int ATime)
        {
            string s;
            SharedConst.fmViewDecision = new FmViewDecision();
            SharedConst.fmViewDecision.VwColorAlt = AColorAlt;
            SharedConst.fmViewDecision.VwColorBadAlt = AColorBadAlt;
            SharedConst.fmViewDecision.VwColorFont = AColorFont;

            SharedConst.fmViewDecision.ParamAlt = f_PartialDecision.GetItems(0).ParamAlt;
            SharedConst.fmViewDecision.SetBTVText(f_OptB, f_OptT, f_OptV);
            SharedConst.fmViewDecision.SetSostavText(f_Sostav, f_Cnt_alt.ToString(), f_CntComm.ToString());
            SharedConst.fmViewDecision.SetInformText(SharedConst.fmStartDecision.GetEdit1(),
            SharedConst.fmStartDecision.GetEdit5(), SharedConst.fmStartDecision.GetEdit2(),
            SharedConst.fmStartDecision.GetEdit3(), SharedConst.fmStartDecision.GetEdit4());
            SharedConst.fmViewDecision.Type_Char = SharedConst.fmStartDecision.type_char;
            SharedConst.fmViewDecision.SetTimeText(ATime.ToString() + " мсек");
            SharedConst.fmViewDecision.ShowDialog();
        }
        /*    void Ozenk_TFE();*/
        public TPredicateTree Tree
        {
            get { return f_Tree;  }
        }
            
     /*       __property TPredicateTreeItem* PTI[int AIndex] = { read = GetPTI };*/
        public int CountPTI
        {
            get { return GetCountPTI(); }
        }
        public int unpack_sostav(string S)
        {
            int i1, I, J;
            char[] n1 = new char[1024], n2 = new char[1024];
            int[] n3 = new int[1024];
            string p;
            n1[0] = '\0';
            n2[0] = '\0';
            p = S;
            for (i1 = 0; i1 < SharedConst.opt_sadacha.OptSovm.HiCol() + 1; i1++)
                n3[i1] = 0;
            int q = 0;
            for (; ; )
            {
                i1 = 0; while (p[q] != ';' && p[q] != ':' && q != p.Length) n1[i1++] = p[q++]; n1[i1] = '\0';
                q++; i1 = 0; while (p[q] != ';' && p[q] != ':' && q != p.Length) n2[i1++]  = p[q++]; n2[i1] = '\0';
                n3[Int64.Parse(n1.ToString())] = Int32.Parse(n2.ToString());
                if (q != p.Length) 
                { 
                    q++; continue; 
                }
                else break;
            }

            int k = 0, k1 = 0;
            for (I = 0; I < SharedConst.opt_sadacha.OptSovm.HiRow() + 1; I++)
            {
                for (J = 0; J < SharedConst.opt_sadacha.OptSovm.HiCol() + 1; J++)
                {
                    if ((int)SharedConst.opt_sadacha.OptSovm.GetItems(I,J) != 0) k++;
                    if (((int)SharedConst.opt_sadacha.OptSovm.GetItems(I, J) != 0) && ((int)SharedConst.opt_sadacha.OptSovm.GetItems(I, J) == n3[J])) k1++;
                }
                if ((k1 != k) || (k == 0)) { k = 0; k1 = 0; continue; }
                else return 0;
            }
            return 1;

        }
    }
}
