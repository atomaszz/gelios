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
        public delegate void TAfterLinePrepare(TBaseWorkShape WS);
        public delegate void TLineCopy(TArrowLine Line, int Num_Line);
        public delegate void TWSFlagCreate(TFlag AFlag, TBaseWorkShape WS);
        public delegate void TWSFlagDestroy(TFlag AFlag, TBaseWorkShape WS);
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
        TLineCopy FOnLineCopy;
        bool f_LEControl;
        /*          HWND F_WndHandler;*/
        Control F_UnderControl;
        Color F_FlagColor;
        int F_FlagType;
        Color F_FlagSColor;
        int F_FlagSType;
        Color F_FlagEColor;
        int F_FlagEType;
        Color F_FrameColorTFE;
        TListFlag ListFlag;
        TWSFlagCreate FOnWSFlagCreate;
        TWSFlagDestroy FOnWSFlagDestroy;
        bool f_ApplyAttribute;
        int f_ParentShapeID;
        int f_Tag;
        TAfterLinePrepare FOnAfterLinePrepare;
        bool f_LEActive;
        int f_BaseOffsetX;
        int f_BaseOffsetY;
        Color f_BaseLineColor;
        TCompositeBaseWork f_CompositeWorkShape;
        void PenCopy()
        {
            TBaseShape currShape;
            int i;
            if (!F_IsPenCopy) return;
            for (i = 0; i <= WorkShapes.Count - 1; i++)
            {
                currShape = (TBaseShape)WorkShapes.ElementAt(i);
                currShape.PenColor = PenColor;
                currShape.PenWidth = PenWidth;
                //   currShape.PenStyle = PenStyle;
                //  currShape.PenMode = PenMode;
            }
        }
        /*     void BrushCopy();
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
        void DoSetWndHandler()
        {
            int i;
            TBaseShape bs;
            TRectLine line;
            for (i = 0; i <= WorkShapes.Count - 1; i++)
            {
                bs = (TBaseShape)(WorkShapes.ElementAt(i));
                //       bs.WndHandler = F_WndHandler;
            }
            for (i = 0; i <= WorkLines.Count - 1; i++)
            {
                line = (TRectLine)WorkLines.ElementAt(i);
                //       line.WndHandler = F_WndHandler;
            }
        }
        //            public void SetUnderControl(Control Value);
        void DoSetUnderCotrol()
        {
            int i;
            TBaseShape bs;
            TRectLine line;
            for (i = 0; i <= WorkShapes.Count - 1; i++)
            {
                bs = (TBaseShape)WorkShapes.ElementAt(i);
                //      bs.UnderControl = F_UnderControl;
            }
            for (i = 0; i <= WorkLines.Count - 1; i++)
            {
                line = (TRectLine)WorkLines.ElementAt(i);
                //    line.UnderControl = F_UnderControl;
            }
        }
        /*          void DoSetFlag();
                  void DoSetFlagS();
                  void DoSetFlagE();*/
        void FlagCreate(TRectLine ASender, TFlagShape AFlag, int APosFlag)
        {
            bool res = false;
            TBaseShape Shape = GetShapeByLine(ASender, APosFlag);
            TFlag Flag = ListFlag.AddFlag(AFlag, Shape, ASender, APosFlag, ref res);
            if (!res && FOnWSFlagCreate != null) OnWSFlagCreate(Flag, this);

        }
        void FlagDestroy(TRectLine ASender, TFlagShape AFlag, int APosFlag)
        {
            TFlag Flag = ListFlag.DeleteFlagByShape(AFlag);
            if (Flag != null && FOnWSFlagDestroy != null) OnWSFlagDestroy(Flag, this);
        }

        /*           TRectLine* __fastcall GetRectLineItem(int AIndex);
                   int __fastcall GetRectLineCount();*/
        void DoSetLEActive()
        {
            int i;
            TBaseShape bs;
            for (i = 0; i <= WorkShapes.Count - 1; i++)
            {
                bs = (TBaseShape)(WorkShapes.ElementAt(i));
                //            bs.LEActive = f_LEActive;
            }
        }
        /*            void __fastcall SetLEActive(bool AValue);*/
        void SetBaseLineColor(Color AValue)
        {
            TArrowLine Line;
            f_BaseLineColor = AValue;
            for (int i = WorkLines.Count - 1; i >= 0; i--)
            {
                Line = (TArrowLine)(WorkLines.ElementAt(i));
                Line.BaseLineColor = f_BaseLineColor;
            }
        }
        protected int F_Step;

        int F_TypeShape;
        Rectangle F_RealRect;   //Реальный прямоугольник рисования


        protected int F_NumberShapeId;
        protected int F_NumberLineId;
        protected int F_LastShapeId;
        protected int F_LastLineId;
        protected int F_WidthWork;
        protected int F_Indent;
        public void FreeWorkShapes()
        {
            WorkShapes.Clear();
        }
        public virtual int GetTypeShape()
        {
            return F_TypeShape;
        }
        public virtual Point GetEndPoint()
        {
            return new Point(0, 0);
        }
        int GetWorkLinesCount()
        {
            return WorkLines.Count;
        }
        int  GetWorkShapesCount()
        {
            return WorkShapes.Count;
        }
        public virtual void SetStartPoint(Point Value)
        {
            F_StartPoint = Value;
        }
        public virtual Point GetStartPoint()
        {
            if (f_CompositeWorkShape != null)
                return f_CompositeWorkShape.StartPoint;
            return F_StartPoint;
        }
        void SetBaseStartPoint(Point Value)
        {
            f_BaseStartPoint = Value;
        }
        bool GetDrawCaption()
        {
            return F_DrawCaption;
        }
        void SetDrawCaption(bool Value)
        {
            TBaseShape baseShape;
            F_DrawCaption = Value;
            for (int i = 0; i <= WorkShapes.Count - 1; i++)
            {
                baseShape = (TBaseShape)WorkShapes.ElementAt(i);
                baseShape.DrawCaption = F_DrawCaption;
            }
        }
        /*          void __fastcall SetFont(Graphics::TFont* Value);*/
        public virtual int CalcBend(int t_x1, int t_x2)
        {
            int res = 0;
            if (t_x1 < t_x2) res = 2;
            if (t_x1 > t_x2) res = 3;
            return res;
        }
        void PaintFirstFlag()
        {
            FirstLine.DrawFlagS = F_DrawFirstFlag;
            FirstLine.Prepare();
        }
        void PaintLastFlag()
        {
            LastLine.DrawFlagE = F_DrawLastFlag;
            LastLine.Prepare();
        }
        void PaintMiddleFlag()
        {
            if (MiddleLine!=null)
            {
                MiddleLine.DrawFlag = F_DrawMiddleFlag;
                MiddleLine.Prepare();
            }
        }
        public virtual TRectLine GetFirstLine()
        {
            if (f_CompositeWorkShape!=null)
                return f_CompositeWorkShape.FirstLine;
            return null;
        }
        public virtual TRectLine GetLastLine()
        {
            return null;
        }
        public virtual TRectLine GetMiddleLine()
        {
            return null;
        }
              /*  void __fastcall SetDrawFirstFlag(bool Value);
                void __fastcall SetDrawLastFlag(bool Value);
                void __fastcall SetDrawMiddleFlag(bool Value);
                void __fastcall SetApplyAttribute(bool Value);*/
        public virtual void PrepareLines()
        {
            TRectLine line;
            for (int i = 0; i <= WorkLines.Count - 1; i++)
            {
                line = (TRectLine)(WorkLines.ElementAt(i));
                line.OnRctFlagCreate = FlagCreate;
                line.OnRctFlagDestroy = FlagDestroy;
                line.Prepare();
            }
            if (WorkLines.Count > 0)
                if (FOnAfterLinePrepare!=null) OnAfterLinePrepare(this);
        }
        /*       virtual int __fastcall GetOffsetXFromStart();*/
        public virtual int CalcWidthWork()
        {
            F_WidthWork = LastLine.xEnd - FirstLine.xEnd;
            return F_WidthWork;
        }
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
         //   ListFlag =  new List<object>();

            f_LEControl = false;
            /*           F_WndHandler = 0;
                       F_UnderControl = NULL;*/
            F_FlagColor = Color.White;
            F_FlagType = 0;
            F_FlagSColor = Color.White;
            F_FlagSType = 0;
            F_FlagEColor = Color.White;
            F_FlagEType = 0;
            F_FrameColorTFE = Color.Red;

            FOnWSFlagCreate = null;
            FOnWSFlagDestroy = null;
            f_ApplyAttribute = true;
            F_DrawCaption = true;
            f_ParentShapeID = 0;
            f_Tag = 0;
            FOnAfterLinePrepare = null;
            f_LEActive = true;
            f_BaseOffsetX = 0;
            f_BaseOffsetY = 0;
            F_WidthWork = 0;
            F_Indent = 0;
            f_CompositeWorkShape = null;
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
            DoSetWndHandler();
            DoSetUnderCotrol();
            DoSetLEActive();
            PrepareLines();
            PaintFirstFlag();
            PaintLastFlag();
            PaintMiddleFlag();
        }
        public virtual void Paint(Graphics Canvas)
        {
            int i;
            TBaseShape currShape;
            TArrowLine currLine;
            Color OldPenColor;
            if (f_CompositeWorkShape!=null)
            {
                f_CompositeWorkShape.Selected = F_DrawFrame;
                f_CompositeWorkShape.Paint(Canvas);
                return;
            }
            PenCopy();
      //      BrushCopy();
     //       FontCopy();
            for (i = 0; i <= WorkShapes.Count - 1; i++)
            {
                currShape = (TBaseShape)WorkShapes.ElementAt(i);
                currShape.FrameColor = F_FrameColorTFE;

                OldPenColor = currShape.PenColor;
                if (F_DrawFrame) currShape.PenColor = F_FrameColor;

                if (OnShapeCopy!=null) OnShapeCopy(currShape, i); //переставлено
                currShape.Paint(Canvas);
                currShape.PenColor = OldPenColor;

            }
     /*       LineCopy();

            DoSetFlag();
            DoSetFlagS();
            DoSetFlagE();*/

            for (i = 0; i <= WorkLines.Count - 1; i++)
            {
                currLine = (TArrowLine)WorkLines.ElementAt(i);
                if (OnLineCopy!=null) OnLineCopy(currLine, i);
                OldPenColor = currLine.Color;
                if (F_DrawFrame) currLine.Color = F_FrameColor;
                currLine.Paint(Canvas);
                currLine.Color = OldPenColor;
            }
        }
        public virtual TBaseShape GetShapeByLine(TRectLine ALine, int APos)
        {
            return null;
        }
        public void AddShape(TBaseShape N)
        {
            WorkShapes.Add(N);
        }
        public void AddLine(TArrowLine L)
        {
            WorkLines.Add(L);
        }
        public TBaseShape GetWorkShape(int num)
        {
            TBaseShape Res = null;
            if ((num >= 0) || (num < WorkShapes.Count))
                Res = (TBaseShape)(WorkShapes.ElementAt(num));
            return Res;
        }
        TBaseShape GetWorkNode(int num)
        {
            TBaseShape N = null;
            if ((num >= 0) || (num < WorkShapes.Count))
                N = (TBaseShape)(WorkShapes.ElementAt(num));
            return N;
        }
        public TArrowLine GetWorkLine(int num)
        {
            TArrowLine Res = null;
            if ((num >= 0) || (num < WorkLines.Count))
                Res = (TArrowLine)(WorkLines.ElementAt(num));
            return Res;
        }
        void SetOffsetPosition(int X_Ofs, int Y_Ofs)
        {
            Rectangle R;
            TBaseShape baseShape;
            TRectLine baseLine;
            if (CompositeWorkShape!=null)
            {
                CompositeWorkShape.ApplyOffset(X_Ofs, Y_Ofs);
                return;
            }
            for (int i = 0; i <= WorkShapes.Count - 1; i++)
            {
                baseShape = (TBaseShape)(WorkShapes.ElementAt(i));
                R = baseShape.BoundRect;
                R.X = R.Left + X_Ofs;
                R.Width = R.Right + X_Ofs;
                R.Y = R.Top + Y_Ofs;
                R.Width = R.Bottom + Y_Ofs;
                baseShape.BoundRect = R;
            }
        }
        void SetBaseOffsetPosition(int X_Ofs, int Y_Ofs)
        {
            f_BaseOffsetX = X_Ofs;
            f_BaseOffsetY = Y_Ofs;
        }
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
                 virtual void TrimFirstLine(bool ATrimComposite, TPoint APStart, TPoint APEnd);*/
        public Point StartPoint
        {
            set { SetStartPoint(value); }
            get { return GetStartPoint();  }

        }
        public Point BaseStartPoint
        {
            set { SetBaseStartPoint(value); }
            get { return f_BaseStartPoint; }
        }

        public Color  BrushColor
        {
            set { F_BrushColor = value; }
            get { return F_BrushColor; }
        }
          /*      __property TBrushStyle BrushStyle = {read = F_BrushStyle, write = F_BrushStyle};*/

        public Color  PenColor
        {
            set { F_PenColor = value; }
            get { return F_PenColor; }
        }
        public int PenWidth
        {
            set { F_PenWidth = value; }
            get { return F_PenWidth; }
        }
        /*        __property TPenStyle PenStyle = {read = F_PenStyle, write = F_PenStyle};
                     __property TPenMode PenMode = {read = F_PenMode, write = F_PenMode};
                     __property Graphics::TFont*  Font = { read = F_Font, write = SetFont};*/
        public Color FrameColor
        {
            set { F_FrameColor = value; }
            get { return F_FrameColor; }
        }
        public Color FrameColorTFE
        {
            set { F_FrameColorTFE = value; }
            get { return F_FrameColorTFE; }
        }
        public bool DrawFrame
        {
            set { F_DrawFrame = value; }
            get { return F_DrawFrame; }
        }
        public Color LineColor
        {
            set { F_LineColor = value; }
            get { return F_LineColor; }
        }
        public int LineWidth
        {
            set { F_LineWidth = value; }
            get { return F_LineWidth; }
        }
        /*       __property TPenStyle LineStyle = {read = F_LineStyle, write = F_LineStyle};
                    __property TPenMode  LineMode  = {read = F_LineMode,  write = F_LineMode};
                    __property bool IsLineCopy = { read = F_IsLineCopy, write = F_IsLineCopy };
               __property bool IsBrushCopy = { read = F_IsBrushCopy, write = F_IsBrushCopy };
               __property bool IsFontCopy = { read = F_IsFontCopy, write = F_IsFontCopy };
               __property bool IsPenCopy = { read = F_IsPenCopy, write = F_IsPenCopy };*/
        public int TypeShape
        {
            get { return GetTypeShape(); }
        }
        public TShapeCopy  OnShapeCopy
        {
            set { FOnShapeCopy = value; }
            get { return FOnShapeCopy; }
        }
        public TLineCopy  OnLineCopy
        {
            set { FOnLineCopy = value; }
            get { return FOnLineCopy; }
        }
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
        public int WorkShapesCount
        {
            get { return GetWorkShapesCount(); }
        }
        public int WorkLinesCount
        {
            get { return GetWorkLinesCount(); }
        }   
      public bool DrawCaption
        {
          set { SetDrawCaption(value); }
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
              //     __property TTrailer* LastTrailer = {read = F_LastTrailer};*/
        public TRectLine FirstLine
        {
            get { return GetFirstLine(); }
        }
        public TRectLine LastLine
        {
            get { return GetLastLine();  }
        }
        public TRectLine MiddleLine
        {
            get { return GetMiddleLine(); }
        }
            
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
        public Color FlagColor
        {
            set { F_FlagColor = value; }
            get { return F_FlagColor; }
        }
        public int FlagType
        {
            set { F_FlagType = value; }
            get { return F_FlagType; }
        }
        public Color FlagSColor
        {
            set { F_FlagSColor = value; }
            get { return F_FlagSColor; }
        }
        public int FlagSType
        {
            set { F_FlagSType = value; }
            get { return F_FlagSType; }
        }

        public Color FlagEColor
        {
            set { F_FlagEColor = value; }
            get { return F_FlagEColor; }
        }
        public int FlagEType
        {
            set { F_FlagEType = value; }
            get { return F_FlagEType; }
        }
        public int Step
        {
            get { return F_Step; }
        }
        public TWSFlagCreate OnWSFlagCreate
        {
            set { FOnWSFlagCreate = value; }
            get { return FOnWSFlagCreate;  }
        }
        public TWSFlagDestroy  OnWSFlagDestroy
        {
            set { FOnWSFlagDestroy = value; }
            get { return FOnWSFlagDestroy;  }
        }    

      /*       __property TRectLine* RectLineItems[int AIndex] = { read = GetRectLineItem };
        __property int RectLineCount = { read = GetRectLineCount };
        __property bool ApplyAttribute = { read = f_ApplyAttribute, write = SetApplyAttribute };*/
        public int ParentShapeID {
            set { f_ParentShapeID = value; }
            get { return f_ParentShapeID;  }
        }
        /*      __property int Tag = { read = f_Tag, write = f_Tag };*/
        public TAfterLinePrepare OnAfterLinePrepare
        {
            set { FOnAfterLinePrepare = value; }
            get { return FOnAfterLinePrepare; }
        }

        /*          __property bool LEActive = { read = f_LEActive, write = SetLEActive };
             __property int OffsetXFromStart = { read = GetOffsetXFromStart };
             __property int BaseOffsetX = { read = f_BaseOffsetX };
             __property int BaseOffsetY = { read = f_BaseOffsetY };
             __property int WidthWork = { read = CalcWidthWork };
             __property int Indent = { read = F_Indent };*/
        public Color BaseLineColor
        {
            set { SetBaseLineColor(value); }
            get { return f_BaseLineColor; }
        }
        public TCompositeBaseWork CompositeWorkShape
        {
            set { SetCompositeWorkShape(value); }
            get { return f_CompositeWorkShape;  }
        }
    }
}
