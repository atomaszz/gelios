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
        public FmStartDecision()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void set_sadacha_edit()
        {
            string s;

            if (type_char == SharedConst.PROP)
            { label9.Text = "вероятностные"; }
            if (type_char == SharedConst.FUZZY)
            { label9.Text = "нечеткие"; }
            pnPribl.Visible = !(type_metod == SharedConst.TOHN);

            switch (SharedConst.opt_sadacha.type_sadacha)
            {
                case SharedConst.ZAD_1:
                    label1.Text = "B(F) . max";
                    label5.Text = "    F <= Do";

                    switch (SharedConst.opt_sadacha.type_ogr)
                    {
                        case 0:
                            label4.Text = "";
                            label6.Text = "";
                            label10.Text = "";
                            break;
                        case 1:
                            s = "V(F) <= Vd";
                            label4.Text = s;
                            label10.Text = "Vd=" + SharedConst.opt_sadacha.Vd;
                            label6.Text = "";
                            break;
                        case 2:
                            s = "T(F) <= Td";
                            label4.Text = "";
                            label6.Text = s;
                            label10.Text = "Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 3:
                            s = "V(F) <= Vd";
                            label4.Text = s;
                            s = "T(F) <= Td";
                            label6.Text = s;
                            label10.Text = "Vd=" + SharedConst.opt_sadacha.Vd + "   Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 4:
                            label4.Text = "";
                            label6.Text = "";
                            label10.Text = "";
                            break;
                        case 5:
                            s = "V(F) <= Vd";
                            label4.Text = s;
                            label10.Text = "Vd=" + SharedConst.opt_sadacha.Vd;
                            label6.Text = "";
                            break;
                        case 6:
                            s = "T(F) <= Td";
                            label4.Text = "";
                            label6.Text = s;
                            label10.Text = "Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 7:
                            s = "V(F) <= Vd";
                            label4.Text = s;
                            s = "T(F) <= Td";
                            label6.Text = s;
                            label10.Text = "Vd=" + SharedConst.opt_sadacha.Vd + "   Td=" + SharedConst.opt_sadacha.Td;
                            break;
                    }
                    break;
                case SharedConst.ZAD_2:
                    label1.Text = "T(F) . min";
                    label5.Text = "    F <= Do";

                    switch (SharedConst.opt_sadacha.type_ogr)
                    {
                        case 0:
                            label4.Text = "";
                            label6.Text = "";
                            label10.Text = "";
                            break;
                        case 1:
                            s = "V(F) <= Vd";
                            label4.Text = s;
                            label10.Text = "Vd=" + SharedConst.opt_sadacha.Vd;
                            label6.Text = "";
                            break;
                        case 2:
                            s = "B(F) >= Bd";
                            label4.Text = "";
                            label6.Text = s;
                            label10.Text = "Bd=" + SharedConst.opt_sadacha.Bd;
                            break;
                        case 3:
                            s = "V(F) <= Vd";
                            label4.Text = s;
                            s = "B(F) => Bd";
                            label6.Text = s;
                            label10.Text = "Vd=" + SharedConst.opt_sadacha.Vd + "   Bd=" + SharedConst.opt_sadacha.Bd;
                            break;
                        case 4:
                            label4.Text = "";
                            label6.Text = "";
                            label10.Text = "";
                            break;
                        case 5:
                            s = "V(F) <= Vd";
                            label4.Text = s;
                            label10.Text = "Vd=" + SharedConst.opt_sadacha.Vd;
                            label6.Text = "";
                            break;
                        case 6:
                            s = "B(F) >= Bd";
                            label4.Text = "";
                            label6.Text = s;
                            label10.Text = "Bd=" + SharedConst.opt_sadacha.Bd;
                            break;
                        case 7:
                            s = "V(F) <= Vd";
                            label4.Text = s;
                            s = "B(F) => Bd";
                            label6.Text = s;
                            label10.Text = "Vd=" + SharedConst.opt_sadacha.Vd + "   Bd=" + SharedConst.opt_sadacha.Bd;
                            break;
                    }
                    break;
                case SharedConst.ZAD_3:
                    label1.Text = "V(F) . min";
                    label5.Text = "    F <= Do";

                    switch (SharedConst.opt_sadacha.type_ogr)
                    {
                        case 0:
                            label4.Text = "";
                            label6.Text = "";
                            break;
                        case 1:
                            s = "B(F) => Bd";
                            label4.Text = s;
                            label10.Text = "Bd=" + SharedConst.opt_sadacha.Bd;
                            label6.Text = "";
                            break;
                        case 2:
                            s = "T(F) <= Td";
                            label4.Text = "";
                            label6.Text = s;
                            label10.Text = "Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 3:
                            s = "B(F) => Bd";
                            label4.Text = s;
                            s = "T(F) <= Td";
                            label6.Text = s;
                            label10.Text = "Bd=" + SharedConst.opt_sadacha.Bd + "   Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 4:
                            label4.Text = "";
                            label6.Text = "";
                            break;
                        case 5:
                            s = "B(F) => Bd";
                            label4.Text = s;
                            label10.Text = "Bd=" + SharedConst.opt_sadacha.Bd;
                            label6.Text = "";
                            break;
                        case 6:
                            s = "T(F) <= Td";
                            label4.Text = "";
                            label6.Text = s;
                            label10.Text = "Td=" + SharedConst.opt_sadacha.Td;
                            break;
                        case 7:
                            s = "B(F) => Bd";
                            label4.Text = s;
                            s = "T(F) <= Td";
                            label6.Text = s;
                            label10.Text = "Bd=" + SharedConst.opt_sadacha.Bd + "   Td=" + SharedConst.opt_sadacha.Td;
                            break;
                    }
                    break;
                case SharedConst.ZAD_4:
                    label1.Text = "c1*B(F) - c2*T(F) - c3*V(F) . max";
                    label5.Text = "                           F <= Do";
                    label4.Text = "";
                    label6.Text = "";
                    label10.Text = "c1=" + SharedConst.opt_sadacha.c1 + "   c2=" + SharedConst.opt_sadacha.c2 + "   c3=" + SharedConst.opt_sadacha.c3;
                    break;
                case SharedConst.ZAD_5:
                    label1.Text = "c1*(B(F)-B')/(B'-B,)+c2*(T(F)-T')/(T'-T,)+c3*(V(F)-V')/(V'-V,).max";
                    label5.Text = "                                                            F <= Do";
                    label4.Text = "";
                    label6.Text = "";
                    label10.Text = "c1=" + SharedConst.opt_sadacha.c1 + "   c2=" + SharedConst.opt_sadacha.c2 + "   c3=" + SharedConst.opt_sadacha.c3;
                    break;
                case SharedConst.ZAD_6:
                    label1.Text = "B^l (F) - T^k (F) - V^m (F) . max";
                    label5.Text = "                           F <= Do";
                    label4.Text = "";
                    label6.Text = "";
                    label10.Text = "l=" + SharedConst.opt_sadacha.c1 + "   k=" + SharedConst.opt_sadacha.c2 + "   m=" + SharedConst.opt_sadacha.c3;
                    break;
            }
            if (SharedConst.opt_sadacha.type_ogr > 3)
            { label7.Text = "S(F)"; }
            else
            { label7.Text = ""; }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            double d = 0;
            if (Double.TryParse(edPercent.Text, out d))
            {
                MessageBox.Show("Использован недопустимый символ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                edPercent.Focus();
                return;
            }
            SharedConst.opt_sadacha.Rate = d;
         //   ModalResult = mrOk;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
         //   CreateTrackShow(Zadacha, Zadacha.Track());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Zadacha.Ozenk_TFE();
        }
    }
}
