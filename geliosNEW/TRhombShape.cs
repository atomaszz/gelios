using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TRhombShape : TBaseShape
    {
        public static void GetPointRhomb(ref Point[] Pt, Rectangle Rect)
        {
            int x1, y1, x2, y2, x3, y3, x4, y4;
            int quot;
            x1 = Rect.Left;

            quot = (Rect.Bottom - Rect.Top)/2;
            y1 = Rect.Top + quot;

            quot = (Rect.Right - Rect.Left)/2;
            x2 = Rect.Right - quot;

            y2 = Rect.Top;
            x3 = Rect.Right;
            y3 = y1;
            x4 = x2;
            y4 = Rect.Bottom;
            Pt[0] = new Point(x1, y1);
            Pt[1] = new Point(x2, y2);
            Pt[2] = new Point(x3, y3);
            Pt[3] = new Point(x4, y4);
        }
        public TRhombShape(int X, int Y, int step, int number = 0) : base (X, Y, step, number)//:TBaseShape(number);
        {
            F_TypeShape = 3;
        }
        override public void Paint(Graphics Canvas)
        {
            Point[] P = new Point[4];
            GetPointRhomb(ref P, BoundRect);
            SaveCanvas(Canvas);
            base.Paint(Canvas);
            Canvas.DrawPolygon(new Pen(Color.Black,2), P);
            if (DrawCaption)
                Canvas.DrawString(Caption, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(20, 20));
            //      DrawText(Canvas.Handle, Caption.c_str(), -1, &BoundRect, DT_CENTER | DT_VCENTER | DT_SINGLELINE);
            RestoreCanvas(Canvas);
        }
    }
}
