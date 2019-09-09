using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    public class TBaseLine
    {
        public delegate void TFlagCreate (TBaseLine ASender, TFlagShape AFlag, int APosFlag);
        public delegate void TFlagDestroy(TBaseLine ASender, TFlagShape AFlag, int APosFlag);
        public delegate void TFlagImport(TBaseLine ASource, TBaseLine ADest, TFlagShape AFlag, int APosFlag);

        int F_Step;
        protected bool F_DrawFlag;
        bool F_DrawFlagS;
        bool F_DrawFlagE;
        TFlagShape F_Flag;
        Color F_FlagColor;
        double F_FlagRadius;

        TFlagShape F_FlagS;
        Color F_FlagSColor;
        double F_FlagSRadius;

        TFlagShape F_FlagE;
        Color F_FlagEColor;
        double F_FlagERadius;
        int F_FlagType;
        int F_FlagSType;
        int F_FlagEType;

        bool f_LEControl;
  //      HWND F_WndHandler;
        Control F_UnderControl;
        bool F_Visible;
        Color f_BasePenColor;


        TFlagCreate FOnFlagCreate;
        TFlagDestroy FOnFlagDestroy;
        TFlagImport FOnFlagImport;
        int f_Tag;
        int f_Tag2;

        void SetPenColor(Color Value)
        {
            Pen.Color = Value;
        }
        void SetPenWidth(int Value)
        {
            Pen.Width = Value;
        }
        /*     void SetPenStyle(TPenStyle Value);
             void SetPenMode(TPenMode Value);

             int GetTypeLine();*/

        Color GetPenColor()
        {
            return Pen.Color;
        }
        int GetPenWidth()
        {
            return (int)Pen.Width;
        }
        /*        TPenStyle GetPenStyle();
                TPenMode GetPenMode();*/

        Point GetPointStart()
        {
            return (new Point(x0, y0));
        }
        Point GetPointEnd()
        {
            return (new Point(x1, y1));
        }
        void SetPointStart(Point Value)
        {
            x0 = Value.X;
            y0 = Value.Y;
        }
        void  SetPointEnd(Point Value)
        {
            x1 = Value.X;
            y1 = Value.Y;
        }
        void  SetDrawFlag(bool Value)
        {
            int pos = 1;
            F_DrawFlag = Value;
            if (F_DrawFlag && (F_Flag==null))
            {
                F_Flag = new TFlagShape(F_Step, this, 0);
                F_Flag.LEControl = true;
               // F_Flag.WndHandler = F_WndHandler;
                F_Flag.BrushColor = F_FlagColor;
                if (FOnFlagCreate!=null) OnFlagCreate(this, F_Flag, pos);
            }

            if ((F_DrawFlag) && (F_Flag!=null))
            {
                if (FOnFlagDestroy!=null) OnFlagDestroy(this, F_Flag, pos);
                F_Flag = null;
            }
        }
        /*   void  SetDrawFlagS(bool Value);
           void  SetDrawFlagE(bool Value);*/

        bool GetCoordLines(ref Point p0, ref Point p1, ref Point p2, ref Point p3, ref Point Center)
        {
            int cnt;
            int xd, yd;
            int x_start, x_end, y_start, y_end;
            p0 = new Point(0, 0);
            p1 = new Point(0, 0);
            p2 = new Point(0, 0);
            p3 = new Point(0, 0);
            cnt = (int)(F_Flag.Radius * F_Step);
            xd = Math.Abs((int)((x1 - x0) / 2));
            yd = Math.Abs((int)((y1 - y0) / 2));
            if (y0 == y1)
            {
                if (x0 == x1) return false;
                x_start = Math.Min(x0, x1);
                x_end = x_start + xd - cnt;
                p0 = new Point(x_start, y0);
                p1 = new Point(x_end, y0);

                Center = new Point(x_end + cnt, y0);

                x_start = x_end + 2 * cnt;
                x_end = x_start + xd - cnt;
                p2 = new Point(x_start, y0);
                p3 = new Point(x_end, y0);

            }
            if (x0 == x1)
            {
                if (y0 == y1) return false;
                y_start = Math.Min(y0, y1);
                y_end = y_start + yd - cnt;
                p0 = new Point(x1, y_start);
                p1 = new Point(x1, y_end);

                Center = new Point(x0, y_end + cnt);

                y_start = y_end + 2 * cnt;
                y_end = y_start + yd - cnt;
                p2 = new Point(x1, y_start);
                p3 = new Point(x1, y_end);
            }
            return true;
        }
        void DrawLinesAndFlag(PaintEventArgs Canvas)
        {
            Point m_s = new Point(x0, y0);
            Point m_e = new Point(x1, y1);
            Point m_1 = new Point(0, 0);
            Point m_2 = new Point(0, 0);
            Point temp1 = new Point(), temp2 = new Point(), temp3 = new Point(), temp4 = new Point(), center = new Point();
            Point center_S = new Point(), center_C = new Point(), center_E = new Point();
            bool p_c, p_s, p_e;
            p_c = p_s = p_e = false;
            if (F_FlagS != null)
            {
                if (GetCoordLinesStart(ref temp1, ref center))
                {
                    m_s = temp1;
                    p_s = true;
                    center_S = center;
                }
            }
            if (F_Flag!=null)
            {
                if (GetCoordLines(ref temp1, ref temp2, ref temp3, ref temp4, ref center))
                {
                    m_1 = temp2;
                    m_2 = temp3;
                    p_c = true;
                    center_C = center;
                }
            }
            if (F_FlagE!=null)
            {

                if (GetCoordLinesEnd(ref temp1, ref center))
                {
                    m_e = temp1;
                    p_e = true;
                    center_E = center;
                }
            }

    //        Canvas.MoveTo(m_s.X, m_s.Y);
            if (F_Flag!=null)
            {
                Canvas.Graphics.DrawLine(new Pen(Color.Black,2),m_s, m_1);
        /*        Canvas.LineTo(m_1.X, m_1.Y);
                Canvas.MoveTo(m_2.X, m_2.Y);*/
            }
            Canvas.Graphics.DrawLine(new Pen(Color.Black, 2), m_2, m_e);
    //        Canvas.LineTo(m_e.X, m_e.Y);
            if (p_s)
            {
                F_FlagS.Center = center_S;
                F_FlagS.Paint(Canvas);
            }
            else if (F_FlagS!=null) F_FlagS.Paint(Canvas);
            if (p_c)
            {
                F_Flag.Center = center_C;
                // F_Flag->BrushColor = F_FlagColor;
                F_Flag.Paint(Canvas);
            }
            else if (F_Flag!=null) F_Flag.Paint(Canvas);
            if (p_e)
            {
                F_FlagE.Center = center_E;
                // F_FlagE->BrushColor = F_FlagEColor;
                F_FlagE.Paint(Canvas);
            }
            else if (F_FlagE!=null) F_FlagE.Paint(Canvas);
        }

        bool GetCoordLinesStart(ref Point  p, ref Point Center)
        {
            int cnt;
            int x_start, y_start;
            p = new Point(0, 0);
            Center = new Point(0, 0);
            cnt = (int)(F_FlagS.Radius * F_Step);

            if (y0 == y1)
            {
                if (x0 == x1)
                    return false;
                if (x0 <= x1)
                {
                    x_start = x0 + cnt * 2;
                    Center = new Point(x_start - cnt, y0);
                }
                else
                {
                    x_start = x0 - cnt * 2;
                    Center = new Point(x_start + cnt, y0);
                }
                p = new Point(x_start, y0);
            }
            if (x0 == x1)
            {
                if (y0 == y1)
                    return false;
                if (y0 <= y1)
                {
                    y_start = y0 + cnt * 2;
                    Center = new Point(x0, y_start - cnt);
                }
                else
                {
                    y_start = y0 - cnt * 2;
                    Center = new Point(x0, y_start + cnt);
                }
                p = new Point(x0, y_start);
            }
            return true;
        }
        bool GetCoordLinesEnd(ref Point p, ref Point Center)
        {
            int cnt;
            int x_end, y_end;
            p = new Point(0, 0);
            Center = new Point(0, 0);
            cnt = (int)(F_FlagE.Radius * F_Step);
            if (y0 == y1)
            {
                if (x0 == x1) return false;
                if (x0 <= x1)
                {
                    x_end = x1 - cnt * 2;
                    Center = new Point(x_end + cnt, y1);
                }
                else
                {
                    x_end = x1 + cnt * 2;
                    Center = new Point(x_end - cnt, y1);
                }
                p = new Point(x_end, y1);
            }
            if (x0 == x1)
            {
                if (y0 == y1) return false;
                if (y0 <= y1)
                {
                    y_end = y1 - cnt * 2;
                    Center = new Point(x1, y_end + cnt);
                }
                else
                {
                    y_end = y1 + cnt * 2;
                    Center = new Point(x1, y_end - cnt);
                }

                p = new Point(x1, y_end);
            }
            return true;
        }
   /*        Point GetStart();
           Point GetEnd();*/
           //void __fastcall SetParentWindow(TWinControl* Value);
    /*       void SetLEControl(bool Value);
           void SetWndHandler(const HWND Value);
           void SetUnderControl(TControl* Value);*/
        void  SetFlagColor(Color Value)
        {
            F_FlagColor = Value;
        }
        void  SetFlagSColor(Color Value)
        {
            F_FlagSColor = Value;
        }
        void  SetFlagEColor(Color Value)
        {
            F_FlagEColor = Value;
        }
  /*        int __fastcall GetMinX();
          int __fastcall GetMinY();
          int __fastcall GetMaxX();
          int __fastcall GetMaxY();

          // void DoSetParentWindow();
          // void DoSetWndHandler();
          // void DoSetUnderControl();
          protected:*/
        protected  int x0, y0, x1, y1;
        Pen Pen;
        Pen OldPenParent;
           //   public:
        public TBaseLine(int x0, int y0, int x1, int y1, int step)
        {
            ApplyCoord(x0, y0, x1, y1);
   //         Pen = new Graphics::TPen;
         //   OldPenParent = new Graphics::TPen;
            F_Step = step;
            F_Flag = null;
            F_FlagS = null;
            F_FlagE = null;
            F_DrawFlag = false;
            F_DrawFlagS = false;
            F_DrawFlagE = false;

            F_FlagColor = Color.White;
            F_DrawFlagS = false;
            F_FlagSColor = Color.White;
            F_DrawFlagE = false;
            F_FlagEColor = Color.White;

            F_FlagType = 0;
            F_FlagSType = 0;
            F_FlagEType = 0;

            F_FlagRadius = 0.7;
            F_FlagSRadius = 0.7;
            F_FlagERadius = 0.7;

      //      F_WndHandler = 0;
            F_UnderControl = null;
            F_Visible = true;
            FOnFlagCreate = null;
            FOnFlagDestroy = null;
            FOnFlagImport = null;
            f_LEControl = false;
            f_Tag = 0;
            f_Tag2 = 0;
        }
        ~TBaseLine() { }
        /*           int CompareToPoint(TPoint P);*/
        public virtual void Paint(PaintEventArgs Canvas)
        {
            Point p0, p1, p2, p3, Center;
            if (!F_Visible) return;
   //         OldPenParent.Assign(Canvas.Pen);
  //          Canvas.Pen.Assign(this.Pen);
            if ((F_DrawFlag) && (F_Flag!=null))
            {
                F_Flag.TypeFlag = F_FlagType;
                F_Flag.PenWidth = Width;
                F_Flag.PenColor = Color;
                F_Flag.Radius = F_FlagRadius;
            }
            if ((F_DrawFlagS) && (F_FlagS != null))
            {
                F_FlagS.TypeFlag = F_FlagSType;
                F_FlagS.PenWidth = Width;
                F_FlagS.PenColor = Color;
                F_FlagS.Radius = F_FlagSRadius;
            }
            if (F_DrawFlagE && (F_FlagE!=null))
            {
                F_FlagE.TypeFlag = F_FlagEType;
                F_FlagE.PenWidth = Width;
                F_FlagE.PenColor = Color;
                F_FlagE.Radius = F_FlagERadius;
            }
            DrawLinesAndFlag(Canvas);
     //       Canvas.Pen.Assign(OldPenParent);
        }
  /*            virtual void PaintLine(TCanvas* Canvas);
              virtual void PaintFlag(TCanvas* Canvas);
              bool KeepFlag(TBaseShape* Flag, int &type);*/
        public void ApplyCoord(int x0, int y0, int x1, int y1)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.x1 = x1;
            this.y1 = y1;
        }
        /*        void ApplyOffset(int Ax, int Ay);
                void MoveTo(int Ax, int Ay);
                void MoveTo(TPoint APoint);*/
        public bool ImportFlag(TFlagShape AFlag, int APos, int ATypeFlag,
                    double ARadius, Color ABrushColor)
        {
            if ((APos > 2) || (APos < 0)) return false;
            if (AFlag==null) return false;

            if (APos == 0)
            {
                if (F_FlagS == AFlag) return true;
                F_FlagS = AFlag;
                F_FlagSType = ATypeFlag;
                F_FlagSRadius = ARadius;
                if (FOnFlagImport!=null) OnFlagImport(AFlag.Owner, this, AFlag, 0);
                AFlag.Owner = this;
            }

            if (APos == 1)
            {
                if (F_Flag == AFlag) return true;
                F_Flag = AFlag;
                F_FlagType = ATypeFlag;
                F_FlagRadius = ARadius;
                F_FlagColor = ABrushColor;
                if (FOnFlagImport!=null) OnFlagImport(AFlag.Owner, this, AFlag, 1);
                AFlag.Owner = this;
            }
            if (APos == 2)
            {
                if (F_FlagE == AFlag) return true;
                F_FlagE = AFlag;
                F_FlagEType = ATypeFlag;
                F_FlagERadius = ARadius;
                F_FlagEColor = ABrushColor;
                if (FOnFlagImport!=null) OnFlagImport(AFlag.Owner, this, AFlag, 2);
                AFlag.Owner = this;
            }
            return true;
        }
        /*   // bool NilFlag(int APos, TFlagShape *AFlag = NULL);
           int NilFlag(TFlagShape* AFlag);
           virtual bool CopyObject(TBaseLine* ASource);*/
        public  Color  Color
        {
            set { SetPenColor(value); }
            get { return GetPenColor(); }
        }

        public  int Width
        {
            set { SetPenWidth(value); }
            get { return GetPenWidth(); }
        }
        /*   public TPenStyle Style = {read = GetPenStyle, write = SetPenStyle

         __property TPenMode  Mode  = {read = GetPenMode,  write = SetPenMode};
             __property int TypeLine = { read = GetTypeLine };*/
        public Point PointStart
        {
            set { SetPointStart(value); }
            get { return GetPointStart(); }
        }
        public Point PointEnd
        {
            set { SetPointEnd(value); }
            get { return GetPointEnd(); }
        }
        public  bool DrawFlag
        {
            set { SetDrawFlag(value); }
            get { return F_DrawFlag; }
        }

        public Color FlagColor
        {
            set { SetFlagColor(value); }
            get { return F_FlagColor; }
        }
  /*        __property double FlagRadius = { read = F_FlagRadius, write = F_FlagRadius };*/
      public int FlagType
        {
            set { F_FlagType = value; }
            get { return F_FlagType; }
        }

  /*    __property bool DrawFlagS = { read = F_DrawFlagS, write = SetDrawFlagS };
      __property TColor      FlagSColor = {read = F_FlagSColor, write = SetFlagSColor};
          __property double FlagSRadius = { read = F_FlagSRadius, write = F_FlagSRadius };*/
      public int FlagSType
        {
            set { F_FlagSType = value; }
            get { return F_FlagSType; }
        }


   /*   __property bool DrawFlagE = { read = F_DrawFlagE, write = SetDrawFlagE };
      __property TColor      FlagEColor = {read = F_FlagEColor, write = SetFlagEColor};
          __property double FlagERadius = { read = F_FlagERadius, write = F_FlagERadius };
      __property int FlagEType = { read = F_FlagEType, write = F_FlagEType };

      __property TPoint Start = {read = GetStart};
          __property TPoint End = {read = GetEnd};

         // __property TWinControl *ParentWindow = {read = F_ParentWindow, write = SetParentWindow};
          __property bool LEControl = { read = f_LEControl, write = SetLEControl };
      __property HWND WndHandler = {read = F_WndHandler, write = SetWndHandler};
          __property TControl* UnderControl = { read = F_UnderControl, write = SetUnderControl };*/
        public bool Visible
        {
            set { F_Visible = value; }
            get { return F_Visible; }
        }

        public  TFlagCreate   OnFlagCreate
        {
            set { FOnFlagCreate = value; }
            get { return FOnFlagCreate; }
        }
        public TFlagDestroy  OnFlagDestroy
        {
            set { FOnFlagDestroy = value; }
            get { return FOnFlagDestroy; }
        }
        public TFlagImport   OnFlagImport
        {
            set { FOnFlagImport = value; }
            get { return FOnFlagImport; }
        }

        public int X0
        {
            set { x0 = value; }
            get { return x0; }
        }
        public int X1
        {
            set { x1 = value; }
            get { return x1; }
        }
        public int Y0
        {
            set { y0 = value; }
            get { return y0; }
        }
        public int Y1
        {
            set { y1 = value; }
            get { return y1; }
        }
   /*     public int MinX
        { get { return GetMinX(); } }
__property int MinY = { read = GetMinY };
__property int MaxX = { read = GetMaxX };
__property int MaxY = { read = GetMaxY };
__property TColor BasePenColor = {read = f_BasePenColor, write = f_BasePenColor};
    __property int Tag = { read = f_Tag, write = f_Tag };
__property int Tag2 = { read = f_Tag2, write = f_Tag2 };*/
    }
}
