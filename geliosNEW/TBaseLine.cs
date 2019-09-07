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
        bool F_DrawFlag;
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

             int GetTypeLine();

             Color GetPenColor();*/
        int GetPenWidth()
        {
            return (int)Pen.Width;
        }
  /*        TPenStyle GetPenStyle();
          TPenMode GetPenMode();

          Point GetPointStart();
          Point GetPointEnd();
          void SetPointStart(TPoint Value);
          void  SetPointEnd(TPoint Value);*/
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
           void  SetDrawFlagE(bool Value);

           bool GetCoordLines(TPoint &p0, TPoint &p1, TPoint &p2, TPoint &p3, TPoint &Center);
           void DrawLinesAndFlag(TCanvas* Canvas);

           bool GetCoordLinesStart(TPoint &p0, TPoint &Center);
           bool GetCoordLinesEnd(TPoint &p0, TPoint &Center);
           TPoint __fastcall GetStart();
           TPoint __fastcall GetEnd();
           //void __fastcall SetParentWindow(TWinControl* Value);
           void __fastcall SetLEControl(bool Value);
           void __fastcall SetWndHandler(const HWND Value);
           void __fastcall SetUnderControl(TControl* Value);*/
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
      /*     TBaseLine(int x0, int y0, int x1, int y1, int step);
              virtual ~TBaseLine();
              int CompareToPoint(TPoint P);
              virtual void Paint(TCanvas* Canvas);
              virtual void PaintLine(TCanvas* Canvas);
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
     //       get { return GetPenColor(); }
        }

        public  int Width
        {
            set { SetPenWidth(value); }
            get { return GetPenWidth(); }
        }
     /*   public TPenStyle Style = {read = GetPenStyle, write = SetPenStyle

      __property TPenMode  Mode  = {read = GetPenMode,  write = SetPenMode};
          __property int TypeLine = { read = GetTypeLine };
      __property TPoint    PointStart = {read  = GetPointStart, write = SetPointStart};
          __property TPoint    PointEnd = {read  = GetPointEnd, write = SetPointEnd};*/
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
