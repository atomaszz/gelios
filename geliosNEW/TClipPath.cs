using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TClipPath
    {
        List<object> F_Rects;
        List<object> F_Rgn;
 //       void ClearRgn()
        public TClipPath()
        {
            F_Rects = new List<object>();
            F_Rgn = new List<object>();
        }
        ~TClipPath() { }
        public void Clear()
        {
            F_Rects.Clear();
        }
        public void Add(Rectangle Rect, int Offs = 0)
        {
            Rectangle R = new Rectangle();
            R = Rect;
            if (Offs>0)
            {
                R.X -= Offs;
                R.Y -= Offs;
                R.Width += 2*Offs;
                R.Height += 2*Offs;
            }
            F_Rects.Add(R);
        }
  //      HRGN GetCliptRgn();
    }
}
