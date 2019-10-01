using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TInvalidateList
    {
        public List<object> Items;
        int f_Width;
        int f_Heigth;
        TBaseWorkShape GetItem(int AIndex)
        {
            TBaseWorkShape res = null;
            if ((AIndex >= 0) && (AIndex <= Items.Count - 1))
                res = (TBaseWorkShape)(Items.ElementAt(AIndex));
            return res;
        }
        int GetCount()
        {
            return (Items.Count);
        }
        public TInvalidateList()
        {
            Items = new List<object>();
            f_Width = f_Heigth = 0;
        }
        ~TInvalidateList() { }
        public void Clear()
        {
            Items.Clear();
        }
        public void AddWorkShape(TBaseWorkShape AShape)
        {
            Rectangle R;
            Rectangle Bounds = new Rectangle(0, 0, f_Width, f_Heigth);
            Point P1, P2;
            TBaseWorkShape Tmp;
            for (int i = 0; i <= Items.Count - 1; i++)
            {
                Tmp = (TBaseWorkShape)Items.ElementAt(i);
                if (Tmp == AShape) return;
            }
            R = AShape.GetFrameRectWithLines();
            P1 = new Point(R.Left, R.Top);
            P2 = new Point(R.Right, R.Bottom);
            //    if (PtInRect(&Bounds, P1) || PtInRect(&Bounds, P2) )
            if ((R.Top <= f_Heigth) || (R.Bottom <= f_Heigth) || (R.Left!=0))
                Items.Add(AShape);
        }
        public int Count
        {
            get { return GetCount(); }
        }
        //       public int Width = { read = f_Width, write = f_Width };
        //       public int Heigth = { read = f_Heigth, write = f_Heigth };
    }
}
