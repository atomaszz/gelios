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
    public partial class FmViewDecision : Form
    {
        public int Type_Char;
        public TParamAlternative ParamAlt;
        public Color VwColorAlt;
        public Color VwColorBadAlt;
        public Color VwColorFont;
        public FmViewDecision()
        {
            InitializeComponent();
        }
        public void SetBTVText(string str1, string str2, string str3)
        {
            edB.Text = str1;
            edT.Text = str2;
            edV.Text = str3;
        }
        public void SetSostavText(string str1, string str2, string str3)
        {
            sdOptSostav.Text = str1;
            textBox1.Text = str2;
            textBox2.Text = str3;
        }

        public void SetInformText(string str1, string str2, string str3, string str4, string str5)
        {
            edVid1.Text = str1;
            edVid2.Text = str2;
            edOgr1.Text = str3;
            edOgr2.Text = str4;
            edKoef.Text = str5;
        }
        public void SetTimeText(string str)
        {
            edTime.Text = str;
        }
        
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
