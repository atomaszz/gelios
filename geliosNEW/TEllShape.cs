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
        override public void Paint(Graphics Canvas)
        {
        //    SaveCanvas(Canvas);
            base.Paint(Canvas);
            Pen tpen = new Pen(Color.Black, 2);
            Canvas.DrawEllipse(tpen, BoundRect);
            //     Ellipse(BoundRect.Left, BoundRect.Top, BoundRect.Right, BoundRect.Bottom);
            if (DrawCaption)
                Canvas.DrawString(Caption, new Font("Times New Roman", 12, FontStyle.Bold), new SolidBrush(Color.Black), BoundRect.X + BoundRect.Width / 4, BoundRect.Y + 2);
            //DrawText(Canvas.Handle, Caption.c_str(), -1, &BoundRect, DT_CENTER|DT_VCENTER|DT_SINGLELINE);;
        }
    }
}

