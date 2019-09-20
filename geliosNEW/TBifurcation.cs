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
        /*       int CalcBend(int t_x1, int t_x2);
               void ShapeCopy(TBaseShape* Shape, int Num_Shape);*/

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
        /*        protected int  GetTypeShape();*/

        public TBifurcation(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
        /*
        //---------------------------------------------------------------------------
        void __fastcall TWork::LineCopy(TArrowLine *Line, int Num_Line)
        {
           if (Num_Line == 0)
             Line.Width= 0;

        }
        */

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
        /*    public void Prepare();
            public void Paint(TCanvas Canvas);
            public TPoint  GetEndPoint();
            public bool CanAlternate(int ID_Shape1, int ID_Shape2);*/
    }
}
