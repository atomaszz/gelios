using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    public class TZadacha
    {
        private double f_TMax;
        private double f_VMax;
        private string f_OptB;
        private string f_OptT;
        private string f_OptV;
        private string f_Sostav;
        private int f_Cnt_alt;
        private int f_CntComm;
        private bool f_CheckNud;
        private TPredicateTree f_Tree;
        private TDynamicArray f_Equal;
        private TPartialDecision f_PartialDecision;
        private List<TPredicateTreeItem> f_ListPTI;
        private TDischargedMassiv ozenk_t;
        private TDischargedMassiv ozenk_v;
        private string f_FullPredcateModel;

        /*       private void DoEqual();
               private  void SavePredicateModelToTempFile();
               private bool CheckCanDecision(ref int AID);
               private  bool CheckPLGParamAlternative(TParamAlternative AL);
               private bool CheckCanPLGDecision(ref int AID);
               private void ChekDeleted(TPredicateTreeItem AI);
               private void get_opt_alt();
               private void get_opt_alt_fuz();
               private  void Nud_podgot();
               private double ozenk_t_min(TBaseShape B);
               private double ozenk_v_min(TBaseShape B);
               private void ClearPTI();
               private  void AddPTI(TPredicateTreeItem AItem);*/
        public TPredicateTreeItem  GetPTI(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_ListPTI.Count - 1)
                return (TPredicateTreeItem)(f_ListPTI.ElementAt(AIndex));
            else
                return null;
        }
               private  int  GetCountPTI() { return f_ListPTI.Count; }
         /*      private string DoCheckEqualTree();
               private string DoCheckLogic();
               private string DoCheckLogicItemUP(TPredicateScannerItemKnot AKnot, int AID);
               private string DoCheckLogicItemDown(TPredicateScannerItemKnot AKnot, int AID);
               private TPredicateTreeItem FindToTree(TPredicateScannerItemKnot AKnot);
               private TPredicateScannerItemKnot FindToScanner(TPredicateTreeItem AItem);*/
        private double Get_V_Min(TPredicateTreeItem ATI, int AIndex)
        {
            int idx = ATI.GetTFE_ID(AIndex);
            if (idx == 0)
                return 100000000.0;
            if (idx < 0)
                return (double)ozenk_v.GetItems(1,idx); //bbb
            double v1 = (double)ozenk_v.GetItems(1,idx); //bbb
            double v2 = (double)ozenk_v.Val[idx]; //bbb
            return Math.Min(v1, v2);
        }
        private double Get_T_Min(TPredicateTreeItem ATI, int AIndex)
        {
            int idx = ATI.GetTFE_ID(AIndex);
            if (idx == 0)
                return 100000000.0;
            if (idx < 0)
                return (double)ozenk_t.GetItems(1,idx); //aaa
            double t1 = (double)ozenk_t.GetItems(1,idx); //aaa
            double t2 = (double)ozenk_t.Val[idx]; //aaa
            return Math.Min(t1, t2);
        }

      /*         public TPredicateScanner Scanner;
               public TPredicateTrackCreator TrackCreator;
               public  TZadacha()
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
           /*    ~TZadacha() {  }
               public void Clear();
               public void Init(int AType_Char, bool ACheckNud, string AFullPredcateModel);
               public void Process();
               public string Check();
               public string CheckTrack();*/
        public string Track()
        {
            int m_type;
            string Res="";
            TPredicateTreeItem TI;
            TPredicateScannerItemKnot Item;
            for (int i = 0; i <= CountPTI - 1; i++)
            {
                TI = GetPTI(i);
                Item = new TPredicateScannerItemKnot();
                Item.ParentID = TI.ParentID;
                Item.NumAlt = TI.NumAlt;
                m_type = TI.TypeWorkShape;
                if (m_type == 12)
                    m_type = 1;
                Item.TypeKnot = m_type;
                Item.TFE_ID1 = TI.GetTFE_ID(0);
                Item.TFE_ID2 = TI.GetTFE_ID(1);
                Item.TFE_ID3 = TI.GetTFE_ID(2);
                Res = Res + Item.ItemName() + "\r\n";
              //  delete Item;
            }
            return Res;
        }


 /*       public string AcceptTrackFromScanner();*/
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
                    ozenk_v.SetItems(1,num_parent, AValue);
                else
                {
                    v1 = Get_V_Min(TI, 0);
                    v2 = Get_V_Min(TI, 1);
                    v_parent = (double)ozenk_v.GetItems(1,num_parent); //bbb
                    switch (TI.TypeWorkShape)
                    {
                        case SharedConst.RAB:
                        case SharedConst.RAB_FAKE:
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, v1));
                            break;
                        case SharedConst.RAB_POSL:
                        case SharedConst.RAB_2par_AND:
                        case SharedConst.RAB_2par_OR:
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, (v1 + v2)));
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
                            if (B!=null && B.ParamAlt != null)
                            {
                                if (!B.ParamAlt.Items[0].CheckPLG)
                                    temp = v2;
                            }
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, temp));
                            break;

                    }
                }
            }
            return (double)ozenk_v.GetItems(1,num_parent) > f_VMax;
        }
        public  bool CheckOzenk_TFE_t(TPredicateTreeItem ATI, double AValue)
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
                    v_parent = (double)ozenk_v.GetItems(1,num_parent); //bbb
                    switch (TI.TypeWorkShape)
                    {
                        case SharedConst.RAB:
                        case SharedConst.RAB_FAKE:
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, v1));
                            break;
                        case SharedConst.RAB_POSL:
                        case SharedConst.RAB_2par_AND:
                        case SharedConst.RAB_2par_OR:
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, (v1 + v2)));
                            break;
                        case SharedConst.DIAGN:
                        case SharedConst.DIAGN_2:
                        case SharedConst.PROV_IF:
                        case SharedConst.WHILE_DO:
                        case SharedConst.WHILE_DO_2:
                        case SharedConst.DO_UNTIL:
                        case SharedConst.DO_UNTIL_2:
                            ozenk_v.SetItems(1,num_parent,Math.Min(v_parent, (v1 + v2)));
                            break;
                        case SharedConst.RASV:
                            ozenk_v.SetItems(1,num_parent,Math.Min(v_parent, Math.Min(v1, v2)));
                            break;
                        case SharedConst.DO_WHILE_DO:
                        case SharedConst.DO_WHILE_DO_2:
                            ozenk_v.SetItems(1,num_parent,Math.Min(v_parent, (v1 + v2)));
                            break;
                        case SharedConst.RASV_SIM:
                            double temp = v1;
                            TBaseShape B = TI.GetTFE(2);
                            if (B!=null && B.ParamAlt != null)
                            {
                                if (!B.ParamAlt.Items[0].CheckPLG)
                                    temp = v2;
                            }
                            ozenk_v.SetItems(1,num_parent, Math.Min(v_parent, temp));
                            break;

                    }
                }
            }
            return (double)ozenk_v.GetItems(1,num_parent) > f_VMax;
        }
 /*       public void ShowDecision(Color AColorAlt, Color AColorBadAlt, Color AColorFont,  int ATime);*/
        public void Ozenk_TFE()
        {
            TPredicateTreeItem TI;
            TOzenkTFE mOzenk = new TOzenkTFE(f_PartialDecision);
            for (int i = CountPTI - 1; i >= 0; i--)
            {
                TI = GetPTI(i);
                mOzenk.AddPredicateTree(TI);
            }
            mOzenk.InitMassiv();
            mOzenk.Ozenk();
            ShowOzenk(mOzenk.ValueOzenk(0).ToString(), mOzenk.ValueOzenk1(0).ToString());
          //  delete mOzenk;
        }

        /*  public TPredicateTree Tree = {read = f_Tree*/

        /*       public TPredicateTreeItem PTI[int AIndex] = { read = GetPTI };   --.> GetPTI*/
        public int CountPTI
        {
            get { return GetCountPTI(); }
        }
        void ShowOzenk(string APower, string AWork)
        {
        /*    TfmOzenkView* F = new TfmOzenkView(Application);
            F.edPower.Text = APower;
            F.edWork.Text = AWork;
            F.ShowModal();
            F.Release();*/
        }

    }
}
