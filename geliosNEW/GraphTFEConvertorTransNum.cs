using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TGraphTFEConvertorTransNumItem
    {
        int f_ID;
        int f_OldID;
        int f_Prefix;
        public TGraphTFEConvertorTransNumItem() { f_ID = 0; f_OldID = 0; f_Prefix = 0; }
        public int ID { set { f_ID = value; } get { return f_ID; } }    
        public int OldID { set { f_OldID = value; } get { return f_OldID; } }

        public int Prefix { set { f_Prefix = value; } get { return f_Prefix; } }
    }

    class TGraphTFEConvertorTransNumTFS
    {
        List<object> f_ListItem;
        string f_Name;
        int f_NumAlt;
        int f_ParentID;
        int f_ParentIDReal;
        /*    void FreeList();
            int __fastcall GetItemCount();
            TGraphTFEConvertorTransNumItem* __fastcall GetItems(int AIndex);
            public:
         TGraphTFEConvertorTransNumTFS();
            ~TGraphTFEConvertorTransNumTFS();
            TGraphTFEConvertorTransNumItem* AddItem(int AId, int AOldId, int APrefix);
            __property AnsiString Name = {read = f_Name, write = f_Name
        };
        __property int NumAlt = { read = f_NumAlt, write = f_NumAlt };
        __property int ParentID = { read = f_ParentID, write = f_ParentID };
        __property int ParentIDReal = { read = f_ParentIDReal, write = f_ParentIDReal };

        __property int ItemCount = { read = GetItemCount };
        __property TGraphTFEConvertorTransNumItem* Items[int AIndex] = { read = GetItems };*/
    }
    class TGraphTFEConvertorTransNum
    {
     List<object> f_List;
    TPredicateNumGenerator f_NGen;
        /*    void FreeList();
            int GetPrefix(TGraphTFEConvertorItem* AItem);
            int GetParentID(TGraphTFEConvertorItem* AItem, int APrefix);
            int GetPrefixForItem(int ANum);
            AnsiString DoMake(TGraphTFEConvertorTransNumTFS* AItem);
            AnsiString ListIDFromItem(TGraphTFEConvertorTransNumTFS* AItem);
            public:
             TGraphTFEConvertorTransNum();
            ~TGraphTFEConvertorTransNum();
            void AddGTItem(TGraphTFEConvertorItem* AItem);
            AnsiString Make();*/
    }
}
