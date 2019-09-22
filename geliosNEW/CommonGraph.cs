using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TRect
    {
        public int Top, Left, Right, Buttom;
        public TRect (int tx, int ty, int tr, int tb)
        {
            Top = tx;
            Left = ty;
            Right = tr;
            Buttom = tb;
        }
        public TRect()
        {
            Top = 0;
            Left = 0;
            Right = 0;
            Buttom = 0;
        }
        public int X
        {
            get { return Top; }
        }
        public int Y
        {
            get { return Left; }
        }
        public int Width
        {
            get { return Right - Left; }
        }
        public int Height
        {
            get { return Buttom - Top; }
        }
    }
    class CommonGraph
    {
        public static string float_2_string(double ff, int pr)
        {
            string sResult;
     /*       DecimalSeparator = '.';
            sResult = FloatToStrF(ff, ffFixed, pr, 5);
            if (sResult == "NAN" || sResult == "INF" || sResult == "-INF")*/
                sResult = "0.00000][test";
            return sResult;
        }
    }
}
