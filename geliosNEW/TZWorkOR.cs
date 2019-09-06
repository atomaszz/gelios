using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TZWorkOR : TBaseWorkShape
    {
        Point VPoint;
        Pen F_OldPenParent;
        /*      void CreateLines();
              protected TRectLine GetFirstLine();
              protected TRectLine  GetLastLine();
              protected int CalcBend(int t_x1, int t_x2);
              protected int GetTypeShape();*/
        public TZWorkOR(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id)
        {
          //  F_OldPenParent = new Graphics::TPen;
        }
        ~TZWorkOR() { }
/*        public void Init();
        public void Prepare();
        public void Paint(TCanvas* Canvas);
        public Point GetEndPoint();*/
    }
}
