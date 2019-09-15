using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAltSelectorItem
    {
        int f_Num;
        int f_ID;
        int f_ParentShapeID;
        public TAltSelectorItem(int AID, int ANum, int AParentShapeID)
        {
            f_Num = ANum;
            f_ID = AID;
            f_ParentShapeID = AParentShapeID;
        }
   /*     public int Num = { read = f_Num };
        public int ID = { read = f_ID };
        public int ParentShapeID = { read = f_ParentShapeID };*/
    }


    class TAltSelector
    {
        List<object> f_List;
        List<object> f_FinderList;
        int f_Id;
        int f_pos;
   //     void FreeList();
        public TAltSelector()
        {
            f_List = new List<object>();
            f_FinderList = new List<object>();
            f_pos = 0;
            f_Id = 0;
        }
        ~TAltSelector() { }
 /*       public int AddAltItem(int AID);
        public TAltSelectorItem CreateNewAlternateID(int AParentShapeID, int AStartNum = 0);
        public TAltSelectorItem CreateNewAlternateID2(int AID, int AParentShapeID, int ANum);
        public bool DeleteAltItem(int AID, int ANum);
        public TAltSelectorItem FindFirst(int AID, int AParentShapeID);
        public TAltSelectorItem FindNext();
        public void ClearAll();*/
    }
}
