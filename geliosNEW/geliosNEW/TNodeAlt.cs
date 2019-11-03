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
}
