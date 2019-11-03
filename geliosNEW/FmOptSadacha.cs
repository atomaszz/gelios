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
<<<<<<< HEAD
        public TDischargedMassiv OptSovm;
        public double Rate;
=======
        TDischargedMassiv OptSovm;
        double Rate;
>>>>>>> parent of 4b1337c... \|\/
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
                all_visible_false();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
     /*       if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false &&
   checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                MessageBox.Show("Не выбран тип задачи оптимизации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //проверка наличия введеных коэффициентов
            bool f;
            f = true;
            if (checkBox7.Checked && checkBox8.Checked == false && checkBox9.Checked == false) type_ogr = 1;
            if (checkBox7.Checked == false && checkBox8.Checked && checkBox9.Checked == false) type_ogr = 2;
            if (checkBox7.Checked && checkBox8.Checked && checkBox9.Checked == false) type_ogr = 3;
            if (checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == false) type_ogr = 0;
            if (checkBox7.Checked && checkBox8.Checked == false && checkBox9.Checked == true) type_ogr = 5;
            if (checkBox7.Checked == false && checkBox8.Checked && checkBox9.Checked == true) type_ogr = 6;
            if (checkBox7.Checked && checkBox8.Checked && checkBox9.Checked == true) type_ogr = 7;
            if (checkBox7.Checked == false && checkBox8.Checked == false && checkBox9.Checked == true) type_ogr = 4;
            switch (type_sadacha)
            {
                case SharedConst.ZAD_1:
                    if (checkBox7.Checked)
                        if (textBox4.Text == "") f = false;
                        else Vd = textBox4.Text;//V
                    if (checkBox8.Checked)
                        if (textBox1.Text == "") f = false;
                        else Td = textBox1.Text;//T
                    break;

                case SharedConst.ZAD_2:
                    if (checkBox7.Checked)
                        if (Edit6.Text == "") f = false;
                        else Vd = Edit6.Text;//V
                    if (checkBox8.Checked)
                        if (Edit7.Text == "") f = false;
                        else Bd = Edit7.Text;//B
                    break;

                case SharedConst.ZAD_3:
                    if (checkBox7.Checked)
                        if (Edit8.Text == "") f = false;
                        else Bd = Edit8.Text;//B
                    if (checkBox8.Checked)
                        if (Edit9.Text == "") f = false;
                        else Td = Edit9.Text; //T
                    break;

                case SharedConst.ZAD_4:
                    if (Edit10.Text == "" || Edit11.Text == "" || Edit12.Text == "") f = false;
                    c1 = Edit10.Text; c2 = Edit11.Text; c3 = Edit12.Text;
                    break;
                case SharedConst.ZAD_5:
                    if (Edit1.Text == "" || Edit2.Text == "" || Edit3.Text == "") f = false;
                    c1 = Edit1.Text; c2 = Edit2.Text; c3 = Edit3.Text;
                    break;
                case SharedConst.ZAD_6:
                    if (Edit13.Text == "" || Edit14.Text == "" || Edit15.Text == "") f = false;
                    c1 = Edit13.Text; c2 = Edit14.Text; c3 = Edit15.Text;
                    break;
            }
            if (f == false)
            {
                MessageBox.Show("Не заданы коэффициенты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
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

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

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
            label7.Visible = false; label6.Visible = false; textBox1.Visible = false;
            label10.Visible = false; label8.Visible = false; textBox2.Visible = false;
            label14.Visible = false; label13.Visible = false; textBox5.Visible = false;
            label4.Visible = false; label5.Visible = false; textBox4.Visible = false;
            label11.Visible = false; label12.Visible = false; textBox3.Visible = false;
            label15.Visible = false; label16.Visible = false; textBox6.Visible = false;
        }
        public int get_type_metod()
        {
            return f_TypeMetod;
        }
        public int type_t_v()
        {
            switch (type_sadacha)
            {
                case SharedConst.ZAD_1:
                    switch (type_ogr)
                    {
                        case 0: return 0;
                        case 1: return 2;
                        case 2: return 1;
                        case 3: return 3;
                        case 4: return 0;
                        case 5: return 2;
                        case 6: return 1;
                        case 7: return 3;
                    }
                    break;
                case SharedConst.ZAD_2:
                    switch (type_ogr)
                    {
                        case 0: return 0;
                        case 1: return 2;
                        case 2: return 0;
                        case 3: return 2;
                        case 4: return 0;
                        case 5: return 2;
                        case 6: return 0;
                        case 7: return 2;
                    }
                    break;
                case SharedConst.ZAD_3:
                    switch (type_ogr)
                    {
                        case 0: return 0;
                        case 1: return 1;
                        case 2: return 0;
                        case 3: return 1;
                        case 4: return 0;
                        case 5: return 1;
                        case 6: return 0;
                        case 7: return 1;
                    }
                    break;
                case SharedConst.ZAD_4://обобщенные задачи
                case SharedConst.ZAD_5:
                case SharedConst.ZAD_6: return 0;
            }
            return 0;
        }
        //отображение выбранной задачи в предикатной модели
        public string make_sadacha()
        {
            string s="";
            if (checkBox9.Checked == true)
            {

            }
            switch (type_sadacha)
            {
                case SharedConst.ZAD_1:
                    s = "zadacha_opt(" + (type_sadacha + 1);
                    if ((type_ogr == 3) || (type_ogr == 7)) s = s + ",[[Vd," + Vd + "],[Td," + Td + "]]";
                    if ((type_ogr == 1) || (type_ogr == 5)) s = s + ",[[Vd," + Vd + "],[]]";
                    if ((type_ogr == 2) || (type_ogr == 6)) s = s + ",[[],[Td," + Td + "]]";
                    if ((type_ogr == 0) || (type_ogr == 4)) s = s + ",[[],[]]";
                    s = s + ").";
                    break;

                case SharedConst.ZAD_2:
                    s = "zadacha_opt(" + (type_sadacha + 1);
                    if ((type_ogr == 3) || (type_ogr == 7)) s = s + ",[[Vd," + Vd + "],[Bd," + Bd + "]]";
                    if ((type_ogr == 1) || (type_ogr == 5)) s = s + ",[[Vd," + Vd + "],[]]";
                    if ((type_ogr == 2) || (type_ogr == 6)) s = s + ",[[],[Bd," + Bd + "]]";
                    if ((type_ogr == 0) || (type_ogr == 4)) s = s + ",[[],[]]";
                    s = s + ").";
                    break;

                case SharedConst.ZAD_3:
                    s = "zadacha_opt(" + (type_sadacha + 1);
                    if ((type_ogr == 3) || (type_ogr == 7)) s = s + ",[[Bd," + Bd + "],[Td," + Td + "]]";
                    if ((type_ogr == 1) || (type_ogr == 5)) s = s + ",[[Bd," + Bd + "],[]]";
                    if ((type_ogr == 2) || (type_ogr == 6)) s = s + ",[[],[Td," + Td + "]]";
                    if ((type_ogr == 0) || (type_ogr == 4)) s = s + ",[[],[]]";
                    s = s + ").";
                    break;

                case SharedConst.ZAD_4:
                    s = "zadacha_opt(" + (type_sadacha + 1);
                    s = s + ",[[c1," + c1 + "],[c2," + c2 + "],[c3," + c3 + "]]";
                    s = s + ").";
                    break;

                case SharedConst.ZAD_5:
                    s = "zadacha_opt(" + (type_sadacha + 1);
                    s = s + ",[[c1," + c1 + "],[c2," + c2 + "],[c3," + c3 + "]]";
                    s = s + ").";
                    break;

                case SharedConst.ZAD_6:
                    s = "zadacha_opt(" + (type_sadacha + 1);
                    s = s + ",[[l," + c1 + "],[k," + c2 + "],[m," + c3 + "]]";
                    s = s + ").";
                    break;
            }
            return s;
        }
        public string make_ogrsovm()
        {
            int v;
            string Res="", Item;
            int rc = MassWork.Count;
            int rw = OptSovm.HiRow();
            if (checkBox9.Checked)
            {
                for (int i = 0; i <= rw; i++)
                {
                    Item = "ogr_sovmest([";
                    for (int j = 0; j <= rc - 1; j++)
                    {
                        v = (int)OptSovm.GetItems(i,j + 1);
                        if (j==0)
                            Item = Item + v.ToString();
                        else
                            Item = Item + "," + v.ToString();
                    }
                    Item = Item + "]).";
                    Res = Res + Item + "\r\n";
                }
            }
            return Res;
        }
    }
}
