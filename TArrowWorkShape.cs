using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TArrowWorkShape : TBaseWorkShape
    {
  /*      int  GetCountNodeHind();
        int  GetNodeHintItem(int AIndex);*/
        public TArrowWorkShape(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) 
            : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
        ~TArrowWorkShape() { }
 /*       public bool AddNodeHint(int ANum);
        public bool DeleteNodeHint(int ANum);
        public bool IsEmptyNodeHint();
        public void Init();
        public TRect GetRegionRect();
        public TRect GetSmallRegionRect();
        public int CountNodeHint = { read = GetCountNodeHind };
        public int NodeHind[int AIndex] = { read = GetNodeHintItem };*/
    }
}
