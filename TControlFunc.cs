using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TControlFunc : TBaseWorkShape
    {
        void CreateLines()
        {
            TArrowLine Line, Lnb;
            Point P1 = new Point(), P2 = new Point();
            int tmp_x;
            TTfeRectShape Rct;
            TTfeEllShape Ell;
            FreeWorkLines();
            F_LastLineId = F_NumberLineId;

            Rct = (TTfeRectShape)(GetWorkShape(0));
            Ell = (TTfeEllShape)(GetWorkShape(1));
            Rct.GetTailPoint(0, ref P1);
            F_LastLineId++;
            //1
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P1.X - 2 * F_Step;
            Line.yEnd = P1.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            AddLine(Line);
            Lnb = Line;

            F_LastLineId++;
            //2
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            AddLine(Line);

            Rct.GetTailPoint(1, ref P1);
            Ell.GetTailPoint(0, ref P2);

            F_LastLineId++;
            //3
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            AddLine(Line);

            Rct.GetTailPoint(0, ref P1);
            Ell.GetTailPoint(1, ref P2);

            F_LastLineId++;
            //4
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            AddLine(Line);

            Ell.GetTailPoint(2, ref P2);
            F_LastLineId++;
            //5
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P2.X;
            Line.yStart = P2.Y;
            Line.xEnd = P2.X + 2 * F_Step;
            Line.yEnd = P2.Y;
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
           //     Shape.BrushStyle = bsSolid;
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
            L = (TRectLine)(GetWorkLine(4));
            return L;
        }
        override public int  GetTypeShape()
        {
            return 5;
        }
        public TControlFunc(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
        override public void Init()
        {
            Point P1 = new Point(), P2 = new Point();
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape Rct;
            TTfeEllShape Ell;

            F_LastShapeId = F_NumberShapeId;
            P1.X = StartPoint.X + 4 * F_Step;
            P1.Y = StartPoint.Y;

            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
            Rct = new TTfeRectShape(P1.X, P1.Y, F_Step, F_LastShapeId);
            AddShape(Rct);

            Rct.GetTailPoint(1, ref P2);
            P2.X = P2.X + 2 * F_Step;
            F_LastShapeId++;
            Ell = new TTfeEllShape(P2.X, P2.Y, F_Step, F_LastShapeId);
            Ell.TailLeft = true;
            Ell.TailTop = true;
            Ell.TailRight = true;
            AddShape(Ell);
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
            TTfeEllShape Ell;

            Rct = (TTfeRectShape)(GetWorkShape(0));
            Ell = (TTfeEllShape)(GetWorkShape(1));
            Rct.GetTailPoint(0, ref P1);
            Line = (TArrowLine)(GetWorkLine(0));
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P1.X - 2 * F_Step;
            Line.yEnd = P1.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            Lnb = Line;

            Line = (TArrowLine)(GetWorkLine(1));
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;

            Rct.GetTailPoint(1, ref P1);
            Ell.GetTailPoint(0, ref P2);

            Line = (TArrowLine)(GetWorkLine(2));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;

            Rct.GetTailPoint(0, ref P1);
            Ell.GetTailPoint(1, ref P2);

            Line = (TArrowLine)(GetWorkLine(3));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;

            Ell.GetTailPoint(2, ref P2);
            Line = (TArrowLine)(GetWorkLine(4));
            Line.xStart = P2.X;
            Line.yStart = P2.Y;
            Line.xEnd = P2.X + 2 * F_Step;
            Line.yEnd = P2.Y;

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
            TBaseShape Shp1, Shp2;
            bool res = false;
            Shp1 = GetWorkShape(0);
            Shp2 = GetWorkShape(1);
            if ((Shp1.ID == ID_Shape1) && (Shp2.ID == ID_Shape2)) res = true;
            if ((Shp1.ID == ID_Shape2) && (Shp2.ID == ID_Shape1)) res = true;
            return res;
        }


    }
}
