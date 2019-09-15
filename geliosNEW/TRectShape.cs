using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TRectShape : TBaseShape
    {
        public bool PowerIn()
        {
            return true;
        }
        public TRectShape(int X, int Y, int step, int number = 0) :base(X, Y, step, number)
        {
            Rectangle R = new Rectangle(X,Y - step * 2, step * 8, step * 4);
            BoundRect = R;
            F_TypeShape = 1;
        }
     /*   public void Paint(TCanvas Canvas)
        {
            SaveCanvas(Canvas);
            TBaseShape::Paint(Canvas);
            Canvas.Rectangle(BoundRect.Left, BoundRect.Top, BoundRect.Right, BoundRect.Bottom);
            if (DrawCaption)
                DrawText(Canvas.Handle, Caption.c_str(), -1, &BoundRect, DT_CENTER | DT_VCENTER | DT_SINGLELINE);
            RestoreCanvas(Canvas);
        }*/
    }
}
