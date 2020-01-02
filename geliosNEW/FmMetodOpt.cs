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
    public partial class FmMetodOpt : Form
    {
        public bool m_bIsApproximate;
        public FmMetodOpt()
        {
            InitializeComponent();
            m_bIsApproximate = false;
        }

        public int get_type_metod()
        {
            int res = SharedConst.TOHN;
            if (cbxMetod.SelectedIndex == 1)
            {
                res = SharedConst.PRIBLJ1;
                if (rg1.Checked)
                    res = SharedConst.PRIBLJ2;
            }
            return res;
        }

        public void set_type_metod(int typ)
        {
            if (typ == SharedConst.TOHN)
                cbxMetod.SelectedIndex = 0;
            else
                cbxMetod.SelectedIndex = 1;
            if (typ == SharedConst.PRIBLJ1)
                rg0.Checked = true;
            if (typ == SharedConst.PRIBLJ2)
                rg1.Checked = true;
            CbxMetod();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtOkClick_Click(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(edPercent.Text, out d))
            {
                MessageBox.Show("Использован недопустимый символ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edPercent.Focus();
                return;
            }
        }
        void CbxMetod()
        {
            m_bIsApproximate = cbxMetod.SelectedIndex == 1;
            rgMetod.Enabled = m_bIsApproximate;
            label2.Enabled = m_bIsApproximate;
            edPercent.Enabled = m_bIsApproximate;
        }

        private void CbxMetod_SelectedIndexChanged(object sender, EventArgs e)
        {
            CbxMetod();
        }
    }
}
