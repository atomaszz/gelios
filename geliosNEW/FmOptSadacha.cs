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
    public partial class FmOptSadacha : Form
    {
        short type_sadacha; //выбранный тип задачи оптимизации
        short type_ogr;     //выбранный тип ограничений
        bool can_list;
        int type_char;
        string  c1, c2, c3;     //коэффициенты, нужные для задач 4-6
        string Bd, Td, Vd;     //коэффициенты, нужные для задач 1-3
        public TDynamicArray MassWork;
        TDischargedMassiv OptSovm;
        double Rate;
        int f_TypeMetod;

        public FmOptSadacha()
        {
            InitializeComponent();

            type_sadacha = SharedConst.ZAD_1;
            type_ogr = 0;
            Bd = "0"; Td = "100000000"; Vd = "100000000";
            c1 = "0"; c2 = "0"; c3 = "0";
            textBox4.Text = Vd;//V
            textBox1.Text = Td;//T
            textBox3.Text = Vd;//V
            textBox2.Text = Bd;//B
            textBox6.Text = Bd;//B
            textBox5.Text = Td;//T
            MassWork = new TDynamicArray();
            OptSovm = new TDischargedMassiv(0);
            Rate = 0.0;
            f_TypeMetod = SharedConst.TOHN;

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtShowGridSovm_Click(object sender, EventArgs e)
        {
        }

        public void InitData()
        {
            TBaseWorkShape WS;
            TBaseShape TFE;
            TGlsBinaryTree BTree = new TGlsBinaryTree(OPM_CompareNode);
            for (int i = 0; i <= MassWork.Count - 1; i++)
            {
                WS = (TBaseWorkShape)(MassWork.GetItems(i));
                for (int j = 0; j <= WS.WorkShapesCount - 1; j++)
                {
                    TFE = (TBaseShape)(WS.GetWorkShape(j));
                    BTree.insert(TFE);
                }
            }

            MassWork.Clear();
            BTree.inorder(OPM_Inorder);
         //   delete BTree;
            CheckCol();
        }

        private void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void FmOptSadacha_Activated(object sender, EventArgs e)
        {
            can_list = true;
            switch (type_sadacha)
            {
                case SharedConst.ZAD_1:
                    checkBox1.Checked = true; tabControl1.SelectedIndex = 0;
                    break;
                case SharedConst.ZAD_2:
                    checkBox2.Checked = true; tabControl1.SelectedIndex = 1;
                    break;
                case SharedConst.ZAD_3: checkBox3.Checked = true; tabControl1.SelectedIndex = 2; break;
                case SharedConst.ZAD_4: checkBox4.Checked = true; tabControl1.SelectedIndex = 3; break;
                case SharedConst.ZAD_5: checkBox5.Checked = true; tabControl1.SelectedIndex = 4; break;
                case SharedConst.ZAD_6: checkBox6.Checked = true; tabControl1.SelectedIndex = 5; break;
            }
            if (type_sadacha == 0 || type_sadacha == 1 || type_sadacha == 2)
                switch (type_ogr)
                {
                    case 0:
                        checkBox7.Checked = false;
                        checkBox8.Checked = false;
                        checkBox9.Checked = false;
                        break;
                    case 1:
                        checkBox7.Checked = true;
                        checkBox8.Checked = false;
                        checkBox9.Checked = false;
                        break;
                    case 2:
                        checkBox7.Checked = false;
                        checkBox8.Checked = true;
                        checkBox9.Checked = false;
                        break;
                    case 3:
                        checkBox7.Checked = true;
                        checkBox8.Checked = true;
                        checkBox9.Checked = false;
                        break;
                    case 4:
                        checkBox7.Checked = false;
                        checkBox8.Checked = false;
                        checkBox9.Checked = true;
                        break;
                    case 5:
                        checkBox7.Checked = true;
                        checkBox8.Checked = false;
                        checkBox9.Checked = true;
                        break;
                    case 6:
                        checkBox7.Checked = false;
                        checkBox8.Checked = true;
                        checkBox9.Checked = true;
                        break;
                    case 7:
                        checkBox7.Checked = true;
                        checkBox8.Checked = true;
                        checkBox9.Checked = true;
                        break;
                }
            else
                switch (type_ogr)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        checkBox9.Checked = false;
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        checkBox9.Checked = true;
                        break;
                }
            can_list = false;
            CheckBox9Click();
        }

        private void checkBox9_Click(object sender, EventArgs e)
        {
            CheckBox9Click();
        }
        void CheckBox9Click()
        {
            btShowGridSovm.Enabled = checkBox9.Checked;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                what_sadacha_check(SharedConst.ZAD_1);
                type_sadacha = SharedConst.ZAD_1;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox6.Checked = false;
                checkBox5.Checked = false;

                checkBox7.Visible = true;
                checkBox8.Visible = true;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                //     all_visible_false();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                what_sadacha_check(SharedConst.ZAD_2);
                type_sadacha = SharedConst.ZAD_2;
                checkBox1.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
                checkBox6.Checked = false; checkBox5.Checked = false;

                checkBox7.Visible = true; checkBox8.Visible = true;
                checkBox7.Checked = false; checkBox8.Checked = false;
                all_visible_false();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                what_sadacha_check(SharedConst.ZAD_3);
                type_sadacha = SharedConst.ZAD_3;
                checkBox2.Checked = false; checkBox1.Checked = false; checkBox4.Checked = false;
                checkBox6.Checked = false; checkBox5.Checked = false;

                checkBox7.Visible = true; checkBox8.Visible = true;
                checkBox7.Checked = false; checkBox8.Checked = false;
                all_visible_false();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                what_sadacha_check(SharedConst.ZAD_4);
                type_sadacha = SharedConst.ZAD_4;
                checkBox2.Checked = false; checkBox3.Checked = false; checkBox1.Checked = false;
                checkBox6.Checked = false; checkBox5.Checked = false;

                checkBox7.Visible = false; checkBox8.Visible = false;
                checkBox7.Checked = false; checkBox8.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                what_sadacha_check(SharedConst.ZAD_5);
                type_sadacha = SharedConst.ZAD_5;
                checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
                checkBox6.Checked = false; checkBox1.Checked = false;

                checkBox7.Visible = false; checkBox8.Visible = false;
                checkBox7.Checked = false; checkBox8.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                what_sadacha_check(SharedConst.ZAD_6);
                type_sadacha = SharedConst.ZAD_6;
                checkBox2.Checked = false; checkBox3.Checked = false; checkBox4.Checked = false;
                checkBox1.Checked = false; checkBox5.Checked = false;

                checkBox7.Visible = false; checkBox8.Visible = false;
                checkBox7.Checked = false; checkBox8.Checked = false;
            }
        }

        bool OPM_Inorder(object A)
        {
            TBaseShape m_A = (TBaseShape)(A);
            SharedConst.opt_sadacha.MassWork.Append((object)m_A.ID);
            return true;
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                switch (type_sadacha)
                {
                    case SharedConst.ZAD_1:
                        label4.Visible = true; label5.Visible = true; textBox4.Visible = true;
                        textBox4.Text = Vd;
                        break;
                    case SharedConst.ZAD_2:
                        label11.Visible = true; label12.Visible = true; textBox3.Visible = true;
                        textBox3.Text = Vd;
                        break;
                    case SharedConst.ZAD_3:
                        label15.Visible = true; label16.Visible = true; textBox6.Visible = true;
                        textBox6.Text = Bd;
                        break;
                }
            }
            else
            {
                switch (type_sadacha)
                {
                    case SharedConst.ZAD_1:
                        label4.Visible = false; label5.Visible = false; textBox4.Visible = false;
                        break;
                    case SharedConst.ZAD_2:
                        label11.Visible = false; label12.Visible = false; textBox3.Visible = false;
                        break;
                    case SharedConst.ZAD_3:
                        label15.Visible = false; label16.Visible = false; textBox6.Visible = false;
                        break;
                }
            }
        }

        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                switch (type_sadacha)
                {
                    case SharedConst.ZAD_1:
                        label7.Visible = true; label6.Visible = true; textBox1.Visible = true;
                        textBox1.Text = Td;
                        break;
                    case SharedConst.ZAD_2:
                        label10.Visible = true; label8.Visible = true; textBox2.Visible = true;
                        textBox2.Text = Bd;
                        break;
                    case SharedConst.ZAD_3:
                        label13.Visible = true; label14.Visible = true; textBox5.Visible = true;
                        textBox5.Text = Td;
                        break;
                }
            }
            else
            {
                switch (type_sadacha)
                {
                    case SharedConst.ZAD_1:
                        label7.Visible = false; label6.Visible = false; textBox1.Visible = false;
                        break;
                    case SharedConst.ZAD_2:
                        label10.Visible = false; label8.Visible = false; textBox2.Visible = false;
                        break;
                    case SharedConst.ZAD_3:
                        label13.Visible = false; label14.Visible = false; textBox5.Visible = false;
                        break;
                }
            }
        }

        int OPM_CompareNode(object A, object B)
        {
            TBaseShape m_A = (TBaseShape)(A);
            TBaseShape m_B = (TBaseShape)(B);
            if (m_A.ID > m_B.ID)
                return 1;
            if (m_A.ID < m_B.ID)
                return -1;
            return 0;
        }
        void CheckCol()
        {
            int rw = OptSovm.HiRow();
            int rc = OptSovm.HiCol();
            int v;
            for (int i = 0; i <= rw; i++)
            {
                for (int j = 0; j <= rc; j++)
                {
                    v = (int)(OptSovm.GetItems(i,j));
                    if (v!=0 && MassWork.Find((object)j)==null)
                        OptSovm.SetVal(i,j,0);
                }
            }
        }
        //получение картинки задачи в зависимости от выбора
        void  what_sadacha_check(int i)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            can_list =true;
            switch (i)
            {
            case SharedConst.ZAD_1:
                    label1.Text="Ограничения";
                    pictureBox1.Image = imageList1.Images[SharedConst.ZAD_1];
                    pictureBox2.Image = imageList2.Images[SharedConst.ZAD_1];
                    tabControl1.SelectedIndex = 0;
                    break;
            case SharedConst.ZAD_2:
                    label1.Text = "Ограничения";
                    pictureBox1.Image = imageList1.Images[SharedConst.ZAD_2];
                    pictureBox2.Image = imageList2.Images[SharedConst.ZAD_2];
                    tabControl1.SelectedIndex = 1;
                    break;
            case SharedConst.ZAD_3:label1.Text = "Ограничения";
                    pictureBox1.Image = imageList1.Images[SharedConst.ZAD_3];
                    pictureBox2.Image = imageList2.Images[SharedConst.ZAD_3];
                    tabControl1.SelectedIndex = 2;
                    break;
            case SharedConst.ZAD_4:
                    label1.Text = "Примечания";
                    pictureBox1.Image = imageList1.Images[SharedConst.ZAD_3];
                    pictureBox2.Image = imageList2.Images[SharedConst.ZAD_3];
                    tabControl1.SelectedIndex = 3;
             break;
            case SharedConst.ZAD_5:
                    label1.Text = "Примечания";
                    pictureBox1.Image = imageList1.Images[SharedConst.ZAD_5];
                    pictureBox2.Image = imageList2.Images[SharedConst.ZAD_5];
                    tabControl1.SelectedIndex = 4;
                    break;
            case SharedConst.ZAD_6:
                    label1.Text = "Примечания";
                    pictureBox1.Image = imageList1.Images[SharedConst.ZAD_6];
                    pictureBox2.Image = imageList2.Images[SharedConst.ZAD_6];
                    tabControl1.SelectedIndex = 5;
                    break;
      }
            can_list =false;
            pictureBox1.Update();
            pictureBox1.Update();
        }
        void all_visible_false()
        {
        /*    label7.Visible = false; label6.Visible = false; textBox1.Visible = false;
            label10.Visible = false; label8.Visible = false; textBox2.Visible = false;
            Label17.Visible = false; Label18.Visible = false; Edit9.Visible = false;
            Label7.Visible = false; Label8.Visible = false; Edit4.Visible = false;
            Label11.Visible = false; Label12.Visible = false; Edit6.Visible = false;
            Label15.Visible = false; Label16.Visible = false; Edit8.Visible = false;*/
        }
    }
}
