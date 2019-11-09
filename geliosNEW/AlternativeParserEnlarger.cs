using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAlternativeParserEnlargerBase
    {
        TAlternativeParserEnlargerItem f_Parent;
        /*     public:
          TAlternativeParserEnlargerBase() {; }
             virtual ~TAlternativeParserEnlargerBase() {; }
             virtual int Who() { return -1; }*/
    }
    class TAlternativeParserEnlargerTFS : TAlternativeParserEnlargerBase
    {
        /*   int Who();
          ~TAlternativeParserEnlargerTFS() {; }*/
    }
    class TAlternativeParserEnlargerBig : TAlternativeParserEnlargerBase
    {
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
      /*  int __fastcall GetCount();
        TAlternativeParserEnlargerTFS* __fastcall GetItems(int AIndex);
        public:
             int Who();
        TAlternativeParserEnlargerBig();
        ~TAlternativeParserEnlargerBig();
        void AddItem(TAlternativeParserEnlargerTFS* ATfs);
        __property int Count = { read = GetCount };
        __property TAlternativeParserEnlargerTFS* Items[int AIndex] = { read = GetItems };*/
    }
    class TAlternativeParserEnlargerItem
    {
        List<object> f_List;
        bool f_Basis;
    TAlternativeParserGrpCrossItem f_ParentMain;
    TAlternativeParserGrpCrossItemOut f_Parent;
        public int GetCount()
        {
            return f_List.Count;
        }
        public TAlternativeParserGrpItemTFS  GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserGrpItemTFS)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        public TAlternativeParserEnlargerItem()
        {
            f_List = new List<object>();
            f_Basis = false;
            f_Parent = null;
            f_ParentMain = null;
        }
        ~TAlternativeParserEnlargerItem() {}
        public int Pos(TAlternativeParserEnlargerStep AStep)
        {
            int plen = AStep.Count;
            int slen = Count;
            int pindx;
            int cmppos;
            int endpos;
            for (endpos = plen - 1; endpos < slen;)
            {
                for (cmppos = endpos, pindx = (plen - 1); pindx >= 0; cmppos--, pindx--)
                    if (GetItems(cmppos).TFS != AStep.GetItems(pindx).TFS)
                    {
                        endpos += 1;
                        break;
                    }
                if (pindx < 0)
                    return (endpos - (plen - 1));
            }
            return -1;
        }
        public void AddTfsItem(TAlternativeParserGrpItemTFS AGrpTfs)
        {
            if (f_List.IndexOf(AGrpTfs) < 0)
                f_List.Add(AGrpTfs);
        }
        void DeleteTfsItem(TAlternativeParserGrpItemTFS AGrpTfs)
        {
            int inn = f_List.IndexOf(AGrpTfs);
            if (inn >= 0)
                f_List.RemoveAt(inn);
        }
        public void CascadeDelete(TDynamicArray AMass)
        {
            for (int i = 0; i <= AMass.Count - 1; i++)
                DeleteTfsItem((TAlternativeParserGrpItemTFS)(AMass.GetItems(i)));
        }
        public int FillStep(TAlternativeParserEnlargerStep AStep, int APos, int ACount)
        {
            int res = -1;
            int d = Count;
            if ((d - APos - ACount + 1) > 0)
            {
                for (res = APos; res <= APos + ACount - 1; res++)
                    AStep.AddItem(GetItems(res));
            }
            return res;
        }
        public int Find(TAlternativeParserGrpItemTFS AGrpTfs)
        {
            return f_List.IndexOf(AGrpTfs);
        }
        public bool Basis
        {
            set { f_Basis = value; }
            get { return f_Basis; }
        }
        public TAlternativeParserGrpCrossItemOut Parent
        {
            set { f_Parent = value; }
            get { return f_Parent; }
        }
        public TAlternativeParserGrpCrossItem ParentMain
        {
            set { f_ParentMain = value; }
            get { return f_ParentMain; }
        }
        public int Count
        {
            get { return GetCount(); }
        }
    }
    class TAlternativeParserEnlargerStep
    {
        List<object> f_List;
        public int GetCount()
        {
            return f_List.Count;
        }
        public TAlternativeParserGrpItemTFS  GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserGrpItemTFS)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        public TAlternativeParserEnlargerStep()
        {
            f_List = new List<object>();
        }
        ~TAlternativeParserEnlargerStep() { }
        public  void Clear()
        {
            f_List.Clear();
        }
        public void AddItem(TAlternativeParserGrpItemTFS AGrpTfs)
        {
            if (f_List.IndexOf(AGrpTfs) < 0)
                f_List.Add(AGrpTfs);
        }
  /*      public TAlternativeParserEnlargerItem Parent
        {
            set { f_Parent = value;  }
            get { return f_Parent; }
        }*/
        public int Count
        {
            get { return GetCount();  }
        }    
    }
    class TAlternativeParserEnlargerTrashItem
    {
        int f_ID;
        int f_Length;
        TAlternativeParserEnlargerItem f_Owner;
        TAlternativeParserGrpItemTFS f_Pos;
        public TAlternativeParserEnlargerTrashItem()
        {
            f_ID = 0;
            f_Length = 0;
            f_Pos = null;
            f_Owner = null;
        }
        public int Length
        {
            set { f_Length = value; }
            get { return f_Length; }
        }
        public TAlternativeParserGrpItemTFS Pos
        {
            set { f_Pos = value; }
            get { return f_Pos; }
        }
        public TAlternativeParserEnlargerItem Owner
        {
            set { f_Owner = value; }
            get { return f_Owner; }
        }
        public int ID
        {
            set { f_ID = value; }
            get { return f_ID; }
        }
    }
    class TAlternativeParserEnlargerTrash
    {
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
        int  GetCount()
        {
            return f_List.Count();
        }
        public TAlternativeParserEnlargerTrashItem GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserEnlargerTrashItem)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        public TAlternativeParserEnlargerTrash()
        {
            f_List = new List<object>();
        }
        ~TAlternativeParserEnlargerTrash() { }
        public TAlternativeParserEnlargerTrashItem NewTrashItem()
        {
            TAlternativeParserEnlargerTrashItem Item = new TAlternativeParserEnlargerTrashItem();
            f_List.Add(Item);
            return Item;
        }
        public void Clear()
        {
            FreeList();
        }
        public int Count
        {
            get { return GetCount();  }
        }         
    }
    class TAlternativeParserEnlarger
    {
        List<object> f_List;
        TAlternativeParserEnlargerTrash f_Trash;
        void FreeList()
        {
            f_List.Clear();
        }
        void DoFill(TAlternativeParserGrpCrossItem AItem)
        {
            int m_who;
            TAlternativeParserGrpItemTFS mTfs;
            TAlternativeParserGrpItemBase mBase;
            TAlternativeParserGrpCrossItemOut mOut;
            TAlternativeParserEnlargerItem Item = GetNew(AItem);
            Item.Basis = true;
            for (int i = 0; i <= AItem.CountBasis - 1; i++)
                Item.AddTfsItem((TAlternativeParserGrpItemTFS)(AItem.GetItemsBasis(i)));

            for (int i = 0; i <= AItem.CountOut - 1; i++)
            {
                mOut = AItem.GetItemsOut(i);
                Item = GetNew(AItem);
                Item.Parent = mOut;
                for (int j = 0; j <= mOut.Count - 1; j++)
                {
                    mBase = mOut.GetItems(j);
                    m_who = mBase.Who();
                    if (m_who == 0)
                    {
                        mTfs = (TAlternativeParserGrpItemTFS)(mBase);
                        Item.AddTfsItem(mTfs);
                    }
                }
            }
        }
        void DoEnlarge()
        {
            int m, cnt, index, r_f, r_pos, m_id;
            TAlternativeParserEnlargerStep MStep;
            TAlternativeParserEnlargerItem A, B;
            TDynamicArray DM = new TDynamicArray();
            MStep = new TAlternativeParserEnlargerStep();
            int c_trash;
            bool go = true;
            while (go)
            {
                go = false;
                m = FindMax().Count;
                cnt = Count;
                c_trash = 0;
                for (int i = m; i >= 1; i--)
                {
                    DM.Clear();
                    for (int j = 0; j <= cnt - 1; j++)
                    {
                        A = GetItems(j);
                        MStep.Clear();
                        index = 0;
                        r_f = A.FillStep(MStep, index, i);
                        DM.Append(A);
                        while (r_f > 0)
                        {
                            m_id = SharedConst.NextTrashItemID();
                            for (int k = 0; k <= cnt - 1; k++)
                            {
                                B = GetItems(k);
                                if (DM.Find(B)==null)
                                {
                                    r_pos = B.Pos(MStep);
                                    if (r_pos >= 0)
                                    {
                                        CreateTrashItem(A.GetItems(index), i, A, m_id);
                                        CreateTrashItem(B.GetItems(r_pos), i, B, m_id);
                                        c_trash++;
                                    }
                                }
                            }
                            MStep.Clear();
                            r_f = A.FillStep(MStep, ++index, i);
                        }
                    }
                    if (c_trash>0)
                    {
                        Restruct();
                        go = true;
                        break;
                    }
                }
            }
            MStep = null;
            DM = null;
        }
        TAlternativeParserEnlargerItem GetNew(TAlternativeParserGrpCrossItem AParentMain)
        {
            TAlternativeParserEnlargerItem Item = new TAlternativeParserEnlargerItem();
            Item.ParentMain = AParentMain;
            f_List.Add(Item);
            return Item;
        }
        TAlternativeParserEnlargerItem FindMax()
        {
            TAlternativeParserEnlargerItem Res = null;
            int a, b = 0;
            for (int i = 0; i <= Count - 1; i++)
            {
                a = GetItems(i).Count;
                if (a > b)
                {
                    b = a;
                    Res = GetItems(i);
                }
            }
            return Res;
        }
        public void Restruct()
        {
            int mpos;
            TAlternativeParserEnlargerTrashItem TI;
            TDynamicArray mDel = new TDynamicArray();
            for (int i = 0; i <= f_Trash.Count - 1; i++)
            {
                TI = f_Trash.GetItems(i);
                mpos = TI.Owner.Find(TI.Pos);
                if (mpos >= 0)
                {
                    mDel.Clear();
                    for (int j = mpos; j <= mpos + TI.Length - 1; j++)
                        mDel.Append(TI.Owner.GetItems(j));
                    TI.Owner.CascadeDelete(mDel);
                }
            }
            mDel = null;
        }
        bool IsEmptyTrash()
        {
            return (f_Trash.Count == 0);
        }
        void ClearTrash()
        {
            f_Trash.Clear();
        }
        void CreateTrashItem(TAlternativeParserGrpItemTFS APos, int ALength,
             TAlternativeParserEnlargerItem AOwner, int AID)
        {
            TAlternativeParserEnlargerTrashItem Item = f_Trash.NewTrashItem();
            Item.Pos = APos;
            Item.Length = ALength;
            Item.Owner = AOwner;
            Item.ID = AID;
        }
        int  GetCount()
        {
            return f_List.Count;
        }
        TAlternativeParserEnlargerItem  GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserEnlargerItem)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        public TAlternativeParserEnlarger()
        {
            f_List = new List<object>();
            f_Trash = new TAlternativeParserEnlargerTrash();
        }
        ~TAlternativeParserEnlarger() {}
        public void Init()
        {
            ClearTrash();
            FreeList();//26.08.2007
        }
        public void Enlarge(TAlternativeParserGrpCrossItem AItem)
        {
            DoFill(AItem);
            DoEnlarge();
        }
        public void FindTrashItem(TAlternativeParserGrpCrossItem AOwner, TDynamicArray AOut)
        {
            TAlternativeParserEnlargerTrashItem Item;
            AOut.Clear();
            for (int i = 0; i <= f_Trash.Count - 1; i++)
            {
                Item = f_Trash.GetItems(i);
                if (Item.Owner.ParentMain == AOwner)
                    AOut.Append(Item);
            }
        }
        public int Count
        {
            get { return GetCount();  }
        }
    }
}
