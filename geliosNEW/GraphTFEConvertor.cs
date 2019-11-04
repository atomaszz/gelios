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
        /*      int __fastcall GetParentID();
              AnsiString __fastcall GetAlias();
              AnsiString ListIDFromTFE();
              void DoMake();
              TBaseShape* __fastcall GetParentBaseShape();
              public:
           TGraphTFEConvertorItem();
              void Make(TPredicateItemBase* AItem, TPredicateItemBig* AParent);
              void ListIDFromTFE(TDynamicArray* AL);
              __property AnsiString OutString = {read = f_Out
          };
          __property TPredicateItemBase* Item = { read = f_Item };
          __property TPredicateItemBig* Parent = { read = f_Parent };
          __property int ParentID = { read = GetParentID };
          __property AnsiString Alias = {read = GetAlias
      };
      __property TBaseShape* ParentBaseShape = { read = GetParentBaseShape };*/
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
        void PushTFS(TPredicateItemTFS ATFS, TDynamicArray AStack)
        {
            int m_type = ATFS.TFS.BaseWorkShape.TypeShape;
            if ((m_type != 1) || ((m_type == 1) && (ATFS.EnvelopeBIG!=null)))
                AStack.InsertToFirst(ATFS);
            for (int i = 0; i <= ATFS.TFECount - 1; i++)
                if (ATFS.GetTFEItems(i).Big!=null)
                    AStack.InsertToFirst(ATFS.GetTFEItems(i).Big);
        }
        void CheckParseItem(TPredicateItemBase ABase, TDynamicArray AStack)
        {
            int m_type;
            TPredicateItemPWork m_PW;
            if (ABase!=null)
            {
                m_type = ABase.Who();
                if (m_type == 0)
                    PushTFS((TPredicateItemTFS)(ABase), AStack);
                if (m_type == 1)
                    PushBig((TPredicateItemBig)(ABase), AStack);
                if (m_type == 2)
                    PushPWork((TPredicateItemPWork)(ABase), AStack);
            }
        }
        void PushBig(TPredicateItemBig ABig, TDynamicArray AStack)
        {
            if (ABig.Envelope)
            {
                TPredicateItemBase B = ABig.GetItems(0);
                B.EnvelopeBIG = ABig;
                int m_who = B.Who();
                if ((m_who == 2) || (m_who == 1))
                    AStack.InsertToFirst(B);
                if (m_who == 0)
                    PushTFS((TPredicateItemTFS)(B), AStack);
            }
            else
                AStack.InsertToFirst(ABig);
        }
        /*    void PushPWork(TPredicateItemPWork* APWork, TDynamicArray* AStack);
            AnsiString PrintPWork(TPredicateItemPWork* APWork, TDynamicArray* AStack);
            AnsiString PrintBig(TPredicateItemBig* ABig, TDynamicArray* AStack);
            AnsiString ParseItem(TPredicateItemBase* ABase, TDynamicArray* AStack);*/

        TPredicateItemBase DoParseItem(TPredicateItemBase ABase, TDynamicArray AStack)
        {
            TPredicateItemBase Res = null;
            int m_who = ABase.Who();
            if (m_who == 1)
            {
                TPredicateItemBig m_Big = (TPredicateItemBig)(ABase);
                Res = DoPrintBig(m_Big, AStack);
            }
            if (m_who == 2)
            {
                TPredicateItemPWork m_PW = (TPredicateItemPWork)(ABase);
                Res = DoPrintPWork(m_PW, AStack);
            }
            if (m_who == 0)
                Res = ABase;
            return Res;
        }
        TPredicateItemPWork DoPrintPWork(TPredicateItemPWork APWork, TDynamicArray AStack)
        {
            CheckParseItem(APWork.Item1, AStack);
            CheckParseItem(APWork.Item2, AStack);
            return APWork;
        }
        TPredicateItemBig DoPrintBig(TPredicateItemBig ABig, TDynamicArray AStack)
        {
            TPredicateItemBig Res = null;
            TPredicateItemBase m_Base;
            if (!ABig.Envelope)
            {
                if (ABig.Rfc.ParentTFE!=null && ABig.Print)
                    Res = ABig;
                int m_cnt = ABig.Count;
                for (int i = 0; i <= m_cnt - 1; i++)
                {
                    m_Base = ABig.GetItems(i);
                    m_Base.EnvelopeBIG = ABig;
                    CheckParseItem(m_Base, AStack);
                }
            }
            return Res;
        }
         /*     void MakeElement(TPredicateItemBase* AElement);
              void MakeElementTFS(TPredicateItemTFS* ATFS);
              void AddElementToTree(TPredicateTree* APredicateTree);
              public:
               TGraphTFEConvertor();
              ~TGraphTFEConvertor();*/
        public void Init(TPredicateItemBig AHead, TPredicateTree APredicateTree)
        {
            string SC;
            bool pass;
            TPredicateItemBase Base, NC;
            f_PrStruct = "";
            f_PrRab = "";
            f_PrControlRab = "";
            f_PrControlFunc = "";
            f_PrCheckCondition = "";
            TDynamicArray m_Stack = new TDynamicArray();
            m_Stack.InsertToFirst(AHead);
            Base = (TPredicateItemBase)(m_Stack.Pop());
            while (Base!=null)
            {
                NC = DoParseItem(Base, m_Stack);
                if (NC!=null)
                    f_BTree.insert(NC);
                Base = (TPredicateItemBase)(m_Stack.Pop());
            }
            m_Stack = null;


            SharedConst.lcList.clear();
            f_BTree.inorder(acp);
            SharedConst.lcList.first();
            for (int i = 0; i <= SharedConst.lcList.length() - 1; i++)
            {
                Base = (TPredicateItemBase)(SharedConst.lcList.val());
                f_Item.Make(Base, Base.EnvelopeBIG);
                SC = f_Item.OutString;
                if (SC.Length > 0)
                {
                    f_PrStruct = f_PrStruct + SC + "\r\n";
                    MakeElement(Base);
                    if (APredicateTree!=null)
                        AddElementToTree(APredicateTree);
                }
                //  MakeElement(Base);
                //  f_Tran.AddGTItem(f_Item);
                SharedConst.lcList.next();
            }
            // f_TextRecalc = f_Tran.Make();

        }
        /*    __property AnsiString PrStruct = {read = f_PrStruct
        };
        __property AnsiString TextRecalc = {read = f_TextRecalc};
             __property AnsiString PrRab = {read = f_PrRab};
             __property AnsiString PrControlRab = {read = f_PrControlRab};
             __property AnsiString PrControlFunc = {read = f_PrControlFunc};
             __property AnsiString PrCheckCondition = {read = f_PrCheckCondition};*/
    }
}
