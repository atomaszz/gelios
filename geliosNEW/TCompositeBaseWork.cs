using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    public class TCompositeBaseWork
    {
        List<object> f_ListItem;
        List<object> f_ListBL;
        List<object> f_ListRectLine;
        int f_TopBorder;
        int f_OffsetTop;
        bool f_Selected;
        Point f_StartPoint;
        TColorSetup f_ColorSetup;
        long f_Ref;
 //       TCompositeStack2 f_History;
  /*      TBaseLine GetBaseLineItem(int AIndex);
        int GetBaseLineCount();*/
        TBaseWorkShape f_ConvertedBWS;
        protected int f_step;
        protected int f_LastLineBend;
        protected int f_FirstLineBend;
        protected Point f_EndPoint;
        /*      protected void FreeListItem();
              protected void FreeListBL();
              protected void HideLines();
              protected void FreeListRectLine();
              protected void virtual SetTopBorder(int AValue);
              protected void  SetLineColor(TColor AValue);
              protected int  GetItemCount();*/
        public virtual Point GetEndPoint()
        {
            return new Point(0, 0);
        }
        public virtual Point GetStartPoint()
        {
            return new Point(0, 0);
        }
        public virtual TBaseLine  GetEndLine()
        {
            return null;
        }
        public virtual void SetStartPoint(Point AValue)
        {
            int m_x, m_y;
            Point m_startP = StartPoint;
            if ((m_startP.X != AValue.X) || (m_startP.Y != AValue.Y))
            {
                m_x = AValue.X - m_startP.X;
                m_y = AValue.Y - m_startP.Y;
                ApplyOffset(m_x, m_y);
            }
        }
        void  SetSelected(bool AValue)
        {
            TCompositeBaseWorkItem Item;
            TBaseLine BL;
            f_Selected = AValue;
            for (int i = f_ListBL.Count - 1; i >= 0; i--)
            {
                BL = (TBaseLine)f_ListBL.ElementAt(i);
         //           BL.Color = (f_Selected) ? f_ColorSetup.FrameColorTFS : f_ColorSetup.LineColor;
            }
                for (int i = 0; i <= f_ListItem.Count - 1; i++)
                {
                    Item = (TCompositeBaseWorkItem)f_ListItem.ElementAt(i);
                    if (Item.BaseShape!=null)
                    {
                /*        if (f_Selected)
                            Item.BaseShape.PenColor = f_ColorSetup.FrameColorTFS;
                        else
                            Item.BaseShape.PenColor = Item.BaseShape.Tag ? f_ColorSetup.HaveChildColor : f_ColorSetup.LineColor;
                        if (Item.BaseShape.Clon.ParamAlt)
                        {
                            if (f_ColorSetup.AltParamShapeColorEnable)
                            {
                                Item.BaseShape.BrushStyle = bsSolid;
                                Item.BaseShape.BrushColor = f_ColorSetup.AltParamShapeColor;
                            }
                            else
                                Item.BaseShape.BrushStyle = bsClear;
                            Item.BaseShape.PenColor = f_ColorSetup.AltParamLineColor;
                        }*/
                    }
               /*     for (int j = 0; j <= Item.CompositeWorkCount - 1; j++)
                        Item.CompositeWork[j].SetSelected(AValue);*/
                }
        }
     /*   TBaseLine GetBaseLine(int AIndex);
        TBaseLine GetNewLine();*/
        public virtual TRectLine GetFirstLine()
        {
            return null;
        }

        public TCompositeBaseWork()
        {
            f_ListItem = new List<object>();
            f_ListBL = new List<object>();
            f_ListRectLine = new List<object>();
            f_TopBorder = 0;
            f_OffsetTop = 0;
            f_LastLineBend = 0;
            f_FirstLineBend = 0;
            f_ColorSetup = null;
            f_Selected = false;
            f_Ref = 1;
     //       f_History = new TCompositeStack2;
            f_ConvertedBWS = null;
        }

        ~TCompositeBaseWork() { }
    /*    public TCompositeBaseWorkItem* GetItem(int ANum);
        public void AddBaseShape(TBaseShape* ABaseShape, bool IsHaveChild);
        public void AddWorkItemShape(TCompositeBaseWorkItem* ABaseWorkItem);
        public void AddBaseLine(TBaseLine* BL);
        public void AddRectLine(TRectLine* ARectLine);
        public TPoint OffsetEndCoordinate(TPoint AStart);*/
        virtual public void Prepare()
        {
   /*         TCompositeBaseWorkItem Item;
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                Item = (TCompositeBaseWorkItem)(f_ListItem.Items[i]);
                Item.Prepare();
            }*/
        }
        virtual public void Paint(Graphics ACanvas)
        {
            TCompositeBaseWorkItem Item;
            TBaseLine BL;
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                Item = (TCompositeBaseWorkItem)f_ListItem.ElementAt(i);
                Item.Paint(ACanvas);
            }
            for (int j = 0; j <= f_ListBL.Count - 1; j++)
            {
                BL = (TBaseLine)f_ListBL.ElementAt(j);
                //      BL.Color = f_ColorSetup.LineColor;
                BL.Paint(ACanvas);
            }
        }

        /*   virtual public void ReplaceShape(int IdShapeReplace, TCompositeBaseWork* ANew);
           virtual public void Appearance();
           virtual public bool ConvertWorkShape(TAlternateViewItemTFS* AWS, TAlternateView* AV);
           virtual public void ConvertWorkShapeFromBase(TBaseWorkShape* AWS, TAlternateView* AV);*/
        public Rectangle GetMaxRect()
        {
            {
                TCompositeBaseWorkItem Item;
                Rectangle R;
                Rectangle Res = new Rectangle(0, 0, 0, 0);
                TBaseLine bLine;
                if (f_ListItem.Count > 0)
                {
                    Item = (TCompositeBaseWorkItem)f_ListItem.ElementAt(0);
                    Res = Item.MaxRect;
                    for (int i = 1; i <= f_ListItem.Count - 1; i++)
                    {
                        Item = (TCompositeBaseWorkItem)f_ListItem.ElementAt(i);
                        R = Item.MaxRect;
                        if (R.Right > Res.Right) Res.Width = R.Right;
                        if (R.Bottom > Res.Bottom) Res.Height = R.Bottom;
                        if (R.Left < Res.Left) Res.X = R.Left;
                        if (R.Top < Res.Top) Res.Y = R.Top;
                    }
                }
                for (int i = 0; i <= f_ListBL.Count - 1; i++)
                {
                    bLine = (TBaseLine)f_ListBL.ElementAt(i);
                    if (bLine.X0 < Res.Left) Res.X = bLine.X0;
                    if (bLine.X1 < Res.Left) Res.X = bLine.X1;
                    if (bLine.X0 > Res.Right) Res.Width = bLine.X0;
                    if (bLine.X1 > Res.Right) Res.Width = bLine.X1;

                    if (bLine.Y0 < Res.Top) Res.Y = bLine.Y0;
                    if (bLine.Y1 < Res.Top) Res.Y = bLine.Y1;
                    if (bLine.Y0 > Res.Bottom) Res.Height = bLine.Y0;
                    if (bLine.Y1 > Res.Bottom) Res.Height = bLine.Y1;
                }
                return Res;
            }
        }
        public TBaseShape FindTFE(int Ax, int Ay)
        {
            TCompositeBaseWorkItem Item;
            TBaseShape BS;
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                Item = (TCompositeBaseWorkItem)(f_ListItem.ElementAt(i));
                BS = Item.FindTFE(Ax, Ay);
                if (BS!=null)
                    return BS;
            }
            return null;
        }
        public TBaseShape CloneShape(TBaseShape ADest)
        {
            TBaseShape mShape = null;
            if (ADest == null) return null;
            switch (ADest.TypeShape)
            {
                case 5:
                    mShape = new TTfeRectShape(0, 0, 0, 0);
                    break;
                case 6:
                    mShape = new TTfeRhombShape(0, 0, 0, 0);
                    break;
                case 7:
                    mShape = new TTfeEllShape(0, 0, 0, 0);
                    break;
                case 8:
                    mShape = new TTfeHexahedronShape(0, 0, 0, 0);
                    break;
            }
            if (mShape==null) return null;
            mShape.Clon = ADest;
            ADest.CopyObject(mShape);
            return mShape;
        }
        virtual public void ApplyOffset(int Ax, int Ay)
        {
            TCompositeBaseWorkItem Item;
            TBaseLine BL;
            TRectLine RL;
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                Item = (TCompositeBaseWorkItem)(f_ListItem.ElementAt(i));
                Item.ApplyOffset(Ax, Ay);
            }
            for (int j = 0; j <= f_ListBL.Count - 1; j++)
            {
                BL = (TBaseLine)(f_ListBL.ElementAt(j));
                BL.ApplyOffset(Ax, Ay);
            }
            for (int k = 0; k <= f_ListRectLine.Count - 1; k++)
            {
                RL = (TRectLine)f_ListRectLine.ElementAt(k);
                RL.ApplyOffset(Ax, Ay);
            }
        }
        /*         public TRect GetAnyRect();
                 public TRect GetRectSummary(TRect ARect);*/
        public TCompositeBaseWorkItem FindItem(int ABaseShapeID, TCompositeBaseWork AFind)
        {
            TCompositeBaseWorkItem WI;
            TCompositeBaseWorkItem Res = null;
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                WI = (TCompositeBaseWorkItem)(f_ListItem.ElementAt(i));
                if (WI.BaseShape!=null)
                {
                    if (WI.BaseShape.ID == ABaseShapeID)
                    {
                        AFind = this;
                        return WI;
                    }
                }
                for (int j = 0; j <= WI.CompositeWorkCount - 1; j++)
                {
                    Res = WI.CompositeWork[j].FindItem(ABaseShapeID, AFind);
                    if (Res!=null)
                        return Res;
                }
            }
            return null;
        }
        public bool ContainedShape(int ABaseShapeID)
        {
            TCompositeBaseWorkItem WI;
            bool Res;
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                WI = (TCompositeBaseWorkItem)(f_ListItem.ElementAt(i));
                if (WI.BaseShape!=null)
                {
                    if (WI.BaseShape.ID == ABaseShapeID)
                    {
                        return true;
                    }
                }
                for (int j = 0; j <= WI.CompositeWorkCount - 1; j++)
                {
                    Res = WI.CompositeWork[j].ContainedShape(ABaseShapeID);
                    if (Res)
                        return Res;
                }
            }
            return false;
        }
           /*      public TCompositeBaseWork CopyRef();
                 public void FreeRef();
                 public void GetAllLines(TDynamicArray* R, bool AMarkFirst);
                 public void GetAllShapes(TDynamicArray* R);
                 virtual public void MakeFirstLine(TPoint AStart, int ABend);*/
        public void SetColorAll(Color AColor)
        {
            TCompositeBaseWorkItem Item;
            TBaseLine BL;
            for (int i = f_ListBL.Count - 1; i >= 0; i--)
            {
                BL = (TBaseLine)(f_ListBL.ElementAt(i));
                BL.Color = AColor;
            }
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                Item = (TCompositeBaseWorkItem)f_ListItem.ElementAt(i);
                if (Item.BaseShape!=null)
                    Item.BaseShape.PenColor = AColor;
                for (int j = 0; j <= Item.CompositeWorkCount - 1; j++)
                    Item.CompositeWork[j].SetColorAll(AColor);
            }
        }
        public void SetBrushColorAll(Color AColor)
        {
            TCompositeBaseWorkItem Item;
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                Item = (TCompositeBaseWorkItem)(f_ListItem.ElementAt(i));
                if (Item.BaseShape!=null)
                    Item.BaseShape.BrushColor = AColor;
                for (int j = 0; j <= Item.CompositeWorkCount - 1; j++)
                    Item.CompositeWork[j].SetBrushColorAll(AColor);

            }
        }
         /*        public void SetBrushStyleAll(TBrushStyle AStyle);
                 virtual public void TrimFirstLine(TPoint APStart, TPoint APEnd);
                 public void DeleteLine(void Line);


                 __property int TopBorder = { read = f_TopBorder, write = SetTopBorder };
                 __property int OffsetTop = { read = f_OffsetTop };
                 __property TBaseLine* BaseLineItem[int AIndex] = {read = GetBaseLineItem
             };
             __property int BaseLineCount = { read = GetBaseLineCount };
             __property int ItemCount = { read = GetItemCount };
             __property int LastLineBend = { read = f_LastLineBend };
             __property int FirstLineBend = { read = f_FirstLineBend };*/
        public Point StartPoint
        {
            set { SetStartPoint(value);  }
            get { return GetStartPoint(); }

        }
        public Point EndPoint
        {
            get { return GetEndPoint(); }
        }
        public TBaseLine EndLine
        {
            get { return GetEndLine(); }
        }
        public TColorSetup ColorSetup
        {
            set { f_ColorSetup = value; }
            get { return f_ColorSetup; }

        }
        public bool Selected
        {
            set { f_Selected = value; }
         /*   get { return SetSelected(); }*/
        }
        public  TRectLine FirstLine { get { return GetFirstLine(); } }
        /*__property TCompositeStack2* History = { read = f_History };*/
        public TBaseWorkShape ConvertedBWS
        {
            set { f_ConvertedBWS = value; }
            get { return f_ConvertedBWS; }
        }
    }
}
