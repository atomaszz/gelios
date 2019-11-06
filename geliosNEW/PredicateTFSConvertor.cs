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
        virtual ~TPredicateItemBase() { return; }*/
        public virtual int Who() { return -1; }
       public virtual void ListIDFill(TDynamicArray AList)
        {
            AList.AppendInteger(f_ID, null);
        }
        public int NumAlt
        {
            set { f_NumAlt = value; }
            get { return f_NumAlt;  }
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
        /*  public:
           TPredicateItemTFE();
          ~TPredicateItemTFE();*/
        public TTreeListItem TFE
        {
            set { f_TFE = value; }
            get { return f_TFE; }
        }
        public TPredicateItemBig Big
        {
            set { f_Big = value;  }
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
      void FreeList()
        {
            f_ListTFE.Clear();
        }
        int GetTFECount()
        {
            return f_ListTFE.Count;
        }
        public TPredicateItemTFE  GetTFEItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_ListTFE.Count - 1)
                return (TPredicateItemTFE)(f_ListTFE.ElementAt(AIndex));
            else
                return null;
        }
        /*     public:
                   TPredicateItemTFS();
             ~TPredicateItemTFS();*/
        public override int Who() { return 0; }
        public void Assign(TAlternativeParserItemTFS ATfs)
        {
            TPredicateItemTFE mTfe;
            FreeList();
            f_TFS = ATfs.TFS;
            NumAlt = ATfs.NumAlt;
            for (int i = 0; i <= ATfs.TFECount - 1; i++)
            {
                mTfe = new TPredicateItemTFE();
                mTfe.RfcTFE = ATfs.GetTFEItems(i);
                mTfe.TFE = ATfs.GetTFEItems(i).TFE;
                f_ListTFE.Add(mTfe);
            }

        }
        /*    void ListIDFill(TDynamicArray* AList);*/
        public TTreeListTFS TFS
        {
            get { return f_TFS; }
        }
        public int TFECount
        {
            get { return GetTFECount(); }
        }
   /*     __property TPredicateItemTFE* TFEItems[int AIndex] = { read = GetTFEItems };*/
    }
    class TPredicateItemBig : TPredicateItemBase
    {
        bool f_Print;
        List<object> f_List;
        TAlternativeParserItemBig f_Rfc;
        int GetCount()
        {
            return f_List.Count;
        }
        public TPredicateItemBase GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TPredicateItemBase)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        void FreeList()
        {
            f_List.Clear();
        }
           public override int Who() { return 1; }
        /*      TPredicateItemBig();
      ~TPredicateItemBig();*/
      public void AddItem(TPredicateItemBase AItem)
        {
            f_List.Add(AItem);
        }

        /*    void DeleteItemToList(TPredicateItemBase* AItem);*/
        public bool ValidDescendant()
        {
            return true;
        }
        public int Count
        {
            get { return GetCount();  }
        }
