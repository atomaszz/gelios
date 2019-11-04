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
/*        TPredicateItemBase();
        virtual ~TPredicateItemBase() { return; }
        virtual int Who() { return -1; }
        virtual void ListIDFill(TDynamicArray* AList);
        __property int NumAlt = { read = f_NumAlt, write = f_NumAlt };
        __property bool Envelope = { read = f_Envelope, write = f_Envelope };
        __property int ID = { read = f_ID, write = f_ID };
        __property TPredicateItemBig* EnvelopeBIG = {read = f_EnvelopeBIG, write = f_EnvelopeBIG*/
    }
    class TPredicateItemTFE
    {
        TTreeListItem f_TFE;
        TPredicateItemBig f_Big;
        TAlternativeParserItemTFE f_RfcTFE;
        /*  public:
           TPredicateItemTFE();
          ~TPredicateItemTFE();
          __property TTreeListItem* TFE = {read = f_TFE, write = f_TFE
      };
      __property TPredicateItemBig* Big = { read = f_Big, write = f_Big };
      __property TAlternativeParserItemTFE* RfcTFE = { read = f_RfcTFE, write = f_RfcTFE };*/
    }
    class TPredicateItemTFS : TPredicateItemBase
    {
      TTreeListTFS f_TFS;
      List<object> f_ListTFE;
        /*void FreeList();
        int __fastcall GetTFECount();
        TPredicateItemTFE* __fastcall GetTFEItems(int AIndex);
        public:
              TPredicateItemTFS();
        ~TPredicateItemTFS();
        int Who() { return 0; }
        void Assign(TAlternativeParserItemTFS* ATfs);
        void ListIDFill(TDynamicArray* AList);
        __property TTreeListTFS* TFS = { read = f_TFS };
        __property int TFECount = { read = GetTFECount };
        __property TPredicateItemTFE* TFEItems[int AIndex] = { read = GetTFEItems };*/
    }
    class TPredicateItemBig : TPredicateItemBase
    {
        bool f_Print;
        List<object> f_List;
        TAlternativeParserItemBig f_Rfc;
        /*int __fastcall GetCount();
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
//     __property TPredicateItemTFE* OwnerTFE = {read = f_OwnerTFE, write = f_OwnerTFE};
__property TAlternativeParserItemBig* Rfc = { read = f_Rfc, write = f_Rfc };
__property bool Print = { read = f_Print, write = f_Print };*/
    }
    class TPredicateItemPWork :  TPredicateItemBase
    {
      TPredicateItemBase f_Item1;
        TPredicateItemBase f_Item2;
        /*public:
              int Who() { return 2; }
        TPredicateItemPWork();
        ~TPredicateItemPWork();
        void ListIDFill(TDynamicArray* AList);
        __property TPredicateItemBase* Item1 = { read = f_Item1, write = f_Item1 };
        __property TPredicateItemBase* Item2 = { read = f_Item2, write = f_Item2 };*/
    }
    class TPredicateTFSConvertor
    {
        List<object> f_ListEnlarge;
        TPredicateNumGenerator f_NGen;
        TPredicateItemBig f_PredicateStart;
        TPredicatePathItem f_BasePath;
        TPredicatePathItem f_UsedPath;
        int f_PathStyle;
        bool f_TryPath;
        /*   void FreeHead();
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
