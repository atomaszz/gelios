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

        bool OPM_Inorder(object A)
        {
            TBaseShape m_A = (TBaseShape)(A);
            SharedConst.opt_sadacha.MassWork.Append((object)m_A.ID);
            return true;
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
            case SharedConst.ZAD_1: label1.Text="Ограничения";
             imageList1.Add()
                        GetBitmap(SharedConst.ZAD_1, Image1.Picture.Bitmap);
        ImageList2.GetBitmap(ZAD_1, Image2.Picture.Bitmap);
        TabbedNotebook1.PageIndex=0;
             break;
            case SharedConst.ZAD_2:label1.Text = "Ограничения";
             ImageList1.GetBitmap(SharedConst.ZAD_2, Image1.Picture.Bitmap);
        ImageList2.GetBitmap(SharedConst.ZAD_2, Image2.Picture.Bitmap);
        TabbedNotebook1.PageIndex=1;
             break;
            case SharedConst.ZAD_3:label1.Text = "Ограничения";
             ImageList1.GetBitmap(SharedConst.ZAD_3, Image1.Picture.Bitmap);
        ImageList2.GetBitmap(SharedConst.ZAD_3, Image2.Picture.Bitmap);
        TabbedNotebook1.PageIndex=2;
             break;
            case SharedConst.ZAD_4:label1.Text = "Примечания";
             ImageList1.GetBitmap(SharedConst.ZAD_4, Image1.Picture.Bitmap);
        ImageList2.GetBitmap(SharedConst.ZAD_4, Image2.Picture.Bitmap);
        TabbedNotebook1.PageIndex=3;
             break;
            case SharedConst.ZAD_5:label1.Text = "Примечания";
             ImageList1.GetBitmap(SharedConst.ZAD_5, Image1.Picture.Bitmap);
        ImageList2.GetBitmap(SharedConst.ZAD_5, Image2.Picture.Bitmap);
        TabbedNotebook1.PageIndex=4;
             break;
            case SharedConst.ZAD_6:label1.Text = "Примечания";
             ImageList1.GetBitmap(SharedConst.ZAD_6, Image1.Picture.Bitmap);
        ImageList2.GetBitmap(SharedConst.ZAD_6, Image2.Picture.Bitmap);
        TabbedNotebook1.PageIndex=5;
             break;
      }
    can_list=false;

 Image1.Refresh();
    Image2.Refresh();
        }
    }
}
