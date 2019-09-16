using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TCompositeBaseWorkItem
    {
        TBaseShape f_Shape;
        TBaseShape f_SavedShape;
        public List<TCompositeBaseWork> CompositeWork;
        /*     void SetBaseShape(TBaseShape AShape);*/
        TCompositeBaseWork GetCompositeWork(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= CompositeWork.Count - 1)
                return CompositeWork.ElementAt(AIndex);
            else
                return null;
        }
        int GetCompositeWorkCount()
        {
            return CompositeWork.Count;
        }
        Point GetStartPoint()
        {
            return new Point(0, 0);
        }
   /*     Point GetEndPoint();*/
        Rectangle GetMaxRect()
        {
            Rectangle Res = GetAnyRect();
     //       Res = GetRectSummary(Res);
            return Res;
        }
        void SetStartPoint(Point AValue)
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
  /*      void FreeList();
        public TCompositeBaseWorkItem();
        ~TCompositeBaseWorkItem() { };
        public void Prepare();*/
        public void Paint(Graphics ACanvas)
        {
            TCompositeBaseWork Item;
            int mColor;
            if (f_Shape!=null)
            {
                mColor = SharedConst.GMess.SendMess(1, f_Shape.ID, 0);
                if (mColor != 0)
                    f_Shape.PenColor = new Color();
                f_Shape.Paint(ACanvas);
            }
            for (int i = CompositeWork.Count - 1; i >= 0; i--)
            {
                Item = (TCompositeBaseWork)CompositeWork.ElementAt(i);
                Item.Paint(ACanvas);
            }
        }
  /*      public TBaseShape FindTFE(int Ax, int Ay);*/
        public void ApplyOffset(int Ax, int Ay)
        {
            Rectangle R;
            if (f_Shape!=null)
            {
                R = f_Shape.BoundRect;
                R.X = R.Left + Ax;
                R.Width = R.Right + Ax;
                R.Y = R.Top + Ay;
                R.Height = R.Bottom + Ay;
                f_Shape.BoundRect = R;
            }
            TCompositeBaseWork Item;
            for (int i = 0; i <= CompositeWork.Count - 1; i++)
            {
                Item = (TCompositeBaseWork)(CompositeWork.ElementAt(i));
                Item.ApplyOffset(Ax, Ay);
            }
        }
        /*      public void AddCompositeWork(TCompositeBaseWork* AWork);*/
        public Rectangle GetAnyRect()
        {
            if (f_Shape!=null)
                return f_Shape.GetRect();
       /*     if (f_CompositeWorkList.Count > 0)
                return CompositeWork[0].GetAnyRect();*/
            return new Rectangle(0, 0, 0, 0);
        }
    /*    public TRect GetRectSummary(TRect ARect);
        public  void OffsetEndCoordinate();
        public void Degenerate();*/
        public TBaseShape BaseShape
        {
            set { f_Shape = value;  }
            get { return f_Shape; }
        }
        public int CompositeWorkCount
        {
            get { return GetCompositeWorkCount(); }
        }
        public Point StartPoint
        {
            set { SetStartPoint(value); }
            get { return GetStartPoint();  }
        }
            
    /*   public TPoint EndPoint = {read = GetEndPoint};*/
        public Rectangle MaxRect
        { get { return GetMaxRect(); } }
    }
}
