using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TOzenkTFE
    {
        private TPartialDecision f_PartialDecision;
        private List<object> f_ListPredicateTreeItem;
        private TDischargedMassiv f_ozenk;
        private TDischargedMassiv f_ozenk1;
        private TDischargedMassiv f_ozenk0;
        private void FillMassiv(TBaseShape ATFE)
        {
            TParamAlternative Alt;
            TParamAlternativeItem OI;
            TPartialDecisionItem Item = new TPartialDecisionItem(f_PartialDecision);
            Alt = Item.ParamAlt;
            TParamAlternative S = ATFE.ParamAlt;
            if (S!=null)
            {
                for (int i = 0; i <= S.Count - 1; i++)
                {
                    OI = S.Items[i];
                    Alt.AddItem(OI.Clone());
                }
                Item.Proverka_NUOpt();

                f_ozenk.Val[ATFE.ID] = Alt.Count;
                f_ozenk0.Val[ATFE.ID] = Alt.Count;
                f_ozenk1.Val[ATFE.ID] = 0.0;
            }
         //   delete Item;
        }
        private void OzenkItem(TPredicateTreeItem AItem);
        public TOzenkTFE(TPartialDecision APartialDecision)
        {
            f_PartialDecision = APartialDecision;
            f_ozenk = new TDischargedMassiv(0.0);
            f_ozenk1 = new TDischargedMassiv(0.0);
            f_ozenk0 = new TDischargedMassiv(0.0);
            f_ListPredicateTreeItem = new List<object>();
        }
        ~TOzenkTFE() { }
        public void AddPredicateTree(TPredicateTreeItem ANode);
        public void InitMassiv();
        public  double ValueOzenk(int APos);
        public double ValueOzenk1(int APos);

        public void Ozenk();
    }
}
