using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TTreeStackItem
    {
        bool f_Fixed;
        int f_Level;
        public TTreeStackItem() { f_Fixed = false; f_Level = -1; }
        public bool Fixed { set { f_Fixed = value; } get { return f_Fixed; } }
        public int Level  { set { f_Level = value; } get { return f_Level; } }
    }
    class TTreeStack
    {
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
        public TTreeStack()
        {
            f_List = new List<object>();
        }
        ~TTreeStack() { }
        public void AddToStack(int ALevel)
        {
            TTreeStackItem Item;
            for (int i = f_List.Count - 1; i >= 0; i--)
            {
                Item = (TTreeStackItem)(f_List.ElementAt(i));
                if (Item.Level == ALevel) return;
            }
            Item = new TTreeStackItem();
            Item.Level = ALevel;
            f_List.Add(Item);
        }
        public void Clear()
        {
            FreeList();
        }
        public TTreeStackItem GetLevel()
        {
            TTreeStackItem Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TTreeStackItem)(f_List.ElementAt(i));
                if (!Item.Fixed)
                    return Item;
            }
            return null;
        }
    }

    class TTreeList
    {
        TMainTreeList f_TreeList;
        TTreeStack f_Stack;
        TAltInfo f_AltInfo;
        void Init(int ALevel)
        {
            f_TreeList.Clear();
            f_TreeList.Level = ALevel;//08.11.2007
            f_Stack.Clear();
            f_Stack.AddToStack(ALevel);
            f_AltInfo.Clear();
        }
        TMainTreeList FindByLevel(TMainTreeList ABegin, int ALevel)
        {
            TMainTreeList Res = null;
            TDynamicArray Dyn = new TDynamicArray();
            Dyn.Append(ABegin);
            int q = 0;
            while (Dyn.GetItems(q)!=null)
            {
                Res = (TMainTreeList)(Dyn.GetItems(q));
                for (int i = 0; i <= Res.ItemCount - 1; i++)
                    for (int j = 0; j <= Res.GetAlternateItem(i).ItemCount - 1; j++)
                        for (int k = 0; k <= Res.GetAlternateItem(i).GetTreeTFSItem(j).ItemCount - 1; k++)
                            if (Res.GetAlternateItem(i).GetTreeTFSItem(j).GetTreeTFEItem(k).MainNode != null)
                            {
                                Dyn.Append(Res.GetAlternateItem(i).GetTreeTFSItem(j).GetTreeTFEItem(k).MainNode);
                            }
                q++;
            }


            for (int i = 0; i <= Dyn.Count - 1; i++)
            {
                Res = (TMainTreeList)(Dyn.GetItems(i));
                if (Res.Level == ALevel)
                {
                    Dyn.Clear();
                    return Res;
                }
            }
            Dyn.Clear();
            return null;
        }
        public void FillTreeFromList(ref TListNode AListNode)
        {
            TTreeStackItem Item;
            TAltInfoItem AltInfoItem;
            TAlternateTreeList AT;
            TNodeMain Node;
            TTreeListTFS Tfs;
            TMainTreeList AMT;
            TMainTreeList MNew;
            TTreeListItem LI;
            Init(0);
            Item = f_Stack.GetLevel();
            while (Item!=null)
            {
                AMT = FindByLevel(f_TreeList, Item.Level);
                if (AMT!=null)
                {
                    AListNode.LoadInfoForAlternate(ref f_AltInfo, Item.Level);
                    for (int i = 0; i <= f_AltInfo.ItemCount - 1; i++)
                    {
                        AltInfoItem = f_AltInfo.GetItem(i);
                        AT = new TAlternateTreeList();
                        AT.MainAlternative = AltInfoItem.Main;
                        AT.NodeStart = AltInfoItem.NodeStart;
                        AT.NodeEnd = AltInfoItem.NodeEnd;
                        AT.ID = AltInfoItem.ID;
                        AT.Num = AltInfoItem.Num;
                        Node = AListNode.SearchFirstNodeToAlternate(AltInfoItem.ID, AltInfoItem.Num, Item.Level);
                        while (Node!=null)
                        {
                            Tfs = new TTreeListTFS(Node.WorkShape);
                            AT.AddToAlternate(Tfs);
                            for (int j = 0; j <= Tfs.ItemCount - 1; j++)
                            {
                                LI = Tfs.GetTreeTFEItem(j);
                                f_Stack.AddToStack(LI.BaseShape.ID);
                                if (AListNode.IsContainsChildShape(LI.BaseShape.ID))
                                {
                                    if (LI.MainNode==null)
                                    {
                                        MNew = new TMainTreeList();
                                        MNew.Level = LI.BaseShape.ID;
                                        LI.MainNode = MNew;
                                    }
                                }
                            }
                            Node = AListNode.SearchNextNodeToAlternate(AltInfoItem.ID, AltInfoItem.Num, Node);
                        }
                        AMT.AddToTree(AT);
                    }
                }
                Item.Fixed = true;
                Item = f_Stack.GetLevel();
            }
        }
        /*       void FillTreeFromList(TListNode* AListNode, int AParentShapeID, TBaseWorkShape* AStart, TBaseWorkShape* AEnd);*/
        public TTreeList()
        {
            f_TreeList = new TMainTreeList ();
            f_TreeList.Level = 0;
            f_Stack = new TTreeStack();
            f_AltInfo = new TAltInfo();
        }

        ~TTreeList() { }
        public TMainTreeList MainTreeList
        {
            get { return f_TreeList; }
        }
    }
}
