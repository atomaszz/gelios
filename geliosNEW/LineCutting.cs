using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TLineCuttingItem
    {
        Point f_PStart;
        Point f_PEnd;
        bool f_Includet;
        int GetType()
        {
            int res = SharedConst.BL_OTHER;
            if (f_PStart.X == f_PEnd.X)
                res = SharedConst.BL_VERTICAL;
            if (f_PStart.Y == f_PEnd.Y)
                res = SharedConst.BL_HORIZONTAL;
            if ((f_PStart.Y == f_PEnd.Y) && (f_PStart.X == f_PEnd.X))
                res = SharedConst.BL_POINT;
            return res;
        }
        int GetXDln()
        {
            return Math.Abs(SharedConst.MyMax(f_PEnd.X, f_PStart.X) - SharedConst.MyMin(f_PEnd.X, f_PStart.X));
        }
        public TLineCuttingItem()
        {
            f_PStart = new Point(0, 0);
            f_PEnd = new Point(0, 0);
            f_Includet = false;
        }
        public int Type { get { return GetType(); } }

        public Point PointStart
        {
            set { f_PStart = value; }
            get { return f_PStart;  }
        }
        public Point PointEnd
        {
            set { f_PEnd = value; }
            get { return f_PEnd; }
        }
        public bool Includet
        {
            set { f_Includet = value; }
            get { return f_Includet; }
        }
        public int XDln
        {
            get { return GetXDln(); }
        }
    }

    class TLineCutting
    {
        Color f_PenColorWS;
        int f_PenWidthWS;
  //      TPenStyle f_PenStyleWS;
  //      TPenMode f_PenModeWS;
        Color f_FrameColorWS;
  //      TBrushStyle f_BrushStyleWS;
        bool f_DrawCaption;
        int f_BaseX, f_BaseY;
        int f_StartBaseX, f_StartBaseY;
        List<object> f_PointList;
        List<object> f_BaseLineList;
        TBaseWorkShape f_WorkShape;
        TBaseWorkShape f_NextWorkShape;
   //     TCanvas f_Canvas;
        TRectLine f_FirstLine;
        TRectLine f_LastLine;
        bool f_IsFirstWS;
        bool f_IsLastWS;
        TDynamicArray f_DLines;
        TDynamicArray f_DShapes;

        void FreePointList()
        {
            TLineCuttingItem Item;
            for (int i = f_PointList.Count - 1; i >= 0; i--)
            {
                f_PointList.RemoveAt(i);
            }
        }
        void FreeBaseLineList()
        {
            for (int i = f_BaseLineList.Count - 1; i >= 0; i--)
            {
                f_BaseLineList.RemoveAt(i);
            }
        }
        void SetWorkShape(TBaseWorkShape AValue)
        {
            f_WorkShape = AValue;
            FreePointList();
            FreeBaseLineList();
            if (f_WorkShape!=null)
            {
                f_PenColorWS = f_WorkShape.PenColor;
                f_PenWidthWS = f_WorkShape.PenWidth;
            /*    f_PenStyleWS = f_WorkShape.PenStyle;
                f_PenModeWS = f_WorkShape.PenMode;
                f_FrameColorWS = f_WorkShape.FrameColor;
                f_BrushStyleWS = f_WorkShape.BrushStyle;
                f_DrawCaption = f_WorkShape.DrawCaption;
                f_FirstLine.PointStart = f_WorkShape.FirstLine.PointStart;
                f_FirstLine.PointEnd = f_WorkShape.FirstLine.PointEnd;
                if (f_WorkShape.CompositeWorkShape!=null)
                {
                    f_DShapes.Clear();
                    f_WorkShape.CompositeWorkShape.GetAllShapes(f_DShapes);
                }
                CreateImage();*/
            }
        }
   /*     void SetNextWorkShape(TBaseWorkShape AValue);
        void CreateImage();
        void CreateBaseLine();
        TLineCuttingItem FindLine(Point APointStart, Point APointEnd);
        bool AddToPointList(Point APointStart, Point APointEnd);
        bool ComparePoint(TLineCuttingItem A, TLineCuttingItem B, ref Point AStart, ref Point AEnd);
        void ApplyOffset(int Ax, int Ay);
        void Paint(TCanvas ACanvas);
        public TLineCutting(Canvas ACanvas);
        ~TLineCutting() { }
        public void BeginMoving(int Ax, int Ay);
        public void Moving(int Ax, int Ay);
        public void EndMoving(int &AxOfs, int &AyOfs);
        public void ClearAll();*/

        public TBaseWorkShape WorkShape
        {
            set { SetWorkShape(value); }
            get { return f_WorkShape; }
        }

    /*    public TBaseWorkShape* NextWorkShape = { read = f_NextWorkShape, write = SetNextWorkShape };
        public bool IsFirstWS = { read = f_IsFirstWS, write = f_IsFirstWS };
        public bool IsLastWS = { read = f_IsLastWS, write = f_IsLastWS };*/
    }
}
