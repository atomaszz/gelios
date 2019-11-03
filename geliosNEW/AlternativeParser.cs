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
        public TAlternativeParserItemBase GetItems(int AIndex)
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
        void __fastcall SetTFS(TTreeListTFS ATFS);*/
        int  GetTFECount()
        {
            return f_List.Count;
        }
        public TAlternativeParserItemTFE  GetTFEItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserItemTFE)(f_List.ElementAt(AIndex));
            else
                return null;
        }

        public TAlternativeParserItemTFS()
        {
            f_TFS = null;
            f_List = new List<object>();
        }
        ~TAlternativeParserItemTFS() { }
        override public int  Who() { return 0; }
        public TTreeListTFS TFS
        {
            set { f_TFS = value;  }
            get { return f_TFS;  }
        }
        public int TFECount
        {
            get { return GetTFECount(); }
        }
      /*  __property TAlternativeParserItemTFE* TFEItems[int AIndex] = { read = GetTFEItems };*/
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
        int  GetCountBig()
        {
            return f_List.Count;
        }
        TAlternativeParserItemBig  GetItemsBig(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserItemBig)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        int GetBasisCount()
        {
            return f_Basis.Count;
        }
        public TTreeListTFS  GetBasisItems(int AIndex)
        {
            return (TTreeListTFS)(f_Basis.GetItems(AIndex));
        }
        TTreeListTFS FirstFromBasis()
        {
            return GetBasisItems(0);
        }
        TTreeListTFS LastFromBasis()
        {
            return GetBasisItems(BasisCount - 1);
        }

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
        void BasisClear()
        {
            f_Basis.Clear();
        }
    /*    void BasisAdd(TTreeListTFS ATFS);
        void FillBasisFromGrpItemList(TAlternativeParserGrpItemList AList);*/
        public void FillBasisAlternateTreeList(TAlternateTreeList ALT)
        {
            for (int i = 0; i <= ALT.ItemCount - 1; i++)
                BasisAdd(ALT.GetTreeTFSItem(i));
        }
        /*    void FillBasisFromEnlarge(TAlternativeParserGrpCrossItemEnlarge* AEnl);*/
            public bool CompareBasisAndAlternateTreeList(TAlternateTreeList AList)
        {
            TTreeListTFS mTfs;
            int LenB = BasisCount;
            int LenA = AList.ItemCount;
            if (LenA != LenB)
                return false;
            for (int i = 0; i <= LenA - 1; i++)
            {
                if (GetBasisItems(i) != AList.GetTreeTFSItem(i))
                    return false;
            }
            return true;
        }
        public bool CompareBasisAndMassiv(TDynamicArray AMass)
        {
            TTreeListTFS mTfs;
            int LenB = BasisCount;
            int LenA = AMass.Count;
            if (LenA != LenB)
                return false;
            for (int i = 0; i <= LenA - 1; i++)
            {
                if (GetBasisItems(i) != AMass.GetItems(i))
                    return false;
            }
            return true;
        }
        public bool IsTailAlternateTreeList(TAlternateTreeList AList)
        {
            TTreeListTFS FT, ET;
            TBaseWorkShape FW, EW;
            if (AList.NodeEnd==null) return true;
            FW = AList.NodeStart.WorkShape;
            EW = AList.NodeEnd.WorkShape;
            FT = FirstFromBasis();
            ET = LastFromBasis();
            bool res = ((FT.BaseWorkShape == FW) && (ET.BaseWorkShape == EW));
            return res;
        }
        public void AddBig(TAlternativeParserItemBig ABig)
        {
            f_List.Add(ABig);
        }
        public void GetTreeListTFSFromBasis(TAlternateTreeList Alternative,
              TDynamicArray D, ref bool AValid)
        {
            TBaseWorkShape NS, NE, CR;
            TTreeListTFS Tmp;
            bool f = false;
            bool e = false;
            NS = Alternative.NodeStart.WorkShape;
            NE = Alternative.NodeEnd.WorkShape;
            for (int i = 0; i <= BasisCount - 1; i++)
            {
                Tmp = GetBasisItems(i);
                CR = Tmp.BaseWorkShape;
                if (!f && (CR == NS))
                    f = true;

                if (f && !e)
                    D.Append(Tmp);

                if (!e && (CR == NE))
                    e = true;
            }
            AValid = f && e;
        }
        public void GetAllFirstBigsNoCheck(TDynamicArray AMass)
        {
            TAlternativeParserItemBig mTemp;
            TAlternativeParserItemBase mBase;
            TAlternativeParserItemTFS mTfs;
            TAlternativeParserItemTFE mTfe;
            int i, m_who;
            for (i = 0; i <= MainList.Count - 1; i++)
            {
                mBase = MainList.GetItems(i);
                m_who = mBase.Who();
                if (m_who == 1)
                {
                    mTemp = (TAlternativeParserItemBig)(mBase);
                    mTemp.MainTreeList = MainTreeList;
                    if (!mTemp.Check)
                        AMass.InsertToFirst(mTemp);
                    //if (mTemp.Enlarge > 0)
                }
                if (m_who == 0)
                {
                    mTfs = (TAlternativeParserItemTFS)(mBase);
                    for (int j = 0; j <= mTfs.TFECount - 1; j++)
                    {
                        mTfe = mTfs.GetTFEItems(j);
                        if (mTfe.Big!=null && !mTfe.Big.Check)
                            AMass.InsertToFirst(mTfe.Big);
                    }
                }
            }
            for (i = 0; i <= CountBig - 1; i++)
            {
                mTemp = GetItemsBig(i);
                mTemp.MainTreeList = MainTreeList;
                if (!mTemp.Check)
                    AMass.InsertToFirst(mTemp);
                if (mTemp.Cross)
                    mTemp.GetAllFirstBigsNoCheck(AMass);

            }
        }
        public void HookBasisBig()
        {
            TAlternativeParserItemBig m_F;
            BasisClear();
            m_F = GetItemsBig(0);
            for (int i = 0; i <= m_F.BasisCount - 1; i++)
                BasisAdd(m_F.GetBasisItems(i));
            f_List.RemoveAt(f_List.IndexOf(m_F));

            for (int i = 0; i <= CountBig - 1; i++)
                GetItemsBig(i).NumAlt = i + 1;

        }
        public TAlternativeParserItemList MainList
        {
            get { return f_MainList; }
        }
        public int BasisCount
        {
            get { return GetBasisCount(); }
        }
    /*    public TTreeListTFS BasisItems[int AIndex] = { read = GetBasisItems };*/
        public int CountBig
        {
            get { return GetCountBig(); }
        }
   /*         __property TAlternativeParserItemBig ItemsBig[int AIndex] = { read = GetItemsBig };*/
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
            mBig = (TAlternativeParserItemBig)(m_Stack.Pop());
            while (mBig!=null)
            {
                if (CheckEnlarge(mBig))
                    MakeBig(mBig, f_Head == mBig);
                mBig.Check = true;
                mBig.GetAllFirstBigsNoCheck(m_Stack);
                mBig = (TAlternativeParserItemBig)(m_Stack.Pop());
            }
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
                for (int i = 0; i <= ABig.BasisCount - 1; i++)
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
                    f_Grp.AddTfs(TFS);
                }

                if (ABig.BadBasis && !m_hook)
                {
                    ABig.HookBasisBig();
                    m_hook = true;
                    m_whl = true;
                }

            }
            f_Grp.Make();
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

        public TAlternativeParser()
        {
            f_Head = null;
            f_Grp = new TAlternativeParserGrp();
            f_ListEnlarge = new List<object>();
        }
        ~TAlternativeParser() { }
        public void Parse(TMainTreeList AMainTree)
        {
            if (AMainTree!=null)
                DoParse(AMainTree);
        }
        public TAlternativeParserItemBig Head
        {
            get { return f_Head; }
        }
    }
}

