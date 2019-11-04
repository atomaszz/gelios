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
        /*void FreeList();
        int __fastcall GetCount();
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
        /*   int __fastcall GetCount();
           TAlternativeParserGrpItemTFS* __fastcall GetItems(int AIndex);
           public:
            TAlternativeParserEnlargerItem();
           ~TAlternativeParserEnlargerItem();
           int Pos(TAlternativeParserEnlargerStep* AStep);
           void AddTfsItem(TAlternativeParserGrpItemTFS* AGrpTfs);
           void DeleteTfsItem(TAlternativeParserGrpItemTFS* AGrpTfs);
           void CascadeDelete(TDynamicArray* AMass);
           int FillStep(TAlternativeParserEnlargerStep* AStep, int APos, int ACount);
           int Find(TAlternativeParserGrpItemTFS* AGrpTfs);
           __property bool Basis = { read = f_Basis, write = f_Basis };
           __property TAlternativeParserGrpCrossItemOut* Parent = {read = f_Parent, write = f_Parent
       };
       __property TAlternativeParserGrpCrossItem* ParentMain = { read = f_ParentMain, write = f_ParentMain };

       __property int Count = { read = GetCount };
       __property TAlternativeParserGrpItemTFS* Items[int AIndex] = { read = GetItems };*/

    }
    class TAlternativeParserEnlargerStep
    {
        List<object> f_List;
        /*  int __fastcall GetCount();
          TAlternativeParserGrpItemTFS* __fastcall GetItems(int AIndex);
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
        /*   TAlternativeParserEnlargerTrashItem();
          __property int Length = { read = f_Length, write = f_Length };
          __property TAlternativeParserGrpItemTFS* Pos = {read = f_Pos, write = f_Pos
      };
      __property TAlternativeParserEnlargerItem* Owner = { read = f_Owner, write = f_Owner };
      __property int ID = { read = f_ID, write = f_ID };*/
    }
    class TAlternativeParserEnlargerTrash
    {
        List<object> f_List;
        /*  void FreeList();
          int __fastcall GetCount();
          TAlternativeParserEnlargerTrashItem* __fastcall GetItems(int AIndex);
          public:
           TAlternativeParserEnlargerTrash();
          ~TAlternativeParserEnlargerTrash();
          TAlternativeParserEnlargerTrashItem* NewTrashItem();
          void Clear();
          __property int Count = { read = GetCount };
          __property TAlternativeParserEnlargerTrashItem* Items[int AIndex] = {read = GetItems*/
    }
    class TAlternativeParserEnlarger
    {
        List<object> f_List;
        TAlternativeParserEnlargerTrash f_Trash;
        /* void FreeList();
         void DoFill(TAlternativeParserGrpCrossItem* AItem);
         void DoEnlarge();
         TAlternativeParserEnlargerItem* GetNew(TAlternativeParserGrpCrossItem* AParentMain);
         TAlternativeParserEnlargerItem* FindMax();
         void Restruct();
         bool IsEmptyTrash();
         void ClearTrash();
         void CreateTrashItem(TAlternativeParserGrpItemTFS* APos, int ALength,
           TAlternativeParserEnlargerItem* AOwner, int AID);
         int __fastcall GetCount();
         TAlternativeParserEnlargerItem* __fastcall GetItems(int AIndex);
         public:
          TAlternativeParserEnlarger();
         ~TAlternativeParserEnlarger();
         void Init();
         void Enlarge(TAlternativeParserGrpCrossItem* AItem);
         void FindTrashItem(TAlternativeParserGrpCrossItem* AOwner, TDynamicArray* AOut);
         __property int Count = { read = GetCount };
         __property TAlternativeParserEnlargerItem* Items[int AIndex] = {read = GetItems*/
    }
}
