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
        /*   void FreeList();
           int  GetCount();
           TPredicatePathNodeItem  GetItems(int AIndex);
           string  GetText();
           public:*/
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
          void AddItem(TPredicateItemBase* AItem);
          bool IsLike(TPredicatePathNode* ANode);
          TPredicatePathNodeItem* FindIndexFirst(int &APos);
          TPredicatePathNodeItem* FindIndexNext(int &APos);
          TPredicatePathNodeItem* FindByBlockID(int ABlockID);
          void Clear();
          void Assign(TPredicatePathNode* ASource);
          __property int Count = { read = GetCount };
          __property TPredicatePathNodeItem* Items[int AIndex] = {read = GetItems
      };
      __property int ID = { read = f_ID, write = f_ID };
      __property AnsiString Text = {read = GetText};
           __property TPredicateItemBase* ParentItemBase = { read = f_ParentItemBase };
      __property int NumAlt = { read = f_NumAlt, write = f_NumAlt };*/
    }

    class TPredicatePathItem
    {
        List<object> f_List;
        /*   void FreeList();
           int  GetNodeCount();
           TPredicatePathNode  GetNodeItems(int AIndex);
           string  GetText();
           TPredicatePathNodeItem FindPathNodeByParent(TPredicateItemBase AParent);*/
        public TPredicatePathItem()
        {
            f_List = new List<object>();
        }
        ~TPredicatePathItem() { }
        /*void Clear();
        TPredicatePathNode* CreatePathNode(TPredicateItemBase* AParentItemBase);
        TPredicatePathNode* FindLikePathNode(TPredicatePathNode* ANode);
        TPredicatePathNode* LastPathNode();
        __property int NodeCount = { read = GetNodeCount };
        __property TPredicatePathNode* NodeItems[int AIndex] = {read = GetNodeItems
    };
    __property AnsiString Text = {read = GetText};*/
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
           TPredicatePathItem* CloneToDescendant(TPredicatePathItem* ASource);
           __property TPredicatePathItem* BasePath = {read = f_BasePath
       };
       __property TPredicatePathItem* UsedPath = { read = f_UsedPath };

       __property int DescendantCount = { read = GetDescendantCount };
       __property TPredicatePathItem* Descendants[int AIndex] = { read = GetDescendantItems };
       };*/
    }
}
