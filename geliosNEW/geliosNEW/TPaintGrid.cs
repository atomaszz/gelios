using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace geliosNEW
{
    class TPaintGrid
    {
        //переменные
        int f_Width; //ширина
        int f_Height; //высота
        int f_StepPixels; //Шаг пиксела
        int f_StepPixelsGrid; //Шаг пиксела сетки
        bool f_PaintPixels; //рисовать ли пикселы
        Color f_FonColor; //цвет фона
        Color f_PixelColor; //цвет пиксела
                            /*      TCanvas* f_Canvas; //канва
                                  HWND f_OwnerForm;  //форма владельца
                                  bool f_RefreshFon; //нужно ли перерисовывать фон
                                  int f_WSPenWidth; //толщина линий ТФЕ
                                  Graphics::TBitmap* ScrBitmap;
                                  Graphics::TBitmap* ScrBitmapCopy;
                                  bool f_LEControl;
                                  //     TWinControl *f_ParentWindow;
                                  TControl* f_UnderControl;
                                  HWND f_WndHandler;*/
        Point f_CurrEndPoint; //координаты последней точки
                              /*           TClipPath* f_ClipPath; //класс пути отсечения
                                         TListForPaint* f_ListForPaint; //содержит фигуры для отрисовки
                                         TFlagController* f_FlagController; //контроллер флагов
                                         TInvalidateList* f_InvalidateList; //список отрисовываемых фигур реально
                                         TLineCutting* f_LineCutting; //фигура при перетаскивании
                                         TAltWSList* f_AltWSList;//содержит ссодержитписок ТФС для показа альтернативы


                                         int f_X_offs; //смещение по Х
                                         int f_Y_offs; //смещение по Y
                                         int f_X_offsSum;
                                         int f_Y_offsSum;
                                         TColor f_LineColor;
                                         bool f_BrushTFE;
                                         TColor f_BrushColor;
                                         Graphics::TFont* f_FontTFE;
                                         TColor f_LeaveFlagColor;
                                         TColor f_EnterFlagColor;
                                         int f_FlagType;
                                         int f_CurrentCommand; // 1- добавление ТФЕ
                                         int f_TypMouseOperation; //тип операции с мышью
                                         TBaseShape* f_SelectedTFE; //выбранная ТФЕ
                                         TBaseWorkShape* f_SelectedTFS; //выбранная ТФС
                                         TColor f_FrameColorTFE; //цвет линии обрамления ТФЕ
                                         TColor f_FrameColorTFS; //цвет линии обрамления ТФC
                                         bool f_WSMoving;
                                         int f_WSMovingCount;
                                         TFlagShape* f_SelectedFlag; //выбранный флажок*/
                              /*  TBaseWorkShape* f_SelectedAlternateFirst; //первая выбранная ТФС для альтернативы
                                TBaseWorkShape* f_SelectedAlternateLast; //первая выбранная ТФС для альтернативы
                                TBaseWorkShape* f_SelectedDeleteTFSFirst; //первая выбранная ТФС для альтернативы
                                TBaseWorkShape* f_SelectedDeleteTFSLast; //первая выбранная ТФС для альтернативы

                                TColor f_AltFlagColor;
                                TColor f_AltEnterFlagColor;
                                TColor f_AltArrowColor;
                                TColor f_AltEnterArrowColor;
                                TColor f_AltLineColor;
                                TColor f_AltEnabledFlagColor;
                                bool f_localVisiblearrowall;

                                // функции
                                void __fastcall SetStepPixels(int Value);
                                void __fastcall SetStepPixelsGrid(int Value);
                                void __fastcall SetPaintPixels(bool Value);
                                void __fastcall SetFonColor(TColor Value);
                                void __fastcall SetPixelColor(TColor Value);
                                void __fastcall SetLineColor(TColor Value);
                                void __fastcall SetBrushTFE(bool Value);
                                void __fastcall SetBrushColor(TColor Value);
                                void __fastcall SetFontTFE(Graphics::TFont* Value);
                                void __fastcall SetFlagType(int Value);
                                void __fastcall SetEnterFlagColor(TColor Value);
                                void __fastcall SetLeaveFlagColor(TColor Value);
                                void __fastcall SetFrameColorTFE(TColor Value);
                                void __fastcall SetFrameColorTFS(TColor Value);
                                void __fastcall SetTypMouseOperation(int Value);
                                void __fastcall SetAltFlagColor(TColor Value);
                                void __fastcall SetAltEnterFlagColor(TColor Value);
                                void __fastcall SetAltArrowColor(TColor Value);
                                void __fastcall SetAltEnterArrowColor(TColor Value);
                                void __fastcall SetAltLineColor(TColor Value);
                                void __fastcall SetAltEnabledFlagColor(TColor Value);

                                void FreeBitmap();
                                void FreeBitmapCopy();
                                void CreateGrid(int Ax, int Ay);
                                void CreateSrcBitmap(int Ax, int Ay);
                                void CreateSrcBitmapCopy(int Ax, int Ay);
                                void RepaintFon(int Ax, int Ay);
                                void DoPaint();
                                void CopyFon();
                                void ApplyAttributeForWorkShape(TBaseWorkShape* WS); // применяет аттрибуты для ТФС
                                void ApplyAttributeForCompositeWorkShape(TBaseWorkShape* WS);
                                void BeforeResize();*/
        void RecalcCurrEndPoint()  // расчет последней координаты последней ТФС в f_CurrEndPoint
        {
            TBaseWorkShape TempWork;
 /*           TempWork = g_PainterList.Last();
            if (TempWork!=null)
                f_CurrEndPoint = TempWork.EndPoint();*/
        }

                           /*   void __fastcall WsFlagCreate(TFlag* AFlag, TBaseWorkShape* WS);
                              void __fastcall WsFlagDestroy(TFlag* AFlag, TBaseWorkShape* WS);
                              bool SelectTFE(int Ax, int Ay);
                              bool SelectTFS(int Ax, int Ay);
                              void NilTFE();
                              void NilTFS();
                              TBaseWorkShape* FindNextWorkShape(TBaseWorkShape* W);
                              TBaseWorkShape* FindPriorWorkShape(TBaseWorkShape* W);
                              TBaseWorkShape* __fastcall GetLastWorkShape();
                              TBaseWorkShape* __fastcall GetFirstWorkShape();
                              void RecalcFollowWorkShape(TBaseWorkShape* ABeforeInsertWork, TBaseWorkShape* AInsertWork);
                              void PaintAlternateList();
                              bool CreateAternative(TFlagShape* AFlag);
                              bool CreateDeleteTFSList(TFlagShape* AFlag);
                              void NilAternative();
                              void NilDeleteTFSList();*/

        /*    int GetMainTabCount();


            __property int TypMouseOperation = { read = f_TypMouseOperation, write = SetTypMouseOperation };




          */
//        TPainterList g_PainterList; //класс содержащие рабочие блоки
     /*   TAlternateList* g_AlternateList;

        TPaintGrid(TCanvas* ACanvas, HWND AOwnerForm);
        ~TPaintGrid();

        void Recreate(int AWidth, int AHeight);
        void Paint();*/
/*        public TBaseWorkShape AddWorkShape(int AType, int ACurrIDShape, int ACurrIDBlock, int ACurrIDLine)
        {
            TBaseWorkShape m_CurrWorkShape;
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
                        m_CurrWorkShape = new TZWork(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 4:
                        m_CurrWorkShape = new TZWorkOR(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 5:
                        m_CurrWorkShape = new TControlWork(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 6:
                        m_CurrWorkShape = new TControlFunc(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 7:
                        m_CurrWorkShape = new TBifurcation(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 8:
                        m_CurrWorkShape = new TCheckConditionCW(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 9:
                        m_CurrWorkShape = new TCycleWhileDo(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 10:
                        m_CurrWorkShape = new TCycleDoWhileDo(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 11:
                        m_CurrWorkShape = new TCycleDoWhileDoFC(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                    case 12:
                        m_CurrWorkShape = new TCheckCondition(f_CurrEndPoint.x, f_CurrEndPoint.y, f_StepPixels, ACurrIDShape, ACurrIDBlock, ACurrIDLine);
                        break;
                }


                m_CurrWorkShape->LEControl = f_LEControl;
                m_CurrWorkShape->WndHandler = f_WndHandler;
                m_CurrWorkShape->UnderControl = f_UnderControl;
                m_CurrWorkShape->OnWSFlagCreate = WsFlagCreate;
                m_CurrWorkShape->OnWSFlagDestroy = WsFlagDestroy;
                m_CurrWorkShape->BaseStartPoint.x += -f_X_offsSum;
                m_CurrWorkShape->BaseStartPoint.y += -f_Y_offsSum;
                m_CurrWorkShape->Init();
                m_CurrWorkShape->Prepare();
                f_CurrEndPoint = m_CurrWorkShape->EndPoint;

                f_CurrentCommand = 1;
            }
            return m_CurrWorkShape;
        }*/
  /*      TBaseWorkShape* InsertWorkShape(int AType, TBaseWorkShape* AWBefore, int ACurrIDShape, int ACurrIDBlock, int ACurrIDLine);
        HRGN GetRegion(TBaseWorkShape* WS, int AOfs);*/
 /*       Point GetPointPolygon(int AXoffs = 0, int AYoffs = 0) //определение макисмальной точки полигона
        {
            Point res = new Point(0, 0);
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            TBaseWorkShape TempWork;

 /*           TempWork = g_PainterList->First();
            while (TempWork!=null)
            {
                temp = TempWork.GetMaxRect();
                if (temp.Right > res.X) res.X = temp.Right;
                if (temp.Bottom > res.Y) res.Y = temp.Bottom;
                TempWork = g_PainterList->Next();
            }
            res.X = res.X + AXoffs;
            res.Y = res.Y + AYoffs;
            return res;*/
        }
   /*     TPoint GetTopPoint(int AXoffs = 0, int AYoffs = 0);
        void ApplyOffset(int AX, int AY);*/
 /*       public void PreparePaint()
        {
  /*          TBaseWorkShape CurrShape;
            CurrShape = g_PainterList.First();
            while (CurrShape!=null)
            {
                CurrShape.Prepare();
                CurrShape = g_PainterList.Next();
            }
            RecalcCurrEndPoint();
        }*/

  /*      int ApplyVisibleFlag(int APosition, bool AVisible); //показать флажки по всем ТФС по заданной позиции
        int ApplyVisibleFlagForAlternative(bool AVisible);///показать флажки по всем ТФС для создания альтернативы
        int ApplyVisibleFlagForDeleteTFS(bool AVisible);///показать флажки по всем ТФС для удаления от точки до точки
        void ReapintFlag(bool AEnter, TBaseShape* AFlag);
        void ReactMouse(TPoint APoint);*/
 /*       public void MouseUp(object sender, MouseEventArgs e)
        {
            int m_x, m_y;
            TBaseWorkShape W;
      /*      TPoint PO;
           if (f_WSMoving && (f_TypMouseOperation == 2))
            {
                f_LineCutting->EndMoving(m_x, m_y);
                f_LineCutting->WorkShape = NULL;
                f_SelectedTFS->SetOffsetPosition(m_x, m_y);

                if (f_SelectedTFS->CompositeWorkShape && !f_LineCutting->IsFirstWS)
                {
                    PO = f_SelectedTFS->GetStartPointOneComposite();
                    f_SelectedTFS->CompositeWorkShape->MakeFirstLine(PO, f_SelectedTFS->Bend(PO.x, f_SelectedTFS->FirstLine->xEnd));
                }
                else
                    f_SelectedTFS->Prepare();
                f_WSMoving = false;

                W = FindNextWorkShape(f_SelectedTFS);
                if (f_LineCutting->IsFirstWS)
                {
                    PO = TPoint(f_SelectedTFS->StartPoint.x + m_x, f_SelectedTFS->StartPoint.y + m_y);
                    f_SelectedTFS->StartPoint = PO;
                    //        f_SelectedTFS->BaseStartPoint.x = f_SelectedTFS->BaseStartPoint.x + m_x;
                    //        f_SelectedTFS->BaseStartPoint.y = f_SelectedTFS->BaseStartPoint.y + m_y;
                    f_SelectedTFS->Prepare();
                    if (!f_LineCutting->IsLastWS)
                    {
                        if (W)
                        {
                            W->StartPoint = f_SelectedTFS->EndPoint;
                            if (W->CompositeWorkShape)
                            {
                                PO = W->GetStartPointOneComposite();
                                W->CompositeWorkShape->MakeFirstLine(PO, W->Bend(PO.x, W->FirstLine->xEnd));
                            }
                        }
                    }
                }
                else
                {
                    if (W)
                    {
                        PO = TPoint(f_SelectedTFS->EndPoint.x, f_SelectedTFS->EndPoint.y);
                        W->StartPoint = PO;
                        if (W->CompositeWorkShape)
                        {
                            PO = W->GetStartPointOneComposite();
                            W->CompositeWorkShape->MakeFirstLine(PO, W->Bend(PO.x, W->FirstLine->xEnd));
                        }
                        W->Prepare();
                    }
                }
                RecalcBaseOffsetPosition();
                SendMessage(f_OwnerForm, WM_GD_PAINT, 0, 0);

                if (f_LineCutting->IsLastWS)
                    PostMessage(f_OwnerForm, WM_GD_SETNEWPOLYGON, 1, 1);
                else
                    PostMessage(f_OwnerForm, WM_GD_SETNEWPOLYGON, 1, 0);

            }
            if (f_localVisiblearrowall)
            {
                SendMessage(f_OwnerForm, WM_GD_VISIBLEARROWALL, 1, 1);
                f_localVisiblearrowall = false;
            }

            if (f_Regim == 1)
            {                                                
                if (f_SelectedFlag)
                {
                    int m_pos = 0;
                    TFlagControllerItem* CI = f_FlagController->FindByFlagShape(f_SelectedFlag);
                    if (CI)
                        m_pos = CI->Signal->Position;
                    PostMessage(f_OwnerForm, WM_GD_INSERTWORKSHAPE, WPARAM(m_pos),
                      LPARAM(f_FlagController->FindWorkShape(f_SelectedFlag)));
                }
            }
            if (f_Regim == 2)// ñîçäàíèå àëüòåðíàòèâ
            {
                if (CreateAternative(f_SelectedFlag))
                    PostMessage(f_OwnerForm, WM_GD_SETALTERNATE, WPARAM(f_SelectedAlternateFirst),
                      LPARAM(f_SelectedAlternateLast));
            }
            if (f_Regim == 4)// ñîçäàíèå ñïèñêà äëÿ óäàëåíèÿ ÒÔÑ
            {
                if (CreateDeleteTFSList(f_SelectedFlag))
                    PostMessage(f_OwnerForm, WM_GD_DELETETFSLIST, WPARAM(f_SelectedDeleteTFSFirst),
                      LPARAM(f_SelectedDeleteTFSLast));
            }
            if (f_Regim == 5)//âñòàâêà ÒÔÑ èç ôàéëà
            {
                if (f_SelectedFlag)
                {
                    int m_pos = 0;
                    TFlagControllerItem* CI = f_FlagController->FindByFlagShape(f_SelectedFlag);
                    if (CI)
                        m_pos = CI->Signal->Position;
                    PostMessage(f_OwnerForm, WM_GD_INSERTWORKSHAPEFROMFILE, WPARAM(m_pos),
                      LPARAM(f_FlagController->FindWorkShape(f_SelectedFlag)));
                }
            }
            if (f_Regim == 6)// ñîçäàíèå ñïèñêà äëÿ êîïèðîâàíèÿ ÒÔÑ
            {
                if (CreateDeleteTFSList(f_SelectedFlag))
                    PostMessage(f_OwnerForm, WM_GD_COPYTFSLIST, WPARAM(f_SelectedDeleteTFSFirst),
                      LPARAM(f_SelectedDeleteTFSLast));
            }
            if (f_Regim == 7)//âñòàâêà ÒÔÑ èç áóôåðà
            {
                if (f_SelectedFlag)
                {
                    int m_pos = 0;
                    TFlagControllerItem* CI = f_FlagController->FindByFlagShape(f_SelectedFlag);
                    if (CI)
                        m_pos = CI->Signal->Position;
                    PostMessage(f_OwnerForm, WM_GD_INSERTWORKSHAPEFROMCANAL, WPARAM(m_pos),
                      LPARAM(f_FlagController->FindWorkShape(f_SelectedFlag)));
                }
            }*/
        }
    /*    void MouseMove(TObject* Sender, TShiftState Shift, int X, int Y);
        void MouseDown(TObject* Sender, TMouseButton Button, TShiftState Shift, int X, int Y);
        void PrepareLevel();
        void PrepareLevelOnOffset();
        void ClearAltWSList();
        void AddToAltWSList(TBaseWorkShape* AWS);
        HRGN GetRGNAltWSList();
        bool IsAltWSListEmpty();
        TBaseShape* FindTFE(int Ax, int Ay);
        TBaseWorkShape* FindTFS(int Ax, int Ay);*/
  /*      public TAlternateItem FindAlternateItem(int Ax, int Ay)
        {
            TAlternateItem Item;
            Item = g_AlternateList->First();
            while (Item)
            {
                if (PtInRect(&Item->ArrowWorkShape->GetSmallRegionRect(), TPoint(Ax, Ay)))
                    return Item;
                Item = g_AlternateList->Next();
            }
            return Item;
        }*/

  /*      void ClearAll();
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
        __property int Height = { read = f_Height };
        __property int StepPixels = { read = f_StepPixels, write = SetStepPixels };
        __property int StepPixelsGrid = { read = f_StepPixelsGrid, write = SetStepPixelsGrid };
        __property bool PaintPixels = { read = f_PaintPixels, write = SetPaintPixels };
        __property TColor  FonColor = {read = f_FonColor, write = SetFonColor
    };
    __property TColor  PixelColor = {read = f_PixelColor, write = SetPixelColor
};
__property bool LEControl = { read = f_LEControl, write = f_LEControl };
__property HWND WndHandler = {read = f_WndHandler, write = f_WndHandler};
   __property TControl* UnderControl = { read = f_UnderControl, write = f_UnderControl };
__property int WSPenWidth = { read = f_WSPenWidth, write = f_WSPenWidth };
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
 //  public int Regim { get; set; }
        /*__property TBaseWorkShape* LastWorkShape = { read = GetLastWorkShape };
        __property TBaseWorkShape* FirstWorkShape = { read = GetFirstWorkShape };
        __property int OffsetSumX = { read = f_X_offsSum };
        __property int OffsetSumY = { read = f_Y_offsSum };
        __property TBaseShape* SelectedTFE = { read = f_SelectedTFE };
        __property TBaseWorkShape* SelectedTFS = { read = f_SelectedTFS, write = f_SelectedTFS };
        __property TColor AltFlagColor = {read = f_AltFlagColor, write = SetAltFlagColor};
           __property TColor AltEnterFlagColor = {read = f_AltEnterFlagColor, write = SetAltEnterFlagColor};
           __property TColor AltArrowColor = {read = f_AltArrowColor, write = SetAltArrowColor};
           __property TColor AltEnterArrowColor = {read = f_AltEnterArrowColor, write = SetAltEnterArrowColor};
           __property TColor AltLineColor = {read = f_AltLineColor, write = SetAltLineColor};
           __property TColor AltEnabledFlagColor = {read = f_AltEnabledFlagColor, write = SetAltEnabledFlagColor};
           __property int MouseOperation = { read = f_TypMouseOperation };
        */
