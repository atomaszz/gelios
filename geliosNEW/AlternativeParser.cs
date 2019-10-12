using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TAlternativeParserItemBase
    {
        int f_NumAlt;
        TMainTreeList f_MainTree;
        TAlternativeParserItemBig f_OwnerBig;

        public TAlternativeParserItemBase()
        {
            f_MainTree = null;
            f_OwnerBig = null;
            f_NumAlt = 0;
        }
        public virtual int Who() { return -1; }
        ~TAlternativeParserItemBase() { }
        public TMainTreeList MainTreeList
        {
            set { f_MainTree = value; }
            get { return f_MainTree; }
        }
        public TAlternativeParserItemBig OwnerBig
        {
            set { f_OwnerBig = value; }
            get { return f_OwnerBig; }
        }
        public int NumAlt
        {
            set { f_NumAlt = value; }
            get { return f_NumAlt; }
        }
    }
    class TAlternativeParserItemList
    {
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
        int GetCount()
        {
            return f_List.Count;
        }
        TAlternativeParserItemBase GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserItemBase)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        public TAlternativeParserItemList()
        {
            f_List = new List<object>();
        }
        ~TAlternativeParserItemList() { }
        public void Append(TAlternativeParserItemBase AItem)
        {
            TAlternativeParserItemBase Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserItemBase)(f_List.ElementAt(i));
                if (Item == AItem)
                    return;
            }
            f_List.Add(AItem);
        }
        public int Count { get { return GetCount(); } }
    }
    public   class TAlternativeParserItemTFE
    {
        TTreeListItem f_TFE;
        TAlternativeParserItemBig f_Big;
        void  SetTFE(TTreeListItem ATFE)
        {
            if (f_TFE!=null)
                throw (new Exception("Повторное присвоение в TAlternativeParserItemTFE не допустимо!"));
            f_TFE = ATFE;
            if (ATFE.MainNode!=null)
            {
                f_Big = new TAlternativeParserItemBig();
                f_Big.MainTreeList = ATFE.MainNode;
                f_Big.FillBasisAlternateTreeList(f_Big.MainTreeList.MainAlternative);
                f_Big.ParentTFE = this;
            }
        }
        public TAlternativeParserItemTFE()
        {
            f_TFE = null;
            f_Big = null;
        }
    ~TAlternativeParserItemTFE() { }
        public TTreeListItem  TFE
        {
            set { f_TFE = value; }
            get { return f_TFE; }
        }
        public TAlternativeParserItemBig Big
        {
            get { return f_Big; }
        }
    }
    class TAlternativeParserItemTFS : TAlternativeParserItemBase
    {
        TTreeListTFS f_TFS;
        List<object> f_List;
/*void FreeList();
void __fastcall SetTFS(TTreeListTFS ATFS);
int __fastcall GetTFECount();
TAlternativeParserItemTFE* __fastcall GetTFEItems(int AIndex);*/

        public TAlternativeParserItemTFS()
        {
            f_TFS = null;
            f_List = new List<object>();
        }
        ~TAlternativeParserItemTFS() { }
        override public int  Who() { return 0; }
        /*__property TTreeListTFS* TFS = { read = f_TFS, write = SetTFS };
        __property int TFECount = { read = GetTFECount };
        __property TAlternativeParserItemTFE* TFEItems[int AIndex] = { read = GetTFEItems };*/
    }
    public class TAlternativeParserItemBig : TAlternativeParserItemBase
    {
        bool f_Check;
        bool f_BadBasis;
        int f_Enlarge;
        bool f_EnlargeSetNum;
        List<object> f_List;
        TDynamicArray f_Basis;
        bool f_Cross;
     //   void FreeList();
        TAlternativeParserItemList f_MainList;
        TAlternativeParserItemTFE f_ParentTFE;
   /*     int  GetCountBig();
        TAlternativeParserItemBig  GetItemsBig(int AIndex);
        int GetBasisCount();
        TTreeListTFS  GetBasisItems(int AIndex);
        TTreeListTFS FirstFromBasis();
        TTreeListTFS LastFromBasis();*/

      public TAlternativeParserItemBig()
        {
            f_Check = false;
            f_Cross = false;
            f_Enlarge = 0;
            f_EnlargeSetNum = false;
            f_ParentTFE = null;
            f_BadBasis = false;
            f_MainList = new TAlternativeParserItemList();
            f_List = new List<object>();
            f_Basis = new TDynamicArray();
        }
        ~TAlternativeParserItemBig() { }
        public override int Who() { return 1; }
        /*void BasisClear();
        void BasisAdd(TTreeListTFS* ATFS);
        void FillBasisFromGrpItemList(TAlternativeParserGrpItemList* AList);*/
        public void FillBasisAlternateTreeList(TAlternateTreeList ALT)
        {
            for (int i = 0; i <= ALT.ItemCount - 1; i++)
                BasisAdd(ALT.GetTreeTFSItem(i));
        }
        /*    void FillBasisFromEnlarge(TAlternativeParserGrpCrossItemEnlarge* AEnl);
            bool CompareBasisAndAlternateTreeList(TAlternateTreeList* AList);
            bool CompareBasisAndMassiv(TDynamicArray* AMass);
            bool IsTailAlternateTreeList(TAlternateTreeList* AList);
            void AddBig(TAlternativeParserItemBig* ABig);
            void GetTreeListTFSFromBasis(TAlternateTreeList* Alternative,
              TDynamicArray* D, bool &AValid);
            void GetAllFirstBigsNoCheck(TDynamicArray* AMass);
            void HookBasisBig();
            __property TAlternativeParserItemList* MainList = { read = f_MainList };
            __property int BasisCount = { read = GetBasisCount };
            __property TTreeListTFS* BasisItems[int AIndex] = { read = GetBasisItems };
            __property int CountBig = { read = GetCountBig };
            __property TAlternativeParserItemBig* ItemsBig[int AIndex] = { read = GetItemsBig };*/
        public bool Check
        {
            set { f_Check = value; }
            get { return f_Check; }
        }
        public TAlternativeParserItemTFE ParentTFE
        {
            set { f_ParentTFE = value; }
            get { return f_ParentTFE; }
        }
        public bool Cross
        {
            set { f_Cross = value; }
            get { return f_Cross; }
        }
        public bool BadBasis
        {
            set { f_BadBasis = value; }
            get { return f_BadBasis; }
        }
        public int Enlarge
        {
            set { f_Enlarge = value; }
            get { return f_Enlarge; }
        }
        public bool EnlargeSetNum
        {
            set { f_EnlargeSetNum = value; }
            get { return f_EnlargeSetNum; }
        }
        void BasisAdd(TTreeListTFS ATFS)
        {
            for (int i = 0; i <= f_Basis.Count - 1; i++)
            {
                if (f_Basis.GetItems(i) == ATFS)
                    return;
            }
            f_Basis.Append(ATFS);
        }
    }



    class TAlternativeParser
    {
        List<object> f_ListEnlarge;
        TAlternativeParserGrp f_Grp;
        TAlternativeParserItemBig f_Head;
        /*  void FreeHead();
          void CreateHead();
          void DoMakeAlternative();
          void DoParse(TMainTreeList AMainTree);
          void MakeBig(TAlternativeParserItemBig ABig, bool AByPass);
          void FillBigFromGrp(TAlternativeParserItemBig ABig);
          void CreateParserGrpItemList(TDynamicArray AMass, TAlternateTreeList Alternative);
          void CrossToBigs(TAlternativeParserGrpCrossItem ACrossItem, TAlternativeParserItemBig ABig);
          void FillItemGrp(TAlternativeParserGrpItemBase AItem, TAlternativeParserItemBig ABig);
          bool CheckEnlarge(TAlternativeParserItemBig ABig);*/

        public TAlternativeParser()
        {
            f_Head = null;
            f_Grp = new TAlternativeParserGrp();
            f_ListEnlarge = new List<object>();
        }
        ~TAlternativeParser() { }
        /*   void Parse(TMainTreeList AMainTree);
           __property TAlternativeParserItemBig Head = {read = f_Head*/
    }
}

