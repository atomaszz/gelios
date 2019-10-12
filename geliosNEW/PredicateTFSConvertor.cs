using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TPredicateNumGenerator
    {
        int f_CurrentNum;
        public TPredicateNumGenerator()
        {
            f_CurrentNum = 0;
        }
        public int NextNum()
        {
            f_CurrentNum++;
            return f_CurrentNum;
        }
        public void InitNum(int ACurr = 0)
        {
            f_CurrentNum = ACurr;
        }
        public int NextLowNum()
        {
            f_CurrentNum--;
            return f_CurrentNum;
        }
    }
    public class TPredicateItemBase
    {
        int f_ID;
        int f_NumAlt;
        bool f_Envelope;
        TPredicateItemBig f_EnvelopeBIG;
        public TPredicateItemBase()
        {
            f_NumAlt = -1;
            f_Envelope = false;
            f_ID = 0;
            f_EnvelopeBIG = null;
        }
        ~TPredicateItemBase() { }
        public virtual int Who() { return -1; }
        /*      public virtual void ListIDFill(TDynamicArray AList);*/
        public int NumAlt
        {
            set { f_NumAlt = value; }
            get { return f_NumAlt; }
        }
        public bool Envelope
        {
            set { f_Envelope = value; }
            get { return f_Envelope; }
        }
        public int ID
        {
            set { f_ID = value; }
            get { return f_ID; }
        }
        public TPredicateItemBig EnvelopeBIG
        {
            set { f_EnvelopeBIG = value; }
            get { return f_EnvelopeBIG; }
        }
    }
    class TPredicateItemTFE
    {
        TTreeListItem f_TFE;
        TPredicateItemBig f_Big;
        TAlternativeParserItemTFE f_RfcTFE;
        public TPredicateItemTFE()
        {
            f_TFE = null;
            f_Big = null;
            f_RfcTFE = null;
        }
        ~TPredicateItemTFE() { }
        public TTreeListItem TFE
        {
            set { f_TFE = value; }
            get { return f_TFE; }
        }
        public TPredicateItemBig Big
        {
            set { f_Big = value; }
            get { return f_Big; }
        }
        public TAlternativeParserItemTFE RfcTFE
        {
            set { f_RfcTFE = value; }
            get { return f_RfcTFE; }
        }
    }
    class TPredicateItemTFS : TPredicateItemBase
    {
        TTreeListTFS f_TFS;
        List<object> f_ListTFE;
        /*      void FreeList();
              int GetTFECount();
              TPredicateItemTFE GetTFEItems(int AIndex);*/
        public TPredicateItemTFS()
        {
            f_TFS = null;
            f_ListTFE = new List<object>();
        }
        ~TPredicateItemTFS() { }
        override public int Who() { return 0; }
        /*      public void Assign(TAlternativeParserItemTFS ATfs);
              public void ListIDFill(TDynamicArray AList);
              public TTreeListTFS TFS = { read = f_TFS };
              public int TFECount = { read = GetTFECount };
              public TPredicateItemTFE TFEItems[int AIndex] = { read = GetTFEItems };*/
    }
    public class TPredicateItemBig : TPredicateItemBase
    {
        bool f_Print;
        List<object> f_List;
        TAlternativeParserItemBig f_Rfc;
        /*       int GetCount();
               TPredicateItemBase GetItems(int AIndex);
               void FreeList();*/
        public override int Who() { return 1; }
        public TPredicateItemBig()
        {
            f_Rfc = null;
            f_List = new List<object>();
            f_Print = false;
        }
        ~TPredicateItemBig() { }
        /*      public void AddItem(TPredicateItemBase* AItem);
              public void DeleteItemToList(TPredicateItemBase* AItem);
              public bool ValidDescendant();
              public int Count = { read = GetCount };
              public TPredicateItemBase* Items[int AIndex] = { read = GetItems };*/
        public TAlternativeParserItemBig Rfc
        {
            set { f_Rfc = value;  }
            get { return f_Rfc; }
        }
        public bool Print
        {
            set { f_Print = value; }
            get { return f_Print; }
        }
    }
    class TPredicateItemPWork : TPredicateItemBase
    {
        TPredicateItemBase f_Item1;
        TPredicateItemBase f_Item2;
        public override int Who() { return 2; }
        public TPredicateItemPWork()
        {
            f_Item1 = null;
            f_Item2 = null;
        }
        ~TPredicateItemPWork() { }
        /*      public void ListIDFill(TDynamicArray AList);*/
        public TPredicateItemBase Item1
        {
            set { f_Item1 = value; }
            get { return f_Item1; }
        }
        public TPredicateItemBase Item2
        {
            set { f_Item2 = value; }
            get { return f_Item2; }
        }
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
        /*  void FreeHead();
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
          public:*/
           public TPredicateTFSConvertor()
        {
            f_PathStyle = 0;
            f_TryPath = true;
            f_PredicateStart = null;
            f_NGen = new TPredicateNumGenerator();
            f_ListEnlarge = new List<object>();
        }
        ~TPredicateTFSConvertor() { }
      /*    void CopyTree(TAlternativeParserItemBig* AHead);
          void Process(TPredicatePathItem* ABase, TPredicatePathItem* AUsed);
          __property TPredicateItemBig* Head = {read = f_PredicateStart
      };
      __property int PathStyle = { read = f_PathStyle, write = f_PathStyle };
      __property bool TryPath = { read = f_TryPath };
      };*/
    }
}
