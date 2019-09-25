using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    class TPaintGrid
    {
        //---переменные---//
        int f_Width; //ширина
        int f_Height; //высота
        int f_StepPixels; //Шаг пиксела
        int f_StepPixelsGrid; //Шаг пиксела сетки
        bool f_PaintPixels; //рисовать ли пикселы
        Color f_FonColor; //цвет фона
        Color f_PixelColor; //цвет пиксела
        Graphics f_Canvas; //канва
        Form f_OwnerForm;  //форма владельца
        bool f_RefreshFon; //нужно ли перерисовывать фон
        int f_WSPenWidth; //толщина линий ТФЕ
        Graphics ScrBitmap;
        Graphics ScrBitmapCopy;
        bool f_LEControl;
        Control f_UnderControl;
        IntPtr f_WndHandler;
        Point f_CurrEndPoint; //координаты последней точки
                              //      TClipPath f_ClipPath; //класс пути отсечения
        TListForPaint f_ListForPaint; //содержит фигуры для отрисовки
                                      //       TFlagController f_FlagController; //контроллер флагов
        TInvalidateList f_InvalidateList; //список отрисовываемых фигур реально
        TLineCutting f_LineCutting; //фигура при перетаскивании
        TAltWSList f_AltWSList;//содержит ссодержитписок ТФС для показа альтернативы


        int f_X_offs; //смещение по Х
        int f_Y_offs; //смещение по Y
        int f_X_offsSum;
        int f_Y_offsSum;
        Color f_LineColor;
        bool f_BrushTFE;
        Color f_BrushColor;
        Font f_FontTFE;
        Color f_LeaveFlagColor;
        Color f_EnterFlagColor;
        int f_FlagType;
        int f_CurrentCommand; // 1- добавление ТФЕ
        int f_TypMouseOperation; //тип операции с мышью
                                 //       TBaseShape f_SelectedTFE; //выбранная ТФЕ
        TBaseWorkShape f_SelectedTFS; //выбранная ТФС
        Color f_FrameColorTFE; //цвет линии обрамления ТФЕ
        Color f_FrameColorTFS; //цвет линии обрамления ТФC
        bool f_WSMoving;
        int f_WSMovingCount;
        TFlagShape f_SelectedFlag; //выбранный флажок
        int f_Regim;
        TBaseWorkShape f_SelectedAlternateFirst; //первая выбранная ТФС для альтернативы
        TBaseWorkShape f_SelectedAlternateLast; //первая выбранная ТФС для альтернативы
        TBaseWorkShape f_SelectedDeleteTFSFirst; //первая выбранная ТФС для альтернативы
        TBaseWorkShape f_SelectedDeleteTFSLast; //первая выбранная ТФС для альтернативы

        Color f_AltFlagColor;
        Color f_AltEnterFlagColor;
        Color f_AltArrowColor;
        Color f_AltEnterArrowColor;
        Color f_AltLineColor;
        Color f_AltEnabledFlagColor;
        bool f_localVisiblearrowall;

        // функции
        void  SetStepPixels(int Value)
        {
            if (Value < 5) Value = 5;
            if (Value > 12) Value = 12;
            f_StepPixels = Value;
        }
        public void UpdateGraphics(Graphics ACanvas)
        {
                f_Canvas = ACanvas;
        }
        void  SetStepPixelsGrid(int Value)
        {
            if (Value < 5) Value = 5;
            if (Value > 12) Value = 12;
            f_StepPixelsGrid = Value;
        }
        /*    void  SetPaintPixels(bool Value);
            void  SetFonColor(TColor Value);
            void  SetPixelColor(TColor Value);
            void  SetLineColor(TColor Value);
            void  SetBrushTFE(bool Value);
            void  SetBrushColor(TColor Value);
            void  SetFontTFE(Graphics::TFont* Value);
            void  SetFlagType(int Value);
            void  SetEnterFlagColor(TColor Value);
            void  SetLeaveFlagColor(TColor Value);
            void  SetFrameColorTFE(TColor Value);
            void  SetFrameColorTFS(TColor Value);
            void  SetTypMouseOperation(int Value);
            void  SetAltFlagColor(TColor Value);
            void  SetAltEnterFlagColor(Color Value);
            void  SetAltArrowColor(Color Value);
            void  SetAltEnterArrowColor(Color Value);
            void  SetAltLineColor(TColor Value);
            void  SetAltEnabledFlagColor(Color Value);

            void FreeBitmap();
            void FreeBitmapCopy();
            void CreateGrid(int Ax, int Ay);
            void CreateSrcBitmap(int Ax, int Ay);
            void CreateSrcBitmapCopy(int Ax, int Ay);*/
        void RepaintFon(int Ax, int Ay)
        {
            int j, i, m_X, m_Y;
            int x_offs, y_offs;
       //     m_X = ScrBitmap.Width;
       //     m_Y = ScrBitmap.Height;
            if (Math.Abs(Ax) < f_StepPixelsGrid) x_offs = Ax;
   /*         else
            {
                th = div(Ax, f_StepPixelsGrid);
                x_offs = th.rem;
            }
            if (abs(Ay) < f_StepPixelsGrid) y_offs = Ay;
            else
            {
                th = div(Ay, f_StepPixelsGrid);
                y_offs = th.rem;
            }

            ScrBitmap.Canvas.Brush.Color = f_FonColor;
            ScrBitmap.Canvas.FillRect(TRect(0, 0, m_X, m_Y));
            if (f_PaintPixels && (f_StepPixelsGrid > 0))
            {
                for (i = x_offs; i <= m_X + abs(x_offs); i = i + f_StepPixelsGrid)
                {
                    for (j = y_offs; j <= m_Y + abs(y_offs); j = j + f_StepPixelsGrid)
                        ScrBitmap.Canvas.Pixels[i][j] = f_PixelColor;
                }
            }
            ScrBitmapCopy.Canvas.CopyRect(Bounds(0, 0, m_X, m_Y), ScrBitmap.Canvas, Bounds(0, 0, m_X, m_Y));*/
        }
        void DoPaint()
        {
            int i;
            TBaseWorkShape WP;
            TBaseShape BS;
            TListForPaintItem ItemPaint;

            if (f_RefreshFon)
                RepaintFon(f_X_offsSum, f_Y_offsSum);
            else
                CopyFon();


            if ((f_ListForPaint.Count == 0) && (f_RefreshFon ||
              (f_CurrentCommand != 0)))
            {
                f_InvalidateList.Clear();
                WP = g_PainterList.First();
                while (WP!=null)
                {
                    f_InvalidateList.AddWorkShape(WP);
                    if ((WP == f_LineCutting.WorkShape) && (f_WSMovingCount == 0)) continue;
                    ApplyAttributeForWorkShape(WP);
                    WP.Paint(f_Canvas);
                    WP = g_PainterList.Next();
                }
            }

            if ((f_ListForPaint.Count == 0) && (!f_RefreshFon && (f_CurrentCommand == 0)))
            {
                for (i = 0; i <= f_InvalidateList.Count - 1; i++)
                {
                    WP = (TBaseWorkShape)f_InvalidateList.Items[i];
                    if ((WP == f_LineCutting.WorkShape) && (f_WSMovingCount == 0)) continue;
                    ApplyAttributeForWorkShape(WP);
                    WP.Paint(f_Canvas);
                }
            }

            if (f_ListForPaint.Count > 0)
            {
                for (i = 0; i <= f_ListForPaint.Count - 1; i++)
                {
                    ItemPaint =  (TListForPaintItem)f_ListForPaint.Items[i];
                    switch (ItemPaint.Type)
                    {
                        case 0:
                            BS = (TBaseShape)ItemPaint.ClassPoint;
                            BS.Paint(f_Canvas);
                            break;
                        case 1:
                            WP = (TBaseWorkShape)ItemPaint.ClassPoint;
                            ApplyAttributeForWorkShape(WP);
                            if ((WP == f_LineCutting.WorkShape) && (f_WSMovingCount == 0)) continue;
                            WP.Paint(f_Canvas);
                            break;
                    }
                }
                f_ListForPaint.Clear();
            }
            PaintAlternateList();
            f_RefreshFon = false;//f_Srolling;
            f_CurrentCommand = 0;
        }
        void CopyFon()
        {
            int aX, aY;
    //   /     aX = ScrBitmapCopy.Width;
//aY = ScrBitmapCopy.Height;
   //         ScrBitmap.Canvas.CopyRect(Bounds(0, 0, aX, aY), ScrBitmapCopy.Canvas, Bounds(0, 0, aX, aY));
        }
        void ApplyAttributeForWorkShape(TBaseWorkShape WS) // применяет аттрибуты для ТФС
        {
            WS.PenWidth = f_WSPenWidth;
            WS.LineWidth = f_WSPenWidth;
            WS.PenColor = f_LineColor;
            WS.BaseLineColor = f_LineColor;
        /*    if (f_BrushTFE)
                WS.BrushStyle = bsSolid;
            else
                WS.BrushStyle = bsClear;*/
            WS.BrushColor = f_BrushColor;
        //    WS.Font = f_FontTFE;
            WS.FlagSType = f_FlagType;
            WS.FlagEType = f_FlagType;
            WS.FrameColorTFE = f_FrameColorTFE;
            WS.FrameColor = f_FrameColorTFS;
            if (WS.CompositeWorkShape!=null)
            {
                WS.CompositeWorkShape.SetColorAll(f_LineColor);
                WS.CompositeWorkShape.SetBrushColorAll(f_BrushColor);
        //        WS.CompositeWorkShape.SetBrushStyleAll(WS.BrushStyle);
            }
            if (f_AltWSList.Find(WS))
            {
                WS.PenColor = f_AltLineColor;
                if (WS.CompositeWorkShape!=null)
                    WS.CompositeWorkShape.SetColorAll(f_AltLineColor);
            }
            ApplyAttributeForCompositeWorkShape(WS);
        }
        void ApplyAttributeForCompositeWorkShape(TBaseWorkShape WS)
        {
            if (WS.CompositeWorkShape!=null)
            {
                WS.CompositeWorkShape.FirstLine.FlagSType = WS.FlagSType;
                WS.CompositeWorkShape.FirstLine.FlagEType = WS.FlagEType;
            }
        }
   /*     void BeforeResize();*/
        void RecalcCurrEndPoint()  // расчет последней координаты последней ТФС в f_CurrEndPoint
        {
            TBaseWorkShape TempWork;
            TempWork = g_PainterList.Last();
            if (TempWork!=null)
                f_CurrEndPoint = TempWork.EndPoint;

        }
        /*   void  WsFlagCreate(TFlag AFlag, TBaseWorkShape WS);
           void  WsFlagDestroy(TFlag AFlag, TBaseWorkShape WS);
           bool SelectTFE(int Ax, int Ay);
           bool SelectTFS(int Ax, int Ay);
           void NilTFE();
           void NilTFS();
           TBaseWorkShape FindNextWorkShape(TBaseWorkShape W);
           TBaseWorkShape FindPriorWorkShape(TBaseWorkShape W);*/
        TBaseWorkShape  GetLastWorkShape()
        {
            return g_PainterList.Last();
        }
        /*    TBaseWorkShape  GetFirstWorkShape();
            void RecalcFollowWorkShape(TBaseWorkShape ABeforeInsertWork, TBaseWorkShape AInsertWork);*/
        void PaintAlternateList()
        {
      /*      TAlternateItem Item;
            Item = g_AlternateList.First();
            while (Item!=null)
            {
                if (Item.Visible)
                    Item.ArrowWorkShape.Paint(ScrBitmap.Canvas);
                Item = g_AlternateList.Next();
            }*/
        }
     /*      bool CreateAternative(TFlagShape AFlag);
           bool CreateDeleteTFSList(TFlagShape AFlag);*/
        void NilAternative()
        {
            /*       if (f_SelectedAlternateFirst)
                       f_SelectedAlternateFirst.Tag = 0;
                   if (f_SelectedAlternateLast)
                       f_SelectedAlternateLast.Tag = 0;
                   f_SelectedAlternateFirst = f_SelectedAlternateLast = null;*/
        }
        void NilDeleteTFSList()
        {
            /*            if (f_SelectedDeleteTFSFirst)
                            f_SelectedDeleteTFSFirst.Tag = 0;
                        if (f_SelectedDeleteTFSLast)
                            f_SelectedDeleteTFSLast.Tag = 0;
                        f_SelectedDeleteTFSFirst = f_SelectedDeleteTFSLast = null;*/
        }
        void SetRegim(int Value)
        {
            // int m_OldRegim;
            if (f_Regim != Value)
            {
                //   m_OldRegim = f_Regim;
                f_Regim = Value;
                switch (f_Regim)
                {
                    case 0:
                        {
                            NilAternative();
                            NilDeleteTFSList();
                            break;
                        }
                    case 1:
                        {
                            NilAternative();
                            NilDeleteTFSList();
                            break;

                        }
                    case 2:
                        {
                            NilDeleteTFSList();
                            break;
                        }
                    case 3:
                        {
                            NilDeleteTFSList();
                            break;
                        }
                    case 5:
                        {
                            NilAternative();
                            NilDeleteTFSList();
                            break;
                        }
                    case 7:
                        {
                            NilAternative();
                            NilDeleteTFSList();
                            break;
                        }
                }
            }
        }
        /*      int GetMainTabCount();


              int TypMouseOperation 
              {
                  get { return f_TypMouseOperation; }
                  //          set { SetTypMouseOperation(value); }
              }*/

        public TPainterList g_PainterList; //класс содержащие рабочие блоки
        public TAlternateList g_AlternateList;

        public TPaintGrid(UMainFrm AOwnerForm/*TCanvas* ACanvas, HWND AOwnerForm*/)
        {
            f_Width = f_Height = 0;
            f_StepPixels = 6;
            f_StepPixelsGrid = 8;
            f_FonColor = Color.White;
            f_PixelColor = Color.Black;
            f_PaintPixels = true;
            f_OwnerForm = AOwnerForm;
            f_LEControl = false;
            f_WndHandler = new IntPtr();
            f_UnderControl = null;
            f_RefreshFon = true;
            f_CurrEndPoint = new Point(40, 100);
            f_X_offs = 0; //смещение по Х
            f_Y_offs = 0; //смещение по Y
            f_WSPenWidth = 1;
            f_X_offsSum = f_Y_offsSum = 0;
            f_LineColor = Color.Black;
            f_BrushTFE = false;
            f_BrushColor = Color.White;
            f_LeaveFlagColor = Color.Red;
            f_EnterFlagColor = Color.Lime;
            f_CurrentCommand = 0;
            f_FlagType = 0;
            f_TypMouseOperation = 0;
            //         f_SelectedTFE = null;
            f_SelectedTFS = null;
            //         f_FrameColorTFE = null;
            //        f_FrameColorTFS = null;
            f_WSMoving = false;
            //    f_SelectedFlag = null;
            f_Regim = 0;
            f_SelectedAlternateFirst = null; //первая выбранная ТФС для альтернативы
            f_SelectedAlternateLast = null; //первая выбранная ТФС для альтернативы
            f_SelectedDeleteTFSFirst = null; //первая выбранная ТФС для альтернативы
            f_SelectedDeleteTFSLast = null; //первая выбранная ТФС для альтернативы


            /*        f_FontTFE = new Font();
                    ScrBitmap = new Graphics::TBitmap;
                    ScrBitmapCopy = new Graphics::TBitmap;
                    f_ClipPath = new TClipPath;*/
            g_PainterList = new TPainterList();
            f_ListForPaint = new TListForPaint();
            /*   f_FlagController = new TFlagController();*/
            f_InvalidateList = new TInvalidateList();
            f_LineCutting = new TLineCutting(f_Canvas);
            g_AlternateList = new TAlternateList();
            f_AltWSList = new TAltWSList();
            f_localVisiblearrowall = false;
        }
        ~TPaintGrid() { }

        /*       public void Recreate(int AWidth, int AHeight);*/
        public void Paint()
        {
            DoPaint();
            //        f_Canvas.Draw(0, 0, ScrBitmap);
        }
        public TBaseWorkShape AddWorkShape(int AType, int ACurrIDShape, int ACurrIDBlock, int ACurrIDLine)
        {
            TBaseWorkShape m_CurrWorkShape = null;
            if (AType > 0)
            {
                switch (AType)
                {
                    case 1:
                        m_CurrWorkShape = new TWork(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 2:
                        m_CurrWorkShape = new TWork(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 3:
                        m_CurrWorkShape = new TZWork(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 4:
                        m_CurrWorkShape = new TZWorkOR(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 5:
                        m_CurrWorkShape = new TControlWork(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 6:
                        m_CurrWorkShape = new TControlFunc(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 7:
                        m_CurrWorkShape = new TBifurcation(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 8:
                        m_CurrWorkShape = new TCheckConditionCW(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 9:
                        m_CurrWorkShape = new TCycleWhileDo(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 10:
                        m_CurrWorkShape = new TCycleDoWhileDo(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 11:
                        m_CurrWorkShape = new TCycleDoWhileDoFC(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 12:
                        m_CurrWorkShape = new TCheckCondition(f_CurrEndPoint.X, f_CurrEndPoint.Y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                }


                m_CurrWorkShape.LEControl = f_LEControl;
                //      m_CurrWorkShape.WndHandler = f_WndHandler;
                m_CurrWorkShape.UnderControl = f_UnderControl;
                //m_CurrWorkShape.OnWSFlagCreate = WsFlagCreate;
                //      m_CurrWorkShape.OnWSFlagDestroy = WsFlagDestroy;
                m_CurrWorkShape.BaseStartPoint =
                    new Point(m_CurrWorkShape.BaseStartPoint.X - f_X_offsSum, m_CurrWorkShape.BaseStartPoint.Y - f_Y_offsSum);
                m_CurrWorkShape.Init();
                m_CurrWorkShape.Prepare();
                f_CurrEndPoint = m_CurrWorkShape.EndPoint;

                f_CurrentCommand = 1;
            }
            return m_CurrWorkShape;
        }
        /*     public TBaseWorkShape InsertWorkShape(int AType, TBaseWorkShape* AWBefore, int ACurrIDShape, int ACurrIDBlock, int ACurrIDLine);
             HRGN GetRegion(TBaseWorkShape* WS, int AOfs);*/
        public Point GetPointPolygon(int AXoffs = 0, int AYoffs = 0) //определение макисмальной точки полигона
        {
            Point res = new Point(0, 0);
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            TBaseWorkShape TempWork;

            TempWork = g_PainterList.First();
            while (TempWork!=null)
            {
                temp = TempWork.GetMaxRect();
                if (temp.Right > res.X) res.X = temp.Right;
                if (temp.Bottom > res.Y) res.Y = temp.Bottom;
                TempWork = g_PainterList.Next();
            }
            res.X = res.X + AXoffs;
            res.Y = res.Y + AYoffs;
            return res;
        }
        /*       TPoint GetTopPoint(int AXoffs = 0, int AYoffs = 0);
         void ApplyOffset(int AX, int AY);*/
        public void PreparePaint()
        {
            TBaseWorkShape CurrShape;
            CurrShape = g_PainterList.First();
            while (CurrShape!=null)
            {
                CurrShape.Prepare();
                CurrShape = g_PainterList.Next();
            }
            RecalcCurrEndPoint();
        }
   /*     int ApplyVisibleFlag(int APosition, bool AVisible); //показать флажки по всем ТФС по заданной позиции
        int ApplyVisibleFlagForAlternative(bool AVisible);///показать флажки по всем ТФС для создания альтернативы
        int ApplyVisibleFlagForDeleteTFS(bool AVisible);///показать флажки по всем ТФС для удаления от точки до точки
        void ReapintFlag(bool AEnter, TBaseShape* AFlag);
        void ReactMouse(TPoint APoint);
        void MouseUp(TObject* Sender, TMouseButton Button, TShiftState Shift, int X, int Y);
        void MouseMove(TObject* Sender, TShiftState Shift, int X, int Y);
        void MouseDown(TObject* Sender, TMouseButton Button, TShiftState Shift, int X, int Y);
        void PrepareLevel();
        void PrepareLevelOnOffset();
        void ClearAltWSList();
        void AddToAltWSList(TBaseWorkShape* AWS);
        HRGN GetRGNAltWSList();
        bool IsAltWSListEmpty();
        TBaseShape* FindTFE(int Ax, int Ay);
        TBaseWorkShape* FindTFS(int Ax, int Ay);*/
     /*   TAlternateItem FindAlternateItem(int Ax, int Ay)
        {
            TAlternateItem Item;
            Item = g_AlternateList.First();
            while (Item!=null)
            {
                if (PtInRect(&Item.ArrowWorkShape.GetSmallRegionRect(), new Point(Ax, Ay)))
                    return Item;
                Item = g_AlternateList.Next();
            }
            return null;
        }*/
    /*    void ClearAll();
        void RecalcAfterDeleted(bool AFirst, TPoint FPoint);
        void SetWSFlagEvent(TBaseWorkShape* WS);
        void RecalcBaseOffsetPosition();
        void RecalcFollowWorkShape(TBaseWorkShape* ABeforeInsertWork, TPoint AEndPoint);
        void RecalcAfterConverted(bool AFirst, TPoint FPoint);
        TBaseWorkShape* FindShapeFromCompositeWork(int AShapeID);
        void CoordinateCorrectForCompositeWork();
        TCompositeBaseWorkItem* FindComositeBaseWork2(int ATFEID, TCompositeBaseWork** AFind);
        TBaseWorkShape* CreateTempWorkShape(int AType, TPoint AStart, int ANumberShapeId = 0);

        __property int Width = { read = f_Width };
        __property int Height = { read = f_Height };*/
        public int StepPixels
        {
            get { return f_StepPixels; }
            set { SetStepPixels(value); }
        }
        public int StepPixelsGrid
        {
            get { return f_StepPixelsGrid; }
            set { SetStepPixelsGrid(value); }
        }
        /*        __property TColor  FonColor = {read = f_FonColor, write = SetFonColor
            };
            __property TColor  PixelColor = {read = f_PixelColor, write = SetPixelColor
        };*/
        public bool LEControl
        {
            set { f_LEControl = value; }
            get { return f_LEControl; }
        }
        public  IntPtr WndHandler
        {
            set { f_WndHandler = value; }
            get { return f_WndHandler; }
        }
        public Control UnderControl
        {
            set { f_UnderControl = value;  }
            get { return f_UnderControl;  }
        }
/*__property int WSPenWidth = { read = f_WSPenWidth, write = f_WSPenWidth };
__property bool RefreshFon = { read = f_RefreshFon, write = f_RefreshFon };

__property TColor LineColor = {read = f_LineColor, write = SetLineColor};
   __property bool BrushTFE = { read = f_BrushTFE, write = SetBrushTFE };
__property TColor BrushColor = {read = f_BrushColor, write = SetBrushColor};
   __property Graphics::TFont* FontTFE = { read = f_FontTFE, write = SetFontTFE};
__property int FlagType = { read = f_FlagType, write = SetFlagType };
__property TColor LeaveFlagColor  = {read = f_LeaveFlagColor, write = SetLeaveFlagColor};
   __property TColor EnterFlagColor  = {read = f_EnterFlagColor, write = SetEnterFlagColor};
   __property TColor FrameColorTFE = {read = f_FrameColorTFE, write = SetFrameColorTFE};
   __property TColor FrameColorTFS = {read = f_FrameColorTFS, write = SetFrameColorTFS};*/
   public  int Regim
        {
            get { return f_Regim; }
            set { SetRegim(value); }
        }
        public TBaseWorkShape LastWorkShape 
        {
            get { return GetLastWorkShape(); }
        }
        /*  __property TBaseWorkShape* FirstWorkShape = { read = GetFirstWorkShape };*/
        public int OffsetSumX
        {
            get { return f_X_offsSum; }
        }
        public int OffsetSumY
        {
            get { return f_Y_offsSum; }
        }
  /*      __property TBaseShape* SelectedTFE = { read = f_SelectedTFE };
        __property TBaseWorkShape* SelectedTFS = { read = f_SelectedTFS, write = f_SelectedTFS };
        __property TColor AltFlagColor = {read = f_AltFlagColor, write = SetAltFlagColor};
           __property TColor AltEnterFlagColor = {read = f_AltEnterFlagColor, write = SetAltEnterFlagColor};
           __property TColor AltArrowColor = {read = f_AltArrowColor, write = SetAltArrowColor};
           __property TColor AltEnterArrowColor = {read = f_AltEnterArrowColor, write = SetAltEnterArrowColor};
           __property TColor AltLineColor = {read = f_AltLineColor, write = SetAltLineColor};
           __property TColor AltEnabledFlagColor = {read = f_AltEnabledFlagColor, write = SetAltEnabledFlagColor};
           __property int MouseOperation = { read = f_TypMouseOperation };*/
    }
}
