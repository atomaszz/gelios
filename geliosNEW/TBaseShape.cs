﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TBaseShape
    {
        Color F_BrushColor;  //цвет кисти
        Color F_PenColor;   //цвет пена
        Color F_FrameColor; //цвет обрамл¤ющего пр¤моугольника
        Font F_Font;
        int F_PenWidth;  // ширина пена
        Pen F_PenStyle;  //стиль пена
        Brush F_BrushStyle; //стиль браша
        String F_Caption; //подпись фигуры
        bool F_DrawFrame; //рисовать фрейм
        Pen F_PenMode;

        Color F_Old_BrushColor;  //передыдущие характеристики
        Color F_Old_PenColor;
        Brush F_Old_BrushStyle;
        Font F_Old_Font;
        int F_Old_PenWidth;
        Pen F_Old_PenStyle;
        Pen F_Old_PenMode;

        int F_Id; //номер фигуры
        bool F_DrawCaption;

        bool F_DrawLastFlag;
        bool F_DrawFirstFlag;
        Rectangle F_FrameRect;

        Rectangle F_Rect;       //прмоугольник рисовани

        bool f_LEControl;
    //    TLEControl F_LEControl;
     //   HWND F_WndHandler;
        int F_LEFrame;
 //       Control F_UnderControl;
        bool f_ApplyAttribute;
        bool f_LEActive;
  //      TList* f_WorkLines;
        int f_Tag;

        int f_IdAlternative;
        int f_NumAlternative;
        int f_IdAlternativeParent;
        int f_NumAlternativeParent;
        TParamAlternative f_ParamAlt;
        TBaseShape f_Clon;

  /*      void DoSetLEFrame();
        Point  GetPointStartShape();
        Point  GetPointEndShape();
        void  SetBoundRect(const TRect Value);
        void  SetWndHandler(const HWND Value);
        void  SetLEFrame(int Value);
        void  SetUnderControl(TControl* Value);
        void  SetFont(Graphics::TFont* Value);
        void  SetCreateLEControl(bool Value);
        void SetLEControl();
        TRectLine   GetWorkLine(int AIndex);
        int  GetWorkLineCount();
        void CheckNullParamAlt();*/

        protected int F_Step;

        protected int F_TypeShape;
        protected Rectangle F_RealRect;   //реальный прмоугольник рисовани


   /*     protected void SaveCanvas(TCanvas* Canvas);
        protected void RestoreCanvas(TCanvas* Canvas);
        protected virtual int GetTypeShape();
        void SetLEActive(bool AValue);
        virtual TBaseLine  GetBaseLine(int AIndex);
        int  virtual GetBaseLineCount();
        virtual Point  GetPointTailStartShape();
        virtual Point  GetPointTailEndShape();*/

        public TBaseShape(int X, int Y, int step, int number = 0)
        {
            F_BrushColor = Color.White;
            F_PenColor = Color.Black;
            F_FrameColor = Color.Red;
            F_BrushStyle = null;
      //      F_PenMode = pmCopy;
      //      F_Font = new Graphics::TFont;

            F_PenWidth = 1;
    //        F_PenStyle = psSolid;
            F_DrawFrame = false;

    //        F_Old_Font = new Graphics::TFont;

            F_Id = number;
            F_Caption = F_Id.ToString();
            F_TypeShape = 0;

            F_Rect = new Rectangle(X, Y - step * 2, X + step * 4, Y + step * 2);
            F_Step = step;

            F_DrawLastFlag = F_DrawFirstFlag = false;

            F_FrameRect = 
                new Rectangle(F_Rect.Left - SharedConst.OFFS_FRAME * F_PenWidth, F_Rect.Top - SharedConst.OFFS_FRAME * F_PenWidth,
                F_Rect.Right + SharedConst.OFFS_FRAME * F_PenWidth, F_Rect.Bottom + SharedConst.OFFS_FRAME * F_PenWidth);
            F_DrawCaption = true;
          //  F_LEControl = NULL;
          //  F_WndHandler = 0;
            F_LEFrame = 0;
         //   F_UnderControl = NULL;
            f_LEControl = false;
            f_ApplyAttribute = true;
            f_LEActive = true;
         //   f_WorkLines = new TList;
            f_Tag = 0;
            f_IdAlternative = 0;
            f_NumAlternative = 0;
            f_IdAlternativeParent = 0;
            f_NumAlternativeParent = 0;
            f_ParamAlt = null;
            f_Clon = null;
        }
        ~TBaseShape() { }
        /*       public void SetRealRect(int X, int Y, int Width, int Height);
               public void SetRealRect(TRect Rect);

               public virtual void SetRect(int X, int Y, int Width, int Height);
               public virtual void SetRect(TRect Rect);
               public virtual void SetBaseRect(TRect Rect);

               public TRect GetRealRect();
               public TRect GetRect();
               public TRect GetFrameRect();
               public TRect FrameRectToRect(TRect R);

               public virtual void Paint(TCanvas Canvas);
               public int PointInFrame(int X, int Y);
               public virtual bool PowerIn();
               public bool ReactMouse(TPoint APoint);
               public void ApplyOffset(int Ax, int Ay);
               public virtual bool CopyObject(TBaseShape ASource);
               public void AddWorkLine(TRectLine* ALine);
               public void ClearWorkLine();
               public void AddParamAlternativeItem(TParamAlternativeItem* AItem);
               public void DeleteParamAlternativeItem(int AIndex);
               public void DeleteParamAlternativeItem2(void* APointer);
               public virtual AnsiString Make_One_Simple();
               public virtual AnsiString Make_One_SimpleItem(int AIndex);*/


        public  Color  BrushColor
        {
            set { F_BrushColor = value; }
            get { return F_BrushColor; }
        }
        public Color  PenColor
        {
            set { F_PenColor = value; }
            get { return F_PenColor; }
        }
        /*       __property Graphics::TFont*  Font = { read = F_Font, write = SetFont};
               __property int PenWidth = { read = F_PenWidth, write = F_PenWidth };
               __property TPenStyle PenStyle = {read = F_PenStyle, write = F_PenStyle};*/
        public  Brush BrushStyle
        {
            set { F_BrushStyle = value; }
            get { return F_BrushStyle; }
        }
/*           __property String  Caption = {read = F_Caption, write = F_Caption};
           __property TColor FrameColor  = {read = F_FrameColor, write = F_FrameColor};
           __property bool DrawFrame = { read = F_DrawFrame, write = F_DrawFrame };
       __property int TypeShape = { read = GetTypeShape };
       __property TPoint Point_StartShape = {read = GetPointStartShape};
           __property TPoint Point_EndShape = {read = GetPointEndShape};
           __property TPenMode PenMode = {read = F_PenMode, write = F_PenMode};*/
        public int ID
        {
            get { return F_Id; }
        }
        /*__property bool DrawCaption = { read = F_DrawCaption, write = F_DrawCaption };
        __property TRect BoundRect = {read = F_Rect, write = SetBoundRect};
            __property bool LEControl = { read = f_LEControl, write = SetCreateLEControl };
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
        __property int Tag = { read = f_Tag, write = f_Tag };*/
        public TParamAlternative ParamAlt
        {
            get { return f_ParamAlt; }
        }
            
/*__property TBaseShape* Clon = { read = f_Clon, write = f_Clon }; */
    }
}
