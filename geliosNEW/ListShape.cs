using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TNodeAlt
    {
        public int ID;
        public int Num;
        public TNodeMain NodeStart;
        public TNodeMain NodeEnd;
        public TNodeAlt()
        {
            ID = -1;
            Num = -1;
            NodeStart = null;
            NodeEnd = null;
        }
    }
    class TNodeMain
    {
        public int IdAlternate;
        public int IdBlock;
        public int IdParentShape;
        public int NumAlt;
        public int TypeCreate;
        public TBaseWorkShape WorkShape;
        public TNodeMain Next;
        public TNodeMain Prior;
        public TNodeMain()
        {
            IdBlock = 0;
            IdParentShape = 0;
            IdAlternate = 0;
            NumAlt = 0;
            TypeCreate = 0;
            WorkShape = null;
            Prior = null;
            Next = null;
        }
        ~TNodeMain() { }
    };
    class TNodeAncestor
    {
        public int IdBlock;
        public int IdShapeAncestor;
        public TNodeAncestor()
        {
            IdBlock = 0;
            IdShapeAncestor = 0;
        }
    };
    class TNodeSearchController
    {
        List<object> List;
        TListNode MainList;
        void FreeSerchList()
        {
            TNodeSearch Node;
            for (int i = List.Count - 1; i >= 0; i--)
            {
                List.RemoveAt(i);
            }
        }
        int FindNextUid()
        {
            int i, j = 1;
            TNodeSearch Node;
            bool go = true;
            for (j = 1; j < Int32.MaxValue - 1; j++)
            {
                if (go)
                {
                    go = false;
                    for (i = 0; i <= List.Count - 1; i++)
                    {
                        Node = (TNodeSearch)List.ElementAt(i);
                        if (Node.UID == j)
                        {
                            go = true;
                            break;
                        }
                    }
                }
                else break;
            }
            return j;
        }
        TNodeSearch FindNode(int AUID)
        {
            TNodeSearch Node;
            for (int i = List.Count - 1; i >= 0; i--)
            {
                Node = (TNodeSearch)List.ElementAt(i);
                if (Node.UID == AUID) return Node;
            }
            return null;
        }
        public TNodeSearchController()
        {
            List = new List<object>();
            MainList = null;
        }
        ~TNodeSearchController() { }
        public void SetMainList(TListNode AList)
        {
            MainList = AList;
        }
        public TBaseWorkShape FindFirstChild(int AltId, int ANumAlt, int AIdParentShape, ref int AUID)
        {
            int nUid;
            TNodeMain TempN;
            TNodeSearch Node;
            nUid = FindNextUid();
            AUID = nUid;
            Node = new TNodeSearch();
            List.Add(Node);
            Node.UID = nUid;
            Node.indexFindChild = -1;
            TempN = MainList.SearchFirstNodeToAlternate(AltId, ANumAlt, AIdParentShape);
            while (TempN!=null)
            {
                Node.List.Add(TempN.WorkShape);
                TempN = MainList.SearchNextNodeToAlternate(AltId, ANumAlt, TempN);
            }
            if (Node.List.Count > 0)
            {
                Node.indexFindChild = 0;
                return (TBaseWorkShape)(Node.List.ElementAt(Node.indexFindChild));
            }
            return null;
        }
        public TBaseWorkShape FindNextChild(int AUID)
        {
            TNodeSearch Node = FindNode(AUID);
            if (Node!=null)
            {
                Node.indexFindChild++;
                if (Node.List.Count > Node.indexFindChild)
                    return (TBaseWorkShape)(Node.List.ElementAt(Node.indexFindChild));
            }
            return null;
        }
        public bool DisableFind(int AUID)
        {
            TNodeSearch Node;
            for (int i = List.Count - 1; i >= 0; i--)
            {
                Node = (TNodeSearch)List.ElementAt(i);
                if (Node.UID == AUID)
                {
                    List.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public void ClearAll()
        {
            FreeSerchList();
        }
    };
    class TNodeSearch
    {
        public int UID;
        public List<object> List;
        public int indexFindChild;
        public TNodeSearch()
        {
            List = new List<object>();
            UID = 0;
            indexFindChild = 0;
        }
        ~TNodeSearch() { }
    };
    class TPainterList
    {
        public List<object> List;
        int f_pos;
        public int GetCount()
        {
            return List.Count;
        }
        public TPainterList()
        {
            List = new List<object>();
            f_pos = 0;
        }
        ~TPainterList() { }
        public TBaseWorkShape First()
        {
            TBaseWorkShape Res = null;
            f_pos = 0;
            if (List.Count > 0)
                Res = (TBaseWorkShape)List.ElementAt(f_pos);
            return Res;
        }
        public TBaseWorkShape Next()
        {
            TBaseWorkShape Res = null;
            f_pos++;
            if ((List.Count > f_pos) && (f_pos >= 0))
                Res = (TBaseWorkShape)List.ElementAt(f_pos);
            return Res;
        }
        public TBaseWorkShape Prior()
        {
            TBaseWorkShape Res = null;
            f_pos--;
            if ((List.Count > f_pos) && (f_pos >= 0))
                Res = (TBaseWorkShape)List.ElementAt(f_pos);
            return Res;
        }
        public TBaseWorkShape Last()
        {
            TBaseWorkShape Res = null;
            if (List.Count > 0)
            {
                f_pos = List.Count - 1;
                Res = (TBaseWorkShape)List.ElementAt(f_pos);
            }
            return Res;
        }
        public void ClearAll()
        {
            List.Clear();
        }
        public bool IsExists(TBaseWorkShape AWS)
        {
            for (int i = 0; i <= List.Count - 1; i++)
            {
                if ((TBaseWorkShape)List.ElementAt(i) == AWS)
                    return true;
            }
            return false;
        }
        public int Count
        {
            get { return GetCount(); }
        }
    };

}
