using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TZadacha
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

        /*      void DoEqual();
              void SavePredicateModelToTempFile();
              bool CheckCanDecision(int &AID);
              bool CheckPLGParamAlternative(TParamAlternative* AL);
              bool CheckCanPLGDecision(int &AID);
              void ChekDeleted(TPredicateTreeItem* AI);
              void get_opt_alt();
              void get_opt_alt_fuz();
              void Nud_podgot();
              double ozenk_t_min(TBaseShape* B);
              double ozenk_v_min(TBaseShape* B);*/
        void ClearPTI()
        {
            f_ListPTI.Clear();
        }
        /*         void AddPTI(TPredicateTreeItem* AItem);
                 TPredicateTreeItem* __fastcall GetPTI(int AIndex);
                 int __fastcall GetCountPTI() { return f_ListPTI->Count; }
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
        /*        void Init(int AType_Char, bool ACheckNud, AnsiString AFullPredcateModel);
                void Process();
                AnsiString Check();
                AnsiString CheckTrack();
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
