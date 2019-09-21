using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace geliosNEW
{
    class Section
    {
        string hint;
        int imageIndex, X, Y, scaleX, scaleY;
        CheckBox barSec;
        public Section(string tCaption, string tHint, int tImageIndex)
        {
            barSec = new CheckBox();
            barSec.Text = tCaption;
            barSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            hint = tHint;
            imageIndex = tImageIndex;
            X = Y = 0;
            scaleX = scaleY = 15;
        }
        public void iniShape(int tX, int tY, int tScaleX, int tScaleY)
        {
            X = tX;
            Y = tY;
            scaleX = tScaleX;
            scaleY = tScaleY;
        }
        public CheckBox getCheckBox (int tx, int ty, int tScaleX, int tScaleY)
        {
            barSec.Width = tScaleX;
            barSec.Height = tScaleY;
            barSec.FlatStyle = FlatStyle.Popup;
            barSec.Appearance = Appearance.Button;
            barSec.TextAlign = ContentAlignment.BottomCenter;
            barSec.Location = new Point(tx, ty);
            Pen workPen = new Pen(Color.Black, 2f);
            GraphicShapes icon = new GraphicShapes(barSec, workPen);
            icon.drawForNum(imageIndex, X, Y, scaleX, scaleY);
 //           barSec.BackColor = Color.FromArgb(207, 169, 97);
            barSec.BackColor = Color.FromName("DarkGray");
            //      barSec.BackColor = Color.FromName("DimGray");
            return barSec;
        }
        public static Button getButton(int buttonX, int buttonY, int buttonScaleX, int buttonScaleY, bool LorR)
        {
            float drX = buttonScaleX / (LorR ? buttonScaleX : 4);
            float drY = buttonScaleY / 4;
            float drscaleX = buttonScaleY / 9;
            float drscaleY = buttonScaleY / 4; 
            Button control = new Button();
            control.Width = buttonScaleX;
            control.Height = buttonScaleY;
            control.Location = new Point(buttonX, buttonY);
            Pen workPen = new Pen(Color.Black, 2f);
            GraphicShapes icon = new GraphicShapes(control, workPen);
            icon.drawForNum(LorR?13:0, drX, drY, drscaleX, drscaleY);
            return control;
        }

    }
    class SectionBar
    {
        Panel pnlButton;
        List<Control> allControl;
        CheckBox lastCheckedControl;
        int numControl;
        int finishX; // необходимы размер по Х под имеющиеся контролы
        int startY;
        int scaleSectionX;
        int scaleSectionY;
        int onPnlX; // общий размер по Х котролов, находящихся на панели
        int howButtonShow; //сколько кнопок отображается 
        int howButtonFirst = 1; // какая кнопка первая
        int sizePanelX;


        public SectionBar(Panel tPanel, int tX, int tY, int tSX, int tSY)
        {
            pnlButton = tPanel;
            allControl = new List<Control>();
            onPnlX = 0;
            finishX = tX;
            startY = tY;
            scaleSectionX = tSX;
            scaleSectionY = tSY;
        }
        public void addSection(Section tmp)
        {
            CheckBox barSec = tmp.getCheckBox(finishX, startY, scaleSectionX, scaleSectionY);
            allControl.Add(barSec);
            finishX += scaleSectionX + 15;
        }
        public void addControlLeft()
        {
            Button left = Section.getButton(-1, 0, scaleSectionX / 4, pnlButton.Height+1, false);
            allControl.Add(left);
        }
        public void addControlRight()
        {
            Button right = Section.getButton(pnlButton.Width- scaleSectionX / 4+1, 0, scaleSectionX / 4, pnlButton.Height + 1, true);
            allControl.Add(right);
        }
        public void showControls(int TsizePanelX, int pos)
        {
            sizePanelX = TsizePanelX;
            int howContr = (sizePanelX - scaleSectionX / 2) / (15 + scaleSectionX); //сколько поместится кнопок
            if (howContr < howButtonShow)
                pnlButton.Controls.Clear();
            if (pos != 0)
            {
                howButtonFirst += pos;
                pnlButton.Controls.Clear();
            }
            pnlButton.Controls.Clear();
            allControl[0].Click -= (this.LeftClick);
            allControl[0].Click += new System.EventHandler(this.LeftClick);
            pnlButton.Controls.Add(allControl[0]); // кнопка <-
              if (howContr > 12)
                  howButtonShow = 12;
              else
                  howButtonShow = howContr;
            int howNeedX = howButtonShow * (15 + scaleSectionX)+ scaleSectionX/2; // сколько они займут места
            int tail = sizePanelX - howNeedX; //оступ в начале и в конце
            onPnlX = tail / 2 + scaleSectionX / 4 - (tail==0 ? 15 : 0);
            int i;
            
            int lastBotton = (howButtonFirst+ howButtonShow);
            if (lastBotton == 13)
            {
                allControl[13].Enabled = false;
            }
            else if (lastBotton > 13)
            {
                lastBotton = 13;
                howButtonFirst = lastBotton - howContr;
            }
            else
                allControl[13].Enabled = true;
            if (howButtonFirst != 1)
                allControl[0].Enabled = true;
            else
                allControl[0].Enabled = false;
            for (i= howButtonFirst; i<lastBotton; i++)
            {
                allControl[i].Location = new Point(onPnlX, startY);
                allControl[i].Click -= (this.RightClick);
                allControl[i].Click += new System.EventHandler(this.BarButtonClick);
                allControl[i].Tag = i;
                pnlButton.Controls.Add(allControl[i]);
                onPnlX += allControl[i].Width + 15;
            }
            allControl[13].Click -= (this.RightClick);
            allControl[13].Click += new System.EventHandler(this.RightClick);
            allControl[13].Location = new Point(pnlButton.Width- scaleSectionX/4, 0);
            pnlButton.Controls.Add(allControl[13]); // кнопка .

        }
        public void choseControls(int numSection)
        {
            allControl[numSection].BackColor = Color.FromName("DimGray");
        }
        public void BarButtonClick(object sender, EventArgs e)
        {
            if (lastCheckedControl == null)
            {
                lastCheckedControl = ((CheckBox)sender);
            }
            else if (lastCheckedControl != (CheckBox)sender)
            {
                lastCheckedControl.Checked = false;
                lastCheckedControl.BackColor = Color.FromName("DarkGray");
                lastCheckedControl = ((CheckBox)sender);
            }
            if (((CheckBox)sender).Checked)
            {
                lastCheckedControl = (CheckBox)sender;
                lastCheckedControl.BackColor = Color.FromName("DimGray");
                numControl = (int)((CheckBox)sender).Tag;
            }
            else
            {
                ((CheckBox)sender).BackColor = Color.FromName("DarkGray");
                lastCheckedControl = null;
                numControl = -1;
            }

        }
        public bool DownFalse()
        {
            if (lastCheckedControl != null)
            {
                lastCheckedControl.Checked = false;
                lastCheckedControl.BackColor = Color.FromName("DarkGray");
                lastCheckedControl = null;
                numControl = -1;
                return true;
            }
            return false;
        }
        public void RightClick(object sender, EventArgs e)
        {
            showControls(sizePanelX, 1);
        }
        public void LeftClick(object sender, EventArgs e)
        {
            showControls(sizePanelX, -1);
        }
        public int  GetActiveControlNum()
        {
            return numControl;
        }
    }
}
