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
    public class TAlternativeParserItemList
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
    class TAlternativeParserItemTFE
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
        public TAlternativeParserItemTFE();
    ~TAlternativeParserItemTFE() { }
        public TTreeListItem  TFE = {read = f_TFE, write = SetTFE
        public TAlternativeParserItemBig* Big = { read = f_Big };
    }

class TAlternativeParserItemTFS : TAlternativeParserItemBase
{
    private:
      TTreeListTFS* f_TFS;
TList* f_List;
void FreeList();
void __fastcall SetTFS(TTreeListTFS* ATFS);
int __fastcall GetTFECount();
TAlternativeParserItemTFE* __fastcall GetTFEItems(int AIndex);
public:
      TAlternativeParserItemTFS();
~TAlternativeParserItemTFS();
int Who() { return 0; }
__property TTreeListTFS* TFS = { read = f_TFS, write = SetTFS };
__property int TFECount = { read = GetTFECount };
__property TAlternativeParserItemTFE* TFEItems[int AIndex] = { read = GetTFEItems };
}


<<<<<<< HEAD
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
        void FillBasisFromGrpItemList(TAlternativeParserGrpItemList* AList);
        void FillBasisAlternateTreeList(TAlternateTreeList* ALT);
        void FillBasisFromEnlarge(TAlternativeParserGrpCrossItemEnlarge* AEnl);
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
        __property TAlternativeParserItemBig* ItemsBig[int AIndex] = { read = GetItemsBig };
        __property bool Check = { read = f_Check, write = f_Check };
        __property TAlternativeParserItemTFE* ParentTFE = { read = f_ParentTFE, write = f_ParentTFE };
        __property bool Cross = { read = f_Cross, write = f_Cross };
        __property bool BadBasis = { read = f_BadBasis, write = f_BadBasis };
        __property int Enlarge = { read = f_Enlarge, write = f_Enlarge };
        __property bool EnlargeSetNum = { read = f_EnlargeSetNum, write = f_EnlargeSetNum };*/
    }
