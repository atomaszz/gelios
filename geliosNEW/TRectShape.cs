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
        override public void Paint(Graphics Canvas)
        {
            SaveCanvas(Canvas);
            base.Paint(Canvas);
            Canvas.DrawRectangle(new Pen(Color.Blue,2),BoundRect.Left, BoundRect.Top, BoundRect.Width, BoundRect.Height);
            if (DrawCaption)
                Canvas.DrawString(Caption, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(10, 10));
            //        DrawText(Canvas.Handle, Caption.c_str(), -1, &BoundRect, DT_CENTER | DT_VCENTER | DT_SINGLELINE);
            RestoreCanvas(Canvas);
        }
    }
}
