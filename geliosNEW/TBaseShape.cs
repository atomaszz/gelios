using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    public class TBaseShape
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
        List<object> f_WorkLines;
        int f_Tag;

        int f_IdAlternative;
        int f_NumAlternative;
        int f_IdAlternativeParent;
        int f_NumAlternativeParent;
        TParamAlternative f_ParamAlt;
        TBaseShape f_Clon;

        /*      void DoSetLEFrame();*/
        Point  GetPointStartShape()
        {
            return (new Point(F_Rect.Left, F_Rect.Top + (int)((F_Rect.Bottom - F_Rect.Top) / 2)));
        }
        Point  GetPointEndShape()
        {
            return (new Point(F_Rect.Right, F_Rect.Top + (int)((F_Rect.Bottom - F_Rect.Top) / 2)));
        }
        void SetBoundRect(Rectangle Value)
        {
            SetBaseRect(Value);
            //SetLEControl();
        }
   /*     void  SetWndHandler(const HWND Value);
        void  SetLEFrame(int Value);
        void  SetUnderControl(TControl* Value);
        void  SetFont(Graphics::TFont* Value);*/
        void  SetCreateLEControl(bool Value)
        {
     /*       if ((TypeShape == 100) || (TypeShape == 80))
            {
                f_LEControl = Value;
           /*     if (f_LEControl)
                {
                    if (!F_LEControl)
                    {
                        F_LEControl = new TLEControl();
                        F_LEControl.Source = this;
                        F_LEControl.Id = F_Id;
                        F_LEControl.UnderControl = F_UnderControl;
                        F_LEControl.Active = f_LEActive;
                    }
                    SetLEControl();
                }
                else
                {
                    F_LEControl = null;
                }
            }*/
        }
   /*     void SetLEControl();
        TRectLine   GetWorkLine(int AIndex);
        int  GetWorkLineCount();
        void CheckNullParamAlt();*/

        protected int F_Step;

        protected int F_TypeShape;
        protected Rectangle F_RealRect;   //реальный прмоугольник рисовани


/*        protected void SaveCanvas(TCanvas* Canvas)
        {

        }*/

