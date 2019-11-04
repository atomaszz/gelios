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

     /*   public TPredicatePathNodeItem() { f_Index = 0; f_BlockID = 0; f_ItemBase = NULL, f_TFS = NULL; }
        public void SetIndex(int AIndex) { f_Index = AIndex; }
        public int Index = { read = f_Index };
        public int BlockID = { read = f_BlockID, write = f_BlockID };
        public TBaseWorkShape TFS = {read = f_TFS , write = f_TFS
        public TPredicateItemBase* ItemBase = { read = f_ItemBase, write = f_ItemBase };*/
    }
    class TPredicatePathNode
    { 
        int f_ID;
        int f_Cnt;
        int f_NumAlt;
        List<object> f_List;
        TPredicateItemBase f_ParentItemBase;
        /*      void FreeList();
              int  GetCount();
              TPredicatePathNodeItem GetItems(int AIndex);
              string GetText();
              public TPredicatePathNode(TPredicateItemBase* AParentItemBase, int AID, int ANumAlt);
              ~TPredicatePathNode() { }
              public TPredicatePathNodeItem CreateItem();
              public void AddItem(TPredicateItemBase* AItem);
              public bool IsLike(TPredicatePathNode* ANode);
              public TPredicatePathNodeItem* FindIndexFirst(int &APos);
              public TPredicatePathNodeItem* FindIndexNext(int &APos);
              public TPredicatePathNodeItem* FindByBlockID(int ABlockID);
              public void Clear();
              public void Assign(TPredicatePathNode* ASource);
              public int Count = { read = GetCount };
              public TPredicatePathNodeItem* Items[int AIndex] = {read = GetItems
              public int ID = { read = f_ID, write = f_ID };
              public AnsiString Text = {read = GetText};
              public TPredicateItemBase* ParentItemBase = { read = f_ParentItemBase };
              public int NumAlt = { read = f_NumAlt, write = f_NumAlt };*/
    }
    class TPredicatePathItem
    {
        List<object> f_List;
        /*      void FreeList();
              int  GetNodeCount();
              TPredicatePathNode  GetNodeItems(int AIndex);
              string  GetText();
          TPredicatePathNodeItem FindPathNodeByParent(TPredicateItemBase AParent);
              public TPredicatePathItem();
          ~TPredicatePathItem() { }
              public void Clear();
              public TPredicatePathNode CreatePathNode(TPredicateItemBase AParentItemBase);
              public TPredicatePathNode FindLikePathNode(TPredicatePathNode ANode);
              public TPredicatePathNode LastPathNode();
              public int NodeCount = { read = GetNodeCount };
              public TPredicatePathNode NodeItems[int AIndex] = {read = GetNodeItems
              public AnsiString Text = {read = GetText};*/
    }
    class TPredicatePath
    {
        double f_Rate;
        int f_Max;
        List<object> f_ListDescendant;
        TPredicatePathItem f_BasePath;
        TPredicatePathItem f_CurrentPath;
        TPredicatePathItem f_UsedPath;
        /*void FreeListDescendant();
        TPredicatePathItem* InitDescendant();
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
        public:
         TPredicatePath();
        ~TPredicatePath();
        void Init();
        void GenerateDescendant(double ARate, int AMax);
        void ClearDescendant();
        TPredicatePathItem* CloneToDescendant(TPredicatePathItem* ASource);
        __property TPredicatePathItem* BasePath = {read = f_BasePath
    };
    __property TPredicatePathItem* UsedPath = { read = f_UsedPath };

    __property int DescendantCount = { read = GetDescendantCount };
    __property TPredicatePathItem* Descendants[int AIndex] = { read = GetDescendantItems };*/
    }
}
