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
    public partial class UMainFrm : Form
    {
        SectionBar menuBar;
        TPaintGrid Grid;
        int f_IdAlternative; //текущая альтернатива
        int f_NumAlternative; //текущая альтернатива номер
        int f_IdAlternativeParent; //предок текущей альтернативы
        int f_NumAlternativeParent; //нмер предка текущей альтернативы

        int f_CurrIDBlock; //текущий блок
        int f_CurrIDShape; //текущая фигура
        int f_CurrIDLine;//текущая линия
        int f_Operation;//текущая операция
        TLevelController LevelController;
        TListNode MainList;
        Color f_HaveChildColor;
        Color f_AltParamShapeColor;
        Color f_AltParamLineColor;
        bool f_AltParamShapeColorEnable;
        Graphics pbGraph;
        Rectangle rectMainShow;
        PaintEventArgs pntMainShow;
        public UMainFrm()
        {
            InitializeComponent();
            CreateSectionBar();
            /*-----------------------*/
    //        TAltSelectorItem Item;
     //       f_IsDebug = HasParam("debug");
    //        f_StepPixel = 8;
    //        f_PaintPixels = true;
    //        f_DrawFrameLine = false;
     //       f_FonColor = clWhite;
     //       f_PixelColor = clBlack;
            Grid = new TPaintGrid(pbMain.Image, this);
            f_HaveChildColor = Color.Green;
            LevelController = new TLevelController();
            MainList = new TListNode();
            f_AltParamShapeColorEnable = false;
            f_AltParamShapeColor = Color.Yellow;
            f_AltParamLineColor = Color.Fuchsia;
            MainList.OnListChange = ListChange;
            f_CurrIDBlock = 1;
            pbGraph = pbMain.CreateGraphics();
            rectMainShow = new Rectangle(0, 0, pbMain.Width, pbMain.Height);
            pntMainShow = new PaintEventArgs(pbGraph, rectMainShow);
        }
        void ListChange()
        {
            MainList.FillPainterList(Grid.g_PainterList, f_IdAlternative, f_NumAlternative, LevelController.ParentShapeID);
        }
        void SetNewPosition()
        {
            Rectangle R;
            TBaseWorkShape W;
            W = Grid.LastWorkShape;
            if (W!=null)
            {
                R = W.GetFrameRectWithLines();
                if ((R.Right + Math.Abs(Grid.OffsetSumX) - pbMain.Width - sbX.Value) > (Grid.StepPixels * 2))
                    sbX.Value = sbX.Maximum;
                if ((R.Bottom + Math.Abs(Grid.OffsetSumY) - pbMain.Height - sbY.Value) > (Grid.StepPixels * 2))
                    sbY.Value = sbY.Maximum;
            }
        }
        void ShapeCopy(TBaseShape Shape, int Num_Shape)
        {
            if (MainList.IsContainsChildShape(Shape.ID))
                Shape.PenColor = f_HaveChildColor;
            if (Shape.ParamAlt!=null)
            {
                if (f_AltParamShapeColorEnable)
                {
                    Shape.BrushStyle = new SolidBrush(Color.Black);
                    Shape.BrushColor = f_AltParamShapeColor;
                }
                else
                    Shape.BrushStyle = null;
                Shape.PenColor = f_AltParamLineColor;
            }
        }
        void SetNewPolygon()
        {
        /*    Point P;
            P = Grid.GetPointPolygon(sbX.Value, sbY.Value);
            if ((P.X - pbMain.Width - sbX.Value) > 2)
                sbX. = P.x - pbMain.Width + (Grid.StepPixels * 4);
            if ((P.y - pbMain.Height - sbY.Position) > 2)
                sbY.Max = P.y - pbMain.Height + (Grid.StepPixels * 4);*/
        }
        int GetTypShape()
        {
            return menuBar.GetActiveControlNum();
        }
        void AddWorkShape(int AType)
        {
            TBaseWorkShape WH;
            WH = Grid.AddWorkShape(AType, f_CurrIDShape, f_CurrIDBlock, f_CurrIDLine);
            WH.OnShapeCopy = ShapeCopy;
            WH.ParentShapeID = LevelController.ParentShapeID;
            f_CurrIDShape = WH.LastShapeId;
            f_CurrIDLine = WH.LastLineId;
            f_CurrIDBlock++;
            MainList.AddShapeToList(f_IdAlternative, f_NumAlternative, WH, LevelController.ParentShapeID);
            Grid.PreparePaint();
            SetNewPolygon();
            SetNewPosition();
    //        InvalidateRgn(pbMain.Parent.Handle, Grid.GetRegion(WH, 4), false);
            if (AType == 2)
            {
                WH = Grid.AddWorkShape(AType, f_CurrIDShape, f_CurrIDBlock, f_CurrIDLine);
                WH.OnShapeCopy = ShapeCopy;
                WH.ParentShapeID = LevelController.ParentShapeID;
       //         assert(WH);
                f_CurrIDShape = WH.LastShapeId;
                f_CurrIDLine = WH.LastLineId;
                f_CurrIDBlock++;
                MainList.AddShapeToList(f_IdAlternative, f_NumAlternative, WH, LevelController.ParentShapeID);
                Grid.PreparePaint();
                SetNewPolygon();
                SetNewPosition();
      //          InvalidateRgn(pbMain.Parent.Handle, Grid.GetRegion(WH, 4), false);
            }
        }
        void CreateSectionBar()
        {
            menuBar = new SectionBar(pnlButton,8,10,150,100);
            menuBar.addControlLeft();
            Section tmp = new Section("Раб. оперция", "Рабочая операция", 1);
            tmp.iniShape(21,23,18,18);
            menuBar.addSection(tmp);

            tmp = new Section("Послед. рабочая", "Последовательная рабочая операция", 2);
            tmp.iniShape(14, 23, 10, 18);
            menuBar.addSection(tmp);

            tmp = new Section("Парал. рабочая И", "Параллельная рабочая операция И", 3);
            tmp.iniShape(14, 5, 12, 12);
            menuBar.addSection(tmp);

            tmp = new Section("Парал. рабочая ИЛИ", "Параллельная рабочая операция ИЛИ", 4);
            tmp.iniShape(14, 5, 12, 12);
            menuBar.addSection(tmp);

            tmp = new Section("Контроль раб-ти", "Контроль работоспособности", 5);
            tmp.iniShape(7, 17, 12, 12);
            menuBar.addSection(tmp);

            tmp = new Section("Функ-ый контроль", "Функциональный контроль", 6);
            tmp.iniShape(7, 17, 12, 12);
            menuBar.addSection(tmp);

            tmp = new Section("Развилка", "Развилка", 7);
            tmp.iniShape(19, 5, 12, 12);
            menuBar.addSection(tmp);

            tmp = new Section("Проверка условия (к.р.)", "Последовательная рабочая операция", 8);
            tmp.iniShape(19, 5, 12, 12);
            menuBar.addSection(tmp);

            tmp = new Section("Цикл WHILE DO", "Цикл WHILE DO", 9);
            tmp.iniShape(19, 5, 12, 12);
            menuBar.addSection(tmp);

            tmp = new Section("Цикл DO WHILE DO", "Цикл DO WHILE DO", 10);
            tmp.iniShape(13, 5, 12, 9);
            menuBar.addSection(tmp);

            tmp = new Section("  Цикл DO WHILE DO    (с ФК)", "Цикл DO WHILE DO (с ФК)", 11);
            tmp.iniShape(13, 5, 12, 9);
            menuBar.addSection(tmp);

            tmp = new Section("Проверка условия", "Проверка условия", 12);
            tmp.iniShape(13, 5, 12, 9);
            menuBar.addSection(tmp);

            menuBar.addControlRight();
            menuBar.showControls(this.Width,0);
        }
        private void вероятностныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            вероятностныеToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            нечеткиеToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
        }

        private void нечеткиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            вероятностныеToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Unchecked;
            нечеткиеToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        }

        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void UMainFrm_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void новаяСтруктураToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
  /*          toolStripStatusLabel1.Text = e.X.ToString();
            toolStripStatusLabel2.Text = e.Y.ToString();
            //     paralWorkOperAnd(g, 40, 20, 1.5f);

    /*        Pen workPen = new Pen(Color.Black, 2f);
            GraphicShapes test = new GraphicShapes(pbMain, workPen);
            test.drawForNum(0,20,30,15,25);
            test.drawForNum(13, 45, 30, 15, 25);*/
            //  test.drawForNum(4);
            // test.drawForNum(5);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UMainFrm_SizeChanged(object sender, EventArgs e)
        {
            menuBar.showControls(this.Width,0);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            /*draw_panel_Paint(pntMainShow);
            draw_panel_Paint1(pntMainShow);*/
 //           pntMainShow.Graphics.DrawLine(new Pen(Color.Black, 3), 5,5,100,100);
            bool m_tfs, m_tfe;
            TAlternateItem Item;
            int typ = GetTypShape();
            if ((typ > 0) && (Grid.Regim == 0))
            {
                AddWorkShape(typ);
                menuBar.DownFalse();
            }
          /*  else
                Grid.MouseUp(Sender, Button, Shift, X, Y);*/
       /*     Item = Grid.FindAlternateItem(X, Y);
            if ((Button == mbRight) && (Item))
            {
                MenuAlternateItemCreate(Item, X, Y);
                return;
            }
            if (Button == mbRight)
            {
                MenuContextCreate(X, Y);
                return;
            }*/
        }


    /*    private void draw_panel_Paint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Black, 10), 35, 50, 500, 500);
        }
        private void draw_panel_Paint1(PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Red, 5), 35, 50, 100, 100);
        }*/
        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void ПреобразоватьВПридиктнуюМодельToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ВставитьБлокToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PbMain_Paint(object sender, PaintEventArgs e)
        {
            Grid.Paint();
        }
    }
}
