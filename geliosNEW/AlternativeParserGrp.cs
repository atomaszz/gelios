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
        public TAlternativeParserGrpItemTFS()
        {
            f_TFS = null;
        }
        ~TAlternativeParserGrpItemTFS() { return; }
        public override int Who() { return 0; }
        public TTreeListTFS TFS
        {
            set { f_TFS = value; }
            get { return f_TFS;  }
        }
    }
    class TAlternativeParserGrpItemList : TAlternativeParserGrpItemBase
    {
        bool f_CheckAgregate;
        bool f_CheckCross;
        TAlternativeParserGrpItemList f_Agregate;
        TAlternateTreeList f_Alternative;
        List<object> f_List;
     /*   void FreeList();
        int  GetCount();
        TAlternativeParserGrpItemTFS  GetItems(int AIndex);
        void  SetAgregate(TAlternativeParserGrpItemList AValue);*/

        public TAlternativeParserGrpItemList()
        {
            f_List = new List<object>();
            f_CheckAgregate = false;
            f_Agregate = null;
            f_CheckCross = false;
            f_Alternative = null;
        }
        ~TAlternativeParserGrpItemList() { }
        //TAlternativeParserGrpItemTFS FindItemTfs(TTreeListTFS ATFS);
        public override int Who() { return 1; }
   /*     void AddTfs(TTreeListTFS* ATFS);
        public int Count = { read = GetCount };
        public TAlternativeParserGrpItemTFS* Items[int AIndex] = { read = GetItems };
        public bool CheckAgregate = { read = f_CheckAgregate, write = f_CheckAgregate };
        public bool CheckCross = { read = f_CheckCross, write = f_CheckCross };
        public TAlternativeParserGrpItemList* Agregate = { read = f_Agregate, write = SetAgregate };
        public TAlternateTreeList* Alternative = { read = f_Alternative, write = f_Alternative };*/
    }
    class TAlternativeParserGrpCrossItemOut
    {
     List<object> f_List;
        /*  int GetCount();
          TAlternativeParserGrpItemList GetItems(int AIndex);*/
    public TAlternativeParserGrpCrossItemOut()
        {
            f_List = new List<object>();
        }
    ~TAlternativeParserGrpCrossItemOut() { }
        /*   void AddItem(TAlternativeParserGrpItemBase* AItem);
           void ReplaceToEnlarge(TAlternativeParserGrpCrossItemEnlarge* AE);
               public int Count = { read = GetCount };
               public TAlternativeParserGrpItemBase* Items[int AIndex] = {read = GetItems*/
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
public:*/
     TAlternativeParserGrpCrossItem()
        {
            f_List = new List<object>();
            f_Basis = new List<object>();
            f_Out = new List<object>();
        }
        ~TAlternativeParserGrpCrossItem() { }
        public override int Who() { return 2; }
        /*void AddItem(TAlternativeParserGrpItemList* AGList);
        void CreateBasis();
        void CreateListOut();
        TAlternativeParserGrpCrossItemEnlarge* FindEnlarge(TAlternativeParserGrpItemTFS* ATfs);
        TAlternativeParserGrpCrossItemEnlarge* RestructEnlarge(TAlternativeParserEnlargerTrashItem* ATrash);

        public int Count = { read = GetCount };
        public TAlternativeParserGrpItemList* Items[int AIndex] = { read = GetItems };
        public int CountBasis = { read = GetCountBasis };
        public TAlternativeParserGrpItemBase* ItemsBasis[int AIndex] = { read = GetItemsBasis };

        public int CountOut = { read = GetCountOut };
        public TAlternativeParserGrpCrossItemOut* ItemsOut[int AIndex] = { read = GetItemsOut };*/
    }
    class TAlternativeParserGrpCrossItemEnlarge : TAlternativeParserGrpItemBase
    {
        int f_ID;
        List<object> f_List;
/*void FreeList();
int __fstcall GetCount();
TAlternativeParserGrpItemTFS  GetItems(int AIndex);
TAlternativeParserGrpItemTFS  GetPos();*/

        public TAlternativeParserGrpCrossItemEnlarge()
        {
            f_List = new List<object>();
        }
        ~TAlternativeParserGrpCrossItemEnlarge() { }
        public override int Who() { return 3; }
        /*void AddGRPTfs(TAlternativeParserGrpItemTFS* ATFS);
        public int Count = { read = GetCount };
        public TAlternativeParserGrpItemTFS* Items[int AIndex] = { read = GetItems };
        public TAlternativeParserGrpItemTFS* Pos = { read = GetPos };
        public int ID = { read = f_ID, write = f_ID };*/
    }
    class TAlternativeParserGrpCross
    {
        List<object> f_List;
   /*     void FreeList();
        int  GetCount();
        TAlternativeParserGrpCrossItem  GetItems(int AIndex);*/

        public TAlternativeParserGrpCross()
        {
            f_List = new List<object>();
        }
        ~TAlternativeParserGrpCross() { }
        /*  TAlternativeParserGrpCrossItem* FindToCross(TAlternativeParserGrpItemList* AItem);
          void AddItem(TAlternativeParserGrpItemList* A, TAlternativeParserGrpItemList* B);
          public int Count = { read = GetCount };
          public TAlternativeParserGrpCrossItem* Items[int AIndex] = {read = GetItems*/
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
           TAlternativeParserGrpItemList FindFirstList();
           TAlternativeParserGrpItemList FindNextList(TAlternativeParserGrpItemList AByPass);

           TAlternativeParserGrpItemList FindFirstListNoCross();
           TAlternativeParserGrpItemList FindNextListNoCross(TAlternativeParserGrpItemList AByPass);

           int __fastcall GetCountOUT();
           TAlternativeParserGrpItemBase __fastcall GetItemsOUT(int AIndex);
           TAlternativeParserGrpItemTFS FindItemTfs(TTreeListTFS ATFS);
           int CompareAlternate(TAlternativeParserGrpItemList AL1,
             TAlternativeParserGrpItemList AL2, TAlternativeParserGrpItemList AMax,
             TAlternativeParserGrpItemList AMin);
           bool IdentityAlternate(TAlternativeParserGrpItemList AL1, TAlternativeParserGrpItemList AL2);
           void MakeAgregate();
           void MakeCross();
           void MakeOUT();
           void CheckTFS();
           void CheckList();
           void MakeCrossDubles();
           void FreeItem(TAlternativeParserGrpItemBase AItem);
           TAlternativeParserGrpItemBase CheckOut(TAlternativeParserGrpItemList AItem);
           void RestructEnlarge(TAlternativeParserGrpCrossItem AItem);
           void AddToListEnlarge(TAlternativeParserGrpCrossItemEnlarge AItem);*/
        public TAlternativeParserGrp()
        {
            f_List = new List<object>();
            f_ListOut = new List<object>();
            f_ListEnlarge = new List<object>();
            f_Cross = new TAlternativeParserGrpCross();
            f_FindListPos = 0;
            f_FindListPosNoCross = 0;
            f_Enlarger = new TAlternativeParserEnlarger();
        }
        ~TAlternativeParserGrp() { }
 /*   void Clear();
    void Make();
    void AddTfs(TTreeListTFS ATFS);
    TAlternativeParserGrpItemList GetNewList(TAlternateTreeList Alternative);
    public int CountOUT = { read = GetCountOUT };
    public TAlternativeParserGrpItemBase ItemsOUT[int AIndex] = {read = GetItemsOUT
};*/
};
}
