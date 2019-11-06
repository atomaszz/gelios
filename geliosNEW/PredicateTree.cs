using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TPredicateTreeItem
    {
        int f_ParentID;
        int f_TypeWorkShape;
        int f_NumAlt;
        bool f_TReated;
        TBaseWorkShape f_BaseWorkShape;
        TBaseShape f_ParentShape;
        TDynamicArray f_List;
        int GetCount()
        {
            return f_List.Count;
        }

        /*        int __fastcall GetTFE_ID(int AIndex);
                TBaseShape* __fastcall GetTFE(int AIndex);
                public:
            TPredicateTreeItem();
                ~TPredicateTreeItem();*/
        public void AddBaseShape(TBaseShape AShape, int AID)
        {
            f_List.AppendInteger(AID, AShape);
        }

        public int ParentID
        {
            set { f_ParentID = value; }
            get { return f_ParentID; }
        }
        public TBaseWorkShape BaseWorkShape
        {
            set { f_BaseWorkShape = value; }
            get { return f_BaseWorkShape; }
        }
        public TBaseShape ParentShape
        {
            set { f_ParentShape = value; }
            get { return f_ParentShape; }
        }
        public int TypeWorkShape
        {
            set { f_TypeWorkShape = value; }
            get { return f_TypeWorkShape; }
        }
        public int Count
        {
            get { return GetCount(); }
        }
      /*      __property TBaseShape* TFE[int AIndex] = { read = GetTFE };
            __property int TFE_ID[int AIndex] = { read = GetTFE_ID };
            __property bool TReated = { read = f_TReated, write = f_TReated };*/
        public int NumAlt
        {
            set { f_NumAlt = value; }
            get { return f_NumAlt; }
        }

    }
    class TPredicateTree
    {
        List<object> f_List;
        public void FreeList()
        {
            f_List.Clear();
        }
        int GetCount()
        {
            return f_List.Count();
        }
        public TPredicateTreeItem GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TPredicateTreeItem)(f_List.ElementAt(AIndex));
            else
                return null;
        }
    /*    public:
            TPredicateTree();
            ~TPredicateTree(); */
        public void Clear()
        {
            FreeList();
        }
        public TPredicateTreeItem NewPredicateTreeItem()
        {
            TPredicateTreeItem N = new TPredicateTreeItem();
            f_List.Add(N);
            return N;
        }
        TPredicateTreeItem FindByTfeID(int AID, TDynamicArray Arr)
        {
            TPredicateTreeItem Item, Res = null;
            if (Arr!=null)
                Arr.Clear();
            for (int i = 0; i <= Count - 1; i++)
            {
                Item = GetItems(i);
                for (int j = 0; j <= Item.Count - 1; j++)
                {
                    if (Item.TFE_ID[j] == AID)
                    {
                        if (Res==null)
                            Res = Item;
                        if (Arr!=null)
                            Arr.Append(Item);
                    }
                }
            }
            return Res;
        }
   /*     TPredicateTreeItem FindByParentID(int AID);
                void ArrayIDToDelete(TPredicateTreeItem AItem, TDynamicArray Arr);*/
        public int Count
        {
            get { return GetCount();  }
        }
        /*      __property TPredicateTreeItem* Items[int AIndex] = {read = GetItems*/
    }
}
