using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TZWork : TBaseWorkShape
    {
        Point VPoint;
        Pen F_OldPenParent;
        void CreateLines()
        {
            TArrowLine Line, Lnb;
            Point P = new Point(), P2 = new Point();
            int tmp_x;
            TTfeRectShape Shape1, Shape2;
            FreeWorkLines();
            F_LastLineId = F_NumberLineId;

            Shape1 = (TTfeRectShape)(GetWorkShape(0));
            Shape2 = (TTfeRectShape)(GetWorkShape(1));
            Shape1.GetTailPoint(0, ref P);


            F_LastLineId++;
            //1
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P.X - 3 * F_Step;
            Line.yEnd = P.Y + 4 * F_Step;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            AddLine(Line);
            Lnb = Line;
            Shape1.AddWorkLine(Line);

            F_LastLineId++;
            //2
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P.X;
            Line.yEnd = P.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            //stas   Line.Prepare();
            AddLine(Line);
            Shape1.AddWorkLine(Line);



            Shape1.GetTailPoint(1, ref P);
            Shape2.GetTailPoint(1, ref P2);

            tmp_x = P.X;
            if (tmp_x < P2.X) tmp_x = P2.X;
            tmp_x = tmp_x + 3 * F_Step;


            F_LastLineId++;
            //3
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P.X;
            Line.yStart = P.Y;

            Line.xEnd = tmp_x;
            Line.yEnd = Lnb.yEnd;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            AddLine(Line);
            Shape1.AddWorkLine(Line);


            F_LastLineId++;
            //4
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P2.X;
            Line.yStart = P2.Y;

            Line.xEnd = tmp_x;
            Line.yEnd = Lnb.yEnd;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            AddLine(Line);
            Shape2.AddWorkLine(Line);


            Shape2.GetTailPoint(0, ref P2);
            F_LastLineId++;
            //5
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;

            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            AddLine(Line);
            Shape2.AddWorkLine(Line);


            F_LastLineId++;
            //6
            Lnb = (TArrowLine)(GetWorkLine(2));

            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.PointStart = Lnb.PointEnd;
            Line.xEnd = Lnb.PointEnd.X + 2 * F_Step;
            Line.yEnd = Lnb.PointEnd.Y;
            AddLine(Line);
            Shape2.AddWorkLine(Line);
        }

        override public TRectLine  GetFirstLine()
        {
            TRectLine L;
            L = base.GetFirstLine();
            if (L==null)
                L = (TRectLine)(GetWorkLine(0));
            return L;
        }
        override public TRectLine  GetLastLine()
        {
            TRectLine L;
            L = (TRectLine)(GetWorkLine(5));
            return L;
        }
        override public int CalcBend(int t_x1, int t_x2)
        {
            int res = 0;
            if (t_x1 < t_x2) res = 2;
            if (t_x1 > t_x2) res = 3;
            return res;
        }
        override public int GetTypeShape()
        {
            return 2;
        }

        public TZWork(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id)
        {
         //   F_OldPenParent = new Graphics::TPen;
        }
        ~TZWork() { }
        override public void Init()
        {
            Point P1 = new Point();
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape Shape;
            F_LastShapeId = F_NumberShapeId;
            P1.X = StartPoint.X + 6 * F_Step;
            P1.Y = StartPoint.Y - 4 * F_Step;

            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
            Shape = new TTfeRectShape(P1.X, P1.Y, F_Step, F_LastShapeId);
            AddShape(Shape);

            P1.Y = StartPoint.Y + 4 * F_Step;
            F_LastShapeId++;
            Shape = new TTfeRectShape(P1.X, P1.Y, F_Step, F_LastShapeId);
            AddShape(Shape);
            CreateLines();
            CalcWidthWork();
            F_Indent = FirstLine.xEnd - FirstLine.xStart;
            VPoint = new Point(0, 0);
        }
        override public void Prepare()
        {
            TArrowLine Line, Lnb;
            Point P = new Point(), P2 = new Point();
            int tmp_x;
            TTfeRectShape Shape1, Shape2;

            Shape1 = (TTfeRectShape)(GetWorkShape(0));
            Shape2 = (TTfeRectShape)(GetWorkShape(1));
            Shape1.GetTailPoint(0, ref P);


            //1
            Line = (TArrowLine)(GetWorkLine(0));
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P.X - 3 * F_Step;
            Line.yEnd = P.Y + 4 * F_Step;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            Lnb = Line;

            //2
            Line = (TArrowLine)(GetWorkLine(1));
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P.X;
            Line.yEnd = P.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);


            Shape1.GetTailPoint(1, ref P);
            Shape2.GetTailPoint(1, ref P2);

            tmp_x = P.X;
            if (tmp_x < P2.X) tmp_x = P2.X;
            tmp_x = tmp_x + 3 * F_Step;

            //3
            Line = (TArrowLine)(GetWorkLine(2));
            Line.xStart = P.X;
            Line.yStart = P.Y;
            Line.xEnd = tmp_x;
            Line.yEnd = Lnb.yEnd;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            VPoint = new Point(Line.xStart, Line.yEnd);


            Line = (TArrowLine)(GetWorkLine(3));
            Line.xStart = P2.X;
            Line.yStart = P2.Y;
            Line.xEnd = tmp_x;
            Line.yEnd = Lnb.yEnd;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);


            Shape2.GetTailPoint(0, ref P2);
            //5
            Line = (TArrowLine)(GetWorkLine(4));
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;

            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);

            //6
            Lnb = (GetWorkLine(2));
            Line = (GetWorkLine(5));
            Line.PointStart = Lnb.PointEnd;
            Line.xEnd = Lnb.PointEnd.X + 2 * F_Step;
            Line.yEnd = Lnb.PointEnd.Y;

            base.Prepare();
        }
        override public void Paint(Graphics Canvas)
        {
            base.Paint(Canvas);
            if (CompositeWorkShape==null)
            {
                //        F_OldPenParent.Assign(Canvas.Pen);
                //      Canvas.Pen.Width = LineWidth;
                //        Canvas.Pen.Style = LineStyle;
                //        Canvas.Pen.Color = PenColor;
                SharedConst.PaintVShape(Canvas, VPoint, F_Step, F_Step, false);
     //           Canvas.Pen.Assign(F_OldPenParent);
            }
        }
        override public Point GetEndPoint()
        {
            if (CompositeWorkShape!=null)
                return CompositeWorkShape.EndPoint;
            return LastLine.PointEnd;
        }
    }
}