/*__property TPredicateItemBase* Items[int AIndex] = { read = GetItems };
//     __property TPredicateItemTFE* OwnerTFE = {read = f_OwnerTFE, write = f_OwnerTFE};*/
        public TAlternativeParserItemBig Rfc
        {
            set { f_Rfc = value;  }
            get { return f_Rfc;  }
        }
        public bool Print
        {
            set { f_Print = value; }
            get { return f_Print; }
        }
    }
    class TPredicateItemPWork :  TPredicateItemBase
    {
      TPredicateItemBase f_Item1;
        TPredicateItemBase f_Item2;
        /*public:
              int Who() { return 2; }
        TPredicateItemPWork();
        ~TPredicateItemPWork();
        void ListIDFill(TDynamicArray* AList);*/
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
        public void FreeHead()
        {
            if (f_PredicateStart!=null)
            {
                f_PredicateStart = null;
            }
        }
        public TPredicateItemBig NewBig(TAlternativeParserItemBig ABig)
        {
            TPredicateItemBig N = new TPredicateItemBig();
            N.Rfc = ABig;
            N.NumAlt = ABig.NumAlt;
            return N;
        }
        void DoCopyTree(TPredicateItemBig ABig, TDynamicArray AStack)
        {
            int m_who;
            TAlternativeParserItemList ML;
            TAlternativeParserItemBase mBase;
            TAlternativeParserItemTFS mTFS;
            TAlternativeParserItemBig mBig;
            TPredicateItemTFE mTFE;
            TAlternativeParserItemBig mRfc = ABig.Rfc;

            ML = mRfc.MainList;
            for (int i = 0; i <= ML.Count - 1; i++)
            {
                mBase = ML.GetItems(i);
                m_who = mBase.Who();
                if (m_who == 0)
                {
                    mTFS = (TAlternativeParserItemTFS)(mBase);
                    TPredicateItemTFS iTfs = new TPredicateItemTFS();
                    iTfs.Assign(mTFS);
                    ABig.AddItem(iTfs);
                    for (int j = 0; j <= iTfs.TFECount - 1; j++)
                    {
                        mTFE = iTfs.GetTFEItems(j);
                        if (mTFE.RfcTFE.Big!=null)
                        {
                            TPredicateItemBig iBig = NewBig(mTFE.RfcTFE.Big);
                            mTFE.Big = iBig;
                            AStack.InsertToFirst(iBig);
                        }
                    }
                }
                if (m_who == 1)
                {
                    mBig = (TAlternativeParserItemBig)(mBase);
                    TPredicateItemBig iBig = NewBig(mBig);
                    ABig.AddItem(iBig);
                    AStack.InsertToFirst(iBig);
                }
            }

            for (int i = 0; i <= mRfc.CountBig - 1; i++)
            {
                mBig = mRfc.ItemsBig[i];
                TPredicateItemBig iBig = NewBig(mBig);
                ABig.AddItem(iBig);
                AStack.InsertToFirst(iBig);
            }
        }
        void DoSetID()
        {
            TPredicateItemBig Big;
            f_NGen.InitNum();
            TDynamicArray m_Stack = new TDynamicArray();
            m_Stack.InsertToFirst(f_PredicateStart);
            Big = (TPredicateItemBig)(m_Stack.Pop());
            while (Big!=null)
            {
                DoSetIDItem(Big, m_Stack);
                Big = (TPredicateItemBig)(m_Stack.Pop());
            }
            m_Stack = null;
        }
        void DoSetIDItem(TPredicateItemBig AHead, TDynamicArray AStack)
        {
            int m_who;
            TPredicateItemBase m_Base;
            TPredicateItemPWork m_PW;
            int m_cnt = AHead.Count;
            for (int i = 0; i <= m_cnt - 1; i++)
            {
                m_Base = AHead.GetItems(i);
                m_who = m_Base.Who();
                if (m_who == 1)
                {
                    TPredicateItemBig mBig = (TPredicateItemBig)(m_Base);
                    if (CheckEnlargeNum(mBig))
                        return;
                    m_Base.ID = f_NGen.NextLowNum();
                }
                if (m_who == 2)
                {
                    m_PW = (TPredicateItemPWork)(m_Base);

                    m_who = m_PW.Item1.Who();
                    if (m_who == 1)
                    {
                        TPredicateItemBig mBig = (TPredicateItemBig)(m_PW.Item1);
                        if (mBig.Rfc!=null && mBig.Rfc.Enlarge > 0)
                        {
                            if (!CheckEnlargeNum(mBig))
                                m_PW.Item1.ID = f_NGen.NextLowNum();
                        }
                        else
                            m_PW.Item1.ID = f_NGen.NextLowNum();

                    }

                    m_who = m_PW.Item2.Who();
                    if (m_who == 1)
                    {
                        TPredicateItemBig mBig = (TPredicateItemBig)(m_PW.Item2);
                        if (mBig.Rfc!=null && mBig.Rfc.Enlarge > 0)
                        {
                            if (!CheckEnlargeNum(mBig))
                                m_PW.Item2.ID = f_NGen.NextLowNum();
                        }
                        else
                            m_PW.Item2.ID = f_NGen.NextLowNum();
                    }


                    //        m_PW.Item2.ID = f_NGen.NextLowNum();
                }
                DoSetIDItemTFS(m_Base, AStack);
            }

        }
        void DoSetIDItemTFS(TPredicateItemBase ABase, TDynamicArray AStack)
        {
            int m_type;
            TPredicateItemPWork m_PW;
            if (ABase!=null)
            {
                m_type = ABase.Who();
                if (m_type == 0)
                    PushTFS((TPredicateItemTFS)(ABase), AStack);

                if (m_type == 1)
                    AStack.InsertToFirst(ABase);
                if (m_type == 2)
                {
                    m_PW = (TPredicateItemPWork)(ABase);
                    //1
                    m_type = m_PW.Item1.Who();
                    if (m_type == 0)
                        PushTFS((TPredicateItemTFS)(m_PW.Item1), AStack);

                    if (m_type == 1)
                        AStack.InsertToFirst(m_PW.Item1);

                    //2
                    m_type = m_PW.Item2.Who();
                    if (m_type == 0)
                        PushTFS((TPredicateItemTFS)(m_PW.Item2), AStack);
                    if (m_type == 1)
                        AStack.InsertToFirst(m_PW.Item2);

                }
            }
        }
        void PushTFS(TPredicateItemTFS ATFS, TDynamicArray AStack)
        {
            for (int i = 0; i <= ATFS.TFECount - 1; i++)
                if (ATFS.GetTFEItems(i).Big!=null)
                    AStack.InsertToFirst(ATFS.GetTFEItems(i).Big);
        }
        void DoProcess()
        {
            TPredicateItemBig Big;
            f_TryPath = true;
            TDynamicArray m_Stack = new TDynamicArray();
            m_Stack.InsertToFirst(f_PredicateStart);
            Big = (TPredicateItemBig)(m_Stack.Pop());
            while (Big!=null)
            {
                DoProcessItem(Big, m_Stack);
                if (!f_TryPath) break;
                Big = (TPredicateItemBig)(m_Stack.Pop());
            }
            m_Stack = null;
        }
        void DoProcessItemTFS(TPredicateItemBase ABase, TDynamicArray AStack)
        {
            TPredicateItemTFS m_Tfs;
            TPredicateItemTFE m_Tfe;
            if (ABase!=null)
            {
                int m_type = ABase.Who();
                if (m_type == 0)
                {
                    m_Tfs = (TPredicateItemTFS)(ABase);
                    for (int j = 0; j <= m_Tfs.TFECount - 1; j++)
                    {
                        m_Tfe = m_Tfs.GetTFEItems(j);
                        if (m_Tfe.Big!=null)
                            AStack.InsertToFirst(m_Tfe.Big);
                    }
                }
                if (m_type == 1)
                    AStack.InsertToFirst(ABase);
            }
        }
        void DoProcessItem(TPredicateItemBig AHead, TDynamicArray AStack)
        {
            int m_type, m_cnt, m_idx;
            TPredicateItemBase m_Base;
            TPredicateItemBase m_BaseItem1, m_BaseItem2;
            TPredicateItemPWork m_PWork, m_PW;
            TPredicateItemBig m_Big;
            TPredicateItemTFS m_Tfs;
            TPredicateItemTFE m_Tfe;
            TDynamicArray m_D = new TDynamicArray();
            TDynamicArray m_DTail = new TDynamicArray();
            TDynamicArray m_DLN = new TDynamicArray();

            m_cnt = AHead.Count;
            if (m_cnt == 1)
            {
                m_Base = AHead.GetItems(0);
                DoProcessItemTFS(m_Base, AStack);
                if (m_Base.Who() == 1)
                    ((TPredicateItemBig)(m_Base)).Print = true;

                ApplyStyle(AHead, m_Base);
            }
            if (m_cnt > 1)
            {
                for (int i = 0; i <= m_cnt - 1; i++)
                {
                    m_Base = AHead.GetItems(i);
                    m_type = m_Base.Who();
                    if (m_type == 1)
                    {
                        m_Big = (TPredicateItemBig)(m_Base);
                        if (m_Big.NumAlt > 0 || m_Big.Rfc.Cross)
                        {
                            m_DTail.Append(m_Big);
                            m_Big.Print = true;
                        }
                        else
                        {
                            m_DLN.Append(m_Base);
                            // m_Big.Print = m_Big.Rfc.CrossMain;
                        }

                    }
                    else
                        m_DLN.Append(m_Base);
                }
                if (m_DLN.Count == 1)
                {
                    m_Base = (TPredicateItemBase)(m_DLN.GetItems(0));
                    DoProcessItemTFS(m_Base, AStack);
                    ApplyStyle(AHead, m_Base);
                }
                else
                if (m_DLN.Count > 1)
                {
                    ApplyStyle(AHead, m_DLN);
                    m_BaseItem1 = (TPredicateItemBase)(m_DLN.GetItems(0));
                    m_BaseItem2 = (TPredicateItemBase)(m_DLN.GetItems(1));
                    DoProcessItemTFS(m_BaseItem1, AStack);
                    DoProcessItemTFS(m_BaseItem2, AStack);
                    for (int i = 2; i <= m_DLN.Count - 1; i++)
                        m_D.Append(m_DLN.GetItems(i));

                    AHead.DeleteItemToList(m_BaseItem1);
                    AHead.DeleteItemToList(m_BaseItem2);


                    m_BaseItem1 = EnvelopeToBig(m_BaseItem1);
                    m_BaseItem2 = EnvelopeToBig(m_BaseItem2);

                    m_PWork = new TPredicateItemPWork();
                    m_PWork.Item1 = m_BaseItem1;
                    m_PWork.Item2 = m_BaseItem2;
                    SwapNumAlt(m_PWork, m_BaseItem1);



                    while (m_D.Count >= 1)
                    {

                        m_Big = (TPredicateItemBig)(EnvelopeToBig(m_PWork));

                        m_BaseItem1 = m_Big;
                        m_BaseItem2 = (TPredicateItemBase)(m_D.Items[0]);
                        DoProcessItemTFS(m_BaseItem2, AStack);
                        AHead.DeleteItemToList(m_BaseItem2);

                        m_PW = new TPredicateItemPWork();
                        //m_PW.Envelope = true;
                        m_PW.Item1 = m_BaseItem1;
                        m_PW.Item2 = EnvelopeToBig(m_BaseItem2);
                        SwapNumAlt(m_PW, m_Big);
                        m_D.Delete(m_BaseItem2);
                        m_PWork = m_PW;

                    }

                    AHead.AddItem(m_PWork);
                }

                for (int i = 0; i <= m_DTail.Count - 1; i++)
                {
                    m_Base = (TPredicateItemBase)(m_DTail.GetItems(i));
                    AStack.InsertToFirst(m_Base);
                }

                m_DTail = null;
                m_DLN = null;
                m_D = null;
            }
        }

        void SwapNumAlt(TPredicateItemBase ADest, TPredicateItemBase ASource)
        {
            ADest.NumAlt = ASource.NumAlt;
            ASource.NumAlt = 0;
        }
        TPredicateItemBase EnvelopeToBig(TPredicateItemBase ASource)
        {
            TPredicateItemTFS mTfs;
            TPredicateItemBig nBig;
            int m_who = ASource.Who();
            if (m_who == 1)
                return ASource;
            if (m_who == 0)
            {
                mTfs = (TPredicateItemTFS)(ASource);
                if (mTfs.TFS.BaseWorkShape.TypeShape == 1)
                    return ASource;
            }
            nBig = new TPredicateItemBig();
            nBig.Envelope = true;
            nBig.AddItem(ASource);
            SwapNumAlt(nBig, ASource);
            return nBig;
        }
        bool CheckEnlargeNum(TPredicateItemBig ABig)
        {
            TPredicateItemBig Item;
            if (ABig.Rfc.Enlarge > 0)
            {
                for (int i = 0; i <= f_ListEnlarge.Count - 1; i++)
                {
                    Item = (TPredicateItemBig)(f_ListEnlarge.ElementAt(i));
                    if ((Item.Rfc.Enlarge == ABig.Rfc.Enlarge) && (Item.Rfc.EnlargeSetNum))
                    {
                        ABig.ID = Item.ID;
                        return true;
                    }
                }
                ABig.Rfc.EnlargeSetNum = true;
                f_ListEnlarge.Add(ABig);
            }
            return false;
        }

        TPredicatePathNode FillPathNode(TPredicateItemBig AHead, TPredicateItemBase AItem)
        {
            TPredicatePathNode N = null;
            int m_who = AItem.Who();
            bool valid = m_who == 0;
            if (m_who == 1)
                valid = ((TPredicateItemBig)(AItem)).ValidDescendant();
            if (valid)
            {
                N = f_BasePath.CreatePathNode(AHead);
                N.AddItem(AItem);
            }
            return N;
        }
        TPredicatePathNode FillPathNode(TPredicateItemBig AHead, TDynamicArray ADyn)
        {
            int m_who;
            bool valid = false;
            TPredicateItemBase Item;
            TPredicatePathNode N = null;
            TDynamicArray D = new TDynamicArray();
            for (int i = 0; i <= ADyn.Count - 1; i++)
            {
                Item = (TPredicateItemBase)(ADyn.GetItems(i));
                m_who = Item.Who();
                valid = m_who == 0;
                if (m_who == 1)
                    valid = ((TPredicateItemBig)(Item)).ValidDescendant();
                if (valid)
                    D.Append(Item);
            }

            if (D.Count > 0)
            {
                N = f_BasePath.CreatePathNode(AHead);
                for (int i = 0; i <= D.Count - 1; i++)
                    N.AddItem((TPredicateItemBase)(D.GetItems(i)));
            }
            D = null;
            return N;
        }
        bool CheckPath(TPredicateItemBig AHead, TPredicateItemBase AItem)
        {
            TPredicatePathNode N = FillPathNode(AHead, AItem);
            if (N != null && f_UsedPath.FindLikePathNode(N)==null)
                return false;
            return true;
        }
        bool CheckPath(TPredicateItemBig AHead, TDynamicArray ADyn)
        {
            TPredicatePathNode N = FillPathNode(AHead, ADyn);
            if (N != null && f_UsedPath.FindLikePathNode(N) ==null)
                return false;
            return true;
        }
        void SetPathNode(TPredicateItemBig AHead, TDynamicArray ADyn)
        {
            int mpos = -1;
            TPredicatePathNode L;
            TPredicatePathNodeItem NI;
            TPredicatePathNodeItem FI;
            TDynamicArray D = new TDynamicArray();
            TPredicatePathNode N = FillPathNode(AHead, ADyn);
            if (N!=null)
            {
                L = f_UsedPath.FindLikePathNode(N);
                if (L!=null)
                {
                    NI = L.FindIndexFirst(mpos);
                    while (NI!=null)
                    {
                        FI = N.FindByBlockID(NI.BlockID);
                        if (FI != null)
                            D.Append(FI.ItemBase);
                        NI = L.FindIndexNext(mpos);
                    }
                }
            }
            if (D.Count == ADyn.Count)
            {
                ADyn.Clear();
                SharedConst.CopyDynamicArray(D, ADyn, false);
            }
            D = null;
        }
        public void ApplyStyle(TPredicateItemBig AHead, TPredicateItemBase AItem)
        {
            if (f_PathStyle == 0)
                FillPathNode(AHead, AItem);
            if (f_PathStyle == 1)
                f_TryPath = CheckPath(AHead, AItem);
        }
        public void ApplyStyle(TPredicateItemBig AHead, TDynamicArray ADyn)
        {
            if (f_PathStyle == 0)
                FillPathNode(AHead, ADyn);
            if (f_PathStyle == 1)
                f_TryPath = CheckPath(AHead, ADyn);
            if (f_PathStyle == 2)
                SetPathNode(AHead, ADyn);
        }
        /*        public:
                 TPredicateTFSConvertor();
                ~TPredicateTFSConvertor();*/
        public void CopyTree(TAlternativeParserItemBig AHead)
        {
            TPredicateItemBig Big;
            FreeHead();
            f_PredicateStart = NewBig(AHead);
            TDynamicArray m_Stack = new TDynamicArray();
            //0202  m_Stack.InsertToFirst(f_PredicateStart);
            //0202   Big = (TPredicateItemBig)(m_Stack.Pop());
            Big = f_PredicateStart;
            while (Big!=null)
            {
                DoCopyTree(Big, m_Stack);
                Big = (TPredicateItemBig)(m_Stack.Pop());
            }
            m_Stack = null;
        }
        public void Process(TPredicatePathItem ABase, TPredicatePathItem AUsed)
        {
            f_BasePath = ABase;
            f_UsedPath = AUsed;
            f_BasePath.Clear();

            DoProcess();
            DoSetID();
        }
        public TPredicateItemBig Head
        {
            get { return f_PredicateStart; }
        }
        public int PathStyle
        {
            set { f_PathStyle = value; }
            get { return f_PathStyle; }
        }
        public bool TryPath
        {
            get { return f_TryPath; }
        }
    }
}
