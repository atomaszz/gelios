using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    public class TBaseWorkShape
    {
        public delegate void TShapeCopy(TBaseShape Shape, int Num_Shape);
        //    public delegate void TLineCopy(TArrowLine Line, int Num_Line);
        //--переменные--//
        int F_BlockId;
        List<object> WorkShapes;
        List<object> WorkLines;
        Point F_StartPoint;
        Point f_BaseStartPoint;

        Color F_BrushColor;  //цвет кисти
        Color F_PenColor;   //цвет пена
        Color F_FrameColor; //цвет обрамл¤ющего пр¤моугольника
        Font F_Font;
        int F_PenWidth;  // ширина пена
        Pen F_PenStyle;  //стиль пена
        Brush F_BrushStyle; //стиль браша
        string F_Caption; //подпись фигуры
        bool F_DrawFrame; //рисовать фрейм
        Pen F_PenMode;

        Color F_LineColor;
        int F_LineWidth;
        Pen F_LineStyle;
        Pen F_LineMode;
        Point F_Ofs_Point;

        bool F_IsLineCopy;  //Корировать ли свойства линий
        bool F_IsBrushCopy;
        bool F_IsFontCopy;
        bool F_IsPenCopy;

        bool F_DrawCaption;

        bool F_DrawFirstFlag;
        bool F_DrawLastFlag;
        bool F_DrawMiddleFlag;

        TShapeCopy FOnShapeCopy;
         //     TLineCopy FOnLineCopy;
        bool f_LEControl;
        /*          HWND F_WndHandler;*/
        Control F_UnderControl;
        /*       TColor F_FlagColor;
               int F_FlagType;
               TColor F_FlagSColor;
               int F_FlagSType;
               TColor F_FlagEColor;
               int F_FlagEType;
               TColor F_FrameColorTFE;

               TListFlag* ListFlag;
               TWSFlagCreate FOnWSFlagCreate;
               TWSFlagDestroy FOnWSFlagDestroy;
               bool f_ApplyAttribute;*/
               int f_ParentShapeID;
         /*      int f_Tag;
               TAfterLinePrepare FOnAfterLinePrepare;
               bool f_LEActive;
               int f_BaseOffsetX;
               int f_BaseOffsetY;
               TColor f_BaseLineColor;*/
        TCompositeBaseWork f_CompositeWorkShape;


        /*     void PenCopy();
             void BrushCopy();
             void FontCopy();
             void LineCopy();
             void __fastcall SetLEControl(bool Value);
             void __fastcall SetWndHandler(const HWND Value);*/
        void DoSetLEControl()
        {
            int i;
            TBaseShape bs;
            TRectLine line;
            for (i = 0; i <= WorkShapes.Count - 1; i++)
            {
                bs = (TBaseShape)WorkShapes.ElementAt(i);
                bs.LEControl = f_LEControl;
            }
            for (i = 0; i <= WorkLines.Count - 1; i++)
            {
                line = (TRectLine)WorkLines.ElementAt(i);
                line.LEControl = f_LEControl;
            }
        }
        /*     void DoSetWndHandler();
        //            public void SetUnderControl(Control Value);
        /*         void DoSetUnderCotrol();
                 void DoSetFlag();
                 void DoSetFlagS();
                 void DoSetFlagE();

                 void __fastcall FlagCreate(TRectLine* ASender, TFlagShape* AFlag, int APosFlag);
                 void __fastcall FlagDestroy(TRectLine* ASender, TFlagShape* AFlag, int APosFlag);

                 TRectLine* __fastcall GetRectLineItem(int AIndex);
                 int __fastcall GetRectLineCount();
                 void DoSetLEActive();
                 void __fastcall SetLEActive(bool AValue);
                 void __fastcall SetBaseLineColor(TColor AValue);

                 protected:*/
        protected int F_Step;
        protected int F_NumberShapeId;
        int F_NumberLineId;
        protected int F_LastShapeId;
        int F_LastLineId;
        int F_WidthWork;
        protected int F_Indent;
        public void FreeWorkShapes()
        {
            WorkShapes.Clear();
        }
       /*               int __fastcall virtual GetTypeShape();*/
        public virtual Point GetEndPoint()
        {
            return new Point(0, 0);
        }
        /*           int __fastcall GetWorkLinesCount();
                   int __fastcall GetWorkShapesCount();
                   void __fastcall virtual SetStartPoint(TPoint Value);
                   TPoint __fastcall virtual GetStartPoint();*/
        void SetBaseStartPoint(Point Value)
        {
            f_BaseStartPoint = Value;
        }
        bool GetDrawCaption()
        {
            return F_DrawCaption;
        }
        void  SetDrawCaption(bool Value)
        {
            TBaseShape baseShape;
            F_DrawCaption = Value;
            for (int i = 0; i <= WorkShapes.Count - 1; i++)
            {
                baseShape = (TBaseShape)WorkShapes.ElementAt(i);
                baseShape.DrawCaption = F_DrawCaption;
            }
        }
         /*          void __fastcall SetFont(Graphics::TFont* Value);
                   int virtual CalcBend(int t_x1, int t_x2);
                   void PaintFirstFlag();
                   void PaintLastFlag();
                   void PaintMiddleFlag();
                   virtual TRectLine* __fastcall GetFirstLine();
                   virtual TRectLine* __fastcall GetLastLine();
                   virtual TRectLine* __fastcall GetMiddleLine();
                   void __fastcall SetDrawFirstFlag(bool Value);
                   void __fastcall SetDrawLastFlag(bool Value);
                   void __fastcall SetDrawMiddleFlag(bool Value);
                   void __fastcall SetApplyAttribute(bool Value);*/
        public virtual void PrepareLines()
        {
            /*      if (f_CompositeWorkShape)
                  {
                      f_CompositeWorkShape.Prepare();
                      return;
                  }

                  DoSetLEControl();
                  DoSetWndHandler();
                  DoSetUnderCotrol();
                  DoSetLEActive();
                  PrepareLines();
                  PaintFirstFlag();
                  PaintLastFlag();
                  PaintMiddleFlag();*/
        }
        /*       virtual int __fastcall GetOffsetXFromStart();
               virtual int __fastcall  CalcWidthWork();*/
        void  SetCompositeWorkShape(TCompositeBaseWork ACWS)
        {
            f_CompositeWorkShape = ACWS;
            if (f_CompositeWorkShape!=null)
            {
           /*     f_CompositeWorkShape.FirstLine.UnderControl = F_UnderControl;
                f_CompositeWorkShape.FirstLine.WndHandler = F_WndHandler;
                f_CompositeWorkShape.FirstLine.OnRctFlagCreate = &FlagCreate;
                f_CompositeWorkShape.FirstLine.OnRctFlagDestroy = &FlagDestroy;*/

            }
        }

        public TBaseWorkShape(int X, int Y, int Step, int NumberShape_Id, int Block_Id, int NumberLine_Id)
        {
            F_Step = Step;
            F_NumberShapeId = NumberShape_Id;
            F_NumberLineId = NumberLine_Id;
            F_BlockId = Block_Id;
            F_LastShapeId = F_NumberShapeId;
            F_LastLineId = F_NumberLineId;

            F_StartPoint = new Point(X, Y);   
            f_BaseStartPoint = F_StartPoint;

            F_BrushColor = Color.White;
            //         F_BrushStyle = bsClear;
            F_PenColor = Color.Black;
            F_FrameColor = Color.Red;
            //         F_PenMode = pmCopy;
            //         F_Font = new Graphics::TFont;

            F_PenWidth = 1;
            //        F_PenStyle = psSolid;
            //         F_DrawFrame = false;

            F_LineColor = Color.Black;
            F_LineWidth = 1;
            //        F_LineStyle = psSolid;
            //         F_LineMode = pmCopy;

            F_IsLineCopy = true;
            F_IsBrushCopy = true;
            F_IsFontCopy = true;
            F_IsPenCopy = true;
            //          OnShapeCopy = NULL;
            //        OnLineCopy = NULL;
            F_DrawCaption = true;

            F_DrawFirstFlag = false;
            F_DrawLastFlag = false;
            F_DrawMiddleFlag = false;

            WorkShapes = new List<object>();
            WorkLines = new List<object>();
         //   ListFlag = new List<object>();

            f_LEControl = false;
            /*           F_WndHandler = 0;
                       F_UnderControl = NULL;

                       F_FlagColor = clWhite;
                       F_FlagType = 0;
                       F_FlagSColor = clWhite;
                       F_FlagSType = 0;
                       F_FlagEColor = clWhite;
                       F_FlagEType = 0;
                       F_FrameColorTFE = clRed;

                       FOnWSFlagCreate = NULL;
                       FOnWSFlagDestroy = NULL;
                       f_ApplyAttribute = true;
                       F_DrawCaption = true;
                       f_ParentShapeID = 0;
                 /*      f_Tag = 0;
                       FOnAfterLinePrepare = NULL;
                       f_LEActive = true;
                       f_BaseOffsetX = 0;
                       f_BaseOffsetY = 0;
                       F_WidthWork = 0;
                       F_Indent = 0;
                       f_CompositeWorkShape = NULL;*/
        }
        ~TBaseWorkShape() { }
        public virtual void Init() { }
        public virtual void Prepare()
        {
            if (f_CompositeWorkShape != null)
            {
                f_CompositeWorkShape.Prepare();
                return;
            }
            DoSetLEControl();
         /*   DoSetWndHandler();
            DoSetUnderCotrol();
            DoSetLEActive();*/
            PrepareLines();
        /*    PaintFirstFlag();
            PaintLastFlag();
            PaintMiddleFlag();*/
        }
        /*             virtual void Paint(TCanvas* Canvas);
                     virtual TBaseShape* GetShapeByLine(TRectLine* ALine, int APos);
                     void AddShape(TBaseShape* N);
                     void AddLine(TArrowLine* L);
                     TBaseShape* GetWorkShape(int num);
                     TBaseShape* GetWorkNode(int num);
                     TArrowLine* GetWorkLine(int num);
                     void SetOffsetPosition(int X_Ofs, int Y_Ofs);
                     void SetBaseOffsetPosition(int X_Ofs, int Y_Ofs);*/
        public Rectangle GetFrameRectWithLines()
        {
            Rectangle Res, R_tmp;
            TBaseShape baseShape;
            TArrowLine currLine;
            int i;
            if (CompositeWorkShape!=null)
                return CompositeWorkShape.GetMaxRect();

            baseShape = (TBaseShape)WorkShapes.ElementAt(0);
            Res = baseShape.GetRect();

            for (i = 1; i <= WorkShapes.Count - 1; i++)
            {
                baseShape = (TBaseShape)WorkShapes.ElementAt(i);
                R_tmp = baseShape.GetRect();
                if (R_tmp.Left < Res.Left) Res.X = R_tmp.Left;
                if (R_tmp.Right > Res.Right) Res.Width = R_tmp.Right;
                if (R_tmp.Top < Res.Top) Res.Y = R_tmp.Top;
                if (R_tmp.Bottom > Res.Bottom) Res.Height = R_tmp.Bottom;
            }


            for (i = 0; i <= WorkLines.Count - 1; i++)
            {
                currLine = (TArrowLine)WorkLines.ElementAt(i);
                if (currLine.xStart < Res.Left) Res.X = currLine.xStart;
                if (currLine.xEnd < Res.Left) Res.X = currLine.xEnd;
                if (currLine.xStart > Res.Right) Res.Width = currLine.xStart;
                if (currLine.xEnd > Res.Right) Res.Width = currLine.xEnd;

                if (currLine.yStart < Res.Top) Res.Y = currLine.yStart;
                if (currLine.yEnd < Res.Top) Res.Y = currLine.yEnd;
                if (currLine.yStart > Res.Bottom) Res.Width = currLine.yStart;
                if (currLine.yEnd > Res.Bottom) Res.Width = currLine.yEnd;

            }

            Res.X = Res.Left - SharedConst.OFFS_FRAME * PenWidth;
            Res.Y = Res.Top - SharedConst.OFFS_FRAME * PenWidth;
            Res.Width = Res.Right + SharedConst.OFFS_FRAME * PenWidth;
            Res.Height = Res.Bottom + SharedConst.OFFS_FRAME * PenWidth;
            F_Ofs_Point.X = Res.Left - F_StartPoint.X;
            F_Ofs_Point.Y = Res.Top - F_StartPoint.Y;
            return Res;
        }
              /*       TRect FrameRectToRect(TRect R);
                     TPoint GetStartPointFromFrameRect(TRect R);*/
        public Rectangle GetMaxRect()
        {
            Rectangle Res, R_tmp;
            TBaseShape baseShape;
            TArrowLine currLine;
            if (CompositeWorkShape!=null)
                return CompositeWorkShape.GetMaxRect();
            baseShape = (TBaseShape)WorkShapes.ElementAt(0);
            Res = baseShape.GetRect();
            for (int i = 1; i <= WorkShapes.Count - 1; i++)
            {
                baseShape = (TBaseShape)WorkShapes.ElementAt(i);
                R_tmp = baseShape.GetRect();
                if (R_tmp.Left < Res.Left) Res.X = R_tmp.Left;
                if (R_tmp.Right > Res.Right) Res.Width = R_tmp.Right;
                if (R_tmp.Top < Res.Top) Res.Y = R_tmp.Top;
                if (R_tmp.Bottom > Res.Bottom) Res.Height = R_tmp.Bottom;
            }

            for (int i = 0; i <= WorkLines.Count - 1; i++)
            {
                currLine = (TArrowLine)WorkLines.ElementAt(i);
                if (currLine.xStart < Res.Left) Res.X = currLine.xStart;
                if (currLine.xEnd < Res.Left) Res.X = currLine.xEnd;
                if (currLine.xStart > Res.Right) Res.Width = currLine.xStart;
                if (currLine.xEnd > Res.Right) Res.Width = currLine.xEnd;

                if (currLine.yStart < Res.Top) Res.Y = currLine.yStart;
                if (currLine.yEnd < Res.Top) Res.Y = currLine.yEnd;
                if (currLine.yStart > Res.Bottom) Res.Height = currLine.yStart;
                if (currLine.yEnd > Res.Bottom) Res.Height = currLine.yEnd;

            }


            Res.X = Res.Left - SharedConst.OFFS_FRAME * PenWidth;
            Res.Y = Res.Top - SharedConst.OFFS_FRAME * PenWidth;
            Res.Width = Res.Right + SharedConst.OFFS_FRAME * PenWidth;
            Res.Height = Res.Bottom + SharedConst.OFFS_FRAME * PenWidth;
            F_Ofs_Point.X = Res.Left - F_StartPoint.X;
            F_Ofs_Point.Y = Res.Top - F_StartPoint.Y;
            return Res;
        }
        /*         bool KeepFlag(TBaseShape* Flag, int &type);*/
        public void FreeWorkLines()
        {
            WorkLines.Clear();
        }
       /*          virtual bool MakeFlagForShape(TBaseShape* AShape, bool ACreate, int APos, int AType, TColor AColor);
                 int ShapeSupport(TBaseShape* AShape);
                 TBaseShape* ShapeSupportID(int AShapeID);
                 void ShowAllFlagForSahpe(int AType, TColor AColor);
                 void HideAllFlagForSahpe();
                 virtual void CreateLines();
                 int ReactMouse(TPoint APoint);
                 int Bend(int t_x1, int t_x2);
                 TPoint OffsetStartPoint();
                 TPoint GetStartPointOneComposite();
                 virtual void TrimFirstLine(bool ATrimComposite, TPoint APStart, TPoint APEnd);
                 __property TPoint StartPoint = {read = GetStartPoint, write = SetStartPoint*/
        public Point BaseStartPoint
        {
            set { SetBaseStartPoint(value); }
            get { return f_BaseStartPoint; }
        }

        /*   __property TColor  BrushColor = {read = F_BrushColor, write = F_BrushColor};
                __property TBrushStyle BrushStyle = {read = F_BrushStyle, write = F_BrushStyle};

                __property TColor  PenColor = {read = F_PenColor, write = F_PenColor};*/
        public int PenWidth
        {
            set { F_PenWidth = value; }
            get { return F_PenWidth; }
        }
   /*        __property TPenStyle PenStyle = {read = F_PenStyle, write = F_PenStyle};
                __property TPenMode PenMode = {read = F_PenMode, write = F_PenMode};
                __property Graphics::TFont*  Font = { read = F_Font, write = SetFont};
           __property TColor FrameColor  = {read = F_FrameColor, write = F_FrameColor};
                __property TColor FrameColorTFE  = {read = F_FrameColorTFE, write = F_FrameColorTFE};
                __property bool DrawFrame = { read = F_DrawFrame, write = F_DrawFrame };

           __property TColor    LineColor = {read = F_LineColor, write = F_LineColor};
                __property int LineWidth = { read = F_LineWidth, write = F_LineWidth };
           __property TPenStyle LineStyle = {read = F_LineStyle, write = F_LineStyle};
                __property TPenMode  LineMode  = {read = F_LineMode,  write = F_LineMode};
                __property bool IsLineCopy = { read = F_IsLineCopy, write = F_IsLineCopy };
           __property bool IsBrushCopy = { read = F_IsBrushCopy, write = F_IsBrushCopy };
           __property bool IsFontCopy = { read = F_IsFontCopy, write = F_IsFontCopy };
           __property bool IsPenCopy = { read = F_IsPenCopy, write = F_IsPenCopy };
           __property int TypeShape = { read = GetTypeShape };*/
        public TShapeCopy  OnShapeCopy
        {
            set { FOnShapeCopy = value; }
            get { return FOnShapeCopy; }
        }
 /*               __property TLineCopy  OnLineCopy = {read = FOnLineCopy, write = FOnLineCopy};*/
        public int FirstShapeId
        {
            get { return F_NumberShapeId; }
        }
        public int LastShapeId
        {
            get { return F_LastShapeId; }
        }

        public int FirstLineId
        {
            get { return F_NumberLineId; }
        }

        public int LastLineId
        {
            get { return F_LastLineId; }
        }
        public Point EndPoint
        {
            get { return GetEndPoint(); }
        }
/*           __property int WorkShapesCount = { read = GetWorkShapesCount };
      __property int WorkLinesCount = { read = GetWorkLinesCount };*/
      public bool DrawCaption
        { set { SetDrawCaption(value); }
            get { return GetDrawCaption(); }
        }
 /*     __property bool DrawFirstFlag = { read = F_DrawFirstFlag, write = SetDrawFirstFlag };
      __property bool DrawLastFlag = { read = F_DrawLastFlag, write = SetDrawLastFlag };
      __property bool DrawMiddleFlag = { read = F_DrawMiddleFlag, write = SetDrawMiddleFlag };*/
      public int BlockId
        {
            set { F_BlockId = value; }
            get { return F_BlockId; }
        }
/*      __property int ShapeId = { read = F_NumberShapeId };
      __property int LineId = { read = F_NumberLineId };
      //     __property TTrailer* FirstTrailer = {read = F_FirstTrailer};
      //     __property TTrailer* LastTrailer = {read = F_LastTrailer};
      __property TRectLine* FirstLine = { read = GetFirstLine };
      __property TRectLine* LastLine = { read = GetLastLine };
      __property TRectLine* MiddleLine = { read = GetMiddleLine };
      //     __property TWinControl *ParentWindow = {read = F_ParentWindow, write = SetParentWindow};*/
        public bool LEControl
        {
            set { f_LEControl = value; }
            get { return f_LEControl; }
        }
/*__property HWND WndHandler = {read = F_WndHandler, write = SetWndHandler};*/
        public Control UnderControl
        {
            set { F_UnderControl = value; }
            get { return F_UnderControl; }
        }
        /*__property TColor      FlagColor = {read = F_FlagColor, write = F_FlagColor};
             __property int FlagType = { read = F_FlagType, write = F_FlagType };

        __property TColor      FlagSColor = {read = F_FlagSColor, write = F_FlagSColor};
             __property int FlagSType = { read = F_FlagSType, write = F_FlagSType };

        __property TColor      FlagEColor = {read = F_FlagEColor, write = F_FlagEColor};
             __property int FlagEType = { read = F_FlagEType, write = F_FlagEType };
        __property int Step = { read = F_Step };

        __property TWSFlagCreate   OnWSFlagCreate = {read = FOnWSFlagCreate, write = FOnWSFlagCreate};
             __property TWSFlagDestroy  OnWSFlagDestroy = {read = FOnWSFlagDestroy, write = FOnWSFlagDestroy};

             __property TRectLine* RectLineItems[int AIndex] = { read = GetRectLineItem };
        __property int RectLineCount = { read = GetRectLineCount };
        __property bool ApplyAttribute = { read = f_ApplyAttribute, write = SetApplyAttribute };*/
        public int ParentShapeID {
            set { f_ParentShapeID = value; }
            get { return f_ParentShapeID;  }
        }
  /*      __property int Tag = { read = f_Tag, write = f_Tag };
        __property TAfterLinePrepare OnAfterLinePrepare =  {read = FOnAfterLinePrepare, write = FOnAfterLinePrepare};
             __property bool LEActive = { read = f_LEActive, write = SetLEActive };
        __property int OffsetXFromStart = { read = GetOffsetXFromStart };
        __property int BaseOffsetX = { read = f_BaseOffsetX };
        __property int BaseOffsetY = { read = f_BaseOffsetY };
        __property int WidthWork = { read = CalcWidthWork };
        __property int Indent = { read = F_Indent };
        __property TColor BaseLineColor = {read = f_BaseLineColor, write = SetBaseLineColor};*/
        public TCompositeBaseWork CompositeWorkShape
        {
            set { SetCompositeWorkShape(value); }
            get { return f_CompositeWorkShape;  }
        }
    }
}
