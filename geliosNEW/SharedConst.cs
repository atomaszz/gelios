using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class SharedConst
    {
        public const int D_FRAME = 1;
        public const int OFFS_FRAME = 2;

        public const int BL_HORIZONTAL = 0;
        public const int BL_VERTICAL = 1;
        public const int BL_OTHER = 2;
        public const int BL_POINT = 3;

        public static TMessangers GMess;

        public static int MyMin(int A1, int A2)
        {
            if (A1 < A2)
                return A1;
            else
                return A2;
        }

        public static int MyMax(int A1, int A2)
        {
            if (A1 > A2)
                return A1;
            else
                return A2;
        }
    }
}
