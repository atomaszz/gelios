using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TCheckCondition : TBaseWorkShape
    {
        void CreateLines()
        {
            TArrowLine Line, Lnb;
            Point P1 = new Point(), P2 = new Point();
            int tmp_x;
            TTfeRectShape Rct;
            TTfeHexahedronShape Hexa;
            FreeWorkLines();
            F_LastLineId = F_NumberLineId;

            Hexa = (TTfeHexahedronShape)(GetWorkShape(0));
            Rct = (TTfeRectShape)(GetWorkShape(1));
            Hexa.GetTailPoint(0, ref P1);
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

            Hexa.GetTailPoint(1, ref P1);
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

            Hexa.GetTailPoint(3, ref P1);
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
            L = (TRectLine)(GetWorkLine(5));
            return L;
        }
        override public int GetTypeShape()
        {
            return 11;
        }


        public TCheckCondition(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
        override public void Init()
        {
            Point P1 = new Point(), P2 = new Point();
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape Rct;
            TTfeHexahedronShape Hexa;
            F_LastShapeId = F_NumberShapeId;
            P1.X = StartPoint.X + 2 * F_Step;
            P1.Y = StartPoint.Y;

            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
            Hexa = new TTfeHexahedronShape(P1.X, P1.Y, F_Step, F_LastShapeId + 2);
            Hexa.TailLeft = true;
            Hexa.TailTop = true;
            Hexa.TailBottom = true;
            AddShape(Hexa);

            Hexa.GetTailPoint(1, ref P1);
            P1.X = P1.X + 4 * F_Step;
            P1.Y = P1.Y - 2 * F_Step;
            F_LastShapeId++;
            Rct = new TTfeRectShape(P1.X, P1.Y, F_Step, F_LastShapeId - 1);
            AddShape(Rct);

            Hexa.GetTailPoint(3, ref P1);
            P1.X = P1.X + 4 * F_Step;
            P1.Y = P1.Y + 2 * F_Step;
            F_LastShapeId++;
            Rct = new TTfeRectShape(P1.X, P1.Y, F_Step, F_LastShapeId - 1);
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
            TTfeHexahedronShape Hexa;

            Hexa = (TTfeHexahedronShape)(GetWorkShape(0));
            Rct = (TTfeRectShape)(GetWorkShape(1));
            Hexa.GetTailPoint(0, ref P1);
            //1
            Line = (TArrowLine)(GetWorkLine(0));
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P1.X;
            Line.yEnd = P1.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            Lnb = Line;

            Hexa.GetTailPoint(1, ref P1);
            Rct.GetTailPoint(0, ref P2);

            //2
            Line = (TArrowLine)(GetWorkLine(1));
            Line.xStart = P1.X;
            Line.yStart = P1.Y;
            Line.xEnd = P2.X;
            Line.yEnd = P2.Y;

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
            Hexa.GetTailPoint(3, ref P1);
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
    }
}
