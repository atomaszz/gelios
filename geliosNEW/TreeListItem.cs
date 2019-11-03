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
   /*     TAlternateTreeList GetAlternateItem(int AIndex);
        TAlternateTreeList GetMainAlternative();
        int GetItemCount();
        void FreeList();*/
        public TMainTreeList()
        {
            f_List = new List<object>();
            f_Level = -1;
        }
        ~TMainTreeList() { }
<<<<<<< HEAD
<<<<<<< HEAD
    /*    public void AddToTree(TAlternateTreeList Item);*/
        public void Clear()
        {
            //FreeList();
        }
  /*      public  TTreeListItem FindTFE(TBaseShape ABaseShape);
=======
    /*    public void AddToTree(TAlternateTreeList Item);
        public void Clear();
        public  TTreeListItem FindTFE(TBaseShape ABaseShape);
>>>>>>> parent of 7032bbe... next gen
=======
    /*    public void AddToTree(TAlternateTreeList Item);
        public void Clear();
        public  TTreeListItem FindTFE(TBaseShape ABaseShape);
>>>>>>> parent of 7032bbe... next gen
        public void FindAlternate(TBaseWorkShape* ABaseWorkShape, TDynamicArray* D);
        public void FindAlternate2(TBaseWorkShape* AFirstWorkShape, TBaseWorkShape* AEndWorkShape, TDynamicArray* D);
        public void GetTreeListTFSFromMainAlternative(TAlternateTreeList* Alternative, TDynamicArray* D);
        public int ItemCount = { read = GetItemCount };
        public TAlternateTreeList* AlternateItem[int AIndex] = {read = GetAlternateItem
        public int Level = { read = f_Level, write = f_Level };
        public TAlternateTreeList* MainAlternative = { read = GetMainAlternative };*/
    }
    class TAlternateTreeList
    {
     int f_ID;
    int f_Num;
    List<object> f_List;
    bool f_Main;
    TNodeMain f_NodeStart;
    TNodeMain f_NodeEnd;
        /*    TTreeListTFS GetTreeTFSItem(int AIndex);
            int GetItemCount();
            void FreeList();*/

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
        /*     public void AddToAlternate(TTreeListTFS* Item);
             public TTreeListItem* FindTFE(TBaseShape* ABaseShape);
             public TTreeListTFS* FindTFS(TBaseWorkShape* AWS);
             public int ItemCount = { read = GetItemCount };
             public TTreeListTFS* TreeTFSItem[int AIndex] = {read = GetTreeTFSItem
     public bool MainAlternative = { read = f_Main, write = f_Main };
             public TNodeMain* NodeStart = { read = f_NodeStart, write = f_NodeStart };
             public TNodeMain* NodeEnd = { read = f_NodeEnd, write = f_NodeEnd };
         public int ID = { read = f_ID, write = f_ID };
             public int Num = { read = f_Num, write = f_Num };*/
    }

class TTreeListTFS
{

     TBaseWorkShape f_BaseWorkShape;
     List<object> f_List;
  /*  void FreeList();
    int  GetItemCount();
    TTreeListItem  GetTreeTFEItem(int AIndex);*/
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
 /*       public TBaseWorkShape BaseWorkShape = {read = f_BaseWorkShape
        public int ItemCount = { read = GetItemCount };
        public TTreeListItem TreeTFEItem[int AIndex] = { read = GetTreeTFEItem };*/
}


    class TTreeListItem
    {
        TBaseShape f_BaseShape;
        TMainTreeList f_MainNode;
        public TTreeListItem(TBaseShape ABaseShape)
        {
            f_BaseShape = ABaseShape;
            f_MainNode = null;
        }
        ~TTreeListItem() { }
      /*  public TMainTreeList MainNode = {read = f_MainNode, write = f_MainNode
        public TBaseShape BaseShape = { read = f_BaseShape };*/
    }
}
