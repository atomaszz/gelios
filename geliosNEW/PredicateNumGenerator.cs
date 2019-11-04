using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TPredicateNumGenerator
    {
        int f_CurrentNum;
        public TPredicateNumGenerator()
        {
            f_CurrentNum = 0;
        }
        public int NextNum()
        {
            f_CurrentNum++;
            return f_CurrentNum;
        }
        public void InitNum(int ACurr = 0)
        {
            f_CurrentNum = ACurr;
        }
        public int NextLowNum()
        {
            f_CurrentNum--;
            return f_CurrentNum;
        }
    }
}
