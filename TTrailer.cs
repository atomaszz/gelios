using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    class TTrailer : TEllShape
    {
        Point F_Center;
        double F_Radius;
        public TTrailer(int Step, int number = 0) :base(0, 0, Step, number)
        {
       //     BrushStyle = bsClear;
        }
        public void Paint(PaintEventArgs Canvas)
        {
            Rectangle R = new Rectangle();

            R.X = Center.X - (int)(F_Radius * F_Step);
            R.Y = Center.Y - (int)(F_Radius * F_Step);
            R.Width = Center.X + (int)(F_Radius * F_Step);
            R.Height = Center.Y + (int)(F_Radius * F_Step);
            BoundRect = R;
            //      Canvas.Brush.Style = BrushStyle;
            //      Canvas.Brush.Color = BrushColor;
            //   Canvas.Ellipse(BoundRect.Left, BoundRect.Top, BoundRect.Right, BoundRect.Bottom);
            //      RestoreCanvas(Canvas);
            Pen tpen = new Pen(BrushColor, 2);
            Canvas.Graphics.DrawEllipse(tpen, BoundRect);
        }

        public Point Center
        {
            set { F_Center = value; }
            get { return F_Center; }
        }
        public double Radius
        {
            set { F_Radius = value; }
            get { return F_Radius; }
        }
    }
}
