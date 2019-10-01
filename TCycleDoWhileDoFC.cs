using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TCycleDoWhileDoFC : TBaseWorkShape
    {
        void CreateLines()
        {
            TArrowLine Line, Lnb;
            Point P1 = new Point(), P2 = new Point(), VP = new Point();
            int tmp_x;
            TTfeRectShape Rct, Rct2;
            TTfeEllShape Ell;
            FreeWorkLines();
            F_LastLineId = F_NumberLineId;

            Rct = (TTfeRectShape)(GetWorkShape(0));
            Rct2 = (TTfeRectShape)(GetWorkShape(1));
            Ell = (TTfeEllShape)(GetWorkShape(2));
            Rct2.GetTailPoint(0, ref P1);
            VP.X = P1.X - 4 * F_Step;
            VP.Y = P1.Y;

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


            Rct.GetTailPoint(0, ref P1);
            F_LastLineId++;
            //2
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            AddLine(Line);


            Rct.GetTailPoint(1, ref P1);
            Ell.GetTailPoint(1, ref P2);
            F_LastLineId++;
            //3
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            Line.Bend = 1;
            AddLine(Line);


            Rct2.GetTailPoint(0, ref P1);
            F_LastLineId++;
            //4
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            AddLine(Line);

            //5
            Rct2.GetTailPoint(1, ref P1);
            Ell.GetTailPoint(0, ref P2);

            F_LastLineId++;
            Line = new TArrowLine(F_Step, F_LastLineId);
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            AddLine(Line);

            //6
            Ell.GetTailPoint(2, ref P1);
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

        override public TRectLine GetFirstLine()
        {
            TRectLine L = base.GetFirstLine();
            if (L==null)
                L = (TRectLine)(GetWorkLine(0));
            return L;
        }
        override public TRectLine GetLastLine()
        {
            TRectLine L;
            L = (TRectLine)(GetWorkLine(5));
            return L;
        }
        override public int GetTypeShape()
        {
            return 10;
        }
        public TCycleDoWhileDoFC(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
        override public void Init()
        {
            Point P1 = new Point(), P2 = new Point();
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape Rct;
            TTfeEllShape Ell;
            F_LastShapeId = F_NumberShapeId;
            P1.X = StartPoint.X + 6 * F_Step;
            P1.Y = StartPoint.Y - 6 * F_Step;

            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
            Rct = new TTfeRectShape(P1.X, P1.Y, F_Step, F_LastShapeId + 1);
            AddShape(Rct);

            F_LastShapeId++;
            P1.Y = StartPoint.Y;
            Rct = new TTfeRectShape(P1.X, P1.Y, F_Step, F_LastShapeId - 1);
            AddShape(Rct);


            Rct.GetTailPoint(1, ref P1);
            P1.X = P1.X + F_Step;
            P1.Y = StartPoint.Y;
            F_LastShapeId++;
            Ell = new TTfeEllShape(P1.X, P1.Y, F_Step, F_LastShapeId);
            Ell.TailLeft = true;
            Ell.TailTop = true;
            Ell.TailRight = true;
            AddShape(Ell);

            CreateLines();
            F_Indent = FirstLine.xEnd - FirstLine.xStart;

        }
        public void Prepare()
        {
            TArrowLine Line, Lnb, Lnb3;
            Point P1 = new Point(), P2 = new Point(), VP = new Point();
            int tmp_x;
            TTfeRectShape Rct, Rct2;
            TTfeEllShape Ell;


            Rct = (TTfeRectShape)(GetWorkShape(0));
            Rct2 = (TTfeRectShape)(GetWorkShape(1));
            Ell = (TTfeEllShape)(GetWorkShape(2));
            Rct2.GetTailPoint(0, ref P1);
            VP.X = P1.X - 4 * F_Step;
            VP.Y = P1.Y;
            //1
            Line = (TArrowLine)(GetWorkLine(0));
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = VP.X;
            Line.yEnd = VP.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            Lnb = Line;


            //2
            Rct.GetTailPoint(0, ref P1);
            Line = (TArrowLine)(GetWorkLine(1));
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            Line.Bend = 2;


            Rct.GetTailPoint(1, ref P1);
            Ell.GetTailPoint(1, ref P2);
            //3
            Line = (TArrowLine)(GetWorkLine(2));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;
            Line.Bend = 1;

            Rct2.GetTailPoint(0, ref P1);
            //4
            Line = (TArrowLine)(GetWorkLine(3));
            Line.xStart = Lnb.xEnd;
            Line.yStart = Lnb.yEnd;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;

            Rct2.GetTailPoint(1, ref P1);
            Ell.GetTailPoint(0, ref P2);
            //5
            Line = (TArrowLine)(GetWorkLine(4));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;


            //6
            Ell.GetTailPoint(2, ref P1);
            Line = (TArrowLine)(GetWorkLine(5));
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
        override public Point  GetEndPoint()
        {
            if (CompositeWorkShape!=null)
                return CompositeWorkShape.EndPoint;
            return LastLine.PointEnd;
        }
    }
}