/*        protected void RestoreCanvas(TCanvas* Canvas);*/
        protected virtual int GetTypeShape()
        {
            return 1;//F_TypeShape;
        }
  /*      void SetLEActive(bool AValue);
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

            F_Rect = new Rectangle(X, Y - step * 2, step * 4, step * 4);
            F_Step = step;

            F_DrawLastFlag = F_DrawFirstFlag = false;

            F_FrameRect = 
                new Rectangle(F_Rect.Left - SharedConst.OFFS_FRAME * F_PenWidth, 
                F_Rect.Top - SharedConst.OFFS_FRAME * F_PenWidth,
                F_Rect.Right - F_Rect.Left + 2 * SharedConst.OFFS_FRAME * F_PenWidth, 
                F_Rect.Bottom - F_Rect.Top + 2 * SharedConst.OFFS_FRAME * F_PenWidth);
            F_DrawCaption = true;
          //  F_LEControl = NULL;
          //  F_WndHandler = 0;
            F_LEFrame = 0;
         //   F_UnderControl = NULL;
            f_LEControl = false;
            f_ApplyAttribute = true;
            f_LEActive = true;
            f_WorkLines = new List<object>();
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
               public virtual void SetRect(TRect Rect);*/
        public virtual void SetBaseRect(Rectangle Rect)
        {
            F_Rect = Rect;
        }

    /*           public TRect GetRealRect();*/
        public Rectangle GetRect()
        {
            return F_Rect;
        }
        /*         public TRect GetFrameRect();
                 public TRect FrameRectToRect(TRect R);*/
        public virtual void Paint(Graphics Canvas)
        {
            Rectangle R = new Rectangle();
            Point Pt = new Point();
            if (F_DrawFrame)
            {
             //   Canvas.Pen.Width = F_PenWidth;
            //    Canvas.Pen.Color = F_FrameColor;
            //    Canvas.Brush.Style = bsClear;
            //    Canvas.Pen.Mode = F_PenMode;
                Pen tpen = new Pen(F_FrameColor, F_PenWidth);
                F_FrameRect.X = F_Rect.Left - SharedConst.OFFS_FRAME * F_PenWidth;
                F_FrameRect.Y = F_Rect.Top - SharedConst.OFFS_FRAME * F_PenWidth;
                F_FrameRect.Width = F_Rect.Right + SharedConst.OFFS_FRAME * F_PenWidth;
                F_FrameRect.Height = F_Rect.Bottom + SharedConst.OFFS_FRAME * F_PenWidth;
                Canvas.DrawRectangle(tpen, F_FrameRect);

                R.X = F_FrameRect.Left - SharedConst.D_FRAME * F_PenWidth;
                R.Width = F_FrameRect.Left + SharedConst.D_FRAME * F_PenWidth;
                R.Y = F_FrameRect.Top - SharedConst.D_FRAME * F_PenWidth;
                R.Height = F_FrameRect.Top + SharedConst.D_FRAME * F_PenWidth;
                Canvas.DrawEllipse(tpen, R);

                R.X = F_FrameRect.Right - SharedConst.D_FRAME * F_PenWidth;
                R.Width = F_FrameRect.Right + SharedConst.D_FRAME * F_PenWidth;
                R.Y = F_FrameRect.Top - SharedConst.D_FRAME * F_PenWidth;
                R.Height = F_FrameRect.Top + SharedConst.D_FRAME * F_PenWidth;
                Canvas.DrawEllipse(tpen, R);

                R.X = F_FrameRect.Right - SharedConst.D_FRAME * F_PenWidth;
                R.Width = F_FrameRect.Right + SharedConst.D_FRAME * F_PenWidth;
                R.Y = F_FrameRect.Bottom - SharedConst.D_FRAME * F_PenWidth;
                R.Height = F_FrameRect.Bottom + SharedConst.D_FRAME * F_PenWidth;
                Canvas.DrawEllipse(tpen, R);

                R.X = F_FrameRect.Left - SharedConst.D_FRAME * F_PenWidth;
                R.Width = F_FrameRect.Left + SharedConst.D_FRAME * F_PenWidth;
                R.Y = F_FrameRect.Bottom - SharedConst.D_FRAME * F_PenWidth;
                R.Height = F_FrameRect.Bottom + SharedConst.D_FRAME * F_PenWidth;
                Canvas.DrawEllipse(tpen, R);
            }
            if (f_ApplyAttribute)
            {
         /*       Canvas.Brush.Color = F_BrushColor;
                Canvas.Brush.Style = F_BrushStyle;
                Canvas.Pen.Color = F_PenColor;
                Canvas.Pen.Width = F_PenWidth;
                Canvas.Pen.Style = F_PenStyle;
                Canvas.Pen.Mode = F_PenMode;*/
            }
       //     Canvas.Font = F_Font;
        }
   /*            public int PointInFrame(int X, int Y);
               public virtual bool PowerIn();
               public bool ReactMouse(TPoint APoint);
               public void ApplyOffset(int Ax, int Ay);
               public virtual bool CopyObject(TBaseShape ASource);*/
        public void AddWorkLine(TRectLine ALine)
        {
            f_WorkLines.Add(ALine);
        }
   /*            public void ClearWorkLine();
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
        /*       __property Graphics::TFont*  Font = { read = F_Font, write = SetFont};*/
        public int PenWidth
        {
            set { F_PenWidth = value; }
            get { return F_PenWidth; }
        }
     /*          __property TPenStyle PenStyle = {read = F_PenStyle, write = F_PenStyle};*/
        public Brush BrushStyle
        {
            set { F_BrushStyle = value; }
            get { return F_BrushStyle; }
        }
        public String Caption
        {
            set { F_Caption = value; }
            get { return F_Caption; }
        }
        public Color FrameColor
        {
            set { F_FrameColor = value; }
            get { return F_FrameColor; }
        }
  /*         __property bool DrawFrame = { read = F_DrawFrame, write = F_DrawFrame };*/
       public int TypeShape { get { return GetTypeShape(); } }
       public Point Point_StartShape
        {
            get { return GetPointStartShape(); }
        }
        public Point Point_EndShape
        {
            get { return GetPointEndShape(); }
        }
   /*     public TPenMode PenMode = {read = F_PenMode, write = F_PenMode};*/
        public int ID
        {
            get { return F_Id; }
        }
        public  bool DrawCaption
        {
            set { F_DrawCaption = value; }
            get { return F_DrawCaption; }
        }
        public Rectangle BoundRect
        {
            set { SetBoundRect(value); }
            get { return F_Rect; }
        }
            public bool LEControl
        {
            set { SetCreateLEControl(value); }
            get { return f_LEControl; }
        }
            
 /*       __property HWND WndHandler = {read = F_WndHandler, write = SetWndHandler};
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
