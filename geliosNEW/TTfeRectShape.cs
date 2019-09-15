using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    class TTfeRectShape : TRectShape
    {
        TTail Start;
        TTail End;
        void SetTail()
        {
            Point Point;
            Point = Point_StartShape;
            Start.PointEnd = Point;
            Point.X = Point.X - F_Step * 2;
            Start.PointStart = Point;

            Point = Point_EndShape;
            End.PointStart = Point;
            Point.X = Point.X + F_Step * 2;
            End.PointEnd = Point;

        }
     //   void CopyPen();
 /*       protected TBaseLine  GetBaseLine(int AIndex);
        protected int GetBaseLineCount();
        protected Point GetPointTailStartShape();
        protected Point GetPointTailEndShape();*/

        public TTfeRectShape(int X, int Y, int step, int number = 0) : base(X, Y, step, number)
        {
            Rectangle R;
            F_TypeShape = 5;
            Start = new TTail(0, 0, 0, 0, step);
            End = new TTail(0, 0, 0, 0, step);

            R = BoundRect;
            R.X = R.Left + F_Step * 2;
            R.Y = R.Right + F_Step * 2;
            BoundRect = R;

            SetTail();
        }
        ~TTfeRectShape() { }
        public bool GetTailPoint(int num, ref Point pt)
        {
            bool res = ((num == 0) || (num == 1));
            if (num == 0)
                pt = Start.PointStart;
            if (num == 1)
                pt = End.PointEnd;
            return res;
        }
        /*    public void SetRect(int X, int Y, int Width, int Height);
            public void SetRect(TRect Rect);
            public void SetBaseRect(TRect Rect);
            public void Paint(PaintEventArgs Canvas);
            public bool CopyObject(TBaseShape ASource);
            public string  Make_One_SimpleItem(int AIndex);*/
    }
}
