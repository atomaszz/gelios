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
    public partial class FrmMain : Form
    {
        SectionBar menuBar;
        TPaintGrid Grid;
        int f_StepPixel;
        bool f_PaintPixels;
        bool f_DrawFrameLine;
        Color f_FonColor;
        Color f_PixelColor;
        Color f_FrameLineColor;
        Color f_LineColor;
        int f_WSPenWidth;
        int X_Base, Y_Base;
        int X_Ofs, Y_Ofs;
        int __idls;
        int f_FlagType;
        bool f_BrushTFE;
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
        Color f_BrushColor;
        Color f_ColorLeave;
        Color f_ColorEnter;
        Color f_FrameColorTFE;
        Color f_FrameColorTFS;
        Color f_AltFlagColor;
        Color f_AltEnterFlagColor;
        Color f_AltArrowColor;
        Color f_AltEnterArrowColor;
        Color f_AltLineColor;
        Color f_AltEnabledFlagColor;
        bool f_AltParamShapeColorEnable;
        bool f_CanModifyPenWidth;
        TColorSetup f_ColorSetup;
        /*     Graphics pbGraph;
                Rectangle rectMainShow;
                 PaintEventArgs pntMainShow;*/
        public Bitmap pbMainBitMap;
        public Graphics pbMainGrph;
        /*-------------------*/
        bool boolDraw;
        Bitmap bmp;
        Graphics g;
        SolidBrush redBrush;

        bool f_IsDebug;
        int f_TypeParam;
        bool f_CheckNud;
        TAlternateController f_AlternateController;
        TAltSelector f_AltSelector;
        TAltStackController f_AltStackController;

        void InitHelp()
        {
       //     fmHelp = null;
        }
        void InitPieModule()
        {
   /*         string S = "Îøèáêà çàãðóçêè ìîäóëÿ ÏÐÎËÎÃ ñèñòåìû!\r\n";
            S = S + "Áåç äàííîé ôóíêöèè óñëîâèÿ ïðåäèêàòîâ ÒÔÅ â çàäà÷àõ îïòèìèçàöèè áóäóò èãíîðèðîâàòüñÿ!";
            gPieModule = new TPieModule;
            if (!gPieModule.CheckModule())
                MessageBox(0, S.c_str(), "Ïðåäóïðåæäåíèå", MB_ICONWARNING);*/
        }
        public FrmMain()
        {
            InitializeComponent();
            CreateSectionBar();
            /*-----------------------*/
            TAltSelectorItem Item;
            f_IsDebug = false; //HasParam("debug");
            f_StepPixel = 8;
            f_PaintPixels = true;
            f_DrawFrameLine = false;
            f_FonColor = Color.White;
            f_PixelColor = Color.Black;
            pbMainBitMap = new Bitmap(pbMain.Width, pbMain.Height);
            pbMainGrph = Graphics.FromImage(pbMainBitMap);
            /*-----------------------------*/
            bmp = new Bitmap(pbMain.Width, pbMain.Height);
            pbMain.BackgroundImage = bmp;
            g = Graphics.FromImage(bmp);
            redBrush = new SolidBrush(Color.Red);
            /*----------------------------*/
            Grid = new TPaintGrid(this);
            Grid.LEControl = true;
            Grid.WndHandler = this.Handle;
            Grid.UnderControl = pbMain;
            CreateSectionBar();
            MainList = new TListNode();
            MainList.OnListChange = ListChange;
            LevelController = new TLevelController();
            LevelController.Push(0);
            f_IdAlternative = 0;
            f_CurrIDBlock = 1;
            f_CurrIDShape = 0;
            f_CurrIDLine = 0;
            f_WSPenWidth = 1;
            f_FrameLineColor = Color.Black;
            sbY.Maximum = 0;
            sbX.Maximum = 0;
            X_Base = Y_Base = X_Ofs = Y_Ofs = 0;
            f_LineColor = Color.Black;
            f_BrushTFE = false;
            f_BrushColor = Color.White;
       //     f_FontTFE = new Graphics::TFont;
            f_FlagType = 1;
            f_ColorLeave = Color.Red;
            f_ColorEnter = Color.Yellow;
            __idls = 0;
            f_FrameColorTFE = Color.Red;
            f_FrameColorTFS = Color.Red;
            f_HaveChildColor = Color.Green;
            f_AltFlagColor = Color.Blue;
            f_AltEnterFlagColor = Color.Aqua;
            f_AltArrowColor = Color.Blue;
            f_AltEnterArrowColor = Color.Aqua;
            f_AltLineColor = Color.Blue;
            f_AltEnabledFlagColor = Color.Silver;
            f_Operation = 0;
            f_TypeParam = SharedConst.PROP;
            f_CanModifyPenWidth = false;
            f_AltParamLineColor = Color.Fuchsia;
            f_AltParamShapeColor = Color.Yellow;
            f_AltParamShapeColorEnable = false;
            f_CheckNud = false;
            f_AlternateController = new TAlternateController(Handle);
            f_AlternateController.OnListChange = AlternateListChange;
            f_AlternateController.LEControl = true;
            f_AlternateController.WndHandler = this.Handle;
            f_AlternateController.UnderControl = pbMain;
            f_AltSelector = new TAltSelector();
            f_AltStackController = new TAltStackController();
         //   f_MenuController = new TMenuController;
         //   f_ContextMenuController = new TMenuController;
            Item = f_AltSelector.CreateNewAlternateID(LevelController.ParentShapeID);
            f_IdAlternative = Item.ID;
            f_NumAlternative = f_AltSelector.AddAltItem(f_IdAlternative);
            f_IdAlternativeParent = f_IdAlternative;
            f_NumAlternativeParent = f_NumAlternative;
            MainList.CreateAlternate(null, null, f_IdAlternative, f_NumAlternative);
            f_AltStackController.Push(f_IdAlternative, f_NumAlternative,
               f_IdAlternativeParent, f_NumAlternativeParent);
            f_ColorSetup = new TColorSetup();
      /*      f_RSettings = new TGlsRegistry();
            GMess = new TMessangers();
            f_AV = new TAlternateView;
            f_StackHistory = new TDynamicArray();
            f_ActList = new TGlsActionList;
            InitActionList();
            f_RSettings.Path = "\\Software\\TFEGraph\\GLS";
            RestoreSettings();
            GMess.RegistrMessage(1, ContainsChildShape);
            GMess.RegistrMessage(2, SaveHideBar);
            GMess.RegistrMessage(3, CompareWS);
            GMess.RegistrMessage(4, GLBCheckUsedPath);
            GMess.RegistrMessage(5, GLBShowPredicateModel);
            GMess.RegistrMessage(6, GLBFindTFS);
            GMess.RegistrMessage(7, GLBApplySettingsForOutherGrid);*/
            InitHelp();
            InitPieModule();
            /*     f_Zadacha = new TZadacha;
                 f_ClipCopyTFS = new TClipCopyTFS(Handle, 0x8000000);
                 f_PredicatePath = new TPredicatePath;
                 f_PredicateDopPrav = new AnsiString;
                 ApplySettings();
                 randomize();*/

            //      pbGraph = pbMain.CreateGraphics();
            /*       rectMainShow = new Rectangle(0, 0, pbMain.Width, pbMain.Height);
                   pntMainShow = new PaintEventArgs(pbGraph, rectMainShow);*/
            SharedConst.opt_sadacha = new FmOptSadacha();
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
            Point P;
            P = Grid.GetPointPolygon(sbX.Value, sbY.Value);
    /*        if ((P.X - pbMain.Width - sbX.Value) > 2)
                sbX.Value = P.X - pbMain.Width + (Grid.StepPixels * 4);
            if ((P.Y - pbMain.Height - sbY.Value) > 2)
                sbY.Maximum = P.Y - pbMain.Height + (Grid.StepPixels * 4);*/
        }
        int GetTypShape()
        {
            return menuBar.GetActiveControlNum();
        }
        void AlternateListChange()
        {
            f_AlternateController.FillAlternateList(Grid.g_AlternateList,
            LevelController.ParentShapeID, f_IdAlternative, f_NumAlternative);
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
                pbMain.Invalidate();
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

            /*        // Объявляем объект "g" класса Graphics и предоставляем
                    // ему возможность рисования на pictureBox1:
                    Graphics g = pbMain.CreateGraphics();
                    g.Clear(Color.Turquoise);
                    // Создаем объекты-кисти для закрашивания фигур
                    SolidBrush myCorp = new SolidBrush(Color.DarkMagenta);
                    SolidBrush myTrum = new SolidBrush(Color.DarkOrchid);
                    SolidBrush myTrub = new SolidBrush(Color.DeepPink);
                    SolidBrush mySeа = new SolidBrush(Color.Blue);
                    //Выбираем перо myPen желтого цвета толщиной в 2 пикселя:
                    Pen myWind = new Pen(Color.Yellow, 2);
                    // Закрашиваем фигуры
                    g.FillRectangle(myTrub, 300, 125, 75, 75); // 1 труба (прямоугольник)
                    g.FillRectangle(myTrub, 480, 125, 75, 75); // 2 труба (прямоугольник)
                    g.FillPolygon(myCorp, new Point[]      // корпус (трапеция)
                      {
            new Point(100,300),new Point(700,300),
            new Point(700,300),new Point(600,400),
            new Point(600,400),new Point(200,400),
            new Point(200,400),new Point(100,300)
                      }
                    );
                    g.FillRectangle(myTrum, 250, 200, 350, 100); // палуба (прямоугольник)
                                                                 // Море - 12 секторов-полуокружностей
                    int x = 50;
                    int Radius = 50;
                    while (x <= pbMain.Width - Radius)
                    {
                        g.FillPie(mySeа, 0 + x, 375, 50, 50, 0, -180);
                        x += 50;
                    }
                    // Иллюминаторы 
                    for (int y = 300; y <= 550; y += 50)
                    {
                        g.DrawEllipse(myWind, y, 240, 20, 20); // 6 окружностей
                    }*/



            /*     Graphics g;    //  графический объект — некий холст
                 Bitmap buf;  //  буфер для Bitmap-изображения
                 buf = new Bitmap(pbMain.Width, pbMain.Height);  // с размерами
                 g = Graphics.FromImage(buf);   // инициализация g
                 g.DrawRectangle(new Pen(Color.Black, 2), 20, 20, 80, 50);*/

                     toolStripStatusLabel1.Text = e.X.ToString();
                      toolStripStatusLabel2.Text = e.Y.ToString();
                      //     paralWorkOperAnd(g, 40, 20, 1.5f);

            /*     Pen workPen = new Pen(Color.Black, 2f);
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
            redBrush = new SolidBrush(Color.Green);
            pbMain.Invalidate();
            /*    Pen workPen = new Pen(Color.Black, 2f);
                bmp = new Bitmap(pbMain.Width, pbMain.Height);
                workGrph = Graphics.FromImage(bmp);
                workGrph.DrawEllipse(workPen, 10, 10, 100, 100);
                pbMain.Image = bmp;*/


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
        public void SetPanelActiveVisible(bool value)
        {
            panelActiveMenu.Visible = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void ПреобразоватьВПридиктнуюМодельToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PbMain_MouseDown(object sender, MouseEventArgs e)
        {
            Grid.MouseDown(sender, e, ModifierKeys);
            //Keys.Control
            //Keys.Shift


      /*      if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                MessageBox.Show("Control key was held down.");
            }*/
        }
        private void ВставитьБлокToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PbMain_Paint(object sender, PaintEventArgs e)
        {
            Grid.UpdateGraphics(e.Graphics);
            Grid.Paint();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TBaseWorkShape Sel = Grid.FindShapeFromCompositeWork(Grid.SelectedTFE.ID);
                      if (Sel != null)
                      {
                          if (Sel.CompositeWorkShape != null)
                          {
                              TCompositeBaseWork F = new TCompositeBaseWork();
                              Grid.FindComositeBaseWork2(Grid.SelectedTFE.ID, ref F);
                              Sel = F.ConvertedBWS;
                          }
                          TBaseWorkShape WN = Grid.CreateTempWorkShape(Sel.TypeShape, new Point(0, 0), Sel.FirstShapeId - 1);

                          DrawObject imageTfe = new DrawObject ();
                          //     fmParamAlternative.pbTfs.BackgroundImage = Glbmp;
                          BuildGlp(WN, imageTfe , Grid.SelectedTFE);
                          ShowParamAlternative(Grid.SelectedTFE, LevelController.ParentShapeID, f_TypeParam, imageTfe, false);
            }
        }

        private void ЗадачаОптимизацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainList.GetAllWorkShape(SharedConst.opt_sadacha.MassWork);
            SharedConst.opt_sadacha.InitData();
            SharedConst.opt_sadacha.ShowDialog();
        }

        private void найтиРешениеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void МетодОптимизацииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void BuildGlp(TBaseWorkShape AWN, DrawObject Glp, TBaseShape ASel)
        {
            TBaseShape BS;
            FmParamAlternative fmParamAlternative = new FmParamAlternative();
            Glp.SetBitMap(fmParamAlternative.pbTfs.Width, fmParamAlternative.pbTfs.Height);

            //            Glp->Canvas->Brush->Color = f_FonColor;
            //          Glp->Canvas->FillRect(TRect(0, 0, Glp->Width, Glp->Height));
            AWN.StartPoint = new Point(0, 0);
            AWN.Init();
            AWN.Prepare();
         /*   if (f_BrushTFE)
                AWN->BrushStyle = bsSolid;
            else
                AWN->BrushStyle = bsClear;*/
            AWN.BrushColor = f_BrushColor;
            AWN.LineWidth = f_WSPenWidth;
            AWN.PenWidth = f_WSPenWidth;
       //     AWN.Font->Assign(f_FontTFE);
            AWN.FrameColorTFE = f_FrameColorTFE;
            AWN.PenColor = f_LineColor;

            Rectangle R = AWN.GetFrameRectWithLines();
            int rx = (Glp.bmp.Width - R.Width) / 2 - R.Left;
            int ry = (Glp.bmp.Height - R.Height) / 2 - R.Top;
            AWN.SetOffsetPosition(rx, ry);
            AWN.StartPoint = new Point(rx, ry);

            if (ASel.Clon!=null)
                BS = ASel.Clon;
            else
                BS = ASel;

            BS = AWN.ShapeSupportID(BS.ID);
            if (BS!=null)
                BS.DrawFrame = true;

            AWN.Prepare();
            AWN.Paint(Glp.gr);
        }
        void ShowParamAlternative(TBaseShape ATFE, int AParentID, int AType_Char,
  DrawObject AGlp, bool AReadOnly)
        {
            //    Application.CreateForm(__classid(TfmParamAlternative), &fmParamAlternative);
            FmParamAlternative fmParamAlternative = new FmParamAlternative();
            if (ATFE.Clon!=null)
                fmParamAlternative.TFE = ATFE.Clon;
            else
                fmParamAlternative.TFE = ATFE;
            fmParamAlternative.Type_Char = AType_Char;
            fmParamAlternative.ParentShapeID = AParentID;
            fmParamAlternative.Glp = AGlp.gr;
            fmParamAlternative.FReadOnly = AReadOnly;
            //      fmParamAlternative.acAdd.Enabled = !AReadOnly;
            //        fmParamAlternative.acDel.Enabled = !AReadOnly;
            fmParamAlternative.pbTfs.Image = AGlp.bmp;
            fmParamAlternative.ShowDialog();
     //       fmParamAlternative.Release();
        }
    }
}
