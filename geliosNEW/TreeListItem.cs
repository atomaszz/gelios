using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TMainTreeList
    {
        List<object> f_List;
        int f_Level;
        public TAlternateTreeList GetAlternateItem(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TAlternateTreeList)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        TAlternateTreeList GetMainAlternative()
        {
            TAlternateTreeList Res;
            for (int i = 0; i <= ItemCount - 1; i++)
            {
                Res = GetAlternateItem(i);
                if (Res.MainAlternative)
                    return Res;
            }
            return null;
        }
        int GetItemCount()
        {
            return  f_List.Count;
        }
        void FreeList()
        {
            f_List.Clear();
        }
        public TMainTreeList()
        {
            f_List = new List<object>();
            f_Level = -1;
        }
        ~TMainTreeList() { }
        public void AddToTree(TAlternateTreeList Item)
        {
            if (Item == null)
                f_List.Add(Item);
        }
        public void Clear()
        {
            FreeList();
        }
  /*      public  TTreeListItem FindTFE(TBaseShape ABaseShape);*/
        public void FindAlternate(TBaseWorkShape ABaseWorkShape, TDynamicArray D)
        {
            TBaseWorkShape Tfs;
            D.Clear();
            for (int i = 0; i <= ItemCount - 1; i++)
            {
                Tfs = GetAlternateItem(i).NodeStart.WorkShape;
                if (Tfs == ABaseWorkShape)
                    D.Append(GetAlternateItem(i));
            }
        }
        public void FindAlternate2(TBaseWorkShape AFirstWorkShape, TBaseWorkShape AEndWorkShape, TDynamicArray D)
        {
            TBaseWorkShape Tfs1, Tfs2;
            D.Clear();
            for (int i = 0; i <= ItemCount - 1; i++)
            {
                Tfs1 = null;
                Tfs2 = null;
                if (GetAlternateItem(i).NodeStart!=null)
                    Tfs1 = GetAlternateItem(i).NodeStart.WorkShape;
                if (GetAlternateItem(i).NodeEnd!=null)
                    Tfs2 = GetAlternateItem(i).NodeEnd.WorkShape;
                if ((Tfs1 == AFirstWorkShape) && (Tfs2 == AEndWorkShape))
                    D.Append(GetAlternateItem(i));
            }
        }
  /*      public void GetTreeListTFSFromMainAlternative(TAlternateTreeList* Alternative, TDynamicArray* D);*/
        public int ItemCount
        {
            get { return GetItemCount(); }
        }
   /*     public TAlternateTreeList* AlternateItem[int AIndex] = {read = GetAlternateItem*/
        public int Level
        {
            set { f_Level = value; }
            get { return f_Level; }
        }

        public TAlternateTreeList MainAlternative
        {
            get { return GetMainAlternative(); }
        }
    }
    public class TAlternateTreeList
    {
     int f_ID;
    int f_Num;
    List<object> f_List;
    bool f_Main;
    TNodeMain f_NodeStart;
    TNodeMain f_NodeEnd;
    public TTreeListTFS GetTreeTFSItem(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TTreeListTFS)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        int GetItemCount()
        {
            return f_List.Count;
        }
        void FreeList()
        {
            f_List.Clear();
        }

        public TAlternateTreeList()
        {
            f_List = new List<object>();
            f_Main = false;
            f_NodeStart = null;
            f_NodeEnd = null;
            f_ID = -1;
            f_Num = -1;
        }
        ~TAlternateTreeList() { }
        public void AddToAlternate(TTreeListTFS Item)
        {
            if (Item!=null)
                f_List.Add(Item);
        }
        /*    public TTreeListItem* FindTFE(TBaseShape* ABaseShape);
            public TTreeListTFS* FindTFS(TBaseWorkShape* AWS);*/
        public int ItemCount
        {
            get { return GetItemCount(); }
        }
 /*    public TTreeListTFS TreeTFSItem[int AIndex] = {read = GetTreeTFSItem*/
     public bool MainAlternative
        {
            set { f_Main = value;  }
            get { return f_Main; }
        }
        public TNodeMain NodeStart
        {
            set { f_NodeStart = value; }
            get { return f_NodeStart; }
        }
        public TNodeMain NodeEnd
        {
            set { f_NodeEnd = value; }
            get { return f_NodeEnd; }
        }
        public int ID
        {
            set { f_ID = value; }
            get { return f_ID; }
        }
        public int Num
        {
            set { f_Num = value; }
            get { return f_Num; }
        }
    }

public class TTreeListTFS
{

     TBaseWorkShape f_BaseWorkShape;
     List<object> f_List;
    void FreeList()
        {
            f_List.Clear();
        }
    int  GetItemCount()
        {
            return f_List.Count;
        }
    public TTreeListItem  GetTreeTFEItem(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TTreeListItem)(f_List.ElementAt(AIndex));
            else
                return null;
        }
    public TTreeListTFS(TBaseWorkShape ABaseWorkShape)
        {
            TBaseShape mBS;
            TTreeListItem TL;
            f_BaseWorkShape = ABaseWorkShape;
            f_List = new List<object>();
            for (int i = 0; i <= f_BaseWorkShape.WorkShapesCount - 1; i++)
            {
                mBS = f_BaseWorkShape.GetWorkShape(i);
                TL = new TTreeListItem(mBS);
                f_List.Add(TL);
            }
        }
    ~TTreeListTFS() { }
        public TBaseWorkShape BaseWorkShape
        {
            get { return f_BaseWorkShape;  }
        }
        public int ItemCount
        {
            get { return GetItemCount(); }
        }
  /*      public TTreeListItem TreeTFEItem[int AIndex] = { read = GetTreeTFEItem };*/
}


    public class TTreeListItem
    {
        TBaseShape f_BaseShape;
        TMainTreeList f_MainNode;
        public TTreeListItem(TBaseShape ABaseShape)
        {
            f_BaseShape = ABaseShape;
            f_MainNode = null;
        }
        ~TTreeListItem() { }
        public TMainTreeList MainNode
        {
            set { f_MainNode = value; }
            get { return f_MainNode;  }
        }  
        public TBaseShape BaseShape
        {
            get { return f_BaseShape; }
        }
    }
}
