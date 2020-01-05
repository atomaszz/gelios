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
        public int Num
        {
            get { return f_Num; }
        }
        public int ID
        {
            get { return f_ID; }
        }
        public int ParentShapeID
        {
            get { return f_ParentShapeID; }
        }
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
        public int AddAltItem(int AID)
        {
            TAltSelectorItem Item;
            int m_parentId = 0;
            int m_max = 0;
            bool m_ex = false;
            if (AID==0) return 0;// первая альтернатива особенная
            for (int i = f_List.Count - 1; i >= 0; i--)
            {
                Item = (TAltSelectorItem)(f_List.ElementAt(i));
                if (Item.ID == AID)
                {
                    m_ex = true;
                    m_parentId = Item.ParentShapeID;
                    if (m_max < Item.Num)
                        m_max = Item.Num;
                }
            }
            if (m_ex)
            {
                m_max++;
                Item = new TAltSelectorItem(AID, m_max, m_parentId);
                f_List.Add(Item);
                return m_max;
            }
            return -1;
        }
        public TAltSelectorItem CreateNewAlternateID(int AParentShapeID, int AStartNum = 0)
        {
            TAltSelectorItem Item;
            Item = new TAltSelectorItem(f_Id, AStartNum, AParentShapeID);
            f_List.Add(Item);
            f_Id++; // первая альтернатива это особенная
            return Item;
        }
        /*      public TAltSelectorItem CreateNewAlternateID2(int AID, int AParentShapeID, int ANum);
              public bool DeleteAltItem(int AID, int ANum);
              public TAltSelectorItem FindFirst(int AID, int AParentShapeID);
              public TAltSelectorItem FindNext();*/
        public void ClearAll()
        {
            f_List.Clear();
            f_FinderList.Clear();
            f_pos = 0;
            f_Id = 0;
        }
    }
}
