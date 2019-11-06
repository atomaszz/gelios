using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geliosNEW
{
    public class TAlternativeParserGrpItemBase
    {
        ~TAlternativeParserGrpItemBase() { return; }
        public virtual int Who() { return -1; }
    }

    public class TAlternativeParserGrpItemTFS : TAlternativeParserGrpItemBase
    {
      TTreeListTFS f_TFS;
        /*  public:
            TAlternativeParserGrpItemTFS();
          ~TAlternativeParserGrpItemTFS() { return; }
          int Who() { return 0; }*/
        public TTreeListTFS TFS
        {
            set { f_TFS = value; }
            get { return f_TFS; }
        }
    }
    public class TAlternativeParserGrpItemList : TAlternativeParserGrpItemBase
    {
        bool f_CheckAgregate;
        bool f_CheckCross;
        TAlternativeParserGrpItemList f_Agregate;
        TAlternateTreeList f_Alternative;
        List<object> f_List;
        /*void FreeList();*/
        int  GetCount()
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
        /*
void __fastcall SetAgregate(TAlternativeParserGrpItemList* AValue);
public:
  TAlternativeParserGrpItemList();
~TAlternativeParserGrpItemList();*/
        public TAlternativeParserGrpItemTFS FindItemTfs(TTreeListTFS ATFS)
        {
            TAlternativeParserGrpItemTFS Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemTFS)(f_List.ElementAt(i));
                if (Item.TFS == ATFS)
                    return Item;
            }
            return null;
        }
        public override int Who() { return 1; }
        public void AddTfs(TTreeListTFS ATFS)
        {
            if (FindItemTfs(ATFS)==null)
            {
                TAlternativeParserGrpItemTFS T = new TAlternativeParserGrpItemTFS();
                T.TFS = ATFS;
                f_List.Add(T);
            }
        }
        public int Count
        {
            get { return GetCount(); }
        }
     /*   public TAlternativeParserGrpItemTFS
            Items[int AIndex] = { read = GetItems };*/

        public bool CheckAgregate
        {
            set { f_CheckAgregate = value; }
            get { return f_CheckAgregate; }
        }
        public bool CheckCross
        {
            set { f_CheckCross = value; }
            get { return f_CheckCross; }
        }
        public TAlternativeParserGrpItemList Agregate
        {
            set { f_Agregate = value; }
            get { return f_Agregate; }
        }
        public  TAlternateTreeList Alternative 
        {
            set { f_Alternative = value;  }
            get { return f_Alternative;  }
        }
    }
    class TAlternativeParserGrpCrossItemOut
    {
     List<object> f_List;
        int  GetCount()
        {
            return f_List.Count;
        }
        public TAlternativeParserGrpItemList  GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserGrpItemList)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        /* public:
               TAlternativeParserGrpCrossItemOut();
              ~TAlternativeParserGrpCrossItemOut();*/
        public void AddItem(TAlternativeParserGrpItemBase AItem)
        {
            if (f_List.IndexOf(AItem) < 0)
                f_List.Add(AItem);
        }
        public void ReplaceToEnlarge(TAlternativeParserGrpCrossItemEnlarge AE)
        {
            int index = f_List.IndexOf(AE.Pos);
            f_List.Insert(index, AE);
            for (int i = 0; i <= AE.Count - 1; i++)
            {
                index = f_List.IndexOf(AE.GetItems(i));
                if (index >= 0)
                    f_List.RemoveAt(index);
            }
        }
        public int Count
        {
            get { return GetCount(); }
        }
      /*     __property TAlternativeParserGrpItemBase* Items[int AIndex] = {read = GetItems
       };*/
    }
    class TAlternativeParserGrpCrossItem : TAlternativeParserGrpItemBase
    {
        List<object> f_List;
        List<object> f_Basis;
        List<object> f_Out;
        /*void FreeOut();*/
        void DoCreateList()
        {
            TAlternativeParserGrpCrossItemOut mOut;
            for (int i = 0; i <= Count - 1; i++)
            {
                mOut = GetNewCrossOut();
                DoCreateListItem(GetItems(i), mOut);
            }
        }

        void DoCreateBasis()
        {
            TGlsBinaryTree mTree;
            TAlternativeParserGrpItemTFS Tfs;
            TAlternativeParserGrpItemList Item;
            TDynamicArray D = new TDynamicArray();
            SharedConst.lc = new List<object>();
            f_Basis.Clear();
            for (int i = 0; i <= Count - 1; i++)
            {
                Item = GetItems(i);
                for (int j = 0; j <= Item.Count - 1; j++)
                {
                    Tfs = Item.GetItems(j);
                    if (D.Find(Tfs.TFS) == null)
                        MessageBox.Show("ДЕЛАЮ на УГАД, эту строчку НУЖНО ДЕБАЖИТЬ");
                     //   D.AppendInteger((int)Tfs, Tfs.TFS); // ХЗ ДЕЛАЮ на УГАД, эту строчку НУЖНО ДЕБАЖИТЬ
                }
            }
            mTree = new TGlsBinaryTree(SharedConst.APC_CompareNode);
            for (int i = 0; i <= D.Count - 1; i++)
            {
                object tmp = D.GetPosition(i).Int_Value;
                Tfs = (TAlternativeParserGrpItemTFS)tmp;
                mTree.insert(Tfs);
            }
            mTree.inorder(SharedConst.APC_Inorder);
            for (int i = 0; i <= SharedConst.lc.Count - 1; i++)
            {
                Tfs = (TAlternativeParserGrpItemTFS)(SharedConst.lc.ElementAt(i));
                f_Basis.Add(Tfs);
            }
            mTree = null;
            D = null;
            SharedConst.lc = null;
        }
        void DoCreateListItem(TAlternativeParserGrpItemList AItem, TAlternativeParserGrpCrossItemOut ANew)
        {
            int i;
            bool f_s = false;
            TAlternativeParserGrpItemBase Base;
            TAlternativeParserGrpItemTFS Tfs;
            TBaseWorkShape WS, WE;
            WS = AItem.Alternative.NodeStart.WorkShape;
            WE = AItem.Alternative.NodeEnd.WorkShape;
            for (i = 0; i <= CountBasis - 1; i++)
            {
                Base = GetItemsBasis(i);
                if (Base.Who()<=0)
                {
                    Tfs = (TAlternativeParserGrpItemTFS)(Base);
                    if (Tfs.TFS.BaseWorkShape == WS)
                    {
                        f_s = true;
                        break;
                    }
                    ANew.AddItem(Tfs);
                }
            }
            if (f_s)
                ANew.AddItem(AItem);
            for (; i <= CountBasis - 1; i++)
            {
                Base = GetItemsBasis(i);
                if (Base.Who()<=0)
                {
                    Tfs = (TAlternativeParserGrpItemTFS)(Base);
                    if (Tfs.TFS.BaseWorkShape == WE)
                        break;
                }
            }
            for (++i; i <= CountBasis - 1; i++)
                ANew.AddItem(GetItemsBasis(i));
        }
        int GetCount()
        {
            return f_List.Count;
        }
        public TAlternativeParserGrpItemList  GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserGrpItemList)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        int  GetCountBasis()
         {
             return f_List.Count;
         }

         public TAlternativeParserGrpItemBase GetItemsBasis(int AIndex)
         {
             if (AIndex >= 0 && AIndex <= f_Basis.Count - 1)
                 return (TAlternativeParserGrpItemBase)(f_Basis.ElementAt(AIndex));
             else
                 return null;
         }

         int GetCountOut()
         {
             return f_Out.Count;
         }
         public TAlternativeParserGrpCrossItemOut GetItemsOut(int AIndex)
         {
             if (AIndex >= 0 && AIndex <= f_Out.Count - 1)
                 return (TAlternativeParserGrpCrossItemOut)(f_Out.ElementAt(AIndex));
             else
                 return null;
         }
        TAlternativeParserGrpCrossItemOut GetNewCrossOut()
        {
            TAlternativeParserGrpCrossItemOut Item = new TAlternativeParserGrpCrossItemOut();
            f_Out.Add(Item);
            return Item;
        }
        void ReplaceToEnlarge(TAlternativeParserGrpCrossItemEnlarge AE)
        {
            int index = f_Basis.IndexOf(AE.Pos);
            f_Basis.Insert(index, AE);
            for (int i = 0; i <= AE.Count - 1; i++)
            {
                index = f_Basis.IndexOf(AE.GetItems(i));
                if (index >= 0)
                    f_Basis.RemoveAt(index);
            }
        }
   /*     public:
                   TAlternativeParserGrpCrossItem();
              ~TAlternativeParserGrpCrossItem();*/
        public override int Who() { return 2; }
        public void AddItem(TAlternativeParserGrpItemList AGList)
        {
            if (f_List.IndexOf(AGList) < 0)
                f_List.Add(AGList);
        }
        public void CreateBasis()
        {
            DoCreateBasis();
        }
        public void CreateListOut()
        {
            DoCreateList();
        }

        public TAlternativeParserGrpCrossItemEnlarge FindEnlarge(TAlternativeParserGrpItemTFS ATfs)
        {
            TAlternativeParserGrpItemBase Base;
            TAlternativeParserGrpCrossItemOut Outs;
            TAlternativeParserGrpCrossItemEnlarge Enl;
            for (int i = 0; i <= CountBasis - 1; i++)
            {
                Base = GetItemsBasis(i);
                if (Base.Who() == 3)
                {
                    Enl = (TAlternativeParserGrpCrossItemEnlarge)(Base);
                    if (Enl.Pos == ATfs)
                        return Enl;
                }
            }

            for (int i = 0; i <= CountOut - 1; i++)
            {
                Outs = GetItemsOut(i);
                for (int j = 0; j <= Outs.Count - 1; j++)
                {
                    Base = Outs.GetItems(j);
                    if (Base.Who() == 3)
                    {
                        Enl = (TAlternativeParserGrpCrossItemEnlarge)(Base);
                        if (Enl.Pos == ATfs)
                            return Enl;
                    }
                }
            }
            return null;
        }
        TAlternativeParserGrpCrossItemEnlarge RestructEnlarge(TAlternativeParserEnlargerTrashItem ATrash)
        {
            TAlternativeParserGrpItemTFS  Tfs;
            TAlternativeParserGrpItemBase  Base;
            TAlternativeParserGrpCrossItemOut  Outs;
            TAlternativeParserGrpCrossItemEnlarge  Enl = null;
            for (int i = 0; i <= CountBasis - 1; i++)
            {
                Base = GetItemsBasis(i);
                if ((Base.Who() == 0) && (Base == ATrash.Pos))
                {
                    Enl = new TAlternativeParserGrpCrossItemEnlarge();
                    Enl.ID = ATrash.ID;
                    for (int j = i; j <= i + ATrash.Length - 1; j++)
                        Enl.AddGRPTfs((TAlternativeParserGrpItemTFS)(GetItemsBasis(j)));
                    ReplaceToEnlarge(Enl);
                }

            }

            for (int i = 0; i <= CountOut - 1; i++)
            {
                Outs = GetItemsOut(i);
                for (int j = 0; j <= Outs.Count - 1; j++)
                {
                    Base = Outs.GetItems(j);
                    if ((Base.Who() == 0) && (Base == ATrash.Pos))
                    {
                        if (Enl==null)
                        {
                            Enl = new TAlternativeParserGrpCrossItemEnlarge();
                            Enl.ID = ATrash.ID;
                            for (int k = j; k <= j + ATrash.Length - 1; k++)
                            {
                                object tmp = Outs.GetItems(k);
                                Enl.AddGRPTfs((TAlternativeParserGrpItemTFS)tmp);
                            }
                        }
                        Outs.ReplaceToEnlarge(Enl);
                    }
                }
            }
            return Enl;
        }


        public int Count
        {
            get { return GetCount(); }
        }
   /*           __property TAlternativeParserGrpItemList* Items[int AIndex] = { read = GetItems };*/
        public int CountBasis
        {
            get { return GetCountBasis(); }
        }
       /*        __property TAlternativeParserGrpItemBase* ItemsBasis[int AIndex] = { read = GetItemsBasis };*/


        public int CountOut
        {
            get  { return GetCountOut(); }
        }
            /*   __property TAlternativeParserGrpCrossItemOut* ItemsOut[int AIndex] = { read = GetItemsOut };*/
    }

    public class TAlternativeParserGrpCrossItemEnlarge : TAlternativeParserGrpItemBase
    {
        int f_ID;
        List<object> f_List;
        /*   void FreeList();*/
        int  GetCount()
        {
            return f_List.Count;
        }

        public TAlternativeParserGrpItemTFS GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserGrpItemTFS)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        TAlternativeParserGrpItemTFS GetPos()
        {
            return GetItems(0);
        }

        /*       public:
                     TAlternativeParserGrpCrossItemEnlarge();
               ~TAlternativeParserGrpCrossItemEnlarge();*/
        public override int Who() { return 3; }
        public void AddGRPTfs(TAlternativeParserGrpItemTFS ATFS)
        {
            f_List.Add(ATFS);
        }
        public int Count
        {
            get { return GetCount(); }
        }
        /*       __property TAlternativeParserGrpItemTFS* Items[int AIndex] = { read = GetItems };*/
        public TAlternativeParserGrpItemTFS Pos
        {
            get { return GetPos(); }
        }
        public int ID
        {
            set { f_ID = value; }
            get { return f_ID; }
        }
    }
    class TAlternativeParserGrpCross
    {
     List<object> f_List;
        /*  void FreeList();*/
        int GetCount()
        {
            return f_List.Count;
        }
        TAlternativeParserGrpCrossItem  GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternativeParserGrpCrossItem)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        /*  public:
           TAlternativeParserGrpCross();
          ~TAlternativeParserGrpCross();*/
        public TAlternativeParserGrpCrossItem FindToCross(TAlternativeParserGrpItemList AItem)
        {
            {
                TAlternativeParserGrpItemList T;
                TAlternativeParserGrpCrossItem Item;
                for (int i = 0; i <= Count - 1; i++)
                {
                    Item = GetItems(i);
                    for (int j = 0; j <= Item.Count - 1; j++)
                    {
                        T = Item.GetItems(j);
                        if (T == AItem)
                            return Item;
                    }
                }
                return null;
            }
        }
        public void AddItem(TAlternativeParserGrpItemList A, TAlternativeParserGrpItemList B)
        {
            TAlternativeParserGrpItemList T;
            TAlternativeParserGrpCrossItem Item;
            for (int i = 0; i <= Count - 1; i++)
            {
                Item = GetItems(i);
                for (int j = 0; j <= Item.Count - 1; j++)
                {
                    T = Item.GetItems(j);
                    if ((A == T) || (B == T))
                    {
                        Item.AddItem(A);
                        Item.AddItem(B);
                        return;
                    }
                }
            }
            Item = new TAlternativeParserGrpCrossItem();
            Item.AddItem(A);
            Item.AddItem(B);
            f_List.Add(Item);
        }
        public int Count
        {
            get { return GetCount(); }
        }
       /*       __property TAlternativeParserGrpCrossItem* Items[int AIndex] = {read = GetItems*/
    }
    class TAlternativeParserGrp
    {
        int f_FindListPos;
        int f_FindListPosNoCross;
        List<object> f_List;
        List<object> f_ListOut;
        List<object> f_ListEnlarge;
        TAlternativeParserGrpCross f_Cross;
        TAlternativeParserEnlarger f_Enlarger;
        void FreeList()
        {
            f_List.Clear();
        }
        void FreeListOut()
        {
            f_ListOut.Clear();
        }
        void FreeListEnlarge()
        {
            f_ListEnlarge.Clear();
        }
        public TAlternativeParserGrpItemList FindFirstList()
        {
            TAlternativeParserGrpItemBase Item;
            TAlternativeParserGrpItemList Res;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(f_List.ElementAt(i));
                if (Item.Who() == 1)
                {
                    Res = (TAlternativeParserGrpItemList)(Item);
                    if (!Res.CheckAgregate)
                    {
                        f_FindListPos = i;
                        return Res;
                    }
                }
            }
            f_FindListPos = 0;
            return null;
        }
        TAlternativeParserGrpItemList FindNextList(TAlternativeParserGrpItemList AByPass)
        {
            TAlternativeParserGrpItemBase Item;
            TAlternativeParserGrpItemList Res;
            ++f_FindListPos;
            for (int i = f_FindListPos; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(f_List.ElementAt(i));
                if (Item.Who() == 1)
                {
                    Res = (TAlternativeParserGrpItemList)(Item);
                    if (Res != AByPass)
                    {
                        f_FindListPos = i;
                        return Res;
                    }
                }
            }
            return null;
        }
        TAlternativeParserGrpItemList FindFirstListNoCross()
        {
            TAlternativeParserGrpItemBase Item;
            TAlternativeParserGrpItemList Res;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(f_List.ElementAt(i));
                if (Item.Who() == 1)
                {
                    Res = (TAlternativeParserGrpItemList)(Item);
                    if (!Res.CheckCross)
                    {
                        f_FindListPosNoCross = i;
                        return Res;
                    }
                }
            }
            f_FindListPosNoCross = 0;
            return null;
        }
        TAlternativeParserGrpItemList FindNextListNoCross(TAlternativeParserGrpItemList AByPass)
        {
            TAlternativeParserGrpItemBase Item;
            TAlternativeParserGrpItemList Res;
            ++f_FindListPosNoCross;
            for (int i = f_FindListPosNoCross; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(f_List.ElementAt(i));
                if (Item.Who() == 1)
                {
                    Res = (TAlternativeParserGrpItemList)(Item);
                    if (Res != AByPass)
                    {
                        f_FindListPosNoCross = i;
                        return Res;
                    }
                }
            }
            return null;
        }

        int  GetCountOUT()
        {
            return f_ListOut.Count;
        }
        public TAlternativeParserGrpItemBase  GetItemsOUT(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_ListOut.Count - 1)
                return (TAlternativeParserGrpItemBase)(f_ListOut.ElementAt(AIndex));
            else
                return null;
        }
        TAlternativeParserGrpItemTFS FindItemTfs(TTreeListTFS ATFS)
        {
            TAlternativeParserGrpItemTFS Temp;
            TAlternativeParserGrpItemBase Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(f_List.ElementAt(i));
                int m_who = Item.Who();
                if (m_who<=0)
                {
                    Temp = (TAlternativeParserGrpItemTFS)(Item);
                    if (Temp.TFS == ATFS)
                        return Temp;
                }
                if (m_who == 1)
                {
                    Temp = ((TAlternativeParserGrpItemList)(Item)).FindItemTfs(ATFS);
                    if (Temp!=null)
                        return Temp;
                }
            }
            return null;
        }
        int CompareAlternate(TAlternativeParserGrpItemList AL1,
                    TAlternativeParserGrpItemList AL2, ref TAlternativeParserGrpItemList AMax,
                    ref TAlternativeParserGrpItemList AMin)
        {
            int m_d1, m_d2, m_dMin;
            int m_find = 0;
            TTreeListTFS m_TFS;
            TAlternativeParserGrpItemList m_aMin, m_aMax;
            m_d1 = AL1.Count;
            m_d2 = AL2.Count;
            if (m_d1 > m_d2)
            {
                m_dMin = m_d2;
                m_aMax = AL1;
                m_aMin = AL2;
            }
            else
            {
                m_dMin = m_d1;
                m_aMax = AL2;
                m_aMin = AL1;
            }
            AMax = m_aMax;
            AMin = m_aMin;

            for (int i = 0; i <= m_dMin - 1; i++)
            {
                m_TFS = m_aMin.GetItems(i).TFS;
                if (m_aMax.FindItemTfs(m_TFS)!=null)
                    m_find++;
            }
            if (m_find<=0)
                return -1; // не пересекаются  
            if (m_find < m_dMin)
                return 1; // пересекаются
            if (m_find == m_dMin)
                return 0; // вложения
            return -2;

        }
        bool IdentityAlternate(TAlternativeParserGrpItemList AL1, TAlternativeParserGrpItemList AL2)
        {
            TTreeListTFS Tfs1, Tfs2;
            int m_d1 = AL1.Count;
            int m_d2 = AL2.Count;
            if (m_d2 != m_d1)
                return false;
            for (int i = 0; i <= m_d1 - 1; i++)
            {
                if (AL1.GetItems(i).TFS != AL2.GetItems(i).TFS)
                    return false;
            }
            return true;
        }
        void MakeAgregate()
        {
            TAlternativeParserGrpItemList m_Cur, m_Next;
            TAlternativeParserGrpItemList m_Max = null, m_Min = null;
            int m_res;
            while (true)
            {
                m_Cur = FindFirstList();
                if (m_Cur==null)
                    return;
                m_Next = FindNextList(m_Cur);
                while (m_Next!=null)
                {
                    m_res = CompareAlternate(m_Cur, m_Next, ref m_Max, ref m_Min);
                    switch (m_res)
                    {
                        case 0:
                            m_Min.Agregate = m_Max;
                            break;
                    }
                    m_Next = FindNextList(m_Cur);
                }
                m_Cur.CheckAgregate = true;
            }
        }

        void MakeCross()
        {
            TAlternativeParserGrpItemList m_Cur, m_Next;
            TAlternativeParserGrpItemList m_Max=null, m_Min=null;
            int m_res;
            while (true)
            {
                m_Cur = FindFirstListNoCross();
                if (m_Cur==null)
                    return;
                m_Next = FindNextListNoCross(m_Cur);
                while (m_Next!=null)
                {
                    m_res = CompareAlternate(m_Cur, m_Next, ref m_Max, ref m_Min);
                    if (m_res == 1)
                        f_Cross.AddItem(m_Cur, m_Next);
                    m_Next = FindNextListNoCross(m_Cur);
                }
                m_Cur.CheckCross = true;
            }
        }
        void MakeOUT()
        {
            TAlternativeParserGrpItemList Temp;
            TAlternativeParserGrpItemBase Item;
            TDynamicArray D = new TDynamicArray();
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(f_List.ElementAt(i));
                int m_who = Item.Who();
                if (m_who<=0)
                    f_ListOut.Add(Item);
                if (m_who == 1)
                {
                    Temp = (TAlternativeParserGrpItemList)(Item);
                    Item = CheckOut(Temp);
                    if (Item!=null)
                    {
                        if (D.Find(Item)==null)
                        {
                            D.Append(Item);
                            f_ListOut.Add(Item);
                            if (Item.Who() == 2)
                            {
                                TAlternativeParserGrpCrossItem iTmp = (TAlternativeParserGrpCrossItem)(Item);
                                iTmp.CreateBasis();
                                iTmp.CreateListOut();
                            }
                        }
                    }
                }
            }
            D = null;
        }
        void CheckTFS()
        {
            TAlternativeParserGrpItemTFS Temp;
            TAlternativeParserGrpItemBase Item;
            TAlternativeParserGrpItemList List;
            TDynamicArray mTfs = new TDynamicArray();
            TDynamicArray mGrp = new TDynamicArray();
            TDynamicArray mDbl = new TDynamicArray();
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(f_List.ElementAt(i));
                int m_who = Item.Who();
                if (m_who<=0)
                    mTfs.Append(Item);
                if (m_who == 1)
                    mGrp.Append(Item);

            }
            for (int i = 0; i <= mTfs.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(mTfs.GetItems(i));
                Temp = (TAlternativeParserGrpItemTFS)(Item);
                for (int j = 0; j <= mGrp.Count - 1; j++)
                {
                    Item = (TAlternativeParserGrpItemBase)(mGrp.GetItems(j));
                    List = (TAlternativeParserGrpItemList)(Item);
                    if (List.FindItemTfs(Temp.TFS)!=null)
                        mDbl.Append(Temp);
                }
            }
            for (int i = 0; i <= mDbl.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(mDbl.GetItems(i));
                FreeItem(Item);
            }
             mDbl = null;
             mGrp = null;
             mTfs = null;
        }
        void CheckList()
        {
            TAlternativeParserGrpItemBase Item;
            TAlternativeParserGrpItemList List1, List2;
            TDynamicArray mList = new TDynamicArray();
            TDynamicArray mDbl = new TDynamicArray();
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(f_List.ElementAt(i));
                if (Item.Who() == 1)
                    mList.Append(Item);

            }

            for (int i = 0; i <= mList.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(mList.GetItems(i));
                List1 = (TAlternativeParserGrpItemList)(Item);
                for (int j = i + 1; j <= mList.Count - 1; j++)
                {
                    Item = (TAlternativeParserGrpItemBase)(mList.GetItems(j));
                    List2 = (TAlternativeParserGrpItemList)(Item);
                    if (IdentityAlternate(List1, List2))
                        mDbl.Append(Item);
                }
            }
            for (int i = 0; i <= mDbl.Count - 1; i++)
            {
                Item = (TAlternativeParserGrpItemBase)(mDbl.GetItems(i));
                FreeItem(Item);
            }
            mDbl = null;
            mList = null;
        }
        void MakeCrossDubles()
        {
            TAlternativeParserGrpItemBase Base;
            TAlternativeParserGrpCrossItem Cross;
            f_Enlarger.Init();
            for (int i = 0; i <= f_ListOut.Count - 1; i++)
            {
                Base = (TAlternativeParserGrpItemBase)(f_ListOut.ElementAt(i));
                if (Base.Who() == 2)
                {
                    Cross = (TAlternativeParserGrpCrossItem)(Base);
                    f_Enlarger.Enlarge(Cross);
                    RestructEnlarge(Cross);
                }
            }
        }
        void FreeItem(TAlternativeParserGrpItemBase AItem)
        {
            TAlternativeParserGrpItemBase Del;
            int index = f_List.IndexOf(AItem);
            if (index >= 0)
            {
                f_List.RemoveAt(index);
            }
        }
        TAlternativeParserGrpItemBase CheckOut(TAlternativeParserGrpItemList AItem)
        {
            {
                TAlternativeParserGrpItemBase Res;
                if (AItem.Agregate!=null)
                {
                    Res = f_Cross.FindToCross(AItem.Agregate);
                    return Res;
                }
                Res = f_Cross.FindToCross(AItem);
                if (Res!=null)
                    return Res;
                return AItem;
            }
        }
        void RestructEnlarge(TAlternativeParserGrpCrossItem AItem)
        {
            TAlternativeParserGrpItemTFS mPos;
            TAlternativeParserGrpCrossItemEnlarge Enl;
            TAlternativeParserEnlargerTrashItem TrItem;
            TDynamicArray Mass = new TDynamicArray();
            f_Enlarger.FindTrashItem(AItem, Mass);
            for (int i = 0; i <= Mass.Count - 1; i++)
            {
                TrItem = (TAlternativeParserEnlargerTrashItem)(Mass.GetItems(i));
                Enl = AItem.FindEnlarge(TrItem.Pos);
                if (Enl == null)
                    AddToListEnlarge(AItem.RestructEnlarge(TrItem));
            }
            Mass = null;
        }
/*
        void AddToListEnlarge(TAlternativeParserGrpCrossItemEnlarge* AItem);
             public:
               TAlternativeParserGrp();
             ~TAlternativeParserGrp();*/
        public void Clear()
        {
            FreeList();
            FreeListOut();
        }
        public void Make()
        {
            FreeListOut();
            CheckList();
            CheckTFS();
            MakeCross();
            MakeAgregate();
            MakeOUT();
            MakeCrossDubles();
        }
        public void AddTfs(TTreeListTFS ATFS)
        {
            if (FindItemTfs(ATFS)==null)
            {
                TAlternativeParserGrpItemTFS T = new TAlternativeParserGrpItemTFS();
                T.TFS = ATFS;
                f_List.Add(T);
            }
        }
        public TAlternativeParserGrpItemList GetNewList(TAlternateTreeList Alternative)
        {
            TAlternativeParserGrpItemList Item = new TAlternativeParserGrpItemList();
            Item.Alternative = Alternative;
            f_List.Add(Item);
            return Item;
        }
        public int CountOUT
        {
            get { return GetCountOUT(); }
        }
       /*    __property TAlternativeParserGrpItemBase* ItemsOUT[int AIndex] = {read = GetItemsOUT*/
    }
}
