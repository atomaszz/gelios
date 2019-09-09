using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace geliosNEW
{
    class TTail : TBaseLine
    {
        int F_Step;
        double F_FirstRadius;
        double F_LastRadius;
        TTrailer End;
        TTrailer Start;
        public TTail(int x0, int y0, int x1, int y1, int Step) : base(x0, y0, x1, y1, Step)
        {
            F_Step = Step;
            F_FirstRadius = 0;
            F_LastRadius = 0;
            End = new TTrailer(F_Step);
            Start = new TTrailer(F_Step);

        }

        ~TTail() { }
        public void Paint(PaintEventArgs Canvas)
        {
            Rectangle R;
            if ((F_FirstRadius == 0) && (F_LastRadius == 0))
                base.Paint(Canvas);
            else
            {
                //      OldPenParent.Assign(Canvas.Pen);
                //     Canvas.Pen.Assign(this.Pen);
                Pen tpen = new Pen(Color.Black, 2);
          //      Canvas.MoveTo(x0, y0);
                if (F_FirstRadius > 0)
                {
                    Start.Center = new Point(x0, y0);
                    Start.Radius = F_FirstRadius;
                    Start.Paint(Canvas);
                }
                //          Canvas.LineTo(x1, y1);
                Canvas.Graphics.DrawLine(new Pen(Color.Black,2), x0, y0, x1, y1);
                if (F_LastRadius > 0)
                {
                    End.Center = new Point(x1, y1);
                    End.Radius = F_LastRadius;
                    End.Paint(Canvas);
                }
                Canvas.Graphics.DrawLine(new Pen(Color.Black, 2), x0, y0, x1, y1);
           //     Canvas.LineTo(x1, y1);

           //     Canvas.Pen.Assign(OldPenParent);
            }
        }
        public double FirstRadius
        {
            set { F_FirstRadius = value; }
            get { return F_FirstRadius; }
        }
        public double LastRadius
        {
            set { F_LastRadius = value; }
            get { return F_LastRadius; }
        }
    }
}
