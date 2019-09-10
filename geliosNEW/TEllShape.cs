using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    class TEllShape : TBaseShape
    {
        public TEllShape(int X, int Y, int step, int number = 0) :base(X, Y, step, number)
        {
            F_TypeShape = 2;
        }
        public virtual void Paint(PaintEventArgs Canvas)
        {
        //    SaveCanvas(Canvas);
            base.Paint(Canvas);
            Pen tpen = new Pen(Color.Black, 2);
            Canvas.Graphics.DrawEllipse(tpen, BoundRect);
            //     Ellipse(BoundRect.Left, BoundRect.Top, BoundRect.Right, BoundRect.Bottom);
            if (DrawCaption)
                Canvas.Graphics.DrawString(Caption, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(10, 10));
            //DrawText(Canvas.Handle, Caption.c_str(), -1, &BoundRect, DT_CENTER|DT_VCENTER|DT_SINGLELINE);;
        }
    }
}

