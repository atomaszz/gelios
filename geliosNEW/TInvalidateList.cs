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
        List<object> f_List;
        int f_Width;
        int f_Heigth;
   //     TBaseWorkShape GetItem(int AIndex);
    //    int GetCount();
        public TInvalidateList()
        {
            f_List = new List<object>();
            f_Width = f_Heigth = 0;
        }
        ~TInvalidateList() { }
        public void Clear()
        {
            f_List.Clear();
        }
        public void AddWorkShape(TBaseWorkShape AShape)
        {
            Rectangle R;
            Rectangle Bounds = new Rectangle(0, 0, f_Width, f_Heigth);
            Point P1, P2;
            TBaseWorkShape Tmp;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Tmp = (TBaseWorkShape)f_List.ElementAt(i);
                if (Tmp == AShape) return;
            }
            R = AShape.GetFrameRectWithLines();
            P1 = new Point(R.Left, R.Top);
            P2 = new Point(R.Right, R.Bottom);
            //    if (PtInRect(&Bounds, P1) || PtInRect(&Bounds, P2) )
            if ((R.Top <= f_Heigth) || (R.Bottom <= f_Heigth) || (R.Left!=0))
                f_List.Add(AShape);
        }
        //      public TBaseWorkShape  Items[int AIndex] = { read =  GetItem
        //       public int Count = { read = GetCount };
        //       public int Width = { read = f_Width, write = f_Width };
        //       public int Heigth = { read = f_Heigth, write = f_Heigth };
    }
}
