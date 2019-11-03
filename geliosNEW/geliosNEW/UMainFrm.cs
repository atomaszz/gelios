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
        //    SectionBar menuBar;

        //Ported//
        int f_IdAlternative; //текущая альтернатива
        int f_NumAlternative; //текущая альтернатива номер
        int f_IdAlternativeParent; //предок текущей альтернативы
        int f_NumAlternativeParent; //номер предка текущей альтернативы

        int f_CurrIDBlock; //текущий блок
        int f_CurrIDShape; //текущая фигура
        int f_CurrIDLine;//текущаяя линия
        int f_Operation;//текущая операция
        TPaintGrid Grid;
        TGLSSectionBar SectionBar;
        TLevelController LevelController;
        TListNode MainList;
  //      delegate void TShapeCopy(TBaseShape a, int b);
        public UMainFrm()
        {
            InitializeComponent();
       //     CreateSectionBar();
        }
    /*    void CreateSectionBar()
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
        }*/
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
            toolStripStatusLabel1.Text = e.X.ToString();
            toolStripStatusLabel2.Text = e.Y.ToString();
            //     paralWorkOperAnd(g, 40, 20, 1.5f);

            Pen workPen = new Pen(Color.Black, 2f);
            GraphicShapes test = new GraphicShapes(pictureBox1, workPen);
            test.drawForNum(0,20,30,15,25);
            test.drawForNum(13, 45, 30, 15, 25);
            //  test.drawForNum(4);
            // test.drawForNum(5);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UMainFrm_SizeChanged(object sender, EventArgs e)
        {
     //       menuBar.showControls(this.Width,0);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //Ported//
 /*           TAlternateItem Item;
            int typ = 1; //GetTypShape();
            if ((typ > 0) && (Grid.Regim == 0))
            {
                AddWorkShape(typ);
                SectionBar.DownFalse();
            }
            else
                Grid.MouseUp(sender, e);
            Item = Grid.FindAlternateItem(e.X, e.Y);
            if ((e.Button == MouseButtons.Right) && (Item!=null))
            {
                MenuAlternateItemCreate(Item, e.X, e.Y);
                return;
            }
        /*    if (Button == mbRight)
            {
                MenuContextCreate(X, Y); ЗАПИЛИТЬ МЕНЮ
                return;
            }*/

        }
        void ShapeCopy(TBaseShape Shape, int Num_Shape)
        {
          /*  if (MainList->IsContainsChildShape(Shape->ID) )
                Shape->PenColor = f_HaveChildColor;
            if (Shape->ParamAlt)
            {
                if (f_AltParamShapeColorEnable)
                {
                    Shape->BrushStyle = bsSolid;
                    Shape->BrushColor = f_AltParamShapeColor;
                }
                else
                    Shape->BrushStyle = bsClear;
                Shape->PenColor = f_AltParamLineColor;
            }*/
        }
        void AddWorkShape(int AType)
        {
 /*           TBaseWorkShape WH;
            WH = Grid.AddWorkShape(AType, f_CurrIDShape, f_CurrIDBlock, f_CurrIDLine);
            WH.OnShapeCopy = ShapeCopy;
            WH.ParentShapeID = LevelController.ParentShapeID;
            /*   assert(WH);*/
 /*           f_CurrIDShape = WH.F_LastShapeId;
            f_CurrIDLine = WH.F_LastLineId;
            f_CurrIDBlock++;
            MainList.AddShapeToList(f_IdAlternative, f_NumAlternative, WH, LevelController.ParentShapeID);
            Grid.PreparePaint();
            SetNewPolygon();
            SetNewPosition();
            InvalidateRgn(pbMain->Parent->Handle, Grid->GetRegion(WH, 4), false);

            if (AType == 2)
            {
                Application->ProcessMessages();
                WH = Grid->AddWorkShape(AType, f_CurrIDShape, f_CurrIDBlock, f_CurrIDLine);
                WH->OnShapeCopy = &ShapeCopy;
                WH->ParentShapeID = LevelController->ParentShapeID;
                assert(WH);
                f_CurrIDShape = WH->LastShapeId;
                f_CurrIDLine = WH->LastLineId;
                f_CurrIDBlock++;
                MainList->AddShapeToList(f_IdAlternative, f_NumAlternative, WH, LevelController->ParentShapeID);
                Grid->PreparePaint();
                SetNewPolygon();
                SetNewPosition();
                InvalidateRgn(pbMain->Parent->Handle, Grid->GetRegion(WH, 4), false);
            }*/
        }
        void MenuAlternateItemCreate(TAlternateItem AItem, int AX, int AY)
        {
        /*    int m_num;
            TPoint P;
            TMenuItem* NewItem;
            f_MenuController->Clear();
            for (int i = 0; i <= AItem->ArrowWorkShape->CountNodeHint - 1; i++)
            {
                m_num = AItem->ArrowWorkShape->NodeHind[i];
                NewItem = new TMenuItem(this);
                if (NewItem)
                {
                    NewItem->Tag = m_num;
                    //         NewItem->Action = acAltShow;
                    NewItem->OnClick = AltShow;
                    NewItem->Caption = "Àëüòåðíàòèâà ¹" + IntToStr(m_num);
                    PmAlternate->Items->Add(NewItem);
                    f_MenuController->AddMenu(NewItem);
                }
            }
            P = pbMain->ClientToScreen(TPoint(AX, AY));
            PmAlternate->Popup(P.x, P.y);


            /*
              TMenuItem *NewItem = new TMenuItem(this);
              if (NewItem){
              NewItem->Caption = "Ìÿíþ";
              NewItem->Name = "BNM";
             // cnt++;
              NewItem->Tag = cnt;
              NewItem->OnClick = ManuClick; // ===> òî ÷òî òåáå íàäî
              PopupMenu1->Items->Add (NewItem);
              ShowMessage(IntToStr(PopupMenu1->Items->Count));
              }

              TPoint P = this->ClientToScreen(TPoint(X, Y));
              PopupMenu1->Popup(P.x, P.y);
              delete NewItem;
              ShowMessage(IntToStr(PopupMenu1->Items->Count));
            */

        }
        void SetNewPolygon()
        {
  /*          Point P;
            P = Grid.GetPointPolygon(sbX.Position, sbY.Position);
            if ((P.x - pbMain.Width - sbX.Position) > 2)
                sbX.Max = P.x - pbMain.Width + (Grid.StepPixels * 4);
            if ((P.y - pbMain.Height - sbY.Position) > 2)
                sbY.Max = P.y - pbMain.Height + (Grid.StepPixels * 4);*/
        }

    }
}