<<<<<<< HEAD



    class TAlternativeParser
    {
        List<object> f_ListEnlarge;
        TAlternativeParserGrp f_Grp;
        TAlternativeParserItemBig f_Head;
        void FreeHead()
        {
          /*  if (f_Head!=null)
                delete f_Head;*/
        }
        void CreateHead()
        {
            FreeHead();
            f_Head = new TAlternativeParserItemBig();
        }
        void DoMakeAlternative()
        {

        }
        void DoParse(TMainTreeList AMainTree)
        {
            TAlternativeParserItemBig mBig, mTemp;
            TAlternativeParserItemBase mBase;
            CreateHead();
            f_Head.MainTreeList = AMainTree;
            f_Head.FillBasisAlternateTreeList(f_Head.MainTreeList.MainAlternative);
            TDynamicArray m_Stack = new TDynamicArray();
            m_Stack.InsertToFirst(f_Head);
   /*         mBig = (TAlternativeParserItemBig)(m_Stack.Pop());
            while (mBig!=null)
            {
                if (CheckEnlarge(mBig))
                    MakeBig(mBig, f_Head == mBig);
                mBig.Check = true;
                mBig.GetAllFirstBigsNoCheck(m_Stack);
                mBig = (TAlternativeParserItemBig)(m_Stack.Pop());
            }*/
          //  delete m_Stack;
        }
         void MakeBig(TAlternativeParserItemBig ABig, bool AByPass)
        {
            int m_n = 0;
            bool b_basis, b_main, b_tail, b_go, b_parent, b_cbm, b_valid = false;
            TTreeListTFS TFS;
            TAlternateTreeList AItem;
            TAlternativeParserItemBig NewBig;

            TMainTreeList m_Tree = ABig.MainTreeList;

            TDynamicArray D = new TDynamicArray();
            TDynamicArray Mass = new TDynamicArray();
            bool m_whl = true;
            bool m_hook = false;
            while (m_whl)
            {
                m_whl = false;
                f_Grp.Clear();
       /*         for (int i = 0; i <= ABig.BasisCount - 1; i++)
                {
                    TFS = ABig.GetBasisItems(i);
                    m_Tree.FindAlternate(TFS.BaseWorkShape, D);
                    b_go = false;
                    if (D.Count > 0)
                        for (int j = 0; j <= D.Count - 1; j++)
                        {
                            AItem = (TAlternateTreeList)(D.GetItems(j));
                            b_basis = ABig.CompareBasisAndAlternateTreeList(AItem);
                            b_main = AItem.MainAlternative;
                            b_tail = ABig.IsTailAlternateTreeList(AItem);
                            b_parent = ABig.ParentTFE !=null;
                            if (!b_basis && !b_main)
                            {
                                Mass.Clear();
                                ABig.GetTreeListTFSFromBasis(AItem, Mass, ref b_valid);
                                if (!b_valid)
                                    continue;
                                b_cbm = ABig.CompareBasisAndMassiv(Mass);
                                b_go = (AByPass || !b_cbm || b_parent);
                                if (b_go)
                                    CreateParserGrpItemList(Mass, AItem);
                            }
                            if (b_tail && !b_main && !b_go)
                            {
                                m_n++;
                                NewBig = new TAlternativeParserItemBig();
                                NewBig.NumAlt = m_n;
                                NewBig.FillBasisAlternateTreeList(AItem);
                                NewBig.OwnerBig = ABig;
                                ABig.AddBig(NewBig);
                            }

                        }
                    f_Grp.AddTfs(TFS);*/
                }

                if (ABig.BadBasis && !m_hook)
                {
             //       ABig.HookBasisBig();
                    m_hook = true;
                    m_whl = true;
                }
        //    f_Grp.Make();
     //       FillBigFromGrp(ABig);
        }
        /* void FillBigFromGrp(TAlternativeParserItemBig ABig);*/
         void CreateParserGrpItemList(TDynamicArray AMass, TAlternateTreeList Alternative)
        {
            TAlternativeParserGrpItemList Item;
            if (AMass.Count > 0)
            {
     //           Item = f_Grp.GetNewList(Alternative);
         //       for (int i = 0; i <= AMass.Count - 1; i++)
       //             Item.AddTfs((TTreeListTFS)(AMass.GetItems(i)));
            }
        }

        /*     void CrossToBigs(TAlternativeParserGrpCrossItem ACrossItem, TAlternativeParserItemBig ABig);
             void FillItemGrp(TAlternativeParserGrpItemBase AItem, TAlternativeParserItemBig ABig);*/
        bool CheckEnlarge(TAlternativeParserItemBig ABig)
        {
            TAlternativeParserItemBig Item;
            if (ABig.Enlarge > 0)
            {
                for (int i = 0; i <= f_ListEnlarge.Count - 1; i++)
                {
                    Item = (TAlternativeParserItemBig)(f_ListEnlarge.ElementAt(i));
                    if (Item.Enlarge == ABig.Enlarge)
                        return false;
                }
                f_ListEnlarge.Add(ABig);
            }
            return true;
        }
=======
>>>>>>> parent of 7032bbe... next gen

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
=======
public class TAlternativeParserItemBig : TAlternativeParserItemBase
{
    private:
      bool f_Check;
bool f_BadBasis;
int f_Enlarge;
bool f_EnlargeSetNum;
TList* f_List;
TDynamicArray* f_Basis;
bool f_Cross;
void FreeList();
TAlternativeParserItemList* f_MainList;
TAlternativeParserItemTFE* f_ParentTFE;
int __fastcall GetCountBig();
TAlternativeParserItemBig* __fastcall GetItemsBig(int AIndex);
int __fastcall GetBasisCount();
TTreeListTFS* __fastcall GetBasisItems(int AIndex);
TTreeListTFS* FirstFromBasis();
TTreeListTFS* LastFromBasis();
public:
      TAlternativeParserItemBig();
~TAlternativeParserItemBig();
int Who() { return 1; }
void BasisClear();
void BasisAdd(TTreeListTFS* ATFS);
void FillBasisFromGrpItemList(TAlternativeParserGrpItemList* AList);
void FillBasisAlternateTreeList(TAlternateTreeList* ALT);
void FillBasisFromEnlarge(TAlternativeParserGrpCrossItemEnlarge* AEnl);
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
__property TAlternativeParserItemBig* ItemsBig[int AIndex] = { read = GetItemsBig };
__property bool Check = { read = f_Check, write = f_Check };
__property TAlternativeParserItemTFE* ParentTFE = { read = f_ParentTFE, write = f_ParentTFE };
__property bool Cross = { read = f_Cross, write = f_Cross };
__property bool BadBasis = { read = f_BadBasis, write = f_BadBasis };
__property int Enlarge = { read = f_Enlarge, write = f_Enlarge };
__property bool EnlargeSetNum = { read = f_EnlargeSetNum, write = f_EnlargeSetNum };
};



class TAlternativeParser
{
    private:
      TList* f_ListEnlarge;
    TAlternativeParserGrp* f_Grp;
    TAlternativeParserItemBig* f_Head;
    void FreeHead();
    void CreateHead();
    void DoMakeAlternative();
    void DoParse(TMainTreeList* AMainTree);
    void MakeBig(TAlternativeParserItemBig* ABig, bool AByPass);
    void FillBigFromGrp(TAlternativeParserItemBig* ABig);
    void CreateParserGrpItemList(TDynamicArray* AMass, TAlternateTreeList* Alternative);
    void CrossToBigs(TAlternativeParserGrpCrossItem* ACrossItem, TAlternativeParserItemBig* ABig);
    void FillItemGrp(TAlternativeParserGrpItemBase* AItem, TAlternativeParserItemBig* ABig);
    bool CheckEnlarge(TAlternativeParserItemBig* ABig);

    public:
      TAlternativeParser();
    ~TAlternativeParser();
    void Parse(TMainTreeList* AMainTree);
    __property TAlternativeParserItemBig* Head = {read = f_Head
};
};
>>>>>>> parent of e98a560... ++
}
