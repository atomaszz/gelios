using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace geliosNEW
{
    public class TAlternateItem
    {
        int f_IdAlt;
        int f_NumAlt;
        int f_ParentIdAlt;
        int f_ParentNumAlt;
        bool f_First;
        TBaseWorkShape f_WorkShape;
        TBaseWorkShape f_OtherWorkShape;
   //     TArrowWorkShape f_ArrowWorkShape;
        Color f_ArrowColor;
        Color f_EnterArrowColor;
        bool f_Entered;
        bool f_Visible;
        void SetArrowColor(Color AValue)
        {
            f_ArrowColor = AValue;
        }
        void SetEnterArrowColor(Color AValue)
        {
            f_EnterArrowColor = AValue;
        }
        public TAlternateItem(TBaseWorkShape AWorkShape, int AIdAlt, int ANumAlt,
       int AParentIdAlt, int AParentNumAlt, bool AFirst)
        {
            int m_step;
            f_IdAlt = AIdAlt;
            f_NumAlt = ANumAlt;
            f_ParentIdAlt = AParentIdAlt;
            f_ParentNumAlt = AParentNumAlt;
            f_WorkShape = AWorkShape;
  //          m_step = f_WorkShape.Step;
            f_First = AFirst;
 /*           if (AFirst)
                f_ArrowWorkShape = new TArrowWorkShape(f_WorkShape.StartPoint.x, f_WorkShape.StartPoint.y, m_step, 0, 0, 0);
            else
                f_ArrowWorkShape = new TArrowWorkShape(f_WorkShape.EndPoint.x, f_WorkShape.EndPoint.y, m_step, 0, 0, 0);*/
  /*          f_ArrowWorkShape.BrushStyle = new SolidBrush(Color.Black);
            f_ArrowWorkShape.Init();
            f_ArrowWorkShape.AddNodeHint(f_IdAlt);*/
            f_Entered = false;
            f_Visible = true;
            f_OtherWorkShape = null;

        }
        ~TAlternateItem() { }
/*        public TArrowWorkShape ArrowWorkShape 
        {
            get { return f_ArrowWorkShape; }
        }*/
        public TBaseWorkShape WorkShape 
        {
            get { return f_WorkShape; }
            set { f_WorkShape = value; }
        }
        public TBaseWorkShape OtherWorkShape 
        {
            get { return f_OtherWorkShape; }
            set { f_OtherWorkShape = value; }
        }
        public bool First
        {
            get { return f_First; }
            set { f_First = value; }
        }
        public Color EnterArrowColor
        {
            get { return f_EnterArrowColor; }
            set { SetEnterArrowColor(value); }
        }
        public Color ArrowColor
        {
            get { return f_ArrowColor; }
            set { SetArrowColor(value); }
        }
        public bool Entered
        {
            get { return f_Entered; }
            set { f_Entered = value; }
        }
        public bool Visible 
        {
            get { return f_Visible; }
            set { f_Visible = value; }
        }
        public int IdAlt
        {
            get { return f_IdAlt; }
        }
        public int NumAlt
        {
            get { return f_NumAlt; }
        }
        public int IdAltParent
        {
            get { return f_ParentIdAlt; }
        }
        public int NumAltParent
        {
            get { return f_ParentNumAlt; }
        }
    }
}
