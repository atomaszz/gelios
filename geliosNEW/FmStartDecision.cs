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
    public partial class FmStartDecision : Form
    {
        public TZadacha Zadacha;
        public int type_char;
        public int type_metod;
        public bool ModalResult;
        public FmStartDecision()
        {
            InitializeComponent();
            ModalResult = false;
        }
        public void set_sadacha_edit()
        {
            string s="";

            if (type_char == SharedConst.PROP)
            { textBox6.Text = "вероятностные"; }
            if (type_char == SharedConst.FUZZY)
            { textBox6.Text = "нечеткие"; }
            panel2.Visible = !(type_metod == SharedConst.TOHN);

            switch (SharedConst.opt_sadacha.type_sadacha)
            {
                case SharedConst.ZAD_1:
                    textBox1.Text = "B(F) -> max";
                    textBox5.Text = "    F <= Do";

                    switch (SharedConst.opt_sadacha.type_ogr)
                    {
                        case 0:
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            break;
                        case 1:
                            s = "V(F) <= Vd";
                            textBox2.Text = s;
                            textBox4.Text = "Vd=" + SharedConst.opt_sadacha.Vd;
                            textBox3.Text = "";
                            break;
                        case 2:
                            s = "T(F) <= Td";
                            textBox2.Text = "";
                            textBox3.Text = s;
                            textBox4.Text = "Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 3:
                            s = "V(F) <= Vd";
                            textBox2.Text = s;
                            s = "T(F) <= Td";
                            textBox3.Text = s;
                            textBox4.Text = "Vd=" + SharedConst.opt_sadacha.Vd + "   Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 4:
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            break;
                        case 5:
                            s = "V(F) <= Vd";
                            textBox2.Text = s;
                            textBox4.Text = "Vd=" + SharedConst.opt_sadacha.Vd;
                            textBox3.Text = "";
                            break;
                        case 6:
                            s = "T(F) <= Td";
                            textBox2.Text = "";
                            textBox3.Text = s;
                            textBox4.Text = "Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 7:
                            s = "V(F) <= Vd";
                            textBox2.Text = s;
                            s = "T(F) <= Td";
                            textBox3.Text = s;
                            textBox4.Text = "Vd=" + SharedConst.opt_sadacha.Vd + "   Td=" + SharedConst.opt_sadacha.Td;
                            break;
                    }
                    break;
                case SharedConst.ZAD_2:
                    textBox1.Text = "T(F) -> min";
                    textBox5.Text = "    F <= Do";

                    switch (SharedConst.opt_sadacha.type_ogr)
                    {
                        case 0:
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            break;
                        case 1:
                            s = "V(F) <= Vd";
                            textBox2.Text = s;
                            textBox4.Text = "Vd=" + SharedConst.opt_sadacha.Vd;
                            textBox3.Text = "";
                            break;
                        case 2:
                            s = "B(F) >= Bd";
                            textBox2.Text = "";
                            textBox3.Text = s;
                            textBox4.Text = "Bd=" + SharedConst.opt_sadacha.Bd;
                            break;
                        case 3:
                            s = "V(F) <= Vd";
                            textBox2.Text = s;
                            s = "B(F) => Bd";
                            textBox3.Text = s;
                            textBox4.Text = "Vd=" + SharedConst.opt_sadacha.Vd + "   Bd=" + SharedConst.opt_sadacha.Bd;
                            break;
                        case 4:
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            break;
                        case 5:
                            s = "V(F) <= Vd";
                            textBox2.Text = s;
                            textBox4.Text = "Vd=" + SharedConst.opt_sadacha.Vd;
                            textBox3.Text = "";
                            break;
                        case 6:
                            s = "B(F) >= Bd";
                            textBox2.Text = "";
                            textBox3.Text = s;
                            textBox4.Text = "Bd=" + SharedConst.opt_sadacha.Bd;
                            break;
                        case 7:
                            s = "V(F) <= Vd";
                            textBox2.Text = s;
                            s = "B(F) => Bd";
                            textBox3.Text = s;
                            textBox4.Text = "Vd=" + SharedConst.opt_sadacha.Vd + "   Bd=" + SharedConst.opt_sadacha.Bd;
                            break;
                    }
                    break;
                case SharedConst.ZAD_3:
                    textBox1.Text = "V(F) -> min";
                    textBox5.Text = "    F <= Do";

                    switch (SharedConst.opt_sadacha.type_ogr)
                    {
                        case 0:
                            textBox2.Text = "";
                            textBox3.Text = "";
                            break;
                        case 1:
                            s = "B(F) => Bd";
                            textBox2.Text = s;
                            textBox4.Text = "Bd=" + SharedConst.opt_sadacha.Bd;
                            textBox3.Text = "";
                            break;
                        case 2:
                            s = "T(F) <= Td";
                            textBox2.Text = "";
                            textBox3.Text = s;
                            textBox4.Text = "Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 3:
                            s = "B(F) => Bd";
                            textBox2.Text = s;
                            s = "T(F) <= Td";
                            textBox3.Text = s;
                            textBox4.Text = "Bd=" + SharedConst.opt_sadacha.Bd + "   Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 4:
                            textBox2.Text = "";
                            textBox3.Text = "";
                            break;
                        case 5:
                            s = "B(F) => Bd";
                            textBox2.Text = s;
                            textBox4.Text = "Bd=" + SharedConst.opt_sadacha.Bd;
                            textBox3.Text = "";
                            break;
                        case 6:
                            s = "T(F) <= Td";
                            textBox2.Text = "";
                            textBox3.Text = s;
                            textBox4.Text = "Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 7:
                            s = "B(F) => Bd";
                            textBox2.Text = s;
                            s = "T(F) <= Td";
                            textBox3.Text = s;
                            textBox4.Text = "Bd=" + SharedConst.opt_sadacha.Bd + "   Td=" + SharedConst.opt_sadacha.Td;
                            break;
                    }
                    break;
                case SharedConst.ZAD_4:
                    textBox1.Text = "c1*B(F) - c2*T(F) - c3*V(F) -> max";
                    textBox5.Text = "                           F <= Do";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "c1=" + SharedConst.opt_sadacha.c1 + "   c2=" + SharedConst.opt_sadacha.c2 + "   c3=" + SharedConst.opt_sadacha.c3;
                    break;
                case SharedConst.ZAD_5:
                    textBox1.Text = "c1*(B(F)-B')/(B'-B,)+c2*(T(F)-T')/(T'-T,)+c3*(V(F)-V')/(V'-V,) -> max";
                    textBox5.Text = "                                                            F <= Do";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "c1=" + SharedConst.opt_sadacha.c1 + "   c2=" + SharedConst.opt_sadacha.c2 + "   c3=" + SharedConst.opt_sadacha.c3;
                    break;
                case SharedConst.ZAD_6:
                    textBox1.Text = "B^l (F) - T^k (F) - V^m (F) -> max";
                    textBox5.Text = "                           F <= Do";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "l=" + SharedConst.opt_sadacha.c1 + "   k=" + SharedConst.opt_sadacha.c2 + "   m=" + SharedConst.opt_sadacha.c3;
                    break;
            }
            if (SharedConst.opt_sadacha.type_ogr > 3)
            { textBox7.Text = "S(F)"; }
            else
            { textBox7.Text = ""; }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double d;
            if (!Double.TryParse(edPercent.Text, out d))
            {  
                MessageBox.Show("Использован недопустимый символ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edPercent.Focus();
                return;
            }
            SharedConst.opt_sadacha.Rate = d;
            ModalResult = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }
        public string GetEdit1()
        {
            return textBox1.Text;
        }
        public string GetEdit2()
        {
            return textBox2.Text;
        }
        public string GetEdit3()
        {
            return textBox3.Text;
        }
        public string GetEdit4()
        {
            return textBox4.Text;
        }
        public string GetEdit5()
        {
            return textBox5.Text;
        }
    }
}
