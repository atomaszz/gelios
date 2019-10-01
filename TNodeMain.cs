using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
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
    }
}
