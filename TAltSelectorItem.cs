using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAltSelectorItem
    {
        private int f_Num;
        private int f_ID;
        private int f_ParentShapeID;

        public TAltSelectorItem(int AID, int ANum, int AParentShapeID)
        {
            f_Num = ANum;
            f_ID = AID;
            f_ParentShapeID = AParentShapeID;
        }
        public int Num { get { return f_Num; } }
        public int ID { get { return f_ID; } }
        public int ParentShapeID { get { return f_ParentShapeID; } }
    }
}
