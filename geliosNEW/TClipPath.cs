using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
  /*      public void Clear();
        public void Add(TRect Rect, int Offs = 0);*/
  //      HRGN GetCliptRgn();
    }
}
