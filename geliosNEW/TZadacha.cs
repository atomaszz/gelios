using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        TPredicateTree f_Tree;
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
        /*        void ChekDeleted(TPredicateTreeItem* AI);
                void get_opt_alt();
                void get_opt_alt_fuz();
                void Nud_podgot();
                double ozenk_t_min(TBaseShape* B);
                double ozenk_v_min(TBaseShape* B);*/
        void ClearPTI()
        {
            f_ListPTI.Clear();
        }
        void AddPTI(TPredicateTreeItem AItem)
        {
            if (f_ListPTI.IndexOf(AItem) < 0)
                f_ListPTI.Add(AItem);
        }

        /*    TPredicateTreeItem* __fastcall GetPTI(int AIndex);
            int __fastcall GetCountPTI() { return f_ListPTI.Count; }
            AnsiString DoCheckEqualTree();
            AnsiString DoCheckLogic();
            AnsiString DoCheckLogicItemUP(TPredicateScannerItemKnot* AKnot, int AID);
            AnsiString DoCheckLogicItemDown(TPredicateScannerItemKnot* AKnot, int AID);
            TPredicateTreeItem* FindToTree(TPredicateScannerItemKnot* AKnot);
            TPredicateScannerItemKnot* FindToScanner(TPredicateTreeItem* AItem);
            double Get_V_Min(TPredicateTreeItem* ATI, int AIndex);
            double Get_T_Min(TPredicateTreeItem* ATI, int AIndex);*/
        public TPredicateScanner Scanner;
        public TPredicateTrackCreator TrackCreator;
        TZadacha()
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
        /*     void Process();*/
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
                 AnsiString AcceptTrackFromScanner();
                 bool CheckOzenk_TFE_v(TPredicateTreeItem* ATI, double AValue);
                 bool CheckOzenk_TFE_t(TPredicateTreeItem* ATI, double AValue);
                 void ShowDecision(TColor AColorAlt, TColor AColorBadAlt, TColor AColorFont, unsigned int ATime);
                 void Ozenk_TFE();*/
        public TPredicateTree Tree
        {
            get { return f_Tree;  }
        }
            
     /*       __property TPredicateTreeItem* PTI[int AIndex] = { read = GetPTI };
            __property int CountPTI = { read = GetCountPTI };*/
    }
}
