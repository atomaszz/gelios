using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TStackDustItemWS
    {
        TNodeMain f_Node;
        int f_NodePos;  //возможно не нужно
        bool f_CheckNesting;
        bool f_CheckAlternate;
        public TStackDustItemWS(TNodeMain ANode)
        {
            f_Node = ANode;
            f_NodePos = -1;
            f_CheckNesting = f_CheckAlternate = false;
        }

        public bool CheckNesting
        {
            set { f_CheckNesting = value; }
            get { return f_CheckNesting; }
        }
        public bool CheckAlternate
        {
            set { f_CheckAlternate = value; }
            get { return f_CheckAlternate; }
        }
        public TNodeMain Node
        {
            get { return f_Node; }
        }
        public int NodePos
        {
            set { f_NodePos = value; }
            get { return f_NodePos; }
        }
    }
    class TStackDustController
    {
        List<object> f_ListWS;
        List<object> f_ListAlt;
        int f_posWS;
        int f_posAlt;
        void FreeListWS()
        {
            for (int i = f_ListWS.Count - 1; i >= 0; i--)
            {
               f_ListWS.RemoveAt(i);
            }
        }
        bool IsExistsNode(TNodeMain ANode)
        {
            TStackDustItemWS Item;
            for (int i = 0; i <= f_ListWS.Count - 1; i++)
            {
                Item = (TStackDustItemWS)f_ListWS.ElementAt(i);
                if (Item.Node == ANode)
                    return true;
            }
            return false;
        }
        bool IsExistsAlternate(TNodeAlt ANodeAlt)
        {
            for (int i = 0; i <= f_ListAlt.Count - 1; i++)
            {
                if ((TNodeAlt)f_ListAlt.ElementAt(i) == ANodeAlt)
                    return true;
            }
            return false;
        }

        public TStackDustController()
        {
            f_ListWS = new List<object>();
            f_ListAlt = new List<object>();
            f_posWS = f_posAlt = 0;
        }
        ~TStackDustController() { }
        public TStackDustItemWS FirstWS()
        {
            TStackDustItemWS Res = null;
            f_posWS = 0;
            if (f_ListWS.Count > 0)
                Res = (TStackDustItemWS)f_ListWS.ElementAt(f_posWS);
            return Res;
        }
        public TStackDustItemWS NextWS()
        {
            TStackDustItemWS Res = null;
            f_posWS++;
            if ((f_ListWS.Count > f_posWS) && (f_posWS >= 0))
                Res = (TStackDustItemWS)f_ListWS.ElementAt(f_posWS);
            return Res;
        }
        public TStackDustItemWS PriorWS()
        {
            TStackDustItemWS Res = null;
            f_posWS--;
            if ((f_ListWS.Count > f_posWS) && (f_posWS >= 0))
                Res = (TStackDustItemWS)f_ListWS.ElementAt(f_posWS);
            return Res;
        }
        public TStackDustItemWS LastWS()
        {
            TStackDustItemWS Res = null;
            if (f_ListWS.Count > 0)
            {
                f_posWS = f_ListWS.Count - 1;
                Res = (TStackDustItemWS)f_ListWS.ElementAt(f_posWS);
            }
            return Res;
        }
        public TNodeAlt FirstAlt()
        {
            TNodeAlt Res = null;
            f_posAlt = 0;
            if (f_ListAlt.Count > 0)
                Res = (TNodeAlt)f_ListAlt.ElementAt(f_posAlt);
            return Res;
        }
        public TNodeAlt NextAlt()
        {
            TNodeAlt Res = null;
            f_posAlt++;
            if ((f_ListAlt.Count > f_posAlt) && (f_posAlt >= 0))
                Res = (TNodeAlt)f_ListAlt.ElementAt(f_posAlt);
            return Res;
        }
        public TNodeAlt PriorAlt()
        {
            TNodeAlt Res = null;
            f_posAlt--;
            if ((f_ListAlt.Count > f_posAlt) && (f_posAlt >= 0))
                Res = (TNodeAlt)f_ListAlt.ElementAt(f_posAlt);
            return Res;
        }
        public TNodeAlt LastAlt()
        {
            TNodeAlt Res = null;
            if (f_ListAlt.Count > 0)
            {
                f_posAlt = f_ListAlt.Count - 1;
                Res = (TNodeAlt)f_ListAlt.ElementAt(f_posAlt);
            }
            return Res;
        }
        public void ClearAll()
        {
            FreeListWS();
            f_ListAlt.Clear();
        }
        public void AddNode(TNodeMain ANode, int APos)
        {
            if (!IsExistsNode(ANode))
            {
                TStackDustItemWS Item = new TStackDustItemWS(ANode);
                Item.NodePos = APos;
                f_ListWS.Add(Item);
            }
        }
        public void AddAlternate(TNodeAlt ANodeAlt)
        {
            if (!IsExistsAlternate(ANodeAlt))
                f_ListAlt.Add(ANodeAlt);
        }
    };
}
