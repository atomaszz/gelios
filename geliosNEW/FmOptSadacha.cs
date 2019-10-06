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
   //     TDischargedMassiv OptSovm;
        double Rate;

        public FmOptSadacha()
        {
            InitializeComponent();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        void InitData()
        {
            TBaseWorkShape WS;
            TBaseShape TFE;
            TGlsBinaryTree BTree = new TGlsBinaryTree(OPM_CompareNode);
            for (int i = 0; i <= MassWork.Count - 1; i++)
            {
                WS = (TBaseWorkShape)(MassWork.Items[i]);
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
    }
}
