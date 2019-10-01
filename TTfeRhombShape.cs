using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TTfeRhombShape : TRhombShape
    {
        TTail T0;
        TTail T1;
        TTail T2;
        TTail T3;

        bool F_TailLeft;
        bool F_TailTop;
        bool F_TailBottom;
        bool F_TailRight;

        void SetTailLeft(bool Value)
        {
            F_TailLeft = Value;
            SetTail();
        }
        void SetTailTop(bool Value)
        {
            F_TailTop = Value;
            SetTail();
        }
        void SetTailBottom(bool Value)
        {
            F_TailBottom = Value;
            SetTail();
        }
        void SetTailRight(bool Value)
        {
            F_TailRight = Value;
            SetTail();
        }
        void SetTail()
        {
            Point Point;
            int X, Y;
            if (F_TailLeft)
            {
                Point = Point_StartShape;
                T0.PointEnd = Point;
                Point.X = Point.X - F_Step * 2;
                T0.PointStart = Point;
            }
            if (F_TailTop)
            {
                X = BoundRect.Left + ((BoundRect.Right - BoundRect.Left) / 2);
                Y = BoundRect.Top;
                Point = new Point(X, Y);
                T1.PointStart = Point;
                Point.Y = Point.Y - F_Step * 2;
                T1.PointEnd = Point;
            }
            if (F_TailRight)
            {
                Point = Point_EndShape;
                T2.PointStart = Point;
                Point.X = Point.X + F_Step * 2;
                T2.PointEnd = Point;
            }

            if (F_TailBottom)
            {
                X = BoundRect.Left + ((BoundRect.Right - BoundRect.Left) / 2);
                Y = BoundRect.Bottom;
                Point = new Point(X, Y);
                T3.PointStart = Point;
                Point.Y = Point.Y + F_Step * 2;
                T3.PointEnd = Point;
            }
        }
        //      void CopyPen();
        protected Point GetPointTailStartShape()
        {
            Point Res = new Point(0, 0);
            GetTailPoint(0, ref Res);
            return Res;
        }
        protected Point GetPointTailEndShape()
        {
            Point Res = new Point(0, 0);
            GetTailPoint(2, ref Res);
            return Res;
        }

        public TTfeRhombShape(int X, int Y, int step, int number = 0) : base(X, Y, step, number)
        {
            Rectangle R;
            F_TypeShape = 6;
            F_TailLeft = F_TailTop = F_TailBottom = F_TailRight = false;

            T0 = new TTail(0, 0, 0, 0, step);
            T1 = new TTail(0, 0, 0, 0, step);
            T2 = new TTail(0, 0, 0, 0, step);
            T3 = new TTail(0, 0, 0, 0, step);

            R = BoundRect;
            R.X = R.Left + F_Step * 2;
            R.Width = F_Step * 4;
            BoundRect = R;
        }
        ~TTfeRhombShape() { }
        public bool GetTailPoint(int num, ref Point pt)
        {
            bool res = (((num == 0) && (F_TailLeft))
                     || ((num == 1) && (F_TailTop))
                     || ((num == 2) && (F_TailRight))
                     || ((num == 3) && (F_TailBottom)));
            if (num == 0)
                pt = T0.PointStart;
            if (num == 1)
                pt = T1.PointEnd;
            if (num == 2)
                pt = T2.PointEnd;
            if (num == 3)
                pt = T3.PointEnd;

            return res;
        }
        override public void SetRect(int X, int Y, int Width, int Height)
        {
            base.SetRect(X + F_Step * 2, Y, Width, Height);
            SetTail();
        }
        override public void SetRect(Rectangle Rect)
        {
            Rectangle Temp = Rect;
            Temp.X = Temp.Left + F_Step * 2;
            Temp.Width = F_Step * 2;
            base.SetRect(Temp);
            SetTail();
        }
        override public void SetBaseRect(Rectangle Rect)
        {
            base.SetBaseRect(Rect);
            SetTail();
        }
        override public void Paint(Graphics Canvas)
        {
            SetTail();
          //  CopyPen();
            base.Paint(Canvas);
            T0.Paint(Canvas);
            T1.Paint(Canvas);
            T2.Paint(Canvas);
            T3.Paint(Canvas);
        }
        override public bool CopyObject(TBaseShape ASource)
        {
            /*   base.CopyObject(ASource);
               dynamic_cast<TTfeRhombShape)(ASource).TailLeft = F_TailLeft;
               dynamic_cast<TTfeRhombShape)(ASource).TailTop = F_TailTop;
               dynamic_cast<TTfeRhombShape)(ASource).TailBottom = F_TailBottom;
               dynamic_cast<TTfeRhombShape)(ASource).TailRight = F_TailRight;*/
            return true;
        }
        /*    public AnsiString Make_One_SimpleItem(int AIndex);*/
        public  bool TailLeft
        {
            set { SetTailLeft(value); }
            get { return F_TailLeft;  }
        }
        public bool TailTop
        {
            set { SetTailTop(value); }
            get { return F_TailTop; }
        }
        public bool TailBottom
        {
            set { SetTailBottom(value); }
            get { return F_TailBottom; }
        }
        public bool TailRight
        {
            set { SetTailRight(value); }
            get { return F_TailRight; }
        }
    }
}
