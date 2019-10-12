using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TGraphTFEConvertorTransNumItem
    {
        int f_ID;
        int f_OldID;
        int f_Prefix;
        public TGraphTFEConvertorTransNumItem() { f_ID = 0; f_OldID = 0; f_Prefix = 0; }
        public int ID
        {
            set { f_ID = value; }
            get { return f_ID; }
        }
        public int OldID
        {
            set { f_OldID = value; }
            get { return f_OldID; }
        }
        public int Prefix
        {
            set { f_Prefix = value; }
            get { return f_Prefix; }
        }
    }

    class TGraphTFEConvertorTransNumTFS
    {
        List<object> f_ListItem;
        string f_Name;
        int f_NumAlt;
        int f_ParentID;
        int f_ParentIDReal;
     /*   void FreeList();
        int  GetItemCount();
        TGraphTFEConvertorTransNumItem  GetItems(int AIndex);*/
     public TGraphTFEConvertorTransNumTFS()
        {
            f_Name = "";
            f_NumAlt = 0;
            f_ParentID = 0;
            f_ParentIDReal = 0;
            f_ListItem = new List<object>();
        }
        ~TGraphTFEConvertorTransNumTFS() { }
        public TGraphTFEConvertorTransNumItem AddItem(int AId, int AOldId, int APrefix)
        {
            TGraphTFEConvertorTransNumItem Item = new TGraphTFEConvertorTransNumItem();
            Item.ID = AId;
            Item.OldID = AOldId;
            Item.Prefix = APrefix;
            f_ListItem.Add(Item);
            return Item;
        }
        /*  public string Name = {read = f_Name, write = f_Name
          public int NumAlt = { read = f_NumAlt, write = f_NumAlt };
          public int ParentID = { read = f_ParentID, write = f_ParentID };
          public int ParentIDReal = { read = f_ParentIDReal, write = f_ParentIDReal };

          public int ItemCount = { read = GetItemCount };
          public TGraphTFEConvertorTransNumItem* Items[int AIndex] = { read = GetItems };*/
    }
    class TGraphTFEConvertorTransNum
    {
        List<object> f_List;
        TPredicateNumGenerator f_NGen;
        /*      void FreeList();
          int GetPrefix(TGraphTFEConvertorItem* AItem);
          int GetParentID(TGraphTFEConvertorItem* AItem, int APrefix);
          int GetPrefixForItem(int ANum);
          AnsiString DoMake(TGraphTFEConvertorTransNumTFS* AItem);
          AnsiString ListIDFromItem(TGraphTFEConvertorTransNumTFS* AItem);*/
        public TGraphTFEConvertorTransNum()
        {
            TGraphTFEConvertorTransNumTFS Head = new TGraphTFEConvertorTransNumTFS();
            Head.AddItem(1, 0, 0);
            f_List = new List<object>();
            f_NGen = new TPredicateNumGenerator();
            f_List.Add(Head);
            f_NGen.InitNum(1);
        }

          ~TGraphTFEConvertorTransNum() { }
      /*    void AddGTItem(TGraphTFEConvertorItem* AItem);
          AnsiString Make();*/
    }

}
