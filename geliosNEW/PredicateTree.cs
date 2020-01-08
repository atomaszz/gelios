using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TPredicateTreeItem
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
        public int GetTFE_ID(int AIndex)
        {
            TDynamicArrayItem P = f_List.GetPosition(AIndex);
            if (P!=null)
                return P.Int_Value;
            else
                return 0;
        }
        public TBaseShape GetTFE(int AIndex)
        {
            TDynamicArrayItem P = f_List.GetPosition(AIndex);
            if (P!=null)
                return (TBaseShape)(P.P);
            else
                return null;
        }
        public TPredicateTreeItem()
        {
            f_ParentID = 0;
            f_TypeWorkShape = 0;
            f_NumAlt = 0;
            f_BaseWorkShape = null;
            f_ParentShape = null;
            f_TReated = false;
            f_List = new TDynamicArray();
        }
        ~TPredicateTreeItem() { }
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
              __property int TFE_ID[int AIndex] = { read = GetTFE_ID };*/
        public bool TReated
        {
            set { f_TReated = value; }
            get { return f_TReated; }
        }
        public int NumAlt
        {
            set { f_NumAlt = value; }
            get { return f_NumAlt; }
        }

    }
    public class TPredicateTree
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
        public TPredicateTree()
        {
            {
                f_List = new List<object>();
            }
        }
        ~TPredicateTree() { }
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
        public void AddPredicateTreeItem(TPredicateTreeItem N)
        {
            f_List.Add(N);
        }
        public TPredicateTreeItem FindByTfeID(int AID, TDynamicArray Arr)
        {
            TPredicateTreeItem Item, Res = null;
            if (Arr!=null)
                Arr.Clear();
            for (int i = 0; i <= Count - 1; i++)
            {
                Item = GetItems(i);
                for (int j = 0; j <= Item.Count - 1; j++)
                {
                    if (Item.GetTFE_ID(j) == AID)
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
        public TPredicateTreeItem FindByParentID(int AID)
        {
            TPredicateTreeItem Item;
            for (int i = 0; i <= Count - 1; i++)
            {
                Item = GetItems(i);
                if (Item.ParentID == AID)
                    return Item;
            }
            return null;
        }
        public void ArrayIDToDelete(TPredicateTreeItem AItem, ref TDynamicArray Arr)
        {
            TPredicateTreeItem Item;
            Arr.Clear();
            int del, cfind;
            for (int i = 0; i <= AItem.Count - 1; i++)
            {
                del = AItem.GetTFE_ID(i);
                cfind = 0;
                for (int j = 0; j <= f_List.Count - 1; j++)
                {
                    Item = (TPredicateTreeItem)(f_List.ElementAt(j));
                    if (!Item.TReated && (Item != AItem))
                    {
                        for (int k = 0; k <= Item.Count - 1; k++)
                            if (del == Item.GetTFE_ID(k))
                                cfind++;
                    }
                }
                if (cfind==0 && Arr.Find(del)==null)
                    Arr.Append(del);

            }
        }
        public int Count
        {
            get { return GetCount();  }
        }
        /*      __property TPredicateTreeItem* Items[int AIndex] = {read = GetItems*/
    }
}
