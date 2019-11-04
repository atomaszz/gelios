using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TPredicateItemBase
    {
        int f_ID;
        int f_NumAlt;
        bool f_Envelope;
        TPredicateItemBig f_EnvelopeBIG;
  /*      public TPredicateItemBase();
        ~TPredicateItemBase() { return; }
        public virtual int Who() { return -1; }
        public virtual void ListIDFill(TDynamicArray AList);
        public int NumAlt = { read = f_NumAlt, write = f_NumAlt };
        public bool Envelope = { read = f_Envelope, write = f_Envelope };
        public int ID = { read = f_ID, write = f_ID };
        public TPredicateItemBig EnvelopeBIG = {read = f_EnvelopeBIG, write = f_EnvelopeBIG*/
    }
    class TPredicateItemTFE
    {
 /*       TTreeListItem f_TFE;
        TPredicateItemBig f_Big;
        TAlternativeParserItemTFE f_RfcTFE;
        public TPredicateItemTFE();
        ~TPredicateItemTFE() { }
        public TTreeListItem TFE = {read = f_TFE, write = f_TFE
        public  TPredicateItemBig* Big = { read = f_Big, write = f_Big };
        public TAlternativeParserItemTFE* RfcTFE = { read = f_RfcTFE, write = f_RfcTFE };*/
    }
    class TPredicateItemTFS : TPredicateItemBase
    {
    /*  TTreeListTFS f_TFS;
      TList* f_ListTFE;
        void FreeList();
        int GetTFECount();
        TPredicateItemTFE  GetTFEItems(int AIndex);
        public TPredicateItemTFS();
        ~TPredicateItemTFS();
        public int Who() { return 0; }
        public void Assign(TAlternativeParserItemTFS* ATfs);
        public void ListIDFill(TDynamicArray* AList);
        public TTreeListTFS* TFS = { read = f_TFS };
        public int TFECount = { read = GetTFECount };
        public TPredicateItemTFE* TFEItems[int AIndex] = { read = GetTFEItems };*/
    }
    class TPredicateItemBig : TPredicateItemBase
    {
        /*  private:
             bool f_Print;
       TList* f_List;
       //      TPredicateItemTFE* f_OwnerTFE;
       TAlternativeParserItemBig* f_Rfc;
       int __fastcall GetCount();
       TPredicateItemBase* __fastcall GetItems(int AIndex);
       void FreeList();
       public:
            int Who() { return 1; }
       TPredicateItemBig();
       ~TPredicateItemBig();
       void AddItem(TPredicateItemBase* AItem);
       void DeleteItemToList(TPredicateItemBase* AItem);
       bool ValidDescendant();
       __property int Count = { read = GetCount };
       __property TPredicateItemBase* Items[int AIndex] = { read = GetItems };
       __property TAlternativeParserItemBig* Rfc = { read = f_Rfc, write = f_Rfc };
       __property bool Print = { read = f_Print, write = f_Print };*/
    }
    class TPredicateItemPWork :  TPredicateItemBase
    {
        TPredicateItemBase f_Item1;
        TPredicateItemBase f_Item2;
        public int Who() { return 2; }
 /*       public TPredicateItemPWork();
        ~TPredicateItemPWork() { }
        public void ListIDFill(TDynamicArray AList);
        public TPredicateItemBase Item1 = { read = f_Item1, write = f_Item1 };
        public TPredicateItemBase Item2 = { read = f_Item2, write = f_Item2 };*/
    }
    class TPredicateTFSConvertor
    {
        /*     TList* f_ListEnlarge;
         TPredicateNumGenerator* f_NGen;
         TPredicateItemBig* f_PredicateStart;
         TPredicatePathItem* f_BasePath;
         TPredicatePathItem* f_UsedPath;
         int f_PathStyle;
         bool f_TryPath;
         void FreeHead();
         TPredicateItemBig* NewBig(TAlternativeParserItemBig* ABig);
         void DoCopyTree(TPredicateItemBig* ABig, TDynamicArray* AStack);
         void DoSetID();
         void DoSetIDItem(TPredicateItemBig* AHead, TDynamicArray* AStack);
         void DoSetIDItemTFS(TPredicateItemBase* ABase, TDynamicArray* AStack);
         void PushTFS(TPredicateItemTFS* ATFS, TDynamicArray* AStack);

         void DoProcess();
         void DoProcessItemTFS(TPredicateItemBase* ABase, TDynamicArray* AStack);
         void DoProcessItem(TPredicateItemBig* AHead, TDynamicArray* AStack);
         void SwapNumAlt(TPredicateItemBase* ADest, TPredicateItemBase* ASource);
         TPredicateItemBase* EnvelopeToBig(TPredicateItemBase* ASource);
         bool CheckEnlargeNum(TPredicateItemBig* ABig);
         TPredicatePathNode* FillPathNode(TPredicateItemBig* AHead, TPredicateItemBase* AItem);
         TPredicatePathNode* FillPathNode(TPredicateItemBig* AHead, TDynamicArray* ADyn);
         bool CheckPath(TPredicateItemBig* AHead, TPredicateItemBase* AItem);
         bool CheckPath(TPredicateItemBig* AHead, TDynamicArray* ADyn);
         void SetPathNode(TPredicateItemBig* AHead, TDynamicArray* ADyn);
         void ApplyStyle(TPredicateItemBig* AHead, TPredicateItemBase* AItem);
         void ApplyStyle(TPredicateItemBig* AHead, TDynamicArray* ADyn);
         public:
          TPredicateTFSConvertor();
         ~TPredicateTFSConvertor();
         void CopyTree(TAlternativeParserItemBig* AHead);
         void Process(TPredicatePathItem* ABase, TPredicatePathItem* AUsed);
         __property TPredicateItemBig* Head = {read = f_PredicateStart
     };
     __property int PathStyle = { read = f_PathStyle, write = f_PathStyle };
     __property bool TryPath = { read = f_TryPath };*/
    }
}
