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
        private List<object> sgObjects;

        public int Type_Char;
        public TParamAlternative ParamAlt;
        public Color VwColorAlt;
        public Color VwColorBadAlt;
        public Color VwColorFont;
        public FmViewDecision()
        {
            InitializeComponent();
            sgObjects = new List<object>();
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

        void StringInit()
        {
            sgAlternative.ColumnCount = 1;
            sgAlternative.RowCount = 1;
            sgAlternative.Rows[0].ReadOnly = true;

            CommonGraph.SGCells(sgAlternative, 0, 0, "СОСТАВ");
       //     sgAlternative.ColWidths[0] = 200;

            if (Type_Char == SharedConst.PROP)
            {
                sgAlternative.ColumnCount = 4;
                CommonGraph.SGCells(sgAlternative, 0, 1, "B");
                CommonGraph.SGCells(sgAlternative, 0, 2, "T");
                CommonGraph.SGCells(sgAlternative, 0, 3, "V");
            }
            else if (Type_Char == SharedConst.FUZZY)
            {
                sgAlternative.ColumnCount = 28;
                CommonGraph.SGCells(sgAlternative, 0, 1, "A1_B_F");
                CommonGraph.SGCells(sgAlternative, 0, 2, "В_F1N");
                CommonGraph.SGCells(sgAlternative, 0, 3, "В_F1B");
                CommonGraph.SGCells(sgAlternative, 0, 4, "A2_В_F");
                CommonGraph.SGCells(sgAlternative, 0, 5, "В_F2N");
                CommonGraph.SGCells(sgAlternative, 0, 6, "В_F2B");
                CommonGraph.SGCells(sgAlternative, 0, 7, "A3_B_F");
                CommonGraph.SGCells(sgAlternative, 0, 8, "В_F3N");
                CommonGraph.SGCells(sgAlternative, 0, 9, "В_F3B");
                CommonGraph.SGCells(sgAlternative, 0, 10, "A1_T_F");
                CommonGraph.SGCells(sgAlternative, 0, 11, "T_F1N");
                CommonGraph.SGCells(sgAlternative, 0, 12, "T_F1B");
                CommonGraph.SGCells(sgAlternative, 0, 13, "A2_T_F");
                CommonGraph.SGCells(sgAlternative, 0, 14, "T_F2N");
                CommonGraph.SGCells(sgAlternative, 0, 15, "T_F2B");
                CommonGraph.SGCells(sgAlternative, 0, 16, "A3_T_F");
                CommonGraph.SGCells(sgAlternative, 0, 17, "T_F3N");
                CommonGraph.SGCells(sgAlternative, 0, 18, "T_F3B");
                CommonGraph.SGCells(sgAlternative, 0, 19, "A1_V_F");
                CommonGraph.SGCells(sgAlternative, 0, 20, "V_F1N");
                CommonGraph.SGCells(sgAlternative, 0, 21, "V_F1B");
                CommonGraph.SGCells(sgAlternative, 0, 22, "A2_V_F");
                CommonGraph.SGCells(sgAlternative, 0, 23, "V_F2N");
                CommonGraph.SGCells(sgAlternative, 0, 24, "V_F2B");
                CommonGraph.SGCells(sgAlternative, 0, 25, "A3_V_F");
                CommonGraph.SGCells(sgAlternative, 0, 26, "V_F3N");
                CommonGraph.SGCells(sgAlternative, 0, 27, "V_F3B");
            }
        }

        void RefreshData()
        {
            if (Type_Char == SharedConst.PROP)
                RefreshDataPROP();
            if (Type_Char == SharedConst.FUZZY)
                RefreshDataFUZZY();
        }


        void RefreshDataPROP()
        {
            TParamAlternativeItem AI;
            sgAlternative.RowCount = 2;
            if (ParamAlt != null)
            {
                int m_cnt = ParamAlt.Count;
                for (int i = 0; i <= m_cnt - 1; i++)
                {
                    if (i + 1 > sgAlternative.RowCount - 1)
                        sgAlternative.RowCount = sgAlternative.RowCount + 1;
                    AI = ParamAlt.Items[i];

                    if (sgObjects.Count <= i + 1)
                        sgObjects.Add((object)AI);
                    else
                        sgObjects[i] = (object)AI;

                    CommonGraph.SGCellsByName(sgAlternative, i, "СОСТАВ", AI.SOSTAV);
                    CommonGraph.SGCellsByName(sgAlternative, i, "B", AI.B);
                    CommonGraph.SGCellsByName(sgAlternative, i, "T", AI.T);
                    CommonGraph.SGCellsByName(sgAlternative, i, "V", AI.V);
                }
            }
        }

        void RefreshDataFUZZY()
        {
            TParamAlternativeItem AI;
            sgAlternative.RowCount = 2;
            if (ParamAlt != null)
            {
                int m_cnt = ParamAlt.Count;
                for (int i = 0; i <= m_cnt - 1; i++)
                {
                    if (i + 1 > sgAlternative.RowCount - 1)
                        sgAlternative.RowCount = sgAlternative.RowCount + 1;
                    AI = ParamAlt.Items[i];

                    if (sgObjects.Count <= i + 1)
                        sgObjects.Add((object)AI);
                    else
                        sgObjects[i] = (object)AI;

                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "СОСТАВ", AI.SOSTAV);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A1_B_F", AI.A1_B_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "В_F1N", AI.B_F1N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "В_F1B", AI.B_F1B);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A2_В_F", AI.A2_B_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "В_F2N", AI.B_F2N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "В_F2B", AI.B_F2B);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A3_B_F", AI.A3_B_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "В_F3N", AI.B_F3N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "В_F3B", AI.B_F3B);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A1_T_F", AI.A1_T_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "T_F1N", AI.T_F1N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "T_F1B", AI.T_F1B);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A2_T_F", AI.A2_T_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "T_F2N", AI.T_F2N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "T_F2B", AI.T_F2B);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A3_T_F", AI.A3_T_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "T_F3N", AI.T_F3N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "T_F3B", AI.T_F3B);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A1_V_F", AI.A1_V_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "V_F1N", AI.V_F1N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "V_F1B", AI.V_F1B);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A2_V_F", AI.A2_V_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "V_F2N", AI.V_F2N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "V_F2B", AI.V_F2B);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "A3_V_F", AI.A3_V_F);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "V_F3N", AI.V_F3N);
                    CommonGraph.SGCellsByName(sgAlternative, 1 + i, "V_F3B", AI.V_F3B);
                }
            }
        }

        private void FmViewDecision_Shown(object sender, EventArgs e)
        {
            StringInit();
            RefreshData();
        }
    }
}
