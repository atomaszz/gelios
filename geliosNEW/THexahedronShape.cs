<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class THexahedronShape : TBaseShape
    {
        public THexahedronShape(int X, int Y, int step, int number = 0) :base(X, Y, step, number)
        {
            F_TypeShape = 4;
        }
        override public void Paint(Graphics Canvas)
        {
            Point[] P = new Point[6];
            int x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            int quot;
            x1 = BoundRect.Left;

            quot = ((BoundRect.Bottom - BoundRect.Top)/2);
            y1 = BoundRect.Top + quot;

            quot = ((BoundRect.Right - BoundRect.Left)/3);
            x2 = BoundRect.Left + quot;

            y2 = BoundRect.Top;

            quot = ((BoundRect.Right - BoundRect.Left)/3);
            x3 = BoundRect.Right - quot;

            y3 = BoundRect.Top;
            x4 = BoundRect.Right;
            y4 = y1;
            x5 = x3;
            y5 = BoundRect.Bottom;
            x6 = x2;
            y6 = BoundRect.Bottom;
            P[0] = new Point(x1, y1);
            P[1] = new Point(x2, y2);
            P[2] = new Point(x3, y3);
            P[3] = new Point(x4, y4);
            P[4] = new Point(x5, y5);
            P[5] = new Point(x6, y6);

            SaveCanvas(Canvas);
            base.Paint(Canvas);
            Canvas.DrawPolygon(new Pen(Color.Black,2),P);
         //   Canvas.DrawLines(new Pen(Color.Black), P);
            if (DrawCaption)
                Canvas.DrawString(Caption, new Font("Times New Roman", 12, FontStyle.Bold), new SolidBrush(Color.Black), BoundRect.X + 5, BoundRect.Y+2);
            //DrawText(Canvas.Handle, Caption.c_str(), -1, &BoundRect, DT_CENTER | DT_VCENTER | DT_SINGLELINE);
            RestoreCanvas(Canvas);
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class THexahedronShape : TBaseShape
    {
        public THexahedronShape(int X, int Y, int step, int number = 0) :base(X, Y, step, number)
        {
            F_TypeShape = 4;
        }
        override public void Paint(Graphics Canvas)
        {
            Point[] P = new Point[6];
            int x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            int quot;
            x1 = BoundRect.Left;

            quot = (BoundRect.Bottom - BoundRect.Top/2);
            y1 = BoundRect.Top + quot;

            quot = (BoundRect.Right - BoundRect.Left/3);
            x2 = BoundRect.Left + quot;

            y2 = BoundRect.Top;

            quot = (BoundRect.Right - BoundRect.Left/3);
            x3 = BoundRect.Right - quot;

            y3 = BoundRect.Top;
            x4 = BoundRect.Right;
            y4 = y1;
            x5 = x3;
            y5 = BoundRect.Bottom;
            x6 = x2;
            y6 = BoundRect.Bottom;
            P[0] = new Point(x1, y1);
            P[1] = new Point(x2, y2);
            P[2] = new Point(x3, y3);
            P[3] = new Point(x4, y4);
            P[4] = new Point(x5, y5);
            P[5] = new Point(x6, y6);

            SaveCanvas(Canvas);
            base.Paint(Canvas);
            Canvas.DrawPolygon(new Pen(Color.Black),P);
            if (DrawCaption)
                Canvas.DrawString(Caption, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(20, 20));
            //DrawText(Canvas.Handle, Caption.c_str(), -1, &BoundRect, DT_CENTER | DT_VCENTER | DT_SINGLELINE);
            RestoreCanvas(Canvas);
        }
    }
}
>>>>>>> parent of e24af0f... v 0.0.1001
