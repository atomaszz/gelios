using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TWork :  TBaseWorkShape
    {
/*        TRectLine GetFirstLine()
        {
            TRectLine L;
            L = base.GetFirstLine();
            if (L==null)
                L = GetWorkLine(0);
            return L;
        }*/
 /*       TRectLine GetLastLine()
        {
            TRectLine Line;
 //           Line = GetWorkLine(1);
            return Line;
        }*/
        int GetTypeShape()
        {
            return 1;
        }

  //      public TWork(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { }
  /*      void Init()
        {
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape* Shape;
            F_LastShapeId = F_NumberShapeId;
            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
            Shape = new TTfeRectShape(StartPoint.x + 2 * F_Step, StartPoint.y, F_Step, F_LastShapeId);
            AddShape(Shape);
            CreateLines();
            CalcWidthWork();
            F_Indent = FirstLine->xEnd - FirstLine->xStart;
        }
        void Prepare();
        void Paint(TCanvas* Canvas);
        void CreateLines();
        TBaseShape GetShapeByLine(TRectLine ALine, int APos);
        Point  GetEndPoint();
        bool MakeFlagForShape(TBaseShape* AShape, bool ACreate, int APos, int AType, TColor AColor);*/
    }
}
