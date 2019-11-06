using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAltInfoItem
    {
        public int f_Id;
        public int f_Num;
        public int f_ParentShapeId;
        public TNodeMain f_NodeStart;
        public TNodeMain f_NodeEnd;
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
        public int ID { get { return f_Id; } }
        public int Num { get { return f_Num; } }
        public int ParentShapeId { get { return f_ParentShapeId; } }
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
        int GetItemCount()
        {
            return f_List.Count;
        }
        public TAltInfoItem GetItem(int AIndex)
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
                if ((Item.f_Id == AId) && (Item.f_Num == ANum) && (Item.f_ParentShapeId == AParentShapeId))
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
            Item.f_Id = AId;
            Item.f_Num = ANum;
            Item.f_ParentShapeId = AParentShapeId;
            Item.f_NodeStart = ANodeStart;
            Item.f_NodeEnd = ANodeEnd;
            f_List.Add(Item);
            return Item;
        }

        public int ItemCount { get { return GetItemCount(); } }


        /*    __property TAltInfoItem* Item[int AIndex] = {read = GetItem*/
    }
}
