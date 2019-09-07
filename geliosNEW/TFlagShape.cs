using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    public class TFlagShape : TBaseShape
    {
        Point F_Center;
        double F_Radius;
        int F_TypeFlag;
        TBaseLine F_Owner;
        TBaseShape F_ShOwner;
        int F_ShPos;
        void SetTypeFlag(int Value)
        {
            if ((Value > 2) || (Value < 0))
                F_TypeFlag = 0;
            else
                F_TypeFlag = Value;
        }

        protected int GetTypeShape()
        {
            return 100;
        }
        public TFlagShape(int Step, TBaseLine Owner, int number) :base(0, 0, Step, number)
        {
            DrawCaption = false;
            F_Center = new Point(0, 0);
            F_Radius = 0;
            F_TypeFlag = 0;
            F_Owner = Owner;
      //      BrushStyle = bsSolid;
            F_ShOwner = null;
            F_ShPos = -1;
        }
/*        public void Paint(TCanvas* Canvas);
        public __property TPoint Center  = {read = F_Center, write = F_Center*/
    public double Radius
        {
            set { F_Radius = value; }
            get { return F_Radius; }
        }
    public int TypeFlag
        {
            set { SetTypeFlag(value); }
            get { return F_TypeFlag; }
        }
    public TBaseLine Owner
        {
            set { F_Owner = value; }
            get { return F_Owner;  }
        }
/*    public TBaseShape* ShapeOwner = { read = F_ShOwner, write = F_ShOwner };
    public int ShapePos = { read = F_ShPos, write = F_ShPos };*/
}
}
