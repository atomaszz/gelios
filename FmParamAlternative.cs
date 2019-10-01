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
        //    RefreshData();
        }
        void StringInit()
        {
            int m_type = TFE.TypeShape;
            sgParam.ColumnCount = 4;
            sgParam.RowCount = 2;
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

    }
}
