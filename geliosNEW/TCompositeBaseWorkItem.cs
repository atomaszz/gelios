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
        List<object> f_CompositeWorkList;
   /*     void SetBaseShape(TBaseShape AShape);*/
        TCompositeBaseWork GetCompositeWork(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_CompositeWorkList.Count - 1)
                return (TCompositeBaseWork)f_CompositeWorkList.ElementAt(AIndex);
            else
                return null;
        }
    /*    int GetCompositeWorkCount();
        Point GetStartPoint();
        Point GetEndPoint();*/
        Rectangle GetMaxRect()
        {
            Rectangle Res = GetAnyRect();
     //       Res = GetRectSummary(Res);
            return Res;
        }
 /*       void SetStartPoint(TPoint AValue);
        void FreeList();
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
            for (int i = f_CompositeWorkList.Count - 1; i >= 0; i--)
            {
                Item = (TCompositeBaseWork)f_CompositeWorkList.ElementAt(i);
                Item.Paint(ACanvas);
            }
        }
  /*      public TBaseShape FindTFE(int Ax, int Ay);
        public void ApplyOffset(int Ax, int Ay);
        public void AddCompositeWork(TCompositeBaseWork* AWork);*/
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
 /*       public TCompositeBaseWork* CompositeWork[int AIndex] = { read = GetCompositeWork };
        public int CompositeWorkCount = { read = GetCompositeWorkCount };
        public TPoint StartPoint = {read = GetStartPoint, write = SetStartPoint
        public TPoint EndPoint = {read = GetEndPoint};*/
        public Rectangle MaxRect
        { get { return GetMaxRect(); } }
    }
}
