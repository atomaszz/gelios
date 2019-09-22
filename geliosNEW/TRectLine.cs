using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    public class TRectLine
    {
        public delegate void TRctFlagCreate (TRectLine ASender, TFlagShape AFlag, int APosFlag);
        public delegate void TRctFlagDestroy(TRectLine ASender, TFlagShape AFlag, int APosFlag);
        int x0, y0, x1, y1;
        int F_id;
        int F_bend;
        int F_Step;
        void CalcCoord()
        {
            TBaseLine line;
            int midl;
            int t_x0, t_x1, t_y0, t_y1;
            bool m_rev = false;
            InvisibleLines();

            t_x0 = x0;
            t_x1 = x1;
            t_y0 = y0;
            t_y1 = y1;

            if ((t_x0 > t_x1) && (t_y0 > t_y1))
            {
                t_x0 = x1;
                t_x1 = x0;
                t_y0 = y1;
                t_y1 = y0;
                m_rev = true;
            }

            if ((t_x0 > t_x1) && (t_y0 < t_y1))
            {
                t_x0 = x1;
                t_x1 = x0;
                t_y0 = y1;
                t_y1 = y0;
                m_rev = true;
            }

            if ((t_x0 < t_x1) && (t_y0 < t_y1))
            {
                if (F_bend == 0)
                {
                    line = (TBaseLine)GetBaseLine(0);
                    line.Visible = true;
                    line.ApplyCoord(t_x0, t_y0, t_x0, t_y1);

                    line = (TBaseLine)GetBaseLine(1);
                    line.Visible = true;
                    CreateMiddleFlagToLine(line, F_DrawFlag);
                    line.ApplyCoord(t_x0, t_y1, t_x1, t_y1);
                }
                if (F_bend == 1)
                {
                    line = (TBaseLine)(GetBaseLine(0));
                    line.Visible = true;
                    line.ApplyCoord(t_x0, t_y0, t_x1, t_y0);

                    line = (TBaseLine)(GetBaseLine(1));
                    line.Visible = true;

                    CreateMiddleFlagToLine(line, F_DrawFlag);
                    line.ApplyCoord(t_x1, t_y0, t_x1, t_y1);
                }
                if (F_bend == 2)
                {
                    midl = (int)((t_x1 - t_x0) / 2 + t_x0);

                    line = (TBaseLine)(GetBaseLine(0));
                    line.Visible = true;
                    line.ApplyCoord(t_x0, t_y0, midl, t_y0);

                    line = (TBaseLine)(GetBaseLine(1));
                    line.Visible = true;
                    CreateMiddleFlagToLine(line, F_DrawFlag);
                    line.ApplyCoord(midl, t_y0, midl, t_y1);

                    line = (TBaseLine)(GetBaseLine(2));
                    line.Visible = true;
                    line.ApplyCoord(midl, t_y1, t_x1, t_y1);

                }
                if (F_bend == 3)
                {
                    midl = (int)((t_y1 - t_y0) / 2 + t_y0);
                    line = (TBaseLine)(GetBaseLine(0));
                    line.Visible = true;
                    line.ApplyCoord(t_x0, t_y0, t_x0, midl);

                    line = (TBaseLine)(GetBaseLine(1));
                    line.Visible = true;
                    CreateMiddleFlagToLine(line, F_DrawFlag);
                    line.ApplyCoord(t_x0, midl, t_x1, midl);

                    line = (TBaseLine)(GetBaseLine(2));
                    line.Visible = true;
                    line.ApplyCoord(t_x1, midl, t_x1, t_y1);

                }
            }
            if ((t_x1 > t_x0) && (t_y0 > t_y1))
            {

                if (F_bend == 0)
                {
                    line = (TBaseLine)(GetBaseLine(0));
                    line.Visible = true;
                    line.ApplyCoord(t_x0, t_y0, t_x0, t_y1);

                    line = (TBaseLine)(GetBaseLine(1));
                    line.Visible = true;
                    CreateMiddleFlagToLine(line, F_DrawFlag);
                    line.ApplyCoord(t_x0, t_y1, t_x1, t_y1);
                }
                if (F_bend == 1)
                {
                    line = (TBaseLine)(GetBaseLine(0));
                    line.Visible = true;
                    line.ApplyCoord(t_x0, t_y0, t_x1, t_y0);

                    line = (TBaseLine)(GetBaseLine(1));
                    line.Visible = true;
                    CreateMiddleFlagToLine(line, F_DrawFlag);
                    line.ApplyCoord(t_x1, t_y0, t_x1, t_y1);
                }
                if (F_bend == 2)
                {
                    midl = (int)((t_x1 - t_x0) / 2 + t_x0);

                    line = (TBaseLine)(GetBaseLine(0));
                    line.Visible = true;
                    line.ApplyCoord(t_x0, t_y0, midl, t_y0);

                    line = (TBaseLine)(GetBaseLine(1));
                    line.Visible = true;
                    CreateMiddleFlagToLine(line, F_DrawFlag);
                    line.ApplyCoord(midl, t_y0, midl, t_y1);

                    line = (TBaseLine)(GetBaseLine(2));
                    line.Visible = true;
                    line.ApplyCoord(midl, t_y1, t_x1, t_y1);
  
                }
                if (F_bend == 3)
                {
                    midl = (int)((t_y0 - t_y1) / 2 + t_y1);

                    line = (TBaseLine)(GetBaseLine(0));
                    line.Visible = true;
                    line.ApplyCoord(t_x0, t_y0, t_x0, midl);


                    line = (TBaseLine)(GetBaseLine(1));
                    line.Visible = true;
                    CreateMiddleFlagToLine(line, F_DrawFlag);
                    line.ApplyCoord(t_x0, midl, t_x1, midl);

                    line = (TBaseLine)(GetBaseLine(2));
                    line.Visible = true;
                    line.ApplyCoord(t_x1, midl, t_x1, t_y1);
                }

            }

            if ((x0 == x1) || (y0 == y1))
            {
                line = (TBaseLine)(GetBaseLine(0));
                line.Visible = true;
                CreateMiddleFlagToLine(line, F_DrawFlag);
                line.ApplyCoord(x0, y0, x1, y1);

            }
      /*      if (m_rev)
                ReverseLines();

            SetDrawFlagS();
            SetDrawFlagE();
            DoSetLEControl();
            DoSetWndHandler();
            DoSetUnderControl();*/
        }

  //      void FreeLines();
        int F_Width;
        Color F_Color;
        Pen F_Style;
        Pen F_PenMode;
        bool F_DrawFlag;
        Color F_FlagColor;
        int F_FlagType;

        bool F_DrawFlagS;
        Color F_FlagSColor;
        int F_FlagSType;

        bool F_DrawFlagE;
        Color F_FlagEColor;
        int F_FlagEType;
        bool f_LEControl;
        /*       HWND F_WndHandler;
               TControl* F_UnderControl;*/
        TFlagShape F_MiddleFlag;
        TRctFlagCreate FOnRctFlagCreate;
        TRctFlagDestroy FOnRctFlagDestroy;
        int f_CurrentBaseLine;
        bool f_PaintLine;
        Color f_BaseLineColor;
        void SetBend(int Value)
        {
            if ((Value > 3) || (Value < 0))
                F_bend = 0;
            else
                F_bend = Value;
        }
        Point GetPointStart()
        {
            return new Point(x0, y0);
        }
        Point GetPointEnd()
        {
            return new Point(x1, y1);
        }
        void SetPointStart(Point Value)
        {
            x0 = Value.X;
            y0 = Value.Y;
        }
        void SetPointEnd(Point Value)
        {
            x1 = Value.X;
            y1 = Value.Y;
        }
        void SetDrawFlagS()
        {
            int i, res;
            TBaseLine line;
            line = (TBaseLine)(Lines.ElementAt(0));
            line.DrawFlagS = F_DrawFlagS;
            line.FlagSType = F_FlagSType;
        }
        void SetDrawFlagE()
        {

        }
        void SetColorFlagS()
        {
            int i, res;
            TBaseLine line;
            if (!F_DrawFlagS) return;
            line = (TBaseLine)Lines.ElementAt(0);
            line.FlagSType = F_FlagSType;
        }
      /*      void SetColorFlagE();
            void __fastcall SetLEControl(bool Value);
            void __fastcall SetWndHandler(const HWND Value);
            void __fastcall SetUnderControl(TControl* Value);
            void DoSetLEControl();
            void DoSetWndHandler();
            void DoSetUnderControl();
            void ReverseLines();*/
        void CreateMiddleFlagToLine(TBaseLine ALine, bool ADrawFlag)
        {
            if (F_MiddleFlag!=null)
            {
                if (ADrawFlag)
                    ALine.ImportFlag(F_MiddleFlag, 1, F_MiddleFlag.TypeFlag,
                                     F_MiddleFlag.Radius, F_MiddleFlag.BrushColor);
                else
                    ALine.DrawFlag = false;
                return;
            }
            else
                ALine.DrawFlag = ADrawFlag;
        }
        void FlagImport(TBaseLine ASource, TBaseLine ADest, TFlagShape AFlag, int APosFlag)
        {
            ASource.NilFlag(AFlag);
        }
        void SetBaseLineColor(Color AValue)
        {
            f_BaseLineColor = AValue;
            TBaseLine line;
            for (int i = Lines.Count - 1; i >= 0; i--)
            {
                line = (TBaseLine)(Lines.ElementAt(i));
                line.BasePenColor = f_BaseLineColor;
            }
        }
        List<object> Lines;
        void InvisibleLines()
        {
            TBaseLine line;
            for (int i = Lines.Count - 1; i >= 0; i--)
            {
                line = (TBaseLine)Lines.ElementAt(i);
                line.Visible = false;
            }
        }

        TBaseLine GetBaseLine(int num)
        {
            TBaseLine Res = null;
            if ((num >= 0) && (num < Lines.Count))
                Res = (TBaseLine)Lines.ElementAt(num);
            return Res;
        }
        public void FlagCreate(TBaseLine ASender, TFlagShape AFlag, int APosFlag)
        {
            if (APosFlag == 1) F_MiddleFlag = AFlag;
            if (FOnRctFlagCreate!=null) FOnRctFlagCreate(this, AFlag, APosFlag);
        }
        public void  FlagDestroy(TBaseLine ASender, TFlagShape AFlag, int APosFlag)
        {
            if (APosFlag == 1) F_MiddleFlag = null;
            if (FOnRctFlagDestroy!=null) FOnRctFlagDestroy(this, AFlag, APosFlag);
        }
        public TRectLine(int step, int number)
        {
            x0 = 0;
            y0 = 0;
            x1 = 0;
            y1 = 0;
            Lines = new List<object>();
            F_id = number;
            F_bend = 0;
            F_Width = 1;
            F_Color = Color.Black;
      //      F_Style = psSolid;
       //     F_PenMode = pmCopy;
            F_Step = step;
            F_DrawFlag = false;
            F_FlagColor = Color.White;
            F_FlagType = 1;

            F_DrawFlagS = false;
            F_FlagSColor = Color.White;
            F_FlagSType = 1;

            F_DrawFlagE = false;
            F_FlagEColor = Color.White;
            F_FlagEType = 1;

            f_LEControl = false;
        //    F_WndHandler = 0;
       //     F_UnderControl = NULL;

       //     F_MiddleFlag = NULL;

      //      FOnRctFlagCreate = NULL;
      //      FOnRctFlagDestroy = NULL;
    //        f_CurrentBaseLine = 0;
            f_PaintLine = true;


            for (int i = 0; i <= 2; i++)
            {
                TBaseLine line = new TBaseLine(0, 0, 0, 0, F_Step);
                line.OnFlagCreate = FlagCreate;
                line.OnFlagDestroy = FlagDestroy;
                line.OnFlagImport = FlagImport;
                Lines.Add(line);
            }

        }
  /*      void SetCoord(int x0, int y0, int x1, int y1, int bend = 0);
        virtual ~TRectLine();*/
        public virtual void Prepare()
        {
            CalcCoord();
        }
        public virtual void Paint(Graphics Canvas)
        {
            int i;
            TBaseLine line;
            if (!f_PaintLine) return;
            SetColorFlagS();
            //SetColorFlagE();
            for (i = 0; i <= Lines.Count - 1; i++)
            {
                line = (TBaseLine)Lines.ElementAt(i);
                line.Color = Color;
                line.Width = Width;
                //   line.Style = Style;
                //     line.Mode = Mode;
                line.PaintLine(Canvas);
            }
            for (i = 0; i <= Lines.Count - 1; i++)
            {
                line = (TBaseLine)Lines.ElementAt(i);
                line.FlagColor = F_FlagColor;
                line.FlagType = F_FlagType;
                line.PaintFlag(Canvas);
            }
        }
     /*   bool KeepFlag(TBaseShape* Flag, int &type);*/
        public void ApplyOffset(int Ax, int Ay)
        {
            x0 = x0 + Ax;
            x1 = x1 + Ax;
            y0 = y0 + Ay;
            y1 = y1 + Ay;
        }
   /*     TBaseLine FirstBaseLine();
        TBaseLine NextBaseLine();*/


        public int xEnd
        {
            set {
                x1 = value;
            }
            get { return x1; }
        }
        public int yEnd
        {
            set { y1 = value; }
            get { return y1; }
        }
        public int xStart
        {
            set { x0 = value; }
            get { return x0; }
        }
        public int yStart
        {
            set { y0 = value; }
            get { return y0; }
        }

        public Color Color
        {
            set { F_Color = value; }
            get { return F_Color; }
        }
        public int Width
        {
            set { F_Width = value; }
            get { return F_Width; }
        }
       /*     __property TPenStyle Style = {read = F_Style, write = F_Style
        };
        __property TPenMode  Mode  = {read = F_PenMode,  write = F_PenMode};*/
        public int Bend
        {
            set { SetBend(value); }
            get { return F_bend; }
        }
        public int ID
        {
            set { F_id = value; }
            get { return F_id; }
        }
        public Point    PointStart
        {
            set { SetPointStart(value); }
            get { return GetPointStart(); }
        }
        public Point    PointEnd
        {
            set { SetPointEnd(value); }
            get { return GetPointEnd(); }
        }

        public bool DrawFlag
        {
            set { F_DrawFlag = value; }
            get { return F_DrawFlag; }
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
        public bool DrawFlagS
        {
            set { F_DrawFlagS = value; }
            get { return F_DrawFlagS; }
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
        public bool DrawFlagE
        {
            set { F_DrawFlagE = value; }
            get { return F_DrawFlagE; }
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
        public bool LEControl
        {
            set { f_LEControl = value; }
            get { return f_LEControl; }
        }
        /*__property HWND WndHandler = {read = F_WndHandler, write = SetWndHandler};
             __property TControl* UnderControl = { read = F_UnderControl, write = SetUnderControl };*/

        public TRctFlagCreate OnRctFlagCreate
        {
            set { FOnRctFlagCreate = value; }
            get { return FOnRctFlagCreate;  }
        }
        public TRctFlagDestroy  OnRctFlagDestroy
        {
            set { FOnRctFlagDestroy = value; }
            get { return FOnRctFlagDestroy; }
        }
        public bool PaintLine
        {
            set { f_PaintLine = value; }
            get { return f_PaintLine; }
        }
        public Color BaseLineColor
        {
            set { SetBaseLineColor(value); }
            get { return f_BaseLineColor; }
        }
    }
}
