using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    public class TArrowLine : TRectLine
    {
     int F_Step;
        public TArrowLine(int Step, int Number = 0) :base(Step, Number)
        {
            F_Step = Step;
        }
        public void Prepare()
        {
            base.Prepare();
        }
        override public void Paint(Graphics Canvas)
        {
            base.Paint(Canvas);
        }

    }
}
