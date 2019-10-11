using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TPredicateTreeItem
    {
        private int f_ParentID;
        private int f_TypeWorkShape;
        private int f_NumAlt;
        private bool f_TReated;
        private TBaseWorkShape f_BaseWorkShape;
        private TBaseShape f_ParentShape;
        private TDynamicArray f_List;
        /*      private int GetCount();
              private int GetTFE_ID(int AIndex);
              private TBaseShape GetTFE(int AIndex);
              public TPredicateTreeItem();
              ~TPredicateTreeItem() { }
              public void AddBaseShape(TBaseShape AShape, int AID);*/
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
          /*       public int Count = { read = GetCount };
                 public TBaseShape TFE[int AIndex] = { read = GetTFE };
                 public int TFE_ID[int AIndex] = { read = GetTFE_ID };*/
        public bool TReated
        {
            set { f_TReated = value; }
            get { return f_TReated;  }
        }
        public int NumAlt
        {
            set { f_NumAlt = value; }
            get { return f_NumAlt; }
        }
    }
    class TPredicateTree
    {
        private List<TPredicateTreeItem> f_List;
  /*      private void FreeList();
        private int  GetCount();*/
        private TPredicateTreeItem  GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (f_List.ElementAt(AIndex));
            else
                return null;
        }
        /*   public  TPredicateTree();
           ~TPredicateTree() { }
           public void Clear();
           public TPredicateTreeItem NewPredicateTreeItem();
           public  TPredicateTreeItem FindByTfeID(int AID, TDynamicArray Arr);
           public TPredicateTreeItem FindByParentID(int AID);
           public void ArrayIDToDelete(TPredicateTreeItem AItem, TDynamicArray Arr);
           public int Count = { read = GetCount };
           public TPredicateTreeItem Items[int AIndex] = {read = GetItems*/
    }
}
