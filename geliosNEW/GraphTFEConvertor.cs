using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TGraphTFEConvertorItem
    {
        string f_Out;
        TPredicateItemBase f_Item;
        TPredicateItemBig f_Parent;
        /*      int GetParentID();
              string  GetAlias();
              string ListIDFromTFE();
              void DoMake();
              TBaseShape  GetParentBaseShape();*/
        public TGraphTFEConvertorItem()
        {
            f_Out = "";
            f_Item = null;
            f_Parent = null;
        }
 /*       public void Make(TPredicateItemBase AItem, TPredicateItemBig AParent);
        public void ListIDFromTFE(TDynamicArray AL);
        public string OutString = {read = f_Out
        public TPredicateItemBase* Item = { read = f_Item };
        public TPredicateItemBig* Parent = { read = f_Parent };
        public int ParentID = { read = GetParentID };
        public AnsiString Alias = {read = GetAlias
        public TBaseShape* ParentBaseShape = { read = GetParentBaseShape };*/
    }



    class TGraphTFEConvertor
    {
        string f_PrStruct;
        string f_PrRab;
        string f_PrControlRab;
        string f_PrControlFunc;
        string f_PrCheckCondition;


        string f_TextRecalc;
        TGraphTFEConvertorItem f_Item;
        TGlsBinaryTree f_BTree;
        TGraphTFEConvertorTransNum f_Tran;
        /*   void PushTFS(TPredicateItemTFS* ATFS, TDynamicArray* AStack);
           void CheckParseItem(TPredicateItemBase* ABase, TDynamicArray* AStack);
           void PushBig(TPredicateItemBig* ABig, TDynamicArray* AStack);
           void PushPWork(TPredicateItemPWork* APWork, TDynamicArray* AStack);
           AnsiString PrintPWork(TPredicateItemPWork* APWork, TDynamicArray* AStack);
           AnsiString PrintBig(TPredicateItemBig* ABig, TDynamicArray* AStack);
           AnsiString ParseItem(TPredicateItemBase* ABase, TDynamicArray* AStack);

           TPredicateItemBase* DoParseItem(TPredicateItemBase* ABase, TDynamicArray* AStack);
           TPredicateItemPWork* DoPrintPWork(TPredicateItemPWork* APWork, TDynamicArray* AStack);
           TPredicateItemBig* DoPrintBig(TPredicateItemBig* ABig, TDynamicArray* AStack);
           void MakeElement(TPredicateItemBase* AElement);
           void MakeElementTFS(TPredicateItemTFS* ATFS);
           void AddElementToTree(TPredicateTree* APredicateTree);
           public:*/
        public TGraphTFEConvertor()
        {
            f_Item = new TGraphTFEConvertorItem();
            f_BTree = new TGlsBinaryTree(SharedConst.CompareNode);
            f_Tran = new TGraphTFEConvertorTransNum();
        }
           ~TGraphTFEConvertor() { }
     /*      void Init(TPredicateItemBig* AHead, TPredicateTree* APredicateTree);
           __property AnsiString PrStruct = {read = f_PrStruct
       };
       __property AnsiString TextRecalc = {read = f_TextRecalc};
            __property AnsiString PrRab = {read = f_PrRab};
            __property AnsiString PrControlRab = {read = f_PrControlRab};
            __property AnsiString PrControlFunc = {read = f_PrControlFunc};
            __property AnsiString PrCheckCondition = {read = f_PrCheckCondition};
            */
    }
}
