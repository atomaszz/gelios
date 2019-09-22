using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TTfeEllShape : TEllShape
    {
        TTail T0;
        TTail T1;
        TTail T2;
        TTail T3;

        bool F_TailLeft;
        bool F_TailTop;
        bool F_TailBottom;
        bool F_TailRight;

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
                X = BoundRect.Left + (BoundRect.Right - BoundRect.Left) / 2;
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
                X = BoundRect.Left + (BoundRect.Right - BoundRect.Left) / 2;
                Y = BoundRect.Bottom;
                Point = new Point(X, Y);
                T3.PointStart = Point;
                Point.Y = Point.Y + F_Step * 2;
                T3.PointEnd = Point;
            }
        }

        void  SetTailLeft(bool Value)
        {
            F_TailLeft = Value;
            SetTail();
        }
        void  SetTailTop(bool Value)
        {
            F_TailTop = Value;
            SetTail();
        }
        void  SetTailBottom(bool Value)
        {
            F_TailBottom = Value;
            SetTail();
        }
        void  SetTailRight(bool Value)
        {
            F_TailRight = Value;
            SetTail();
        }
        void CopyPen()
        {
            T0.Color = PenColor;
            T0.Width = PenWidth;
        //    T0.Style = PenStyle;
         //   T0.Mode = PenMode;

            T1.Color = PenColor;
            T1.Width = PenWidth;
        //    T1.Style = PenStyle;
        //    T1.Mode = PenMode;

            T2.Color = PenColor;
            T2.Width = PenWidth;
        //    T2.Style = PenStyle;
       //     T2.Mode = PenMode;

            T3.Color = PenColor;
            T3.Width = PenWidth;
       //     T3.Style = PenStyle;
       //     T3.Mode = PenMode;
        }
        protected Point  GetPointTailStartShape()
        {
            Point Res = new Point(0, 0);
            GetTailPoint(0, ref Res);
            return Res;
        }
        protected Point  GetPointTailEndShape()
        {
            Point Res = new Point(0, 0);
            GetTailPoint(2, ref Res);
            return Res;
        }
        public TTfeEllShape(int X, int Y, int step, int number = 0) : base(X, Y, step, number)
        {
            Rectangle R;
            F_TypeShape = 7;
            F_TailLeft = F_TailTop = F_TailBottom = F_TailRight = false;
            T0 = new TTail(0, 0, 0, 0, step);
            T1 = new TTail(0, 0, 0, 0, step);
            T2 = new TTail(0, 0, 0, 0, step);
            T3 = new TTail(0, 0, 0, 0, step);

            R = BoundRect;
            R.X = R.Left + F_Step * 2;
   //         R.Right = R.Right + F_Step * 2;
            BoundRect = R;
        }
        ~TTfeEllShape() { }
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
          //  Temp.Right = Temp.Right + F_Step * 2;
            base.SetRect(Temp);
            SetTail();
        }
        override public void Paint(Graphics Canvas)
        {
            SetTail();
            CopyPen();
            base.Paint(Canvas);
            T0.Paint(Canvas);
            T1.Paint(Canvas);
            T2.Paint(Canvas);
            T3.Paint(Canvas);

        }
        override public void SetBaseRect(Rectangle Rect)
        {
            base.SetBaseRect(Rect);
            SetTail();
        }
        override public bool CopyObject(TBaseShape ASource)
        {
            base.CopyObject(ASource);
         /*   (TTfeEllShape)(ASource).TailLeft = F_TailLeft;
            (TTfeEllShape)(ASource).TailTop = F_TailTop;
            (TTfeEllShape)(ASource).TailBottom = F_TailBottom;
            (TTfeEllShape)(ASource).TailRight = F_TailRight;*/
            return true;
        }
        public string  Make_One_SimpleItem(int AIndex)
        {
            char ch = '\"';
            string  Res = "";
            if (ParamAlt!=null)
            {
                TParamAlternativeItem I = (TParamAlternativeItem)ParamAlt.Items[AIndex];
                if (I!=null)
                {
                 /*   Res = "control_func(" + (I.NUMBER).ToString() +
                                 "," + (AIndex + 1).ToString() +  //номер альтернативы  
                                 "," + ch + I.NAME + ch +
                                 "," + ch + I.FUNCTION2 + ch +
                                 "," + ch + I.ELEMENT + ch +
                                 "," + CommonGraph.float_2_string(I.K_11, 6) +
                                 "," + CommonGraph.float_2_string(I.K_00, 6) +
                                 "," + CommonGraph.float_2_string(I.T_F, 10) +
                                 "," + CommonGraph.float_2_string(I.V_F, 10) +
                                 ",[[" + CommonGraph.float_2_string(I.A1_K11_F, 4) +
                                 "," + CommonGraph.float_2_string(I.K11_F1N, 6) +
                                 "," + CommonGraph.float_2_string(I.K11_F1B, 6) +
                                 "],[" + float_2_string(I.A2_K11_F, 4) +
                                 "," + float_2_string(I.K11_F2N, 6) +
                                 "," + float_2_string(I.K11_F2B, 6) +
                                 "],[" + float_2_string(I.A3_K11_F, 4) +
                                 "," + float_2_string(I.K11_F3N, 6) +
                                 "," + float_2_string(I.K11_F3B, 6) +
                                 "]],[[" + float_2_string(I.A1_K00_F, 4) +
                                 "," + float_2_string(I.K00_F1N, 6) +
                                 "," + float_2_string(I.K00_F1B, 6) +
                                 "],[" + float_2_string(I.A2_K00_F, 4) +
                                 "," + float_2_string(I.K00_F2N, 6) +
                                 "," + float_2_string(I.K00_F2B, 6) +
                                 "],[" + float_2_string(I.A3_K00_F, 4) +
                                 "," + float_2_string(I.K00_F3N, 6) +
                                 "," + float_2_string(I.K00_F3B, 6) +
                                 "]],[[" + float_2_string(I.A1_TF_F, 4) +
                                 "," + float_2_string(I.TF_F1N, 10) +
                                 "," + float_2_string(I.TF_F1B, 10) +
                                 "],[" + float_2_string(I.A2_TF_F, 4) +
                                 "," + float_2_string(I.TF_F2N, 10) +
                                 "," + float_2_string(I.TF_F2B, 10) +
                                 "],[" + float_2_string(I.A3_TF_F, 4) +
                                 "," + float_2_string(I.TF_F3N, 10) +
                                 "," + float_2_string(I.TF_F3B, 10) +
                                 "]],[[" + float_2_string(I.A1_VF_F, 4) +
                                 "," + float_2_string(I.VF_F1N, 10) +
                                 "," + float_2_string(I.VF_F1B, 10) +
                                 "],[" + float_2_string(I.A2_VF_F, 4) +
                                 "," + float_2_string(I.VF_F2N, 10) +
                                 "," + float_2_string(I.VF_F2B, 10) +
                                 "],[" + float_2_string(I.A3_VF_F, 4) +
                                 "," + float_2_string(I.VF_F3N, 10) +
                                 "," + float_2_string(I.VF_F3B, 10) +
                                 "]]" + "," + ch + I.PREDICAT + ch + ").";*/
                }
            }
            return Res;
        }
        public bool TailLeft
        {
            set { F_TailLeft = value; }
            get { return F_TailLeft;  }
        }
        public bool TailTop
        {
            set { F_TailTop = value; }
            get { return F_TailTop; }
        }
        public bool TailBottom
        {
            set { F_TailBottom = value; }
            get { return F_TailBottom; }
        }
        public bool TailRight
        {
            set { F_TailRight = value; }
            get { return F_TailRight; }
        }
    }
}
