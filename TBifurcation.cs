using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TBifurcation : TBaseWorkShape
    {
        void CreateLines()
        {
            TArrowLine Line, Lnb;
            Point P1 = new Point(), P2 = new Point();
            int tmp_x;
            TTfeRectShape Rct;
            TTfeRhombShape Rhomb;
            FreeWorkLines();
            F_LastLineId = F_NumberLineId;

            Rhomb = (TTfeRhombShape)(GetWorkShape(0));
            Rct = (TTfeRectShape)(GetWorkShape(1));
            Rhomb.GetTailPoint(0, ref P1);
            F_LastLineId++;
            //1
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            AddLine(Line);
            Lnb = Line;

            Rhomb.GetTailPoint(1, ref P1);
            Rct.GetTailPoint(0, ref P2);

            F_LastLineId++;
            //2
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            AddLine(Line);

            Rct.GetTailPoint(1, ref P1);
            Rct = (TTfeRectShape)(GetWorkShape(2));
            Rct.GetTailPoint(1, ref P2);

            tmp_x = P1.X;
            if (tmp_x < P2.X) tmp_x = P2.X;
            tmp_x = tmp_x + 3 * F_Step;

            F_LastLineId++;
            //3
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = tmp_x;
            Line.yEnd = Lnb.yEnd;
            AddLine(Line);

            F_LastLineId++;
            //4
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P2.X;
            Line.yStart = P2.Y;
            Line.xEnd = tmp_x;
            Line.yEnd = Lnb.yEnd;
            AddLine(Line);

            Rhomb.GetTailPoint(3, ref P1);
            Rct.GetTailPoint(0, ref P2);
            F_LastLineId++;
            //5
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P2.X;
            Line.yStart = P2.Y;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            AddLine(Line);

            F_LastLineId++;
            //6
            Lnb = (TArrowLine)(GetWorkLine(2));
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.PointStart = Lnb.PointEnd;
            Line.xEnd = Lnb.PointEnd.X + 2 * F_Step;
            Line.yEnd = Lnb.PointEnd.Y;
            AddLine(Line);
        }
        override public int CalcBend(int t_x1, int t_x2)
        {
            int res = 0;
            if (t_x1 < t_x2) res = 2;
            if (t_x1 > t_x2) res = 3;
            return res;
        }
        void ShapeCopy(TBaseShape Shape, int Num_Shape)
        {
            if (Num_Shape == 1)
            {
                Shape.PenColor = Color.Green;
                Shape.BrushColor = Color.Yellow;
                Shape.PenWidth = 2;
              //  Shape.BrushStyle = bsSolid;
            }
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
            L = (TRectLine)GetWorkLine(5);
            return L;
        }
        override public int  GetTypeShape()
        {
            return 6;
        }

        public TBifurcation(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }

        override public void Init()
        {
            Point P1 = new Point(), P2 = new Point();
            int n1, n2, n3;
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape Rct;
            TTfeRhombShape Rhomb;
            F_LastShapeId = F_NumberShapeId;
            P1.X = StartPoint.X + 2 * F_Step;
            P1.Y = StartPoint.Y;

            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
            F_LastShapeId++;
            F_LastShapeId++;
            n3 = F_LastShapeId;
            n2 = n3 - 1;
            n1 = n2 - 1;

            Rhomb = new TTfeRhombShape(P1.X, P1.Y, F_Step, n3);
            Rhomb.TailLeft = true;
            Rhomb.TailTop = true;
            Rhomb.TailBottom = true;
            AddShape(Rhomb);

            Rhomb.GetTailPoint(1, ref P1);
            P1.X = P1.X + 4 * F_Step;
            P1.Y = P1.Y - 2 * F_Step;

            Rct = new TTfeRectShape(P1.X, P1.Y, F_Step, n1);
            AddShape(Rct);

            Rhomb.GetTailPoint(3, ref P1);
            P1.X = P1.X + 4 * F_Step;
            P1.Y = P1.Y + 2 * F_Step;
            Rct = new TTfeRectShape(P1.X, P1.Y, F_Step, n2);
            AddShape(Rct);
            CreateLines();
            CalcWidthWork();
            F_Indent = FirstLine.xEnd - FirstLine.xStart;
        }
        override public void Prepare()
        {
            TArrowLine Line, Lnb;
            Point P1 = new Point(), P2 = new Point();
            int tmp_x;
            TTfeRectShape Rct;
            TTfeRhombShape Rhomb;

            Rhomb = (TTfeRhombShape)(GetWorkShape(0));
            Rct = (TTfeRectShape)(GetWorkShape(1));
            Rhomb.GetTailPoint(0, ref P1);
            //1
            Line = (TArrowLine)(GetWorkLine(0));
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            Lnb = Line;

            Rhomb.GetTailPoint(1, ref P1);
            Rct.GetTailPoint(0, ref P2);

            //2
            Line = (TArrowLine)(GetWorkLine(1));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            //Line.Bend = CalcBend(Line.xStart, Line.xEnd);

            Rct.GetTailPoint(1, ref P1);
            Rct = (TTfeRectShape)(GetWorkShape(2));
            Rct.GetTailPoint(1, ref P2);

            tmp_x = P1.X;
            if (tmp_x < P2.X) tmp_x = P2.X;
            tmp_x = tmp_x + 3 * F_Step;

            //3
            Line = (TArrowLine)(GetWorkLine(2));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = tmp_x;
            Line.yEnd = Lnb.yEnd;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);


            //4
            Line = (TArrowLine)(GetWorkLine(3));
            Line.xStart = P2.X;
            Line.yStart = P2.Y;
            Line.xEnd = tmp_x;
            Line.yEnd = Lnb.yEnd;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);

            Rct = (TTfeRectShape)(GetWorkShape(2));
            Rhomb.GetTailPoint(3, ref P1);
            Rct.GetTailPoint(0, ref P2);
            //5
            Line = (TArrowLine)(GetWorkLine(4));
            Line.xStart = P2.X;
            Line.yStart = P2.Y;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;

            //6
            Lnb = (TArrowLine)(GetWorkLine(2));

            Line = (TArrowLine)(GetWorkLine(5));
            Line.PointStart = Lnb.PointEnd;
            Line.xEnd = Lnb.PointEnd.X + 2 * F_Step;
            Line.yEnd = Lnb.PointEnd.Y;
            base.Prepare();
        }
        override public void Paint(Graphics Canvas)
        {
            base.Paint(Canvas);
        }
        override public Point  GetEndPoint()
        {
            if (CompositeWorkShape!=null)
                return CompositeWorkShape.EndPoint;
            return LastLine.PointEnd;
        }
        public bool CanAlternate(int ID_Shape1, int ID_Shape2)
        {
            TBaseShape Shp1, Shp2, Shp3;
            bool res = false;
            Shp1 = GetWorkShape(0);
            Shp2 = GetWorkShape(1);
            Shp3 = GetWorkShape(2);
            if ((Shp1.ID == ID_Shape1) && (Shp2.ID == ID_Shape2)) res = true;
            if ((Shp1.ID == ID_Shape2) && (Shp2.ID == ID_Shape1)) res = true;

            if ((Shp1.ID == ID_Shape1) && (Shp3.ID == ID_Shape2)) res = true;
            if ((Shp1.ID == ID_Shape2) && (Shp3.ID == ID_Shape1)) res = true;
            return res;
        }
    }
}
