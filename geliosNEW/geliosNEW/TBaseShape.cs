using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace geliosNEW
{
    class TBaseShape
    {
  /*      Color F_BrushColor;  //цвет кисти
        Color F_PenColor;   //цвет пена
        Color F_FrameColor; //цвет обрамляющего прямоугольника
        Font F_Font;
        int F_PenWidth;  // ширина пена
        DashStyle F_PenStyle;  //стиль пена
        HatchStyle F_BrushStyle; //стиль браша
        String F_Caption; //подпись фигуры 
        bool F_DrawFrame; //рисовать фрейм
        Pen F_PenMode;

        Color F_Old_BrushColor;  //предыдущая характеристика
        Color F_Old_PenColor;
        HatchStyle F_Old_BrushStyle;
        Font F_Old_Font;
        int F_Old_PenWidth;
        DashStyle F_Old_PenStyle;
        Pen F_Old_PenMode;

        int F_Id; //íîìåð ôèãóðû
        bool F_DrawCaption;

        bool F_DrawLastFlag;
        bool F_DrawFirstFlag;
        Rectangle F_FrameRect;

        Rectangle F_Rect;       //прямоугольник рисования
        bool f_LEControl;
        TLEControl* F_LEControl;
        IntPtr F_WndHandler;
        int F_LEFrame;
        TControl* F_UnderControl;
        bool f_ApplyAttribute;
        bool f_LEActive;
        TList* f_WorkLines;
        int f_Tag;

        int f_IdAlternative;
        int f_NumAlternative;
        int f_IdAlternativeParent;
        int f_NumAlternativeParent;
        TParamAlternative* f_ParamAlt;
        TBaseShape* f_Clon;

        void DoSetLEFrame();
        TPoint __fastcall GetPointStartShape();
        TPoint __fastcall GetPointEndShape();
        void __fastcall SetBoundRect(const TRect Value);
        void __fastcall SetWndHandler(const HWND Value);
        void __fastcall SetLEFrame(int Value);
        void __fastcall SetUnderControl(TControl* Value);
        void __fastcall SetFont(Graphics::TFont* Value);
        void __fastcall SetCreateLEControl(bool Value);
        void SetLEControl();
        TRectLine* __fastcall  GetWorkLine(int AIndex);
        int __fastcall GetWorkLineCount();
        void CheckNullParamAlt();
        protected:
    int F_Step;

        int F_TypeShape;
        TRect F_RealRect;   //ðåàëüíûé ïðÿìîóãîëüíèê ðèñîâàíèÿ

        //TFlagShape *F_FirstFlag;
        //TFlagShape *F_LastFlag;

        void SaveCanvas(TCanvas* Canvas);
        void RestoreCanvas(TCanvas* Canvas);
        int __fastcall virtual GetTypeShape();
        void __fastcall SetLEActive(bool AValue);
        virtual TBaseLine* __fastcall  GetBaseLine(int AIndex);
        int __fastcall virtual GetBaseLineCount();
        virtual TPoint __fastcall GetPointTailStartShape();
        virtual TPoint __fastcall GetPointTailEndShape();

        public:

    TBaseShape(int X, int Y, int step, int number = 0);
        virtual ~TBaseShape();
        void SetRealRect(int X, int Y, int Width, int Height);
        void SetRealRect(TRect Rect);

        virtual void SetRect(int X, int Y, int Width, int Height);
        virtual void SetRect(TRect Rect);
        virtual void SetBaseRect(TRect Rect);

        TRect GetRealRect();
        TRect GetRect();
        TRect GetFrameRect();
        TRect FrameRectToRect(TRect R);

        virtual void Paint(TCanvas* Canvas);
        int PointInFrame(int X, int Y);
        virtual bool PowerIn();
        bool ReactMouse(TPoint APoint);
        void ApplyOffset(int Ax, int Ay);
        virtual bool CopyObject(TBaseShape* ASource);
        void AddWorkLine(TRectLine* ALine);
        void ClearWorkLine();
        void AddParamAlternativeItem(TParamAlternativeItem* AItem);
        void DeleteParamAlternativeItem(int AIndex);
        void DeleteParamAlternativeItem2(void* APointer);
        virtual AnsiString Make_One_Simple();
        virtual AnsiString Make_One_SimpleItem(int AIndex);


        __property TColor  BrushColor = {read = F_BrushColor, write = F_BrushColor
    };
    __property TColor  PenColor = {read = F_PenColor, write = F_PenColor
};
__property Graphics::TFont*  Font = { read = F_Font, write = SetFont};
__property int PenWidth = { read = F_PenWidth, write = F_PenWidth };
__property TPenStyle PenStyle = {read = F_PenStyle, write = F_PenStyle};
    __property TBrushStyle BrushStyle = {read = F_BrushStyle, write = F_BrushStyle};
    __property String  Caption = {read = F_Caption, write = F_Caption};
    __property TColor FrameColor  = {read = F_FrameColor, write = F_FrameColor};
    __property bool DrawFrame = { read = F_DrawFrame, write = F_DrawFrame };
__property int TypeShape = { read = GetTypeShape };
__property TPoint Point_StartShape = {read = GetPointStartShape};
    __property TPoint Point_EndShape = {read = GetPointEndShape};
    __property TPenMode PenMode = {read = F_PenMode, write = F_PenMode};
    __property int ID = { read = F_Id };
__property bool DrawCaption = { read = F_DrawCaption, write = F_DrawCaption };
__property TRect BoundRect = {read = F_Rect, write = SetBoundRect};
    __property bool LEControl = { read = f_LEControl, write = SetCreateLEControl };
//    __property TWinControl *ParentWindow = {read = F_ParentWindow, write = SetParentWindow};
__property HWND WndHandler = {read = F_WndHandler, write = SetWndHandler};
    __property int LEFrame = { read = F_LEFrame, write = SetLEFrame };
__property TControl* UnderControl = { read = F_UnderControl, write = SetUnderControl };
__property bool ApplyAttribute = { read = f_ApplyAttribute, write = f_ApplyAttribute };
__property bool LEActive = { read = f_LEActive, write = SetLEActive };
__property TBaseLine* BaseLine[int AIndex] = { read = GetBaseLine };
__property int BaseLineCount = { read = GetBaseLineCount };
__property TPoint PointTail_StartShape = {read = GetPointTailStartShape};
    __property TPoint PointTail_EndShape = {read = GetPointTailEndShape};
    __property int Step = { read = F_Step };
__property TRectLine* WorkLine[int AIndex] = { read = GetWorkLine };
__property int WorkLineCount = { read = GetWorkLineCount };
__property int Tag = { read = f_Tag, write = f_Tag };
__property TParamAlternative* ParamAlt = { read = f_ParamAlt };
__property TBaseShape* Clon = { read = f_Clon, write = f_Clon }; 
*/
    }
}
