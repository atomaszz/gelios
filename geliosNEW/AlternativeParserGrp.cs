using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAlternativeParserGrpItemBase
    {
        ~TAlternativeParserGrpItemBase() { return; }
        public virtual int Who() { return -1; }
    }

    class TAlternativeParserGrpItemTFS : TAlternativeParserGrpItemBase
    {
      TTreeListTFS f_TFS;
        /*  public:
            TAlternativeParserGrpItemTFS();
          ~TAlternativeParserGrpItemTFS() { return; }
          int Who() { return 0; }
          __property TTreeListTFS* TFS = { read = f_TFS, write = f_TFS };*/
    }
    class TAlternativeParserGrpItemList : TAlternativeParserGrpItemBase
    {
        bool f_CheckAgregate;
        bool f_CheckCross;
        TAlternativeParserGrpItemList f_Agregate;
        TAlternateTreeList f_Alternative;
        List<object> f_List;
        /*void FreeList();
int __fastcall GetCount();
TAlternativeParserGrpItemTFS* __fastcall GetItems(int AIndex);
void __fastcall SetAgregate(TAlternativeParserGrpItemList* AValue);
public:
      TAlternativeParserGrpItemList();
~TAlternativeParserGrpItemList();
TAlternativeParserGrpItemTFS* FindItemTfs(TTreeListTFS* ATFS);
int Who() { return 1; }
void AddTfs(TTreeListTFS* ATFS);
__property int Count = { read = GetCount };
__property TAlternativeParserGrpItemTFS* Items[int AIndex] = { read = GetItems };
__property bool CheckAgregate = { read = f_CheckAgregate, write = f_CheckAgregate };
__property bool CheckCross = { read = f_CheckCross, write = f_CheckCross };
__property TAlternativeParserGrpItemList* Agregate = { read = f_Agregate, write = SetAgregate };
__property TAlternateTreeList* Alternative = { read = f_Alternative, write = f_Alternative };
*/
    }
    class TAlternativeParserGrpCrossItemOut
    {
     List<object> f_List;
        /*   int  GetCount();
           TAlternativeParserGrpItemList* __fastcall GetItems(int AIndex);
           public:
            TAlternativeParserGrpCrossItemOut();
           ~TAlternativeParserGrpCrossItemOut();
           void AddItem(TAlternativeParserGrpItemBase* AItem);
           void ReplaceToEnlarge(TAlternativeParserGrpCrossItemEnlarge* AE);
           __property int Count = { read = GetCount };
           __property TAlternativeParserGrpItemBase* Items[int AIndex] = {read = GetItems
       };*/
    }
    class TAlternativeParserGrpCrossItem : TAlternativeParserGrpItemBase
    {
        List<object> f_List;
        List<object> f_Basis;
        List<object> f_Out;
        /*void FreeOut();
        void DoCreateList();
        void DoCreateBasis();
        void DoCreateListItem(TAlternativeParserGrpItemList* AItem, TAlternativeParserGrpCrossItemOut* ANew);
        int __fastcall GetCount();
        TAlternativeParserGrpItemList* __fastcall GetItems(int AIndex);
        int __fastcall GetCountBasis();
        TAlternativeParserGrpItemBase* __fastcall GetItemsBasis(int AIndex);

        int __fastcall GetCountOut();
        TAlternativeParserGrpCrossItemOut* __fastcall GetItemsOut(int AIndex);
        TAlternativeParserGrpCrossItemOut* GetNewCrossOut();
        void ReplaceToEnlarge(TAlternativeParserGrpCrossItemEnlarge* AE);
        public:
             TAlternativeParserGrpCrossItem();
        ~TAlternativeParserGrpCrossItem();
        int Who() { return 2; }
        void AddItem(TAlternativeParserGrpItemList* AGList);
        void CreateBasis();
        void CreateListOut();
        TAlternativeParserGrpCrossItemEnlarge* FindEnlarge(TAlternativeParserGrpItemTFS* ATfs);
        TAlternativeParserGrpCrossItemEnlarge* RestructEnlarge(TAlternativeParserEnlargerTrashItem* ATrash);

        __property int Count = { read = GetCount };
        __property TAlternativeParserGrpItemList* Items[int AIndex] = { read = GetItems };
        __property int CountBasis = { read = GetCountBasis };
        __property TAlternativeParserGrpItemBase* ItemsBasis[int AIndex] = { read = GetItemsBasis };

        __property int CountOut = { read = GetCountOut };
        __property TAlternativeParserGrpCrossItemOut* ItemsOut[int AIndex] = { read = GetItemsOut };*/
    }

    class TAlternativeParserGrpCrossItemEnlarge : TAlternativeParserGrpItemBase
    {
        int f_ID;
        List<object> f_List;
        /*   void FreeList();
   int __fastcall GetCount();
   TAlternativeParserGrpItemTFS* __fastcall GetItems(int AIndex);
   TAlternativeParserGrpItemTFS* __fastcall GetPos();
   public:
         TAlternativeParserGrpCrossItemEnlarge();
   ~TAlternativeParserGrpCrossItemEnlarge();
   int Who() { return 3; }
   void AddGRPTfs(TAlternativeParserGrpItemTFS* ATFS);
   __property int Count = { read = GetCount };
   __property TAlternativeParserGrpItemTFS* Items[int AIndex] = { read = GetItems };
   __property TAlternativeParserGrpItemTFS* Pos = { read = GetPos };
   __property int ID = { read = f_ID, write = f_ID };*/

    }
    class TAlternativeParserGrpCross
    {
     List<object> f_List;
        /*  void FreeList();
          int __fastcall GetCount();
          TAlternativeParserGrpCrossItem* __fastcall GetItems(int AIndex);
          public:
           TAlternativeParserGrpCross();
          ~TAlternativeParserGrpCross();
          TAlternativeParserGrpCrossItem* FindToCross(TAlternativeParserGrpItemList* AItem);
          void AddItem(TAlternativeParserGrpItemList* A, TAlternativeParserGrpItemList* B);
          __property int Count = { read = GetCount };
          __property TAlternativeParserGrpCrossItem* Items[int AIndex] = {read = GetItems
      };*/
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
        /*   void FreeList();
           void FreeListOut();
           void FreeListEnlarge();
           TAlternativeParserGrpItemList* FindFirstList();
           TAlternativeParserGrpItemList* FindNextList(TAlternativeParserGrpItemList* AByPass);

           TAlternativeParserGrpItemList* FindFirstListNoCross();
           TAlternativeParserGrpItemList* FindNextListNoCross(TAlternativeParserGrpItemList* AByPass);

           int __fastcall GetCountOUT();
           TAlternativeParserGrpItemBase* __fastcall GetItemsOUT(int AIndex);
           TAlternativeParserGrpItemTFS* FindItemTfs(TTreeListTFS* ATFS);
           int CompareAlternate(TAlternativeParserGrpItemList* AL1,
             TAlternativeParserGrpItemList* AL2, TAlternativeParserGrpItemList** AMax,
             TAlternativeParserGrpItemList** AMin);
           bool IdentityAlternate(TAlternativeParserGrpItemList* AL1, TAlternativeParserGrpItemList* AL2);
           void MakeAgregate();
           void MakeCross();
           void MakeOUT();
           void CheckTFS();
           void CheckList();
           void MakeCrossDubles();
           void FreeItem(TAlternativeParserGrpItemBase* AItem);
           TAlternativeParserGrpItemBase* CheckOut(TAlternativeParserGrpItemList* AItem);
           void RestructEnlarge(TAlternativeParserGrpCrossItem* AItem);
           void AddToListEnlarge(TAlternativeParserGrpCrossItemEnlarge* AItem);
           public:
             TAlternativeParserGrp();
           ~TAlternativeParserGrp();
           void Clear();
           void Make();
           void AddTfs(TTreeListTFS* ATFS);
           TAlternativeParserGrpItemList* GetNewList(TAlternateTreeList* Alternative);
           __property int CountOUT = { read = GetCountOUT };
           __property TAlternativeParserGrpItemBase* ItemsOUT[int AIndex] = {read = GetItemsOUT*/
    }
}
