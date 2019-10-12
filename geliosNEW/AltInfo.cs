using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAltInfoItem
    {
        int f_Id;
        int f_Num;
        int f_ParentShapeId;
        TNodeMain f_NodeStart;
        TNodeMain f_NodeEnd;
        bool f_Main;
        public TAltInfoItem()
        {
            f_Id = 0;
            f_Num = 0;
            f_ParentShapeId = 0;
            f_NodeStart = null;
            f_NodeEnd = null;
            f_Main = false;
        }
       public int ID
        {
            set { f_Id = value; }
            get { return f_Id; }
        }
        public int Num
        {
            set { f_Num = value; }
            get { return f_Num; }
        }
        public int ParentShapeId
        {
            set { f_ParentShapeId = value; } 
            get { return f_ParentShapeId; }
        }

        public TNodeMain NodeStart
        {
            set { f_NodeStart = value; }
            get { return f_NodeStart; }
        }

        public TNodeMain NodeEnd
        {
            set { f_NodeEnd = value; }
            get { return f_NodeEnd; }
        }
        public bool Main
        {
            set { f_Main = value; }
            get { return f_Main; }
        }
    }
    class TAltInfo
    {
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
        int  GetItemCount()
        {
            return f_List.Count;
        }
        public TAltInfoItem  GetItem(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAltInfoItem)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        TAltInfoItem FindItem(int AId, int ANum, int AParentShapeId)
        {
            TAltInfoItem Item;
            for (int i = f_List.Count - 1; i >= 0; i--)
            {
                Item = (TAltInfoItem)(f_List.ElementAt(i));
                if ((Item.ID == AId) && (Item.Num == ANum) && (Item.ParentShapeId == AParentShapeId))
                    return Item;
            }
            return null;
        }

        public TAltInfo()
        {
            f_List = new List<object>();
        }
           ~TAltInfo() { }
        public void Clear()
        {
            FreeList();
        }
        public TAltInfoItem AddAltIfo(int AId, int ANum, int AParentShapeId, TNodeMain ANodeStart, TNodeMain ANodeEnd)
        {
            if (FindItem(AId, ANum, AParentShapeId)!=null) return null;
            TAltInfoItem Item = new TAltInfoItem();
            Item.ID = AId;
            Item.Num = ANum;
            Item.ParentShapeId = AParentShapeId;
            Item.NodeStart = ANodeStart;
            Item.NodeEnd = ANodeEnd;
            f_List.Add(Item);
            return Item;
        }
           public  int ItemCount
        {
            get { return GetItemCount(); }
        }

     /*      __property TAltInfoItem* Item[int AIndex] = {read = GetItem*/
    }
}
