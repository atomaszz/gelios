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
    public partial class FmTredactChar : Form
    {
        bool f_Can_list;
        int f_Type_Char;
        TParamAlternativeItem f_PAItem;
        TBaseShape f_TFE;

        public int Type_Char
        {
            set{ f_Type_Char = value; }
            get { return f_Type_Char; }
        }
            
        public TParamAlternativeItem PAItem
        {
            set { f_PAItem = value; }
            get { return f_PAItem; }
        }

        public TBaseShape TFE
        {
            set { f_TFE = value; }
            get { return f_TFE; }
        }

        public bool Can_list
        {
            set { f_Can_list = value; }
            get { return f_Can_list; }
        }

        public FmTredactChar()
        {
            InitializeComponent();
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (check_table() == 0)
            {
                return;
            }

            if (textBox2.Text.Length != 0)
                PAItem.NAME = textBox2.Text;
            else
                PAItem.NAME = "(нет названия)";

            if (textBox3.Text.Length != 0)
                PAItem.PREDICAT = textBox3.Text;
            else
                PAItem.PREDICAT = "";

            PAItem.ELEMENT = "(нет элемента)";

            PAItem.FUNCTION2 = "(нет функции)";

            if (Type_Char == SharedConst.FUZZY)
                if (compare_char_fuzzy() == 0)
                {
                    MessageBox.Show("Значение верхней границы не может быть меньше значения нижней границы.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            if (Type_Char == SharedConst.PROP)
                save_char_prop();
            if (Type_Char == SharedConst.FUZZY)
                save_char_fuzzy();

            Close();
        }

        //функци¤ проверки правильности ввода характеристик
        int check_table()
        {
            float prob1 = 0, prob2 = 0;
            int type = TFE.TypeShape;

            //перед тем, как перейти на другую запись, проверка допустимости значений
            //для вероятностей
            if (type == 5) { prob1 = (float)Double.Parse(textBox4.Text); }
            if (type == 6) { prob1 = (float)Double.Parse(textBox28.Text); prob2 = (float)Double.Parse(textBox29.Text); }
            if (type == 7) { prob1 = (float)Double.Parse(textBox83.Text); prob2 = (float)Double.Parse(textBox84.Text); }

            if (prob1 < 0.0 || prob1 > 1.0)
            {
                MessageBox.Show("«начение вероятности должно быть в интервале 0...1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (type == 1) textBox4.Focus();
                if (type == 2) textBox28.Focus();
                if (type == 3) textBox83.Focus();
                return 0;
            }
            if (prob2 < 0.0 || prob2 > 1.0)
            {
                MessageBox.Show("«начение вероятности должно быть в интервале 0...1", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (type == 2) textBox29.Focus();
                if (type == 3) textBox84.Focus();
                return 0;
            }
            return 1;
        }

        private void FmTredactChar_Activated(object sender, EventArgs e)
        {
            bool m_old_can = f_Can_list;
            f_Can_list = true;
            int type = PAItem.TYPE;
            textBox1.Text = PAItem.SOSTAV;
            textBox1.ReadOnly = true;
            textBox2.Text = PAItem.NAME;
            textBox93.Text = PAItem.PREDICAT;
            textBox3.Text = PAItem.PREDICAT;


            if (Type_Char == SharedConst.PROP)
            {
                show_char_fuzzy();
                show_char_prop();
            }
            else
            {
                show_char_prop();
                show_char_fuzzy();
            }
            switch (type)
            {
                case 5:
                    label7.Text = "Рабочая операция";
                    tabControl1.SelectedIndex = 0;
              //      tabControl1.TabPages[0]
              //      TabbedNotebook1.PageIndex = 0;
                    break;

                case 6:
                    label7.Text = "Контроль работоспособности";
                    tabControl1.SelectedIndex = 1;
             //       TabbedNotebook1.PageIndex = 1;
                    break;

                case 7:
                    label7.Text = "Функциональный контроль";
                    tabControl1.SelectedIndex = 2;
          //          TabbedNotebook1.PageIndex = 2;
                    break;

                case 8:
                    label7.Text = "Проверка условия";
                    tabControl1.SelectedIndex = 3;
        //            TabbedNotebook1.PageIndex = 3;
                    break;
            }
            f_Can_list = m_old_can;
        }

        void show_char_fuzzy()
        {
            int m_type = TFE.TypeShape;
            if (m_type == 5)
            {
                textBox11.Text = String.Format("{0:0.000000}", PAItem.B_F3B);
                textBox12.Text = String.Format("{0:0.000000}", PAItem.B_F3N);
                textBox7.Text = String.Format("{0:0.000000}", PAItem.B_F1B);
                textBox8.Text = String.Format("{0:0.000000}", PAItem.B_F1N);
                textBox9.Text = String.Format("{0:0.000000}", PAItem.B_F2B);
                textBox10.Text = String.Format("{0:0.000000}", PAItem.B_F2N);
                textBox25.Text = String.Format("{0:0.0000}", PAItem.A2_B_F);

                textBox14.Text = String.Format("{0:0.0000000000}", PAItem.T_F3B);
                textBox13.Text = String.Format("{0:0.0000000000}", PAItem.T_F3N);
                textBox18.Text = String.Format("{0:0.0000000000}", PAItem.T_F1B);
                textBox17.Text = String.Format("{0:0.0000000000}", PAItem.T_F1N);
                textBox16.Text = String.Format("{0:0.0000000000}", PAItem.T_F2B);
                textBox15.Text = String.Format("{0:0.0000000000}", PAItem.T_F2N);

                textBox20.Text = String.Format("{0:0.0000000000}", PAItem.V_F3B);
                textBox19.Text = String.Format("{0:0.0000000000}", PAItem.V_F3N);
                textBox24.Text = String.Format("{0:0.0000000000}", PAItem.V_F1B);
                textBox23.Text = String.Format("{0:0.0000000000}", PAItem.V_F1N);
                textBox22.Text = String.Format("{0:0.0000000000}", PAItem.V_F2B);
                textBox21.Text = String.Format("{0:0.0000000000}", PAItem.V_F2N);
            }

            if (m_type == 6)
            {
                textBox45.Text = String.Format("{0:0.000000}", PAItem.P11_F3B);
                textBox44.Text = String.Format("{0:0.000000}", PAItem.P11_F3N);
                textBox49.Text = String.Format("{0:0.000000}", PAItem.P11_F1B);
                textBox48.Text = String.Format("{0:0.000000}", PAItem.P11_F1N);
                textBox47.Text = String.Format("{0:0.000000}", PAItem.P11_F2B);
                textBox46.Text = String.Format("{0:0.000000}", PAItem.P11_F2N);
                textBox31.Text = String.Format("{0:0.0000}", PAItem.A2_P11_F);

                textBox39.Text = String.Format("{0:0.000000}", PAItem.P00_F3B);
                textBox38.Text = String.Format("{0:0.000000}", PAItem.P00_F3N);
                textBox43.Text = String.Format("{0:0.000000}", PAItem.P00_F1B);
                textBox44.Text = String.Format("{0:0.000000}", PAItem.P00_F1N);
                textBox41.Text = String.Format("{0:0.000000}", PAItem.P00_F2B);
                textBox40.Text = String.Format("{0:0.000000}", PAItem.P00_F2N);

                textBox33.Text = String.Format("{0:0.0000000000}", PAItem.TD_F3B);
                textBox32.Text = String.Format("{0:0.0000000000}", PAItem.TD_F3N);
                textBox37.Text = String.Format("{0:0.0000000000}", PAItem.TD_F1B);
                textBox36.Text = String.Format("{0:0.0000000000}", PAItem.TD_F1N);
                textBox35.Text = String.Format("{0:0.0000000000}", PAItem.TD_F2B);
                textBox34.Text = String.Format("{0:0.0000000000}", PAItem.TD_F2N);

                textBox51.Text = String.Format("{0:0.0000000000}", PAItem.VD_F3B);
                textBox50.Text = String.Format("{0:0.0000000000}", PAItem.VD_F3N);
                textBox55.Text = String.Format("{0:0.0000000000}", PAItem.VD_F1B);
                textBox54.Text = String.Format("{0:0.0000000000}", PAItem.VD_F1N);
                textBox53.Text = String.Format("{0:0.0000000000}", PAItem.VD_F2B);
                textBox52.Text = String.Format("{0:0.0000000000}", PAItem.VD_F2N);

                textBox57.Text = String.Format("{0:0.000000}", PAItem.P_EL_F3B);
                textBox56.Text = String.Format("{0:0.000000}", PAItem.P_EL_F3N);
                textBox61.Text = String.Format("{0:0.000000}", PAItem.P_EL_F1B);
                textBox60.Text = String.Format("{0:0.000000}", PAItem.P_EL_F1N);
                textBox59.Text = String.Format("{0:0.000000}", PAItem.P_EL_F2B);
                textBox58.Text = String.Format("{0:0.000000}", PAItem.P_EL_F2N);
            }

            if (m_type == 7)
            {
                textBox76.Text = String.Format("{0:0.000000}", PAItem.K11_F3B);
                textBox75.Text = String.Format("{0:0.000000}", PAItem.K11_F3N);
                textBox80.Text = String.Format("{0:0.000000}", PAItem.K11_F1B);
                textBox79.Text = String.Format("{0:0.000000}", PAItem.K11_F1N);
                textBox78.Text = String.Format("{0:0.000000}", PAItem.K11_F2B);
                textBox77.Text = String.Format("{0:0.000000}", PAItem.K11_F2N);
                textBox62.Text = String.Format("{0:0.0000}", PAItem.A2_K11_F);

                textBox86.Text = String.Format("{0:0.000000}", PAItem.K00_F3B);
                textBox85.Text = String.Format("{0:0.000000}", PAItem.K00_F3N);
                textBox90.Text = String.Format("{0:0.000000}", PAItem.K00_F1B);
                textBox89.Text = String.Format("{0:0.000000}", PAItem.K00_F1N);
                textBox88.Text = String.Format("{0:0.000000}", PAItem.K00_F2B);
                textBox87.Text = String.Format("{0:0.000000}", PAItem.K00_F2N);

                textBox70.Text = String.Format("{0:0.0000000000}", PAItem.TF_F3B);
                textBox69.Text = String.Format("{0:0.0000000000}", PAItem.TF_F3N);
                textBox74.Text = String.Format("{0:0.0000000000}", PAItem.TF_F1B);
                textBox73.Text = String.Format("{0:0.0000000000}", PAItem.TF_F1N);
                textBox72.Text = String.Format("{0:0.0000000000}", PAItem.TF_F2B);
                textBox71.Text = String.Format("{0:0.0000000000}", PAItem.TF_F2N);

                textBox64.Text = String.Format("{0:0.0000000000}", PAItem.VF_F3B);
                textBox63.Text = String.Format("{0:0.0000000000}", PAItem.VF_F3N);
                textBox68.Text = String.Format("{0:0.0000000000}", PAItem.VF_F1B);
                textBox67.Text = String.Format("{0:0.0000000000}", PAItem.VF_F1N);
                textBox66.Text = String.Format("{0:0.0000000000}", PAItem.VF_F2B);
                textBox65.Text = String.Format("{0:0.0000000000}", PAItem.VF_F2N);
            }
            if (m_type == 8)
            {
                textBox93.Text = PAItem.PREDICAT;
            }
            enable_true(m_type);//установка доступности редактировани¤ нечетких характеристик
        }

        void show_char_prop()
        {
            int m_type = TFE.TypeShape;
            label5.Visible = true;
            textBox3.Visible = true;
            if (m_type == 5)
            {
                textBox4.Text = String.Format("{0:0.000000}", PAItem.B);
                textBox4.Text = String.Format("{0:0.000000}", PAItem.B);
                textBox5.Text = String.Format("{0:0.0000000000}", PAItem.T);
                textBox6.Text = String.Format("{0:0.0000000000}", PAItem.V);
            }
            if (m_type == 6)
            {
                textBox28.Text = String.Format("{0:0.000000}", PAItem.P_11);
                textBox29.Text = String.Format("{0:0.000000}", PAItem.P_00);
                textBox27.Text = String.Format("{0:0.0000000000}", PAItem.T_D);
                textBox26.Text = String.Format("{0:0.0000000000}", PAItem.V_D);
                textBox30.Text = String.Format("{0:0.000000}", PAItem.P_DIAGN_EL);
            }
            if (m_type == 7)
            {
                textBox83.Text = String.Format("{0:0.000000}", PAItem.K_11);
                textBox84.Text = String.Format("{0:0.000000}", PAItem.K_00);
                textBox82.Text = String.Format("{0:0.0000000000}", PAItem.T_F);
                textBox81.Text = String.Format("{0:0.0000000000}", PAItem.V_F);
            }
            if (m_type == 8)
            {
                label5.Visible = false;
                textBox3.Visible = false;
            }
            enable_false(m_type);//установка недоступности редактирования нечетких характеристик
        }
        void enable_false(int type)
        {
            if (type == 5)
            {
                textBox11.Enabled = false; textBox12.Enabled = false; textBox7.Enabled = false; textBox8.Enabled = false; textBox9.Enabled = false; textBox10.Enabled = false;
                textBox14.Enabled = false; textBox13.Enabled = false; textBox18.Enabled = false; textBox17.Enabled = false; textBox16.Enabled = false; textBox15.Enabled = false;
                textBox20.Enabled = false; textBox19.Enabled = false; textBox24.Enabled = false; textBox23.Enabled = false; textBox22.Enabled = false; textBox21.Enabled = false;
                textBox25.Enabled = false;
                textBox4.Enabled = true; textBox5.Enabled = true; textBox6.Enabled = true;
            }
            else if (type == 6)
            {
                textBox45.Enabled = false; textBox44.Enabled = false; textBox49.Enabled = false; textBox48.Enabled = false; textBox47.Enabled = false; textBox46.Enabled = false;
                textBox39.Enabled = false; textBox38.Enabled = false; textBox43.Enabled = false; textBox44.Enabled = false; textBox41.Enabled = false; textBox40.Enabled = false;
                textBox33.Enabled = false; textBox32.Enabled = false; textBox37.Enabled = false; textBox36.Enabled = false; textBox35.Enabled = false; textBox34.Enabled = false;
                textBox51.Enabled = false; textBox50.Enabled = false; textBox55.Enabled = false; textBox54.Enabled = false; textBox53.Enabled = false; textBox52.Enabled = false;
                textBox61.Enabled = false; textBox60.Enabled = false; textBox59.Enabled = false; textBox58.Enabled = false; textBox57.Enabled = false; textBox56.Enabled = false;
                textBox31.Enabled = false;
                textBox28.Enabled = true; textBox29.Enabled = true; textBox27.Enabled = true; textBox26.Enabled = true; textBox30.Enabled = true;
            }
            else if (type == 7)
            {
                textBox76.Enabled = false; textBox75.Enabled = false; textBox80.Enabled = false; textBox79.Enabled = false; textBox78.Enabled = false; textBox77.Enabled = false;
                textBox86.Enabled = false; textBox85.Enabled = false; textBox90.Enabled = false; textBox89.Enabled = false; textBox88.Enabled = false; textBox87.Enabled = false;
                textBox70.Enabled = false; textBox69.Enabled = false; textBox74.Enabled = false; textBox73.Enabled = false; textBox72.Enabled = false; textBox71.Enabled = false;
                textBox64.Enabled = false; textBox63.Enabled = false; textBox68.Enabled = false; textBox67.Enabled = false; textBox66.Enabled = false; textBox65.Enabled = false;
                textBox62.Enabled = false;
                textBox83.Enabled = true; textBox84.Enabled = true; textBox82.Enabled = true; textBox81.Enabled = true;
            }
        }
        int compare_char_fuzzy()
        {
            int m_type = TFE.TypeShape;
            if (m_type == 5)
            {
                if ((float)Double.Parse(textBox11.Text) < (float)Double.Parse(textBox12.Text)) { textBox11.Focus(); return 0; }
                if ((float)Double.Parse(textBox7.Text) < (float)Double.Parse(textBox8.Text)) { textBox7.Focus(); return 0; }
                if ((float)Double.Parse(textBox9.Text) < (float)Double.Parse(textBox10.Text)) { textBox9.Focus(); return 0; }


                if ((float)Double.Parse(textBox14.Text) < (float)Double.Parse(textBox13.Text)) { textBox14.Focus(); return 0; }
                if ((float)Double.Parse(textBox18.Text) < (float)Double.Parse(textBox17.Text)) { textBox18.Focus(); return 0; }
                if ((float)Double.Parse(textBox16.Text) < (float)Double.Parse(textBox15.Text)) { textBox16.Focus(); return 0; }

                if ((float)Double.Parse(textBox20.Text) < (float)Double.Parse(textBox19.Text)) { textBox20.Focus(); return 0; }
                if ((float)Double.Parse(textBox24.Text) < (float)Double.Parse(textBox23.Text)) { textBox24.Focus(); return 0; }
                if ((float)Double.Parse(textBox22.Text) < (float)Double.Parse(textBox21.Text)) { textBox22.Focus(); return 0; }
            }
            if (m_type == 6)
            {
                if ((float)Double.Parse(textBox45.Text) < (float)Double.Parse(textBox44.Text)) { textBox45.Focus(); return 0; }
                if ((float)Double.Parse(textBox49.Text) < (float)Double.Parse(textBox48.Text)) { textBox49.Focus(); return 0; }
                if ((float)Double.Parse(textBox47.Text) < (float)Double.Parse(textBox46.Text)) { textBox47.Focus(); return 0; }

                if ((float)Double.Parse(textBox39.Text) < (float)Double.Parse(textBox38.Text)) { textBox39.Focus(); return 0; }
                if ((float)Double.Parse(textBox43.Text) < (float)Double.Parse(textBox44.Text)) { textBox43.Focus(); return 0; }
                if ((float)Double.Parse(textBox41.Text) < (float)Double.Parse(textBox40.Text)) { textBox41.Focus(); return 0; }

                if ((float)Double.Parse(textBox33.Text) < (float)Double.Parse(textBox32.Text)) { textBox33.Focus(); return 0; }
                if ((float)Double.Parse(textBox37.Text) < (float)Double.Parse(textBox36.Text)) { textBox37.Focus(); return 0; }
                if ((float)Double.Parse(textBox35.Text) < (float)Double.Parse(textBox34.Text)) { textBox35.Focus(); return 0; }

                if ((float)Double.Parse(textBox51.Text) < (float)Double.Parse(textBox50.Text)) { textBox51.Focus(); return 0; }
                if ((float)Double.Parse(textBox55.Text) < (float)Double.Parse(textBox54.Text)) { textBox55.Focus(); return 0; }
                if ((float)Double.Parse(textBox53.Text) < (float)Double.Parse(textBox52.Text)) { textBox53.Focus(); return 0; }

                if ((float)Double.Parse(textBox57.Text) < (float)Double.Parse(textBox56.Text)) { textBox57.Focus(); return 0; }
                if ((float)Double.Parse(textBox61.Text) < (float)Double.Parse(textBox60.Text)) { textBox61.Focus(); return 0; }
                if ((float)Double.Parse(textBox59.Text) < (float)Double.Parse(textBox58.Text)) { textBox59.Focus(); return 0; }
            }
            if (m_type == 7)
            {
                if ((float)Double.Parse(textBox76.Text) < (float)Double.Parse(textBox75.Text)) { textBox76.Focus(); return 0; }
                if ((float)Double.Parse(textBox80.Text) < (float)Double.Parse(textBox79.Text)) { textBox80.Focus(); return 0; }
                if ((float)Double.Parse(textBox78.Text) < (float)Double.Parse(textBox77.Text)) { textBox78.Focus(); return 0; }

                if ((float)Double.Parse(textBox86.Text) < (float)Double.Parse(textBox85.Text)) { textBox86.Focus(); return 0; }
                if ((float)Double.Parse(textBox90.Text) < (float)Double.Parse(textBox89.Text)) { textBox90.Focus(); return 0; }
                if ((float)Double.Parse(textBox88.Text) < (float)Double.Parse(textBox87.Text)) { textBox88.Focus(); return 0; }

                if ((float)Double.Parse(textBox70.Text) < (float)Double.Parse(textBox69.Text)) { textBox70.Focus(); return 0; }
                if ((float)Double.Parse(textBox74.Text) < (float)Double.Parse(textBox73.Text)) { textBox74.Focus(); return 0; }
                if ((float)Double.Parse(textBox72.Text) < (float)Double.Parse(textBox71.Text)) { textBox72.Focus(); return 0; }

                if ((float)Double.Parse(textBox64.Text) < (float)Double.Parse(textBox63.Text)) { textBox64.Focus(); return 0; }
                if ((float)Double.Parse(textBox68.Text) < (float)Double.Parse(textBox67.Text)) { textBox68.Focus(); return 0; }
                if ((float)Double.Parse(textBox66.Text) < (float)Double.Parse(textBox65.Text)) { textBox66.Focus(); return 0; }
            }
            return 1;
        }
        //---------------------------------------------------------------------------
        void save_char_fuzzy()
        {
            int m_type = TFE.TypeShape;
            if (m_type == 5)
            {
                PAItem.B_F3B = (float)Double.Parse(textBox11.Text);
                PAItem.B_F3N = (float)Double.Parse(textBox12.Text);
                PAItem.B_F1B = (float)Double.Parse(textBox7.Text);
                PAItem.B_F1N = (float)Double.Parse(textBox8.Text);
                PAItem.B_F2B = (float)Double.Parse(textBox9.Text);
                PAItem.B_F2N = (float)Double.Parse(textBox10.Text);
                PAItem.A2_B_F = (float)Double.Parse(textBox25.Text);
                PAItem.A1_B_F = 0.0;
                PAItem.A3_B_F = 1.0;

                PAItem.T_F3B = (float)Double.Parse(textBox14.Text);
                PAItem.T_F3N = (float)Double.Parse(textBox13.Text);
                PAItem.T_F1B = (float)Double.Parse(textBox18.Text);
                PAItem.T_F1N = (float)Double.Parse(textBox17.Text);
                PAItem.T_F2B = (float)Double.Parse(textBox16.Text);
                PAItem.T_F2N = (float)Double.Parse(textBox15.Text);
                PAItem.A2_T_F = (float)Double.Parse(textBox25.Text);
                PAItem.A1_T_F = 0.0;
                PAItem.A3_T_F = 1.0;

                PAItem.V_F3B = (float)Double.Parse(textBox20.Text);
                PAItem.V_F3N = (float)Double.Parse(textBox19.Text);
                PAItem.V_F1B = (float)Double.Parse(textBox24.Text);
                PAItem.V_F1N = (float)Double.Parse(textBox23.Text);
                PAItem.V_F2B = (float)Double.Parse(textBox22.Text);
                PAItem.V_F2N = (float)Double.Parse(textBox21.Text);
                PAItem.A2_V_F = (float)Double.Parse(textBox25.Text);
                PAItem.A1_V_F = 0.0;
                PAItem.A3_V_F = 1.0;
            }
            if (m_type == 6)
            {
                PAItem.P11_F3B = (float)Double.Parse(textBox45.Text);
                PAItem.P11_F3N = (float)Double.Parse(textBox44.Text);
                PAItem.P11_F1B = (float)Double.Parse(textBox49.Text);
                PAItem.P11_F1N = (float)Double.Parse(textBox48.Text);
                PAItem.P11_F2B = (float)Double.Parse(textBox47.Text);
                PAItem.P11_F2N = (float)Double.Parse(textBox46.Text);
                PAItem.A2_P11_F = (float)Double.Parse(textBox31.Text);
                PAItem.A1_P11_F = 0.0;
                PAItem.A3_P11_F = 1.0;

                PAItem.P00_F3B = (float)Double.Parse(textBox39.Text);
                PAItem.P00_F3N = (float)Double.Parse(textBox38.Text);
                PAItem.P00_F1B = (float)Double.Parse(textBox43.Text);
                PAItem.P00_F1N = (float)Double.Parse(textBox44.Text);
                PAItem.P00_F2B = (float)Double.Parse(textBox41.Text);
                PAItem.P00_F2N = (float)Double.Parse(textBox40.Text);
                PAItem.A2_P00_F = (float)Double.Parse(textBox31.Text);
                PAItem.A1_P00_F = 0.0;
                PAItem.A3_P00_F = 1.0;

                PAItem.TD_F3B = (float)Double.Parse(textBox33.Text);
                PAItem.TD_F3N = (float)Double.Parse(textBox32.Text);
                PAItem.TD_F1B = (float)Double.Parse(textBox37.Text);
                PAItem.TD_F1N = (float)Double.Parse(textBox36.Text);
                PAItem.TD_F2B = (float)Double.Parse(textBox35.Text);
                PAItem.TD_F2N = (float)Double.Parse(textBox34.Text);
                PAItem.A2_TD_F = (float)Double.Parse(textBox31.Text);
                PAItem.A1_TD_F = 0.0;
                PAItem.A3_TD_F = 1.0;

                PAItem.VD_F3B = (float)Double.Parse(textBox51.Text);
                PAItem.VD_F3N = (float)Double.Parse(textBox50.Text);
                PAItem.VD_F1B = (float)Double.Parse(textBox55.Text);
                PAItem.VD_F1N = (float)Double.Parse(textBox54.Text);
                PAItem.VD_F2B = (float)Double.Parse(textBox53.Text);
                PAItem.VD_F2N = (float)Double.Parse(textBox52.Text);
                PAItem.A2_VD_F = (float)Double.Parse(textBox31.Text);
                PAItem.A1_VD_F = 0.0;
                PAItem.A3_VD_F = 1.0;

                PAItem.P_EL_F3B = (float)Double.Parse(textBox57.Text);
                PAItem.P_EL_F3N = (float)Double.Parse(textBox56.Text);
                PAItem.P_EL_F1B = (float)Double.Parse(textBox61.Text);
                PAItem.P_EL_F1N = (float)Double.Parse(textBox60.Text);
                PAItem.P_EL_F2B = (float)Double.Parse(textBox59.Text);
                PAItem.P_EL_F2N = (float)Double.Parse(textBox58.Text);
                PAItem.A2_P_EL_F = (float)Double.Parse(textBox31.Text);
                PAItem.A1_P_EL_F = 0.0;
                PAItem.A3_P_EL_F = 1.0;
            }

            if (m_type == 7)
            {
                PAItem.K11_F3B = (float)Double.Parse(textBox76.Text);
                PAItem.K11_F3N = (float)Double.Parse(textBox75.Text);
                PAItem.K11_F1B = (float)Double.Parse(textBox80.Text);
                PAItem.K11_F1N = (float)Double.Parse(textBox79.Text);
                PAItem.K11_F2B = (float)Double.Parse(textBox78.Text);
                PAItem.K11_F2N = (float)Double.Parse(textBox77.Text);
                PAItem.A2_K11_F = (float)Double.Parse(textBox62.Text);
                PAItem.A1_K11_F = 0;
                PAItem.A3_K11_F = 1;

                PAItem.K00_F3B = (float)Double.Parse(textBox86.Text);
                PAItem.K00_F3N = (float)Double.Parse(textBox85.Text);
                PAItem.K00_F1B = (float)Double.Parse(textBox90.Text);
                PAItem.K00_F1N = (float)Double.Parse(textBox89.Text);
                PAItem.K00_F2B = (float)Double.Parse(textBox88.Text);
                PAItem.K00_F2N = (float)Double.Parse(textBox87.Text);
                PAItem.A2_K00_F = (float)Double.Parse(textBox62.Text);
                PAItem.A1_K00_F = 0.0;
                PAItem.A3_K00_F = 1.0;

                PAItem.TF_F3B = (float)Double.Parse(textBox70.Text);
                PAItem.TF_F3N = (float)Double.Parse(textBox69.Text);
                PAItem.TF_F1B = (float)Double.Parse(textBox74.Text);
                PAItem.TF_F1N = (float)Double.Parse(textBox73.Text);
                PAItem.TF_F2B = (float)Double.Parse(textBox72.Text);
                PAItem.TF_F2N = (float)Double.Parse(textBox71.Text);
                PAItem.A2_TF_F = (float)Double.Parse(textBox62.Text);
                PAItem.A1_TF_F = 0.0;
                PAItem.A3_TF_F = 1.0;

                PAItem.VF_F3B = (float)Double.Parse(textBox64.Text);
                PAItem.VF_F3N = (float)Double.Parse(textBox63.Text);
                PAItem.VF_F1B = (float)Double.Parse(textBox68.Text);
                PAItem.VF_F1N = (float)Double.Parse(textBox67.Text);
                PAItem.VF_F2B = (float)Double.Parse(textBox66.Text);
                PAItem.VF_F2N = (float)Double.Parse(textBox65.Text);
                PAItem.A2_VF_F = (float)Double.Parse(textBox62.Text);
                PAItem.A1_VF_F = 0.0;
                PAItem.A3_VF_F = 1.0;
            }
            if (m_type == 8)
                PAItem.PREDICAT = textBox93.Text;

        }
        void save_char_prop()
        {
            int m_type = TFE.TypeShape;
            if (m_type == 5)
            {
                PAItem.B = (float)Double.Parse(textBox4.Text);
                PAItem.T = (float)Double.Parse(textBox5.Text);
                PAItem.V = (float)Double.Parse(textBox6.Text);
            }
            if (m_type == 6)
            {
                PAItem.P_11 = (float)Double.Parse(textBox28.Text);
                PAItem.P_00 = (float)Double.Parse(textBox29.Text);
                PAItem.T_D = (float)Double.Parse(textBox27.Text);
                PAItem.V_D = (float)Double.Parse(textBox26.Text);
                PAItem.P_DIAGN_EL = (float)Double.Parse(textBox30.Text);
            }
            if (m_type == 7)
            {
                PAItem.K_11 = (float)Double.Parse(textBox83.Text);
                PAItem.K_00 = (float)Double.Parse(textBox84.Text);
                PAItem.T_F = (float)Double.Parse(textBox82.Text);
                PAItem.V_F = (float)Double.Parse(textBox81.Text);
            }
            if (m_type == 8)
            {
                PAItem.PREDICAT = textBox93.Text;
            }
        }
        //установка доступности редактировани¤ нечетких характеристик
        void enable_true(int type)
        {
            if (type == 5)
            {
                textBox11.Enabled = true; textBox12.Enabled = true; textBox7.Enabled = true; textBox8.Enabled = true; textBox9.Enabled = true; textBox10.Enabled = true;
                textBox14.Enabled = true; textBox13.Enabled = true; textBox18.Enabled = true; textBox17.Enabled = true; textBox16.Enabled = true; textBox15.Enabled = true;
                textBox20.Enabled = true; textBox19.Enabled = true; textBox24.Enabled = true; textBox23.Enabled = true; textBox22.Enabled = true; textBox21.Enabled = true;
                //    Edit34.Enabled=true;
                textBox4.Enabled = false; textBox5.Enabled = false; textBox6.Enabled = false;
            }
            else if (type == 6)
            {
                textBox45.Enabled = true; textBox44.Enabled = true; textBox49.Enabled = true; textBox48.Enabled = true; textBox47.Enabled = true; textBox46.Enabled = true;
                textBox39.Enabled = true; textBox38.Enabled = true; textBox43.Enabled = true; textBox44.Enabled = true; textBox41.Enabled = true; textBox40.Enabled = true;
                textBox33.Enabled = true; textBox32.Enabled = true; textBox37.Enabled = true; textBox36.Enabled = true; textBox35.Enabled = true; textBox34.Enabled = true;
                textBox51.Enabled = true; textBox50.Enabled = true; textBox55.Enabled = true; textBox54.Enabled = true; textBox53.Enabled = true; textBox52.Enabled = true;
                textBox61.Enabled = true; textBox60.Enabled = true; textBox59.Enabled = true; textBox58.Enabled = true; textBox57.Enabled = true; textBox56.Enabled = true;
                //    textBox31.Enabled=true;
                textBox28.Enabled = false; textBox29.Enabled = false; textBox27.Enabled = false; textBox26.Enabled = false; textBox30.Enabled = false;
            }
            else if (type == 7)
            {
                textBox76.Enabled = true; textBox75.Enabled = true; textBox80.Enabled = true; textBox79.Enabled = true; textBox78.Enabled = true; textBox77.Enabled = true;
                textBox86.Enabled = true; textBox85.Enabled = true; textBox90.Enabled = true; textBox89.Enabled = true; textBox88.Enabled = true; textBox87.Enabled = true;
                textBox70.Enabled = true; textBox69.Enabled = true; textBox74.Enabled = true; textBox73.Enabled = true; textBox73.Enabled = true; textBox71.Enabled = true;
                textBox64.Enabled = true; textBox63.Enabled = true; textBox68.Enabled = true; textBox67.Enabled = true; textBox66.Enabled = true; textBox65.Enabled = true;
                //    Edit35.Enabled=true;
                textBox83.Enabled = false; textBox84.Enabled = false; textBox82.Enabled = false; textBox81.Enabled = false;
            }
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
