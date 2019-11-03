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
            get { return f_TFE; }
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
            this.Close();
        }

        private void FmParamAlternative_Shown(object sender, EventArgs e)
        {
            int m_type = TFE.TypeShape;
            if (m_type == 5)
                lbType.Text = "Рабочая операция";
            if (m_type == 6)
                lbType.Text = "Контроль работоспособности";
            if (m_type == 7)
                lbType.Text = "Функциональный контроль";
            if (m_type == 8)
                lbType.Text = "Проверка условия";

            if (Type_Char == SharedConst.FUZZY)
                lbTypeParam.Text = "Нечеткие характеристики";
            if (Type_Char == SharedConst.PROP)
                lbTypeParam.Text = "Вероятностные характеристики";

            lbNum.Text = ParentShapeID.ToString();

            StringInit();
            RefreshData();
        }
        void StringInit()
        {
            int m_type = TFE.TypeShape;
            sgParam.ColumnCount = 4;
            sgParam.RowCount = 1;
            sgParam.Rows[0].ReadOnly = true;

            CommonGraph.SGCells(sgParam, 0, 0, "НАЗВАНИЕ");
            CommonGraph.SGCells(sgParam, 0, 1, "ФУНКЦИЯ");
            CommonGraph.SGCells(sgParam, 0, 2, "ЭЛЕМЕНТ");
            CommonGraph.SGCells(sgParam, 0, 3, "СОСТАВ");

            if (Type_Char == SharedConst.PROP)
            {
                if (m_type == 5)
                {
                    sgParam.ColumnCount = 7;
                    CommonGraph.SGCells(sgParam, 0, 4, "B");
                    CommonGraph.SGCells(sgParam, 0, 5, "T");
                    CommonGraph.SGCells(sgParam, 0, 6, "V");
                }
                if (m_type == 6)
                {
                    sgParam.ColumnCount = 10;
                    CommonGraph.SGCells(sgParam, 0, 4, "ЭЛЕМЕНТ(диагн.)");
                    CommonGraph.SGCells(sgParam, 0, 5, "В(диагн)");
                    CommonGraph.SGCells(sgParam, 0, 6, "П_11");
                    CommonGraph.SGCells(sgParam, 0, 7, "П_00");
                    CommonGraph.SGCells(sgParam, 0, 8, "T_д");
                    CommonGraph.SGCells(sgParam, 0, 9, "V_д");
                }
                if (m_type == 7)
                {
                    sgParam.ColumnCount = 8;
                    CommonGraph.SGCells(sgParam, 0, 4, "K_11");
                    CommonGraph.SGCells(sgParam, 0, 5, "K_00");
                    CommonGraph.SGCells(sgParam, 0, 6, "T_Ф");
                    CommonGraph.SGCells(sgParam, 0, 7, "V_Ф");
                }
                if (m_type == 8)
                {
                    sgParam.ColumnCount = 5;
                    CommonGraph.SGCells(sgParam, 0, 4, "УСЛОВИЕ");
                }
            }

            else if (Type_Char == SharedConst.FUZZY)
            {
                if (m_type == 5)
                {
                    sgParam.ColumnCount = 31;
                    CommonGraph.SGCells(sgParam, 0, 4, "A1_B_F");
                    CommonGraph.SGCells(sgParam, 0, 5, "Â_F1N");
                    CommonGraph.SGCells(sgParam, 0, 6, "Â_F1B");
                    CommonGraph.SGCells(sgParam, 0, 7, "A2_Â_F");
                    CommonGraph.SGCells(sgParam, 0, 8, "Â_F2N");
                    CommonGraph.SGCells(sgParam, 0, 9, "Â_F2B");
                    CommonGraph.SGCells(sgParam, 0, 10, "A3_B_F");
                    CommonGraph.SGCells(sgParam, 0, 11, "Â_F3N");
                    CommonGraph.SGCells(sgParam, 0, 12, "Â_F3B");
                    CommonGraph.SGCells(sgParam, 0, 13, "A1_T_F");
                    CommonGraph.SGCells(sgParam, 0, 14, "T_F1N");
                    CommonGraph.SGCells(sgParam, 0, 15, "T_F1B");
                    CommonGraph.SGCells(sgParam, 0, 16, "A2_T_F");
                    CommonGraph.SGCells(sgParam, 0, 17, "T_F2N");
                    CommonGraph.SGCells(sgParam, 0, 18, "T_F2B");
                    CommonGraph.SGCells(sgParam, 0, 19, "A3_T_F");
                    CommonGraph.SGCells(sgParam, 0, 20, "T_F3N");
                    CommonGraph.SGCells(sgParam, 0, 21, "T_F3B");
                    CommonGraph.SGCells(sgParam, 0, 22, "A1_V_F");
                    CommonGraph.SGCells(sgParam, 0, 23, "V_F1N");
                    CommonGraph.SGCells(sgParam, 0, 24, "V_F1B");
                    CommonGraph.SGCells(sgParam, 0, 25, "A2_V_F");
                    CommonGraph.SGCells(sgParam, 0, 26, "V_F2N");
                    CommonGraph.SGCells(sgParam, 0, 27, "V_F2B");
                    CommonGraph.SGCells(sgParam, 0, 28, "A3_V_F");
                    CommonGraph.SGCells(sgParam, 0, 29, "V_F3N");
                    CommonGraph.SGCells(sgParam, 0, 30, "V_F3B");
                }
                if (m_type == 6)
                {
                    sgParam.ColumnCount = 49;
                    CommonGraph.SGCells(sgParam, 0, 4, "A1_P_EL_F");
                    CommonGraph.SGCells(sgParam, 0, 5, "P_EL_F1N");
                    CommonGraph.SGCells(sgParam, 0, 6, "P_EL_F1B");
                    CommonGraph.SGCells(sgParam, 0, 7, "A2_P_EL_F");
                    CommonGraph.SGCells(sgParam, 0, 8, "P_EL_F2N");
                    CommonGraph.SGCells(sgParam, 0, 9, "P_EL_F2B");
                    CommonGraph.SGCells(sgParam, 0, 10, "A3_P_EL_F");
                    CommonGraph.SGCells(sgParam, 0, 11, "P_EL_F3N");
                    CommonGraph.SGCells(sgParam, 0, 12, "P_EL_F3B");
                    CommonGraph.SGCells(sgParam, 0, 13, "A1_P11_F");
                    CommonGraph.SGCells(sgParam, 0, 14, "P11_F1N");
                    CommonGraph.SGCells(sgParam, 0, 15, "P11_F1B");
                    CommonGraph.SGCells(sgParam, 0, 16, "A2_P11_F");
                    CommonGraph.SGCells(sgParam, 0, 17, "P11_F2N");
                    CommonGraph.SGCells(sgParam, 0, 18, "P11_F2B");
                    CommonGraph.SGCells(sgParam, 0, 19, "A3_P11_F");
                    CommonGraph.SGCells(sgParam, 0, 20, "P11_F3N");
                    CommonGraph.SGCells(sgParam, 0, 21, "P11_F3B");
                    CommonGraph.SGCells(sgParam, 0, 22, "A1_P00_F");
                    CommonGraph.SGCells(sgParam, 0, 23, "P00_F1N");
                    CommonGraph.SGCells(sgParam, 0, 24, "P00_F1B");
                    CommonGraph.SGCells(sgParam, 0, 25, "A2_P00_F");
                    CommonGraph.SGCells(sgParam, 0, 26, "P00_F2N");
                    CommonGraph.SGCells(sgParam, 0, 27, "P00_F2B");
                    CommonGraph.SGCells(sgParam, 0, 28, "A3_P00_F");
                    CommonGraph.SGCells(sgParam, 0, 29, "P00_F3N");
                    CommonGraph.SGCells(sgParam, 0, 30, "P00_F3B");
                    CommonGraph.SGCells(sgParam, 0, 31, "A1_TD_F");
                    CommonGraph.SGCells(sgParam, 0, 32, "TD_F1N");
                    CommonGraph.SGCells(sgParam, 0, 33, "TD_F1B");
                    CommonGraph.SGCells(sgParam, 0, 34, "A2_TD_F");
                    CommonGraph.SGCells(sgParam, 0, 35, "TD_F2N");
                    CommonGraph.SGCells(sgParam, 0, 36, "TD_F2B");
                    CommonGraph.SGCells(sgParam, 0, 37, "A3_TD_F");
                    CommonGraph.SGCells(sgParam, 0, 38, "A3_TD_F");
                    CommonGraph.SGCells(sgParam, 0, 39, "TD_F3B");
                    CommonGraph.SGCells(sgParam, 0, 40, "A1_VD_F");
                    CommonGraph.SGCells(sgParam, 0, 41, "VD_F1N");
                    CommonGraph.SGCells(sgParam, 0, 42, "VD_F1B");
                    CommonGraph.SGCells(sgParam, 0, 43, "A2_VD_F");
                    CommonGraph.SGCells(sgParam, 0, 44, "VD_F2N");
                    CommonGraph.SGCells(sgParam, 0, 45, "VD_F2B");
                    CommonGraph.SGCells(sgParam, 0, 46, "A3_VD_F");
                    CommonGraph.SGCells(sgParam, 0, 47, "VD_F3N");
                    CommonGraph.SGCells(sgParam, 0, 48, "VD_F3B");
                }
                if (m_type == 7)
                {
                    sgParam.ColumnCount = 40;
                    CommonGraph.SGCells(sgParam, 0, 4, "A1_K11_F");
                    CommonGraph.SGCells(sgParam, 0, 5, "K11_F1N");
                    CommonGraph.SGCells(sgParam, 0, 6, "K11_F1B");
                    CommonGraph.SGCells(sgParam, 0, 7, "A2_K11_F");
                    CommonGraph.SGCells(sgParam, 0, 8, "K11_F2N");
                    CommonGraph.SGCells(sgParam, 0, 9, "K11_F2B");
                    CommonGraph.SGCells(sgParam, 0, 10, "A3_K11_F");
                    CommonGraph.SGCells(sgParam, 0, 11, "K11_F3N");
                    CommonGraph.SGCells(sgParam, 0, 12, "K11_F3B");
                    CommonGraph.SGCells(sgParam, 0, 13, "A1_K00_F");
                    CommonGraph.SGCells(sgParam, 0, 14, "K00_F1N");
                    CommonGraph.SGCells(sgParam, 0, 15, "K00_F1B");
                    CommonGraph.SGCells(sgParam, 0, 16, "A2_K00_F");
                    CommonGraph.SGCells(sgParam, 0, 17, "K00_F2N");
                    CommonGraph.SGCells(sgParam, 0, 18, "K00_F2B");
                    CommonGraph.SGCells(sgParam, 0, 19, "A3_K00_F");
                    CommonGraph.SGCells(sgParam, 0, 20, "K00_F3N");
                    CommonGraph.SGCells(sgParam, 0, 21, "K00_F3B");
                    CommonGraph.SGCells(sgParam, 0, 22, "A1_TF_F");
                    CommonGraph.SGCells(sgParam, 0, 23, "TF_F1N");
                    CommonGraph.SGCells(sgParam, 0, 24, "TF_F1B");
                    CommonGraph.SGCells(sgParam, 0, 25, "A2_TF_F");
                    CommonGraph.SGCells(sgParam, 0, 26, "TF_F2N");
                    CommonGraph.SGCells(sgParam, 0, 27, "TF_F2B");
                    CommonGraph.SGCells(sgParam, 0, 28, "A3_TF_F");
                    CommonGraph.SGCells(sgParam, 0, 29, "TF_F3N");
                    CommonGraph.SGCells(sgParam, 0, 30, "TF_F3B");
                    CommonGraph.SGCells(sgParam, 0, 31, "A1_VF_F");
                    CommonGraph.SGCells(sgParam, 0, 32, "VF_F1N");
                    CommonGraph.SGCells(sgParam, 0, 33, "VF_F1B");
                    CommonGraph.SGCells(sgParam, 0, 34, "A2_VF_F");
                    CommonGraph.SGCells(sgParam, 0, 35, "VF_F2N");
                    CommonGraph.SGCells(sgParam, 0, 36, "VF_F2B");
                    CommonGraph.SGCells(sgParam, 0, 37, "A3_VF_F");
                    CommonGraph.SGCells(sgParam, 0, 38, "VF_F3N");
                    CommonGraph.SGCells(sgParam, 0, 39, "VF_F3B");
                }
                if (m_type == 8)
                {
                    sgParam.ColumnCount = 5;
                    CommonGraph.SGCells(sgParam, 0, 4, "УСЛОВИЕ");
                }

            }
        }
        TParamAlternativeItem CreateParamAlternativeItem(string sostav, string history, string name, string func, string elem, int type, short number,
                             double b, double t, double v,
                             double k11, double k00, double tf, double vf,
                             double p11, double p00, double td, double vd,
                             string elem_diagn, double p_elem,
                             double a1_b_f, double b_f1n, double b_f1b,
                             double a2_b_f, double b_f2n, double b_f2b,
                             double a3_b_f, double b_f3n, double b_f3b,
                             double a1_t_f, double t_f1n, double t_f1b,
                             double a2_t_f, double t_f2n, double t_f2b,
                             double a3_t_f, double t_f3n, double t_f3b,
                             double a1_v_f, double v_f1n, double v_f1b,
                             double a2_v_f, double v_f2n, double v_f2b,
                             double a3_v_f, double v_f3n, double v_f3b,
                             double a1_k11_f, double k11_f1n, double k11_f1b,
                             double a2_k11_f, double k11_f2n, double k11_f2b,
                             double a3_k11_f, double k11_f3n, double k11_f3b,
                             double a1_k00_f, double k00_f1n, double k00_f1b,
                             double a2_k00_f, double k00_f2n, double k00_f2b,
                             double a3_k00_f, double k00_f3n, double k00_f3b,
                             double a1_tf_f, double tf_f1n, double tf_f1b,
                             double a2_tf_f, double tf_f2n, double tf_f2b,
                             double a3_tf_f, double tf_f3n, double tf_f3b,
                             double a1_vf_f, double vf_f1n, double vf_f1b,
                             double a2_vf_f, double vf_f2n, double vf_f2b,
                             double a3_vf_f, double vf_f3n, double vf_f3b,
                             double a1_p11_f, double p11_f1n, double p11_f1b,
                             double a2_p11_f, double p11_f2n, double p11_f2b,
                             double a3_p11_f, double p11_f3n, double p11_f3b,
                             double a1_p00_f, double p00_f1n, double p00_f1b,
                             double a2_p00_f, double p00_f2n, double p00_f2b,
                             double a3_p00_f, double p00_f3n, double p00_f3b,
                             double a1_td_f, double td_f1n, double td_f1b,
                             double a2_td_f, double td_f2n, double td_f2b,
                             double a3_td_f, double td_f3n, double td_f3b,
                             double a1_vd_f, double vd_f1n, double vd_f1b,
                             double a2_vd_f, double vd_f2n, double vd_f2b,
                             double a3_vd_f, double vd_f3n, double vd_f3b,
                             double a1_p_el_f, double p_el_f1n, double p_el_f1b,
                             double a2_p_el_f, double p_el_f2n, double p_el_f2b,
                             double a3_p_el_f, double p_el_f3n, double p_el_f3b,
                             string predicat, double sovm, double sovm0, double sovm1)
        {
            TParamAlternativeItem Item = new TParamAlternativeItem();
            Item.SOSTAV = sostav;
            Item.PRED_ISTOR = history;
            Item.NAME = name;
            Item.FUNCTION2 = func;
            Item.ELEMENT = elem;
            Item.TYPE = type;
            Item.NUMBER = number;
            Item.SOVM = sovm;
            Item.SOVM0 = sovm0;
            Item.SOVM1 = sovm0;
            Item.PREDICAT = predicat;

            switch (type)
            {
                case 5:
                    Item.B = b;
                    Item.T = t;
                    Item.V = v;

                    Item.A1_B_F = a1_b_f;
                    Item.B_F1N = b_f1n;
                    Item.B_F1B = b_f1b;
                    Item.A2_B_F = a2_b_f;
                    Item.B_F2N = b_f2n;
                    Item.B_F2B = b_f2b;
                    Item.A3_B_F = a3_b_f;
                    Item.B_F3N = b_f3n;
                    Item.B_F3B = b_f3b;

                    Item.A1_T_F = a1_t_f;
                    Item.T_F1N = t_f1n;
                    Item.T_F1B = t_f1b;
                    Item.A2_T_F = a2_t_f;
                    Item.T_F2N = t_f2n;
                    Item.T_F2B = t_f2b;
                    Item.A3_T_F = a3_t_f;
                    Item.T_F3N = t_f3n;
                    Item.T_F3B = t_f3b;

                    Item.A1_V_F = a1_v_f;
                    Item.V_F1N = v_f1n;
                    Item.V_F1B = v_f1b;
                    Item.A2_V_F = a2_v_f;
                    Item.V_F2N = v_f2n;
                    Item.V_F2B = v_f2b;
                    Item.A3_V_F = a3_v_f;
                    Item.V_F3N = v_f3n;
                    Item.V_F3B = v_f3b;
                    break;
                case 7:
                    Item.K_11 = k11;
                    Item.K_00 = k00;
                    Item.T_F = tf;
                    Item.V_F = vf;

                    Item.A1_K11_F = a1_k11_f;
                    Item.K11_F1N = k11_f1n;
                    Item.K11_F1B = k11_f1b;
                    Item.A2_K11_F = a2_k11_f;
                    Item.K11_F2N = k11_f2n;
                    Item.K11_F2B = k11_f2b;
                    Item.A3_K11_F = a3_k11_f;
                    Item.K11_F3N = k11_f3n;
                    Item.K11_F3B = k11_f3b;

                    Item.A1_K00_F = a1_k00_f;
                    Item.K00_F1N = k00_f1n;
                    Item.K00_F1B = k00_f1b;
                    Item.A2_K00_F = a2_k00_f;
                    Item.K00_F2N = k00_f2n;
                    Item.K00_F2B = k00_f2b;
                    Item.A3_K00_F = a3_k00_f;
                    Item.K00_F3N = k00_f3n;
                    Item.K00_F3B = k00_f3b;

                    Item.A1_TF_F = a1_tf_f;
                    Item.TF_F1N = tf_f1n;
                    Item.TF_F1B = tf_f1b;
                    Item.A2_TF_F = a2_tf_f;
                    Item.TF_F2N = tf_f2n;
                    Item.TF_F2B = tf_f2b;
                    Item.A3_TF_F = a3_tf_f;
                    Item.TF_F3N = tf_f3n;
                    Item.TF_F3B = tf_f3b;

                    Item.A1_VF_F = a1_vf_f;
                    Item.VF_F1N = vf_f1n;
                    Item.VF_F1B = vf_f1b;
                    Item.A2_VF_F = a2_vf_f;
                    Item.VF_F2N = vf_f2n;
                    Item.VF_F2B = vf_f2b;
                    Item.A3_VF_F = a3_vf_f;
                    Item.VF_F3N = vf_f3n;
                    Item.VF_F3B = vf_f3b;
                    break;

                case 6:
                    Item.ELEM_DIAGN = elem_diagn;

                    Item.P_11 = p11;
                    Item.P_00 = p00;
                    Item.T_D = td;
                    Item.V_D = vd;

                    Item.P_DIAGN_EL = p_elem;

                    Item.A1_P11_F = a1_p11_f;
                    Item.P11_F1N = p11_f1n;
                    Item.P11_F1B = p11_f1b;
                    Item.A2_P11_F = a2_p11_f;
                    Item.P11_F2N = p11_f2n;
                    Item.P11_F2B = p11_f2b;
                    Item.A3_P11_F = a3_p11_f;
                    Item.P11_F3N = p11_f3n;
                    Item.P11_F3B = p11_f3b;

                    Item.A1_P00_F = a1_p00_f;
                    Item.P00_F1N = p00_f1n;
                    Item.P00_F1B = p00_f1b;
                    Item.A2_P00_F = a2_p00_f;
                    Item.P00_F2N = p00_f2n;
                    Item.P00_F2B = p00_f2b;
                    Item.A3_P00_F = a3_p00_f;
                    Item.P00_F3N = p00_f3n;
                    Item.P00_F3B = p00_f3b;

                    Item.A1_TD_F = a1_td_f;
                    Item.TD_F1N = td_f1n;
                    Item.TD_F1B = td_f1b;
                    Item.A2_TD_F = a2_td_f;
                    Item.TD_F2N = td_f2n;
                    Item.TD_F2B = td_f2b;
                    Item.A3_TD_F = a3_td_f;
                    Item.TD_F3N = td_f3n;
                    Item.TD_F3B = td_f3b;

                    Item.A1_VD_F = a1_vd_f;
                    Item.VD_F1N = vd_f1n;
                    Item.VD_F1B = vd_f1b;
                    Item.A2_VD_F = a2_vd_f;
                    Item.VD_F2N = vd_f2n;
                    Item.VD_F2B = vd_f2b;
                    Item.A3_VD_F = a3_vd_f;
                    Item.VD_F3N = vd_f3n;
                    Item.VD_F3B = vd_f3b;

                    Item.A1_P_EL_F = a1_p_el_f;
                    Item.P_EL_F1N = p_el_f1n;
                    Item.P_EL_F1B = p_el_f1b;
                    Item.A2_P_EL_F = a2_p_el_f;
                    Item.P_EL_F2N = p_el_f2n;
                    Item.P_EL_F2B = p_el_f2b;
                    Item.A3_P_EL_F = a3_p_el_f;
                    Item.P_EL_F3N = p_el_f3n;
                    Item.P_EL_F3B = p_el_f3b;
                    break;

                case 8:
                    Item.PREDICAT = predicat;
                    break;
            }
            return Item;
        }
        void RefreshData()
        {
            if (Type_Char == SharedConst.PROP)
                RefreshDataPROP();
     /*       if (Type_Char == SharedConst.FUZZY)
                RefreshDataFUZZY();
            if (TFE.ParamAlt != null)
                lbCount.Text = (TFE.ParamAlt.Count).ToString();
            else
                lbCount.Text = "0";*/
        }
        void RefreshDataPROP()
        {
            TParamAlternativeItem AI;
            int m_type = TFE.TypeShape;
      //      sgParam.RowCount = 1;
     //       sgParam.RowCount = 2;
      //      sgParam.FixedRows = 1;
     //       sgParam.Rows[1].Clear();
            if (TFE.ParamAlt != null)
            {
                int m_cnt = TFE.ParamAlt.Count;
                sgParam.RowCount = m_cnt;
         /*       if (m_cnt > sgParam.RowCount)
                    sgParam.RowCount += 1;*/
                for (int i = 0; i <= m_cnt - 1; i++)
                {
                    AI = TFE.ParamAlt.Items[i];

                    //sgParam->Objects[0][1 + i] = (TObject*)AI;
                    AI.SOSTAV = (TFE.ID).ToString() + ":" + (i + 1).ToString();
                    CommonGraph.SGCellsByName(sgParam, i, "НАЗВАНИЕ", AI.NAME);
                    CommonGraph.SGCellsByName(sgParam, i, "ФУНКЦИЯ", AI.FUNCTION2);
                    CommonGraph.SGCellsByName(sgParam, i, "ЭЛЕМЕНТ", AI.ELEMENT);
                    CommonGraph.SGCellsByName(sgParam, i, "СОСТАВ", AI.SOSTAV);

                    if (m_type == 5)
                    {
                        CommonGraph.SGCellsByName(sgParam, i, "B", AI.B);
                        CommonGraph.SGCellsByName(sgParam, i, "T", AI.T);
                        CommonGraph.SGCellsByName(sgParam, i, "V", AI.V);
                    }
                    if (m_type == 6)
                    {
                        CommonGraph.SGCellsByName(sgParam, i, "ЭЛЕМЕНТ(диагн.)", AI.ELEM_DIAGN);
                        CommonGraph.SGCellsByName(sgParam, i, "В(диагн)", AI.P_DIAGN_EL);
                        CommonGraph.SGCellsByName(sgParam, i, "П_11", AI.P_11);
                        CommonGraph.SGCellsByName(sgParam, i, "П_00", AI.P_00);
                        CommonGraph.SGCellsByName(sgParam, i, "T_д", AI.T_D);
                        CommonGraph.SGCellsByName(sgParam, i, "V_д", AI.V_D);
                    }
                    if (m_type == 7)
                    {
                        CommonGraph.SGCellsByName(sgParam, i, "K_11", AI.K_11);
                        CommonGraph.SGCellsByName(sgParam, i, "K_00", AI.K_00);
                        CommonGraph.SGCellsByName(sgParam, i, "T_Ф", AI.T_F);
                        CommonGraph.SGCellsByName(sgParam, i, "V_Ф", AI.V_F);
                    }
                    if (m_type == 8)
                    {
                        CommonGraph.SGCellsByName(sgParam, i, "УСЛОВИЕ", AI.PREDICAT);
                    }
                }
                sgParam.Rows[sgParam.RowCount - 1].Selected = true;
            }
        }

        void RefreshDataFUZZY()
        {
            TParamAlternativeItem AI;
            int m_type = TFE.TypeShape;
            sgParam.RowCount = 1;
            //sgParam.RowCount = 2;
            //    sgParam.FixedRows = 1;
            //      sgParam.Rows[1].Clear();
            if (TFE.ParamAlt != null)
            {
                int m_cnt = TFE.ParamAlt.Count;
                sgParam.RowCount = m_cnt;
             /*   if (m_cnt > sgParam.RowCount)
                    sgParam.RowCount += 1;*/
                for (int i = 0; i <= m_cnt - 1; i++)
                {
                    AI = TFE.ParamAlt.Items[i];
        //            sgParam.Rows[1 + i].Cells[0].Value = (object)AI;
                    AI.SOSTAV = (TFE.ID).ToString() + ":" + (i + 1).ToString();
                    CommonGraph.SGCellsByName(sgParam, 1 + i, "НАЗВАНИЕ", AI.NAME);
                    CommonGraph.SGCellsByName(sgParam, 1 + i, "ФУНКЦИЯ", AI.FUNCTION2);
                    CommonGraph.SGCellsByName(sgParam, 1 + i, "ЭЛЕМЕНТ", AI.ELEMENT);
                    CommonGraph.SGCellsByName(sgParam, 1 + i, "СОСТАВ", AI.SOSTAV);

                    if (m_type == 5)
                    {
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_B_F", AI.A1_B_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "В_F1N", AI.B_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "В_F1B", AI.B_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_В_F", AI.A2_B_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "В_F2N", AI.B_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "В_F2B", AI.B_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_B_F", AI.A3_B_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "В_F3N", AI.B_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "В_F3B", AI.B_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_T_F", AI.A1_T_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "T_F1N", AI.T_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "T_F1B", AI.T_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_T_F", AI.A2_T_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "T_F2N", AI.T_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "T_F2B", AI.T_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_T_F", AI.A3_T_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "T_F3N", AI.T_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "T_F3B", AI.T_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_V_F", AI.A1_V_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "V_F1N", AI.V_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "V_F1B", AI.V_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_V_F", AI.A2_V_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "V_F2N", AI.V_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "V_F2B", AI.V_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_V_F", AI.A3_V_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "V_F3N", AI.V_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "V_F3B", AI.V_F3B);
                    }
                    if (m_type == 6)
                    {
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_P_EL_F", AI.A1_P_EL_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P_EL_F1N", AI.P_EL_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P_EL_F1B", AI.P_EL_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_P_EL_F", AI.A2_P_EL_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P_EL_F2N", AI.P_EL_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P_EL_F2B", AI.P_EL_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_P_EL_F", AI.A3_P_EL_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P_EL_F3N", AI.P_EL_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P_EL_F3B", AI.P_EL_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_P11_F", AI.A1_P11_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P11_F1N", AI.P11_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P11_F1B", AI.P11_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_P11_F", AI.A2_P11_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P11_F2N", AI.P11_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P11_F2B", AI.P11_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_P11_F", AI.A3_P11_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P11_F3N", AI.P11_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P11_F3B", AI.P11_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_P00_F", AI.A1_P00_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P00_F1N", AI.P00_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P00_F1B", AI.P00_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_P00_F", AI.A2_P00_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P00_F2N", AI.P00_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P00_F2B", AI.P00_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_P00_F", AI.A3_P00_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P00_F3N", AI.P00_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "P00_F3B", AI.P00_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_TD_F", AI.A1_TD_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TD_F1N", AI.TD_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TD_F1B", AI.TD_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_TD_F", AI.A2_TD_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TD_F2N", AI.TD_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TD_F2B", AI.TD_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_TD_F", AI.A3_TD_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TD_F3N", AI.TD_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TD_F3B", AI.TD_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_VD_F", AI.A1_VD_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VD_F1N", AI.VD_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VD_F1B", AI.VD_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_VD_F", AI.A2_VD_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VD_F2N", AI.VD_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VD_F2B", AI.VD_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_VD_F", AI.A3_VD_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VD_F3N", AI.VD_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VD_F3B", AI.VD_F3B);
                    }
                    if (m_type == 7)
                    {
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_K11_F", AI.A1_K11_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K11_F1N", AI.K11_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K11_F1B", AI.K11_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_K11_F", AI.A2_K11_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K11_F2N", AI.K11_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K11_F2B", AI.K11_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_K11_F", AI.A3_K11_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K11_F3N", AI.K11_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K11_F3B", AI.K11_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_K00_F", AI.A1_K00_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K00_F1N", AI.K00_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K00_F1B", AI.K00_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_K00_F", AI.A2_K00_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K00_F2N", AI.K00_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K00_F2B", AI.K00_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_K00_F", AI.A3_K00_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K00_F3N", AI.K00_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "K00_F3B", AI.K00_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_TF_F", AI.A1_TF_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TF_F1N", AI.TF_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TF_F1B", AI.TF_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_TF_F", AI.A2_TF_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TF_F2N", AI.TF_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TF_F2B", AI.TF_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_TF_F", AI.A3_TF_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TF_F3N", AI.TF_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "TF_F3B", AI.TF_F3B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A1_VF_F", AI.A1_VF_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VF_F1N", AI.VF_F1N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VF_F1B", AI.VF_F1B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A2_VF_F", AI.A2_VF_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VF_F2N", AI.VF_F2N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VF_F2B", AI.VF_F2B);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "A3_VF_F", AI.A3_VF_F);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VF_F3N", AI.VF_F3N);
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "VF_F3B", AI.VF_F3B);
                    }
                    if (m_type == 8)
                    {
                        CommonGraph.SGCellsByName(sgParam, 1 + i, "УСЛОВИЕ", AI.PREDICAT);
                    }

                }
            }
        }

        private void AcAddExecute_Click(object sender, EventArgs e)
        {
            string add_name = "", sos = "";
            int type, num;
            type = TFE.TypeShape;
            num = TFE.ID;
            if (type == 8 && TFE.ParamAlt!=null) return;



            double s_b, s_t, s_v, s_k11, s_k00, s_tf, s_vf,
                      s_p11, s_p00, s_td, s_vd,
                      s_p_el,
                      s_a1_b_f, s_b_f1n, s_b_f1b, s_a2_b_f, s_b_f2n, s_b_f2b, s_a3_b_f, s_b_f3n, s_b_f3b,
                      s_a1_t_f, s_t_f1n, s_t_f1b, s_a2_t_f, s_t_f2n, s_t_f2b, s_a3_t_f, s_t_f3n, s_t_f3b,
                      s_a1_v_f, s_v_f1n, s_v_f1b, s_a2_v_f, s_v_f2n, s_v_f2b, s_a3_v_f, s_v_f3n, s_v_f3b,
                      s_a1_k11_f, s_k11_f1n, s_k11_f1b, s_a2_k11_f, s_k11_f2n, s_k11_f2b, s_a3_k11_f, s_k11_f3n, s_k11_f3b,
                      s_a1_k00_f, s_k00_f1n, s_k00_f1b, s_a2_k00_f, s_k00_f2n, s_k00_f2b, s_a3_k00_f, s_k00_f3n, s_k00_f3b,
                      s_a1_tf_f, s_tf_f1n, s_tf_f1b, s_a2_tf_f, s_tf_f2n, s_tf_f2b, s_a3_tf_f, s_tf_f3n, s_tf_f3b,
                      s_a1_vf_f, s_vf_f1n, s_vf_f1b, s_a2_vf_f, s_vf_f2n, s_vf_f2b, s_a3_vf_f, s_vf_f3n, s_vf_f3b,
                      s_a1_p11_f, s_p11_f1n, s_p11_f1b, s_a2_p11_f, s_p11_f2n, s_p11_f2b, s_a3_p11_f, s_p11_f3n, s_p11_f3b,
                      s_a1_p00_f, s_p00_f1n, s_p00_f1b, s_a2_p00_f, s_p00_f2n, s_p00_f2b, s_a3_p00_f, s_p00_f3n, s_p00_f3b,
                      s_a1_td_f, s_td_f1n, s_td_f1b, s_a2_td_f, s_td_f2n, s_td_f2b, s_a3_td_f, s_td_f3n, s_td_f3b,
                      s_a1_vd_f, s_vd_f1n, s_vd_f1b, s_a2_vd_f, s_vd_f2n, s_vd_f2b, s_a3_vd_f, s_vd_f3n, s_vd_f3b,
                      s_a1_p_el_f, s_p_el_f1n, s_p_el_f1b, s_a2_p_el_f, s_p_el_f2n, s_p_el_f2b, s_a3_p_el_f, s_p_el_f3n, s_p_el_f3b;
            string s_name, s_el, s_func, s_e, s_predicat;


            s_name = "(нет названия)";
            s_el = "(нет элемента)";
            if (TFE.ParamAlt==null)
                s_func = "(нет функции)";
            else
                s_func = TFE.ParamAlt.Items[0].FUNCTION2;


            s_b = 1; s_t = 0; s_v = 0;
            s_k11 = 1; s_k00 = 1; s_tf = 0; s_vf = 0;

            s_p11 = 1; s_p00 = 1; s_td = 0; s_vd = 0;
            s_e = "(нет элемента)"; s_p_el = 1;
            s_a1_p_el_f = 0; s_p_el_f1n = 0; s_p_el_f1b = 0; s_a2_p_el_f = 0.5; s_p_el_f2n = 0; s_p_el_f2b = 0;
            s_a3_p_el_f = 1; s_p_el_f3n = 0; s_p_el_f3b = 0;
            s_a1_b_f = 0; s_b_f1n = 0; s_b_f1b = 0; s_a2_b_f = 0.5; s_b_f2n = 0; s_b_f2b = 0;
            s_a3_b_f = 1; s_b_f3n = 0; s_b_f3b = 0;
            s_a1_t_f = 0; s_t_f1n = 0; s_t_f1b = 0; s_a2_t_f = 0.5; s_t_f2n = 0; s_t_f2b = 0;
            s_a3_t_f = 1; s_t_f3n = 0; s_t_f3b = 0;
            s_a1_v_f = 0; s_v_f1n = 0; s_v_f1b = 0; s_a2_v_f = 0.5; s_v_f2n = 0; s_v_f2b = 0;
            s_a3_v_f = 1; s_v_f3n = 0; s_v_f3b = 0;
            s_a1_k11_f = 0; s_k11_f1n = 0; s_k11_f1b = 0; s_a2_k11_f = 0.5; s_k11_f2n = 0;
            s_k11_f2b = 0; s_a3_k11_f = 1; s_k11_f3n = 0; s_k11_f3b = 0;
            s_a1_k00_f = 0; s_k00_f1n = 0; s_k00_f1b = 0; s_a2_k00_f = 0.5; s_k00_f2n = 0;
            s_k00_f2b = 0; s_a3_k00_f = 1; s_k00_f3n = 0; s_k00_f3b = 0;
            s_a1_tf_f = 0; s_tf_f1n = 0; s_tf_f1b = 0; s_a2_tf_f = 0.5; s_tf_f2n = 0;
            s_tf_f2b = 0; s_a3_tf_f = 1; s_tf_f3n = 0; s_tf_f3b = 0;
            s_a1_vf_f = 0; s_vf_f1n = 0; s_vf_f1b = 0; s_a2_vf_f = 0.5; s_vf_f2n = 0;
            s_vf_f2b = 0; s_a3_vf_f = 1; s_vf_f3n = 0; s_vf_f3b = 0;
            s_a1_p11_f = 0; s_p11_f1n = 0; s_p11_f1b = 0; s_a2_p11_f = 0.5; s_p11_f2n = 0;
            s_p11_f2b = 0; s_a3_p11_f = 1; s_p11_f3n = 0; s_p11_f3b = 0;
            s_a1_p00_f = 0; s_p00_f1n = 0; s_p00_f1b = 0; s_a2_p00_f = 0.5; s_p00_f2n = 0;
            s_p00_f2b = 0; s_a3_p00_f = 1; s_p00_f3n = 0; s_p00_f3b = 0;
            s_a1_td_f = 0; s_td_f1n = 0; s_td_f1b = 0; s_a2_td_f = 0.5; s_td_f2n = 0;
            s_td_f2b = 0; s_a3_td_f = 1; s_td_f3n = 0; s_td_f3b = 0;
            s_a1_vd_f = 0; s_vd_f1n = 0; s_vd_f1b = 0; s_a2_vd_f = 0.5; s_vd_f2n = 0;
            s_vd_f2b = 0; s_a3_vd_f = 1; s_vd_f3n = 0; s_vd_f3b = 0;
            s_predicat = "(нет условия)";

            TParamAlternativeItem NI = CreateParamAlternativeItem(sos, add_name, s_name, s_func, s_el, type, (short)num,
                                                 s_b, s_t, s_v,
                                                 s_k11, s_k00, s_tf, s_vf,
                                                 s_p11, s_p00, s_td, s_vd,
                                                 s_e, s_p_el,
                                                 s_a1_b_f, s_b_f1n, s_b_f1b, s_a2_b_f, s_b_f2n, s_b_f2b, s_a3_b_f, s_b_f3n, s_b_f3b,
                                                 s_a1_t_f, s_t_f1n, s_t_f1b, s_a2_t_f, s_t_f2n, s_t_f2b, s_a3_t_f, s_t_f3n, s_t_f3b,
                                                 s_a1_v_f, s_v_f1n, s_v_f1b, s_a2_v_f, s_v_f2n, s_v_f2b, s_a3_v_f, s_v_f3n, s_v_f3b,
                                                 s_a1_k11_f, s_k11_f1n, s_k11_f1b, s_a2_k11_f, s_k11_f2n, s_k11_f2b, s_a3_k11_f, s_k11_f3n, s_k11_f3b,
                                                 s_a1_k00_f, s_k00_f1n, s_k00_f1b, s_a2_k00_f, s_k00_f2n, s_k00_f2b, s_a3_k00_f, s_k00_f3n, s_k00_f3b,
                                                 s_a1_tf_f, s_tf_f1n, s_tf_f1b, s_a2_tf_f, s_tf_f2n, s_tf_f2b, s_a3_tf_f, s_tf_f3n, s_tf_f3b,
                                                 s_a1_vf_f, s_vf_f1n, s_vf_f1b, s_a2_vf_f, s_vf_f2n, s_vf_f2b, s_a3_vf_f, s_vf_f3n, s_vf_f3b,
                                                 s_a1_p11_f, s_p11_f1n, s_p11_f1b, s_a2_p11_f, s_p11_f2n, s_p11_f2b, s_a3_p11_f, s_p11_f3n, s_p11_f3b,
                                                 s_a1_p00_f, s_p00_f1n, s_p00_f1b, s_a2_p00_f, s_p00_f2n, s_p00_f2b, s_a3_p00_f, s_p00_f3n, s_p00_f3b,
                                                 s_a1_td_f, s_td_f1n, s_td_f1b, s_a2_td_f, s_td_f2n, s_td_f2b, s_a3_td_f, s_td_f3n, s_td_f3b,
                                                 s_a1_vd_f, s_vd_f1n, s_vd_f1b, s_a2_vd_f, s_vd_f2n, s_vd_f2b, s_a3_vd_f, s_vd_f3n, s_vd_f3b,
                                                 s_a1_p_el_f, s_p_el_f1n, s_p_el_f1b, s_a2_p_el_f, s_p_el_f2n, s_p_el_f2b, s_a3_p_el_f, s_p_el_f3n, s_p_el_f3b,
                                                 s_predicat, 1.0, 1, 1);
            TFE.AddParamAlternativeItem(NI);
            RefreshData();
        }

    }
}
