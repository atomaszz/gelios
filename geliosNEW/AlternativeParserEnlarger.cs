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
        int GetCount()
        {
            get { return GetCount(); }
        }
        /*   TAlternativeParserGrpItemTFS* __fastcall GetItems(int AIndex);
           public:
            TAlternativeParserEnlargerItem();
           ~TAlternativeParserEnlargerItem();
           int Pos(TAlternativeParserEnlargerStep* AStep);*/
        public void AddTfsItem(TAlternativeParserGrpItemTFS AGrpTfs)
        {
            if (f_List.IndexOf(AGrpTfs) < 0)
                f_List.Add(AGrpTfs);
        }
        /*      void DeleteTfsItem(TAlternativeParserGrpItemTFS* AGrpTfs);
              void CascadeDelete(TDynamicArray* AMass);
              int FillStep(TAlternativeParserEnlargerStep* AStep, int APos, int ACount);
              int Find(TAlternativeParserGrpItemTFS* AGrpTfs);*/
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

   /*    __property TAlternativeParserGrpItemTFS* Items[int AIndex] = { read = GetItems };*/

    }
    class TAlternativeParserEnlargerStep
    {
        List<object> f_List;
        public int GetCount()
        {
            return f_List.Count;
        }
       /*   TAlternativeParserGrpItemTFS* __fastcall GetItems(int AIndex);
          public:
           TAlternativeParserEnlargerStep();
          ~TAlternativeParserEnlargerStep();
          void Clear();
          void AddItem(TAlternativeParserGrpItemTFS* AGrpTfs);
          //     __property TAlternativeParserEnlargerItem* Parent = {read = f_Parent, write = f_Parent};
          __property int Count = { read = GetCount };
          __property TAlternativeParserGrpItemTFS* Items[int AIndex] = {read = GetItems*/
    }
    class TAlternativeParserEnlargerTrashItem
    {
        int f_ID;
        int f_Length;
        TAlternativeParserEnlargerItem f_Owner;
        TAlternativeParserGrpItemTFS f_Pos;
        /*   TAlternativeParserEnlargerTrashItem();*/
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
        /*     public:
              TAlternativeParserEnlargerTrash();
             ~TAlternativeParserEnlargerTrash();
             TAlternativeParserEnlargerTrashItem* NewTrashItem();*/
        public void Clear()
        {
            FreeList();
        }
        public int Count
        {
            get { return GetCount();  }
        }
            
        /*  __property TAlternativeParserEnlargerTrashItem* Items[int AIndex] = {read = GetItems*/
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
                        A = Items[j];
                        MStep.Clear();
                        index = 0;
                        r_f = A.FillStep(MStep, index, i);
                        DM.Append(A);
                        while (r_f > 0)
                        {
                            m_id = NextTrashItemID();
                            for (int k = 0; k <= cnt - 1; k++)
                            {
                                B = Items[k];
                                if (!DM.Find(B))
                                {
                                    r_pos = B.Pos(MStep);
                                    if (r_pos >= 0)
                                    {
                                        CreateTrashItem(A.Items[index], i, A, m_id);
                                        CreateTrashItem(B.Items[r_pos], i, B, m_id);
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
            TPartialDecisionItem Item = new TPartialDecisionItem(this);
            Item.InitDecision(APTItem);
            f_List.Add(Item);
            return Item;
        }
        TAlternativeParserEnlargerItem FindMax()
        {
            TAlternativeParserEnlargerItem Res = null;
            int a, b = 0;
            for (int i = 0; i <= Count - 1; i++)
            {
                a = Items[i]->Count;
                if (a > b)
                {
                    b = a;
                    Res = Items[i];
                }
            }
            return Res;
        }
  /*      void Restruct();
               bool IsEmptyTrash();*/
        void ClearTrash()
        {
            f_Trash.Clear();
        }
        /*   void CreateTrashItem(TAlternativeParserGrpItemTFS* APos, int ALength,
             TAlternativeParserEnlargerItem* AOwner, int AID);*/
        int  GetCount()
        {
            return f_List.Count;
        }
        /*      TAlternativeParserEnlargerItem* __fastcall GetItems(int AIndex);
              public:
               TAlternativeParserEnlarger();
              ~TAlternativeParserEnlarger();*/
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
        /*       __property int Count = { read = GetCount };
               __property TAlternativeParserEnlargerItem* Items[int AIndex] = {read = GetItems*/
    }
}
