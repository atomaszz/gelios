using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geliosNEW
{
    public partial class FmParamAlternative : Form
    {
        private int f_Type_Char;
        private int f_ParentShapeID;
        private TBaseShape f_TFE;
        private Graphics f_Glp;


        public bool FReadOnly;
        //     __fastcall TfmParamAlternative(TComponent* Owner);
        public int Type_Char
        {
            set { f_Type_Char = value; }
            get { return f_Type_Char; }
        }
        public int ParentShapeID
        {
            set { f_ParentShapeID = value; }
            get { return f_ParentShapeID; }
        }
        public TBaseShape TFE
        {
            set { f_TFE = value; }
            get { return f_TFE;  }
        }

        public Graphics Glp
        {
            set { f_Glp = value; }
            get { return f_Glp; }
        }

        Graphics g;
        Bitmap bmp;

    public FmParamAlternative()
        {
            InitializeComponent();
        }


        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
