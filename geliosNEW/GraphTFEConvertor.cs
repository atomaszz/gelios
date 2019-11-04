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
        int GetParentID()
        {
            if (f_Parent==null)
                return 0;
            if (f_Parent.Rfc!=null)
            {
                TAlternativeParserItemTFE ITE = f_Parent.Rfc.ParentTFE;
                if (ITE!=null)
                    return ITE.TFE.BaseShape.ID;
            }
            return f_Parent.ID;
        }
        string GetAlias()
        {
            string Res = "";
            int mType = f_Item.Who();
            if (mType == 1)
                return "rab_oper";
            if (mType == 2)
                return "rab_oper_posl";
            mType = ((TPredicateItemTFS)(f_Item)).TFS.BaseWorkShape.TypeShape;
            switch (mType)
            {
                case 1:
                    {
                        Res = "rab_oper";
                        break;
                    }
                case 2:
                    {
                        Res = "rab_oper_par_AND";
                        break;
                    }
                case 3:
                    {
                        Res = "rab_oper_par_OR";
                        break;
                    }

                case 4:
                    {
                        Res = "diagn_control_rab";
                        break;
                    }
                case 5:
                    {
                        Res = "diagn_func_coltrol";
                        break;
                    }
                case 6:
                    {
                        Res = "rasvilka";
                        break;
                    }

                case 7:
                    {
                        Res = "proverka_if";
                        break;
                    }

                case 8:
                    {
                        Res = "while_do_control_rab";
                        break;
                    }

                case 9:
                    {
                        Res = "do_while_do_control_rab";
                        break;
                    }

                case 10:
                    {
                        Res = "do_while_do_control_func";
                        break;
                    }


                case 11:
                    {
                        Res = "proverka_uslovia";
                        break;
                    }
            }
            return Res;
        }
        string ListIDFromTFE()
        {
            int n, cnt;
            string Res = "";
            TDynamicArray D = new TDynamicArray();
            f_Item.ListIDFill(D);
            cnt = D.Count;
            for (int i = 0; i <= cnt - 1; i++)
            {
                n = D.GetPosition(i).Int_Value;
                Res = Res + n.ToString();
                if ((i != cnt - 1) && (cnt > 1))
                    Res = Res + ", ";
            }
            D = null;
            return Res;
        }
        void DoMake()
           {
               f_Out = "";
               if (f_Item!=null)
               {
                   f_Out = "knot(" + GetParentID().ToString() + "," + (f_Item.NumAlt + 1).ToString() + ", ";
                   f_Out = f_Out + GetAlias() + ", " + "[" + ListIDFromTFE() + "]).";
               }
           }
           /*       TBaseShape* __fastcall GetParentBaseShape();
                  public:
               TGraphTFEConvertorItem();*/
        public void Make(TPredicateItemBase AItem, TPredicateItemBig AParent)
        {
            f_Item = AItem;
            f_Parent = AParent;
            DoMake();
        }
        public void ListIDFromTFE(TDynamicArray AL)
        {
            f_Item.ListIDFill(AL);
        }
        public string  OutString
        {
            get { return f_Out;  }
        }
      /*     __property TPredicateItemBase* Item = { read = f_Item };
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
        void PushPWork(TPredicateItemPWork APWork, TDynamicArray AStack)
        {
            AStack.InsertToFirst(APWork);
        }
        /*        AnsiString PrintPWork(TPredicateItemPWork* APWork, TDynamicArray* AStack);
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
        void MakeElement(TPredicateItemBase AElement)
        {
            int m_who = AElement.Who();
            if (m_who == 1)
            {
                //throw(Exception("недопустимо использование MakeElement(TPredicateItemBase* AElement). Обратитесь к разработчикам!"));
            }
            if (m_who == 2)
            {
                TPredicateItemPWork m_PW = (TPredicateItemPWork)(AElement);
                MakeElement(m_PW.Item1);
                MakeElement(m_PW.Item2);
            }
            if (m_who == 0)
            {
                TPredicateItemTFS m_TFS = (TPredicateItemTFS)(AElement);
                MakeElementTFS(m_TFS);
            }
        }
        void MakeElementTFS(TPredicateItemTFS ATFS)
        {
            int n, m_who;
            TBaseShape B;
            string S;
            TDynamicArray D = new TDynamicArray();
            TBaseWorkShape WS = ATFS.TFS.BaseWorkShape;
            ATFS.ListIDFill(D);
            for (int i = 0; i <= D.Count - 1; i++)
            {
                n = D.GetPosition(i).Int_Value;
                B = WS.ShapeSupportID(n);
                m_who = B.TypeShape;
                S = B.Make_One_Simple();
                if (S.Length > 0)
                {
                    if (m_who == 5)
                        f_PrRab = f_PrRab + S + "\r\n";
                    if (m_who == 6)
                        f_PrControlRab = f_PrControlRab + S + "\r\n";
                    if (m_who == 7)
                        f_PrControlFunc = f_PrControlFunc + S + "\r\n";
                    if (m_who == 8)
                        f_PrCheckCondition = f_PrCheckCondition + S + "\r\n";
                }
            }
            D = null;
        }
        void AddElementToTree(TPredicateTree APredicateTree)
        {
            TPredicateTreeItem N = APredicateTree.NewPredicateTreeItem();
            N.ParentID = f_Item.ParentID;
            N.ParentShape = f_Item.ParentBaseShape;
            N.NumAlt = f_Item.Item.NumAlt + 1;
            int m_type, m_who = f_Item.Item.Who();
            m_type = -1;
            if (m_who == 0)
            {
                N.BaseWorkShape = (TPredicateItemTFS)(f_Item.Item).TFS.BaseWorkShape;
                m_type = N.BaseWorkShape.TypeShape;
            }
            if (m_who == 1)
                m_type = 12;
            if (m_who == 2)
                m_type = 13;
            N.TypeWorkShape = m_type;

            TDynamicArray D = new TDynamicArray();
            f_Item.Item.ListIDFill(D);
            int cnt = D.Count;
            for (int i = 0; i <= cnt - 1; i++)
                N.AddBaseShape((TBaseShape)(D.Position[i].P), D.Position[i].Int_Value);
            D = null;
        }
     /*   public:
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

            bool acp(object A)
            {
                SharedConst.lcList.append(A);
                return true;
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
