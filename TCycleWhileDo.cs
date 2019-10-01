using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TCycleWhileDo : TBaseWorkShape
    {
        void CreateLines()
        {
            TArrowLine Line, Lnb;
            Point P1 = new Point(), P2 = new Point(), VP = new Point();
            int tmp_x;
            TTfeRectShape Rct;
            TTfeRhombShape Rhomb;
            FreeWorkLines();
            F_LastLineId = F_NumberLineId;

            Rct = (TTfeRectShape)(GetWorkShape(0));
            Rhomb = (TTfeRhombShape)(GetWorkShape(1));
            Rct.GetTailPoint(0, ref P1);
            Rhomb.GetTailPoint(0, ref P2);
            VP.X = P1.X - 4 * F_Step;
            VP.Y = P2.Y;

            F_LastLineId++;
            //1
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = VP.X;
            Line.yEnd = VP.Y;
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
            Line.Bend = 2;
            AddLine(Line);


            Rct.GetTailPoint(1, ref P1);
            Rhomb.GetTailPoint(1, ref P2);
            F_LastLineId++;
            //3
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            Line.Bend = 1;
            AddLine(Line);

            Rhomb.GetTailPoint(0, ref P1);
            F_LastLineId++;
            //4
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            AddLine(Line);


            //5
            Rhomb.GetTailPoint(2, ref P1);
            F_LastLineId++;
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P1.X + 2 * F_Step;
            Line.yEnd = P1.Y;
            AddLine(Line);
        }

        override public int CalcBend(int t_x1, int t_x2)
        {
            int res = 0;
            if (t_x1 < t_x2) res = 2;
            if (t_x1 > t_x2) res = 3;
            return res;
        }
        //    void ShapeCopy(TBaseShape Shape, int Num_Shape);

        override public TRectLine GetFirstLine()
        {
            TRectLine L;
            L = base.GetFirstLine();
            if (L==null)
                L = (TRectLine)(GetWorkLine(0));
            return L;
        }
        override public TRectLine GetLastLine()
        {
            TRectLine L;
            L = (TRectLine)(GetWorkLine(4));
            return L;
        }
        override public int GetTypeShape()
        {
            return 8;
        }

        public TCycleWhileDo(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
        override public void Init()
        {
            Point P1 = new Point(), P2 = new Point();
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape Rct;
            TTfeRhombShape Rhomb;
            F_LastShapeId = F_NumberShapeId;
            P1.X = StartPoint.X + 6 * F_Step;
            P1.Y = StartPoint.Y - 6 * F_Step;

            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
            Rct = new TTfeRectShape(P1.X, P1.Y, F_Step, F_LastShapeId);
            AddShape(Rct);

            Rct.GetTailPoint(1, ref P1);
            P1.X = P1.X + F_Step;
            P1.Y = StartPoint.Y;
            F_LastShapeId++;
            Rhomb = new TTfeRhombShape(P1.X, P1.Y, F_Step, F_LastShapeId);
            Rhomb.TailLeft = true;
            Rhomb.TailTop = true;
            Rhomb.TailRight = true;
            AddShape(Rhomb);


            CreateLines();
            F_Indent = FirstLine.xEnd - FirstLine.xStart;

        }
        override public void Prepare()
        {
            TArrowLine Line, Lnb;
            Point P1 = new Point(), P2 = new Point(), VP = new Point();
            int tmp_x;
            TTfeRectShape Rct;
            TTfeRhombShape Rhomb;


            Rct = (TTfeRectShape)(GetWorkShape(0));
            Rhomb = (TTfeRhombShape)(GetWorkShape(1));
            Rct.GetTailPoint(0, ref P1);
            Rhomb.GetTailPoint(0, ref P2);
            VP.X = P1.X - 4 * F_Step;
            VP.Y = P2.Y;


            //1
            Line = (TArrowLine)(GetWorkLine(0));
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = VP.X;
            Line.yEnd = VP.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            Lnb = Line;


            //2
            Line = (TArrowLine)(GetWorkLine(1));
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            Line.Bend = 2;


            Rct.GetTailPoint(1, ref P1);
            Rhomb.GetTailPoint(1, ref P2);
            //3
            Line = (TArrowLine)(GetWorkLine(2));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            Line.Bend = 1;

            Rhomb.GetTailPoint(0, ref P1);
            //4
            Line = (TArrowLine)(GetWorkLine(3));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = Lnb.xEnd;
            Line.yEnd = Lnb.yEnd;

            //5
            Rhomb.GetTailPoint(2, ref P1);
            Line = (TArrowLine)(GetWorkLine(4));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P1.X + 2 * F_Step;
            Line.yEnd = P1.Y;

            base.Prepare();

        }
        override public void Paint(Graphics Canvas)
        {
            base.Paint(Canvas);
        }
        override public Point GetEndPoint()
        {
            if (CompositeWorkShape!=null)
                return CompositeWorkShape.EndPoint;
            return LastLine.PointEnd;
        }
    }
}
