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
        /*  protected TRectLine GetFirstLine();
          protected TRectLine GetLastLine();
          protected int GetTypeShape();*/
        public TWork(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id) : base(X, Y, Step, NumberShape_Id, Block_Id, NumberLine_Id) { } 
        public void Init()
        {
            FreeWorkLines();
            FreeWorkShapes();
            TTfeRectShape Shape;
            F_LastShapeId = F_NumberShapeId;
            F_LastShapeId++;
            F_NumberShapeId = F_LastShapeId;
      /*      Shape = new TTfeRectShape(StartPoint.x + 2 * F_Step, StartPoint.y, F_Step, F_LastShapeId);
            AddShape(Shape);
            CreateLines();
            CalcWidthWork();
            F_Indent = FirstLine.xEnd - FirstLine.xStart;*/
        }
   /*     public void Prepare();
        public void Paint(TCanvas* Canvas);
        public void CreateLines();
        public TBaseShape GetShapeByLine(TRectLine ALine, int APos);
        public TPoint GetEndPoint();
        public bool MakeFlagForShape(TBaseShape AShape, bool ACreate, int APos, int AType, Color AColor);*/
    }
}
