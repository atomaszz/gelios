using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TControlFunc : TBaseWorkShape
    {
  /*      void CreateLines();
        int CalcBend(int t_x1, int t_x2);
        void ShapeCopy(TBaseShape Shape, int Num_Shape);

        protected TRectLine  GetFirstLine();
        protected TRectLine  GetLastLine();
        protected int  GetTypeShape();*/

        public TControlFunc(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
    /*    public void Init();
        public void Prepare();
        public void Paint(TCanvas Canvas);
        public TPoint  GetEndPoint();
        public bool CanAlternate(int ID_Shape1, int ID_Shape2);*/
    }
}
