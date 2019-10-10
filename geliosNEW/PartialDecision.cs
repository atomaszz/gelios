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
        private void proverka_type_krit(int type_krit);
        private void proverka_type_krit_fuz(int type_krit);
        private TParamAlternative GetParamAlternativeByID(int AID);
        private void proverka_priblj(double ARate);
        private void proverka_priblj_fuz(double ARate);
        private  void proverka_nud();
        private void proverka_nud_fuz();
        private  void sovm_naz(int ind);

        public TPartialDecisionItem(TPartialDecision AParent);
        ~TPartialDecisionItem() { }
        public void InitDecision(TPredicateTreeItem AWorkItem);
        public void Make();
        public void Proverka_NUOpt();
        public TPartialDecision Parent = {read = f_Parent

        public TParamAlternative  ParamAlt = { read = f_ParamAlt };
        public TPredicateTreeItem  WorkItem = { read = f_WorkItem };*/
    }
    public class TPartialDecision
    {
        private TZadacha f_Owner;
        private bool f_CheckNud;
        private int f_Type_Char;
        private List <object> f_List;
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
        public bool CheckOzenk_TFE_v(TPartialDecisionItem AI, double AValue);

        public int Type_Char = { read = f_Type_Char, write = f_Type_Char };
        public bool CheckNud = { read = f_CheckNud, write = f_CheckNud };

        public int Count = { read = GetCount };
        public TPartialDecisionItem Items[int AIndex] = { read =  GetItems */
    }
}
