using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TMainTreeList
    {
        List<object> f_List;
        int f_Level;
        /*    TAlternateTreeList  GetAlternateItem(int AIndex);
            TAlternateTreeList  GetMainAlternative();
            int __fastcall GetItemCount();
            void FreeList();
            public:
         TMainTreeList();
            ~TMainTreeList();
            void AddToTree(TAlternateTreeList* Item);
            void Clear();
            TTreeListItem* FindTFE(TBaseShape* ABaseShape);
            void FindAlternate(TBaseWorkShape* ABaseWorkShape, TDynamicArray* D);
            void FindAlternate2(TBaseWorkShape* AFirstWorkShape, TBaseWorkShape* AEndWorkShape, TDynamicArray* D);
            void GetTreeListTFSFromMainAlternative(TAlternateTreeList* Alternative, TDynamicArray* D);
            __property int ItemCount = { read = GetItemCount };
            __property TAlternateTreeList* AlternateItem[int AIndex] = {read = GetAlternateItem
        };
        __property int Level = { read = f_Level, write = f_Level };
        __property TAlternateTreeList* MainAlternative = { read = GetMainAlternative };*/
    }
    class TAlternateTreeList
    {
        int f_ID;
        int f_Num;
        List<object> f_List;
        bool f_Main;
        TNodeMain f_NodeStart;
        TNodeMain f_NodeEnd;
        /* TTreeListTFS* __fastcall GetTreeTFSItem(int AIndex);
         int __fastcall GetItemCount();
         void FreeList();
         public:
          TAlternateTreeList();
         ~TAlternateTreeList();
         void AddToAlternate(TTreeListTFS* Item);
         TTreeListItem* FindTFE(TBaseShape* ABaseShape);
         TTreeListTFS* FindTFS(TBaseWorkShape* AWS);
         __property int ItemCount = { read = GetItemCount };
         __property TTreeListTFS* TreeTFSItem[int AIndex] = {read = GetTreeTFSItem
     };
     __property bool MainAlternative = { read = f_Main, write = f_Main };
     __property TNodeMain* NodeStart = { read = f_NodeStart, write = f_NodeStart };
     __property TNodeMain* NodeEnd = { read = f_NodeEnd, write = f_NodeEnd };
     __property int ID = { read = f_ID, write = f_ID };
     __property int Num = { read = f_Num, write = f_Num };*/
    }
    class TTreeListTFS
    {
        TBaseWorkShape f_BaseWorkShape;
        List<object> f_List;
        /*  void FreeList();
          int __fastcall GetItemCount();
          TTreeListItem* __fastcall GetTreeTFEItem(int AIndex);
          public:
           TTreeListTFS(TBaseWorkShape* ABaseWorkShape);
          ~TTreeListTFS();
          __property TBaseWorkShape* BaseWorkShape = {read = f_BaseWorkShape
      };
      __property int ItemCount = { read = GetItemCount };
      __property TTreeListItem* TreeTFEItem[int AIndex] = { read = GetTreeTFEItem };*/
    }
    class TTreeListItem
    {
        TBaseShape f_BaseShape;
        TMainTreeList f_MainNode;
        /*  TTreeListItem(TBaseShape* ABaseShape);
         ~TTreeListItem();
         __property TMainTreeList* MainNode = {read = f_MainNode, write = f_MainNode
     };
     __property TBaseShape* BaseShape = { read = f_BaseShape };*/
    }
}
