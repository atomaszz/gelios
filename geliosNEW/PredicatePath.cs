using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TPredicatePathNodeItem
    {
        int f_Index;
        int f_BlockID;
        TBaseWorkShape f_TFS;
        TPredicateItemBase f_ItemBase;
        public TPredicatePathNodeItem() { f_Index = 0; f_BlockID = 0; f_ItemBase = null; f_TFS = null; }
        public void SetIndex(int AIndex) { f_Index = AIndex; }
        public int Index
        {
            get { return f_Index; }
        }
        public int BlockID
        {
            set { f_BlockID = value; }
            get { return f_BlockID; }
        }
        public TBaseWorkShape TFS
        {
            set { f_TFS = value; }
            get { return f_TFS; }
        }
        public TPredicateItemBase ItemBase
        {
            set { f_ItemBase = value; }
            get { return f_ItemBase; }
        }
    }

    class TPredicatePathNode
    {
        int f_ID;
        int f_Cnt;
        int f_NumAlt;
        List<object> f_List;
        TPredicateItemBase f_ParentItemBase;
        /*   void FreeList();*/
        int  GetCount()
        {
            return f_List.Count;
        }
        public TPredicatePathNodeItem  GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TPredicatePathNodeItem)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        string  GetText()
        {
            int m_pos = 0, i = 0;
            TPredicatePathNodeItem T;
            string Res = "branch(" + f_ID.ToString() + ", " + f_NumAlt.ToString() + ", [";
            T = FindIndexFirst(ref m_pos);
            while (T!=null)
            {
                if (i != 0)
                    Res = Res + ", ";
                Res = Res + T.BlockID.ToString();
                i++;
                T = FindIndexNext(ref m_pos);
            }
            Res = Res + "]).";
            return Res;
        }
        public TPredicatePathNode(TPredicateItemBase AParentItemBase, int AID, int ANumAlt)
              {
                  f_Cnt = 0;
                  f_ID = AID;
                  f_ParentItemBase = AParentItemBase;
                  f_NumAlt = ANumAlt;
                  f_List = new List<object>();
              }
              ~TPredicatePathNode() { }
              /*  TPredicatePathNodeItem* CreateItem();
                void AddItem(TPredicateItemBase* AItem);*/
        public bool IsLike(TPredicatePathNode ANode)
        {
            int mCnt = 0;
            if (f_List.Count == ANode.Count)
            {
                if (f_ID == ANode.ID)
                {
                    if (f_NumAlt == ANode.NumAlt)
                    {
                        for (int i = 0; i <= ANode.Count - 1; i++)
                            if (FindByBlockID(ANode.GetItems(i).BlockID)!=null)
                                mCnt++;
                        return mCnt == ANode.Count;
                    }
                }
            }
            return false;
        }
        public TPredicatePathNodeItem FindIndexFirst(ref int APos)
        {
            APos = 0;
            TPredicatePathNodeItem T;
            for (int i = APos; i <= f_List.Count - 1; i++)
            {
                T = GetItems(i);
                if (T.Index == 0)
                    return T;
            }
            return null;
        }
        TPredicatePathNodeItem FindIndexNext( ref int APos)
        {
            APos++;
            TPredicatePathNodeItem T;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                T = GetItems(i);
                if (T.Index == APos)
                    return T;
            }
            return null;
        }
        public TPredicatePathNodeItem FindByBlockID(int ABlockID)
        {
            TPredicatePathNodeItem T;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                T = GetItems(i);
                if (T.BlockID == ABlockID)
                    return T;
            }
            return null;
        }
    /*    void Clear();
                void Assign(TPredicatePathNode* ASource);*/
        public int Count
        {
            get { return GetCount(); }
        }
        /*       __property TPredicatePathNodeItem* Items[int AIndex] = {read = GetItems*/
        public int ID
        {
            set { f_ID = value;  }
            get { return f_ID; }
        }
      public  string  Text
        {
            get { return GetText(); }
        }
        public TPredicateItemBase ParentItemBase
        {
            get { return f_ParentItemBase; }
        }
        public int NumAlt
        {
            set { f_NumAlt = value;  }
            get { return f_NumAlt; }
        }
    }

    class TPredicatePathItem
    {
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
        int  GetNodeCount()
        {
            return f_List.Count;
        }
        TPredicatePathNode  GetNodeItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TPredicatePathNode)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        string  GetText()
        {
            string Res = "";
            TPredicatePathNode N;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                N = (TPredicatePathNode)(f_List.ElementAt(i));
                Res = Res + N.Text + "\r\n";
            }
            return Res;
        }
        TPredicatePathNodeItem FindPathNodeByParent(TPredicateItemBase AParent)
        {
            TPredicatePathNode Item;
            TPredicatePathNodeItem NItem;
            for (int i = 0; i <= NodeCount - 1; i++)
            {
                Item = GetNodeItems(i);
                for (int j = 0; j <= Item.Count - 1; j++)
                {
                    NItem = Item.GetItems(j);
                    if (NItem.ItemBase == AParent)
                        return NItem;
                }
            }
            return null;
        }
        public TPredicatePathItem()
        {
            f_List = new List<object>();
        }
        ~TPredicatePathItem() { }
        public void Clear()
        {
            FreeList();
        }
        TPredicatePathNode CreatePathNode(TPredicateItemBase AParentItemBase)
        {
            int mID = 0;
            int Num = 0;
            if (AParentItemBase!=null)
            {
                Num = ((TPredicateItemBig)(AParentItemBase)).NumAlt;
                TPredicatePathNodeItem NI = FindPathNodeByParent(AParentItemBase);
                if (NI!=null)
                    mID = NI.BlockID;
            }
            TPredicatePathNode N = new TPredicatePathNode(AParentItemBase, mID, Num);
            f_List.Add(N);
            return N;
        }
        public TPredicatePathNode FindLikePathNode(TPredicatePathNode ANode)
        {
            TPredicatePathNode Item;
            for (int i = 0; i <= NodeCount - 1; i++)
            {
                Item = GetNodeItems(i);
                if (Item.IsLike(ANode))
                    return Item;
            }
            return null;
        }

        /*       TPredicatePathNode* LastPathNode();*/
        public int NodeCount
        {
            get { return GetNodeCount();  }
        }
        /*     __property TPredicatePathNode* NodeItems[int AIndex] = {read = GetNodeItems
         };*/
        public  string  Text
        {
            get { return GetText(); }
        }
    }
    class TPredicatePath
    {
        double f_Rate;
        int f_Max;
        List<object> f_ListDescendant;
        TPredicatePathItem f_BasePath;
        TPredicatePathItem f_CurrentPath;
        TPredicatePathItem f_UsedPath;
        /*   void FreeListDescendant();
           TPredicatePathItem InitDescendant();
           int __fastcall GetDescendantCount();
           TPredicatePathItem* __fastcall GetDescendantItems(int AIndex);
           void Swap(int* m, int i, int j);
           void Swap_Array(int* m, int i, int j);
           int Find_Min(int* m, int i, int N);
           void NextArray(int* m, int N);
           int Factorial(int N);
           void DoGenerateDescendant(TPredicatePathItem* AItem, TDynamicArray* AStack);
           bool CheckRnd();
           bool AddPredicatePathNodeFromBase(TPredicatePathItem* AItem);
           public:*/
           public  TPredicatePath()
        {
            f_Max = 10000;
            f_Rate = 100.0;
            f_BasePath = new TPredicatePathItem();
            f_UsedPath = new TPredicatePathItem();
            f_ListDescendant = new List<object>();
        }
        ~TPredicatePath() { }
        public void Init()
        {
            SharedConst.PredicatePathInit();
        }
        /*      void GenerateDescendant(double ARate, int AMax);
              void ClearDescendant();
              TPredicatePathItem* CloneToDescendant(TPredicatePathItem* ASource);*/
        public TPredicatePathItem BasePath
        {
            get { return f_BasePath; }
        }        
       public TPredicatePathItem UsedPath
        {
            get { return f_UsedPath;  }
        }

  /*     __property int DescendantCount = { read = GetDescendantCount };
       __property TPredicatePathItem* Descendants[int AIndex] = { read = GetDescendantItems };
       };*/
    }
}
