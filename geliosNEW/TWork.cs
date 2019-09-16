using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TWork : TBaseWorkShape
    {
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
            TRectLine Line;
            Line = (TRectLine)(GetWorkLine(1));
            return Line;
        }

     /*     protected int GetTypeShape();*/
        public TWork(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
        override public void Init()
        {
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape Shape;
            F_LastShapeId = F_NumberShapeId;
            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
            Shape = new TTfeRectShape(StartPoint.X + 2 * F_Step, StartPoint.Y, F_Step, F_LastShapeId);
            AddShape(Shape);
            CreateLines();
            CalcWidthWork();
            F_Indent = FirstLine.xEnd - FirstLine.xStart;
        }
        override public void Prepare()
        {
            TArrowLine Line;
            Point P = new Point();
            TTfeRectShape Shape;
            Line = (TArrowLine)(GetWorkLine(0));
            Shape = (TTfeRectShape)(GetWorkShape(0));
            Shape.GetTailPoint(0, ref P);
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P.X;
            Line.yEnd = P.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);

            Line = (TArrowLine)(GetWorkLine(1));
            Shape = (TTfeRectShape)(GetWorkShape(0));
            Shape.GetTailPoint(1, ref P);
            Line.xStart = P.X;
            Line.yStart = P.Y;
            Line.xEnd = P.X + 2 * F_Step;
            Line.yEnd = P.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            base.Prepare();
        }
        override public void Paint(Graphics Canvas)
        {
            base.Paint(Canvas);
        }
        public void CreateLines()
        {
            TArrowLine Line;
            Point P = new Point();
            TTfeRectShape Shape;
            FreeWorkLines();
            F_LastLineId = F_NumberLineId;
            F_LastLineId++;
            Line = new TArrowLine(F_Step, F_LastLineId);
            Shape = (TTfeRectShape)GetWorkShape(0);
            Shape.GetTailPoint(0, ref P);
            Line.xStart = StartPoint.X;
            Line.yStart = StartPoint.Y;
            Line.xEnd = P.X;
            Line.yEnd = P.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            AddLine(Line);
            Shape.AddWorkLine(Line);

            F_LastLineId++;
            Line = new TArrowLine(F_Step, F_LastLineId);
            Shape = (TTfeRectShape)(GetWorkShape(0));
            Shape.GetTailPoint(1, ref P);
            Line.xStart = P.X;
            Line.yStart = P.Y;
            Line.xEnd = P.X + 2 * F_Step;
            Line.yEnd = P.Y;
            Line.Bend = CalcBend(Line.xStart, Line.xEnd);
            AddLine(Line);
            Shape.AddWorkLine(Line);
        }
        override public TRectLine GetMiddleLine()
        {
            TRectLine Line;
            Line = (TRectLine)(GetWorkLine(1));
            return Line;
        }
    /*    public TBaseShape GetShapeByLine(TRectLine ALine, int APos);
        public TPoint GetEndPoint();
        public bool MakeFlagForShape(TBaseShape AShape, bool ACreate, int APos, int AType, Color AColor);*/
}
}
