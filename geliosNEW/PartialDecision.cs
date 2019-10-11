using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TPartialDecisionItem
    {
        private TPartialDecision f_Parent;
        private TPredicateTreeItem f_WorkItem;
        private TParamAlternative f_ParamAlt;
        private TParamAlternative f_Apd;
   /*     private void FreeApd();
        private void DoDecision();
        private void proverka_type_krit(int type_krit);*/
        private void proverka_type_krit_fuz(int type_krit)
        {
            //Алгоритм
            //признак удаления в FALSE
            //Начинаем с начала отфильтрованной таблицы
            //Цикл (  пока признак удаления = = TRUE )
            //1. Берем ПА (параметрическую альтернативу)
            //2. Сравниваем с остальными ПА
            //   Если для текущей ПА не выполняется НУОпт - удаляем эту ПА и признак удаления в TRUE
            //   Иначе идем дальше по таблице
            //3. Если конец таблицы, то снова в начало

            string str, str_next;
            double a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
              a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b,
              a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b,
              a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
              a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
              a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b;

            TParamAlternativeItem AI, AJ;

            TDynamicArray mDel = new TDynamicArray();
            for (int i = 0; i <= f_ParamAlt.Count - 1; i++)
            {
                AI = f_ParamAlt.Items[i];
                if (!mDel.Find(AI))
                {

                    a1_b_f = AI.A1_B_F;
                    b_f1n = AI.B_F1N;
                    b_f1b = AI.B_F1B;
                    a2_b_f = AI.A2_B_F;
                    b_f2n = AI.B_F2N;
                    b_f2b = AI.B_F2B;
                    a3_b_f = AI.A3_B_F;
                    b_f3n = AI.B_F3N;
                    b_f3b = AI.B_F3B;

                    a1_t_f = AI.A1_T_F;
                    t_f1n = AI.T_F1N;
                    t_f1b = AI.T_F1B;
                    a2_t_f = AI.A2_T_F;
                    t_f2n = AI.T_F2N;
                    t_f2b = AI.T_F2B;
                    a3_t_f = AI.A3_T_F;
                    t_f3n = AI.T_F3N;
                    t_f3b = AI.T_F3B;

                    a1_v_f = AI.A1_V_F;
                    v_f1n = AI.V_F1N;
                    v_f1b = AI.V_F1B;
                    a2_v_f = AI.A2_V_F;
                    v_f2n = AI.V_F2N;
                    v_f2b = AI.V_F2B;
                    a3_v_f = AI.A3_V_F;
                    v_f3n = AI.V_F3N;
                    v_f3b = AI.V_F3B;
                    str = AI.SOSTAV;

                    for (int j = 0; j <= f_ParamAlt.Count - 1; j++)
                    {
                        AJ = f_ParamAlt.Items[j];
                        if ((i != j) && (mDel.Find(AJ))== null)
                        {
                            a1_b_n_f = AJ.A1_B_F;
                            b_n_f1n = AJ.B_F1N;
                            b_n_f1b = AJ.B_F1B;
                            a2_b_n_f = AJ.A2_B_F;
                            b_n_f2n = AJ.B_F2N;
                            b_n_f2b = AJ.B_F2B;
                            a3_b_n_f = AJ.A3_B_F;
                            b_n_f3n = AJ.B_F3N;
                            b_n_f3b = AJ.B_F3B;

                            a1_t_n_f = AJ.A1_T_F;
                            t_n_f1n = AJ.T_F1N;
                            t_n_f1b = AJ.T_F1B;
                            a2_t_n_f = AJ.A2_T_F;
                            t_n_f2n = AJ.T_F2N;
                            t_n_f2b = AJ.T_F2B;
                            a3_t_n_f = AJ.A3_T_F;
                            t_n_f3n = AJ.T_F3N;
                            t_n_f3b = AJ.T_F3B;

                            a1_v_n_f = AJ.A1_V_F;
                            v_n_f1n = AJ.V_F1N;
                            v_n_f1b = AJ.V_F1B;
                            a2_v_n_f = AJ.A2_V_F;
                            v_n_f2n = AJ.V_F2N;
                            v_n_f2b = AJ.V_F2B;
                            a3_v_n_f = AJ.A3_V_F;
                            v_n_f3n = AJ.V_F3N;
                            v_n_f3b = AJ.V_F3B;
                            str_next =  AJ.SOSTAV;

                            //если частичное решение с b_next доминирует частичное решение с b, то удаляем решение b
                            switch (type_krit)
                            {
                                case SharedConst.BB:
                                    if (domin_P_B_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                               a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b)) mDel.Append(AI); break;
                                case SharedConst.BT:
                                    if (domin_P_BT_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                     a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                     a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
                                     a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b)) mDel.Append(AI); break;
                                case SharedConst.BV:
                                    if (domin_P_BV_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                     a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                     a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b,
                                     a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b)) mDel.Append(AI); break;
                                case SharedConst.BTV:
                                    if (domin_P_BTV_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                    a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                    a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
                                    a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b,
                                    a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b,
                                    a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b)) mDel.Append(AI); break;
                                case SharedConst.BBS:
                                    if (domin_P_BS_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                              a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BTS:
                                    if (domin_P_BTS_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                    a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                    a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
                                    a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BVS:
                                    if (domin_P_BVS_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                    a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                    a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b,
                                    a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BTVS:
                                    if (domin_P_BTVS_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                   a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                   a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
                                   a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b,
                                   a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b,
                                   a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b, str_next, str)) mDel.Append(AI); break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i <= mDel.Count - 1; i++)
                f_ParamAlt.Delete2(mDel.GetItems(i));
            delete mDel;
            proverka_priblj_fuz(opt_sadacha.Rate);
            if (f_Parent.CheckNud)
                proverka_nud_fuz();
        }
/*        private TParamAlternative GetParamAlternativeByID(int AID);
        private void proverka_priblj(double ARate);
        private void proverka_priblj_fuz(double ARate);
        private  void proverka_nud();
        private void proverka_nud_fuz();
        private  void sovm_naz(int ind);*/

        public TPartialDecisionItem(TPartialDecision AParent)
        {
            f_Apd = null;
            f_WorkItem = null;
            f_Parent = AParent;
            f_ParamAlt = new TParamAlternative();
        }
        ~TPartialDecisionItem() { }
   /*     public void InitDecision(TPredicateTreeItem AWorkItem);
        public void Make();*/
        public void Proverka_NUOpt()
        {
            if (f_Parent.Type_Char == SharedConst.PROP)
            {
                switch (SharedConst.opt_sadacha.type_sadacha)
                {
                    case SharedConst.ZAD_1:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по В
                        {
                            case 0: proverka_type_krit(SharedConst.BB); break;//только по В
                            case 1: proverka_type_krit(SharedConst.BV); break;//критерий V
                            case 2: proverka_type_krit(SharedConst.BT); break;//критерий T
                            case 3: proverka_type_krit(SharedConst.BTV); break;//критерий V и T
                            case 4: proverka_type_krit(SharedConst.BBS); break;//только по В
                            case 5: proverka_type_krit(SharedConst.BVS); break;//критерий V
                            case 6: proverka_type_krit(SharedConst.BTS); break;//критерий T
                            case 7: proverka_type_krit(SharedConst.BTVS); break;//критерий V и T
                        }
                        break;
                    case SharedConst.ZAD_2:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по Т
                        {
                            case 0: proverka_type_krit(SharedConst.BT); break;//только по Т (плюс всегда В)
                            case 1: proverka_type_krit(SharedConst.BTV); break;//критерий V
                            case 2: proverka_type_krit(SharedConst.BT); break;//критерий B
                            case 3: proverka_type_krit(SharedConst.BTV); break;////критерий V и B
                            case 4: proverka_type_krit(SharedConst.BTS); break;//только по Т (плюс всегда В)
                            case 5: proverka_type_krit(SharedConst.BTVS); break;//критерий V
                            case 6: proverka_type_krit(SharedConst.BTS); break;//критерий B
                            case 7: proverka_type_krit(SharedConst.BTVS); break;////критерий V и B
                        }
                        break;
                    case SharedConst.ZAD_3:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по V
                        {
                            case 0: proverka_type_krit(SharedConst.BV); break;//нет критериев
                            case 1: proverka_type_krit(SharedConst.BV); break;//критерий B
                            case 2: proverka_type_krit(SharedConst.BTV); break;//критерий T
                            case 3: proverka_type_krit(SharedConst.BTV); break;//критерий T и B
                            case 4: proverka_type_krit(SharedConst.BVS); break;//нет критериев
                            case 5: proverka_type_krit(SharedConst.BVS); break;//критерий B
                            case 6: proverka_type_krit(SharedConst.BTVS); break;//критерий T
                            case 7: proverka_type_krit(SharedConst.BTVS); break;//критерий T и B
                        }
                        break;

                    case SharedConst.ZAD_4://обобщенные задачи
                    case SharedConst.ZAD_5:
                    case SharedConst.ZAD_6:
                        if (SharedConst.opt_sadacha.type_ogr < 4)
                        {
                            proverka_type_krit(SharedConst.BTV);
                            break;
                        }
                        else
                        {
                            proverka_type_krit(SharedConst.BTVS);
                            break;
                        }
                }
            }

            if (f_Parent.Type_Char == SharedConst.FUZZY)
            {
                switch (SharedConst.opt_sadacha.type_sadacha)
                {
                    case SharedConst.ZAD_1:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по В
                        {
                            case 0: proverka_type_krit_fuz(SharedConst.BB); break;//только по В
                            case 1: proverka_type_krit_fuz(SharedConst.BV); break;//критерий V
                            case 2: proverka_type_krit_fuz(SharedConst.BT); break;//критерий T
                            case 3: proverka_type_krit_fuz(SharedConst.BTV); break;//критерий V и T
                            case 4: proverka_type_krit_fuz(SharedConst.BBS); break;//только по В
                            case 5: proverka_type_krit_fuz(SharedConst.BVS); break;//критерий V
                            case 6: proverka_type_krit_fuz(SharedConst.BTS); break;//критерий T
                            case 7: proverka_type_krit_fuz(SharedConst.BTVS); break;//критерий V и T
                        }
                        break;
                    case SharedConst.ZAD_2:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по Т
                        {
                            case 0: proverka_type_krit_fuz(SharedConst.BT); break;//только по Т (плюс всегда В)
                            case 1: proverka_type_krit_fuz(SharedConst.BTV); break;//критерий V
                            case 2: proverka_type_krit_fuz(SharedConst.BT); break;//критерий B
                            case 3: proverka_type_krit_fuz(SharedConst.BTV); break;////критерий V и B
                            case 4: proverka_type_krit_fuz(SharedConst.BTS); break;//только по Т (плюс всегда В)
                            case 5: proverka_type_krit_fuz(SharedConst.BTVS); break;//критерий V
                            case 6: proverka_type_krit_fuz(SharedConst.BTS); break;//критерий B
                            case 7: proverka_type_krit_fuz(SharedConst.BTVS); break;////критерий V и B
                        }
                        break;
                    case SharedConst.ZAD_3:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по V
                        {
                            case 0: proverka_type_krit_fuz(SharedConst.BV); break;//нет критериев
                            case 1: proverka_type_krit_fuz(SharedConst.BV); break;//критерий B
                            case 2: proverka_type_krit_fuz(SharedConst.BTV); break;//критерий T
                            case 3: proverka_type_krit_fuz(SharedConst.BTV); break;//критерий T и B
                            case 4: proverka_type_krit_fuz(SharedConst.BVS); break;//нет критериев
                            case 5: proverka_type_krit_fuz(SharedConst.BVS); break;//критерий B
                            case 6: proverka_type_krit_fuz(SharedConst.BTVS); break;//критерий T
                            case 7: proverka_type_krit_fuz(SharedConst.BTVS); break;//критерий T и B
                        }
                        break;

                    case SharedConst.ZAD_4://обобщенные задачи
                    case SharedConst.ZAD_5:
                    case SharedConst.ZAD_6:
                        if (SharedConst.opt_sadacha.type_ogr < 4) { proverka_type_krit_fuz(SharedConst.BTVS); break; }
                        else { proverka_type_krit_fuz(SharedConst.BTVS); break; }

                }
            }
        }
        void proverka_type_krit(int type_krit)
        {
            //Алгоритм
            //признак удаления в FALSE
            //Начинаем с начала отфильтрованной таблицы
            //Цикл (  пока признак удаления = = TRUE )
            //1. Берем ПА (параметрическую альтернативу)
            //2. Сравниваем с остальными ПА
            //   Если для текущей ПА не выполняется НУОпт - удаляем эту ПА и признак удаления в TRUE
            //   Иначе идем дальше по таблице
            //3. Если конец таблицы, то снова в начало

            //фильтр для текущего подблока
            string str, str_next;
            double b, t, v, b_next, t_next, v_next; //,sovm,sovm_next;

            TParamAlternativeItem AI, AJ;

            TDynamicArray mDel = new TDynamicArray();
            for (int i = 0; i <= f_ParamAlt.Count - 1; i++)
            {
                AI = f_ParamAlt.Items[i];
                if (mDel.Find(AI) == null)
                {
                    b = AI.B;
                    t = AI.T;
                    v = AI.V;
                    str = AI.SOSTAV;
                    for (int j = 0; j <= f_ParamAlt.Count - 1; j++)
                    {
                        AJ = f_ParamAlt.Items[j];
                        if ((i != j) && (!mDel.Find(AJ)))
                        {
                            b_next = AJ.B;
                            t_next = AJ.T;
                            v_next = AJ.V;
                            str_next = AJ.SOSTAV;

                            //если частичное решение с b_next доминирует частичное решение с b, то удаляем решение b
                            switch (type_krit)
                            {
                                case SharedConst.BB: if (domin_P_B(b_next, b)) mDel.Append(AI); break;
                                case SharedConst.BT: if (domin_P_BT(b_next, b, t_next, t)) mDel.Append(AI); break;
                                case SharedConst.BV: if (domin_P_BV(b_next, b, v_next, v)) mDel.Append(AI); break;
                                case SharedConst.BTV: if (domin_P_BTV(b_next, b, t_next, t, v_next, v)) mDel.Append(AI); break;
                                case SharedConst.BBS: if (domin_P_B_S(b_next, b, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BTS: if (domin_P_BT_S(b_next, b, t_next, t, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BVS: if (domin_P_BV_S(b_next, b, v_next, v, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BTVS: if (domin_P_BTV_S(b_next, b, t_next, t, v_next, v, str_next, str)) mDel.Append(AI); break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i <= mDel.Count - 1; i++)
                f_ParamAlt.Delete2(mDel.Items[i]);
            delete mDel;
            proverka_priblj(opt_sadacha.Rate);
            if (f_Parent.CheckNud)
                proverka_nud();
        }

        public TPartialDecision Parent
        {
            get { return f_Parent; }
        }

        public TParamAlternative  ParamAlt
        {
            get { return f_ParamAlt; }
        }
            
        public TPredicateTreeItem  WorkItem
        {
            get { return f_WorkItem; }
        }
    }
    public class TPartialDecision
    {
        private TZadacha f_Owner;
        private bool f_CheckNud;
        private int f_Type_Char;
        private List<object> f_List;
        /*     private void FreeList();
             private int  GetCount();
             private TPartialDecisionItem  GetItems(int AIndex);*/

        public TPartialDecision(TZadacha AOwner)
        {
            f_Type_Char = 0;
            f_CheckNud = false;
            f_List = new List<object>();
            f_Owner = AOwner;
        }
        ~TPartialDecision() { }
        /*      public void Clear();
              public TPartialDecisionItem FindPartialDecisionItemByParentID(int AID);
              public TPartialDecisionItem FindPartialDecisionItemByTFEID(int AID);
              public  TPartialDecisionItem GetNew(TPredicateTreeItem APTItem);
              public bool FreeItem(TPartialDecisionItem AItem);
              public TPartialDecisionItem PullAlternate(TPartialDecisionItem AItem);
              public bool CheckOzenk_TFE_t(TPartialDecisionItem AI, double AValue);
              public bool CheckOzenk_TFE_v(TPartialDecisionItem AI, double AValue);*/

        public int Type_Char
        {
            set { f_Type_Char = value; }
            get { return f_Type_Char; }
        }
        public bool CheckNud
        {
            set { f_CheckNud = value; }
            get { return f_CheckNud; }
        }

    /*    public int Count = { read = GetCount };
        public TPartialDecisionItem Items[int AIndex] = { read =  GetItems */
    }
}
