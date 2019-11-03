using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace geliosNEW
{
    class SimpleFigure
    {
        Pen workPen;
        Graphics workGrph;
        public SimpleFigure(Graphics tmpGrp, Pen tmpPen)
        {
            workGrph = tmpGrp;
            workPen = tmpPen;
        }
        public void drawRhombus(float tX, float tY, float defSizeX, float defSizeY)
        {
            PointF[] masRomb = new PointF[5];
            masRomb[0] = new PointF(tX, tY + defSizeY);
            masRomb[1] = new PointF(tX + defSizeX, tY + defSizeY * 2);
            masRomb[2] = new PointF(tX + defSizeX * 2, tY + defSizeY);
            masRomb[3] = new PointF(tX + defSizeX, tY);
            masRomb[4] = new PointF(tX, tY + defSizeY);
            workGrph.DrawLines(workPen, masRomb);
        }
        public  float drawRect(float tX, float tY, float defSizeX, float defSizeY) //прямоугольник
        {
            workGrph.DrawLine(workPen, tX, tY + defSizeY, tX + defSizeX, tY + defSizeY);
            workGrph.DrawRectangle(workPen, tX + defSizeX, tY, defSizeX * 4, defSizeY * 2);
            workGrph.DrawLine(workPen, tX + defSizeX * 5, tY + defSizeY, tX + defSizeX * 6, tY + defSizeY);
            return tX + defSizeX * 6;
        }
        public  float drawStartAndFinishLine(float sX, float sY, float fX, float defSizeX) //линии начала и конца тфе
        {
            workGrph.DrawLine(workPen, sX, sY, sX + defSizeX, sY);
            workGrph.DrawLine(workPen, fX, sY, fX + defSizeX, sY);
            return fX + defSizeX;
        }
        public void drawHexagon(float tX, float tY, float defSizeX, float defSizeY)
        {
            workGrph.DrawLine(workPen, tX + defSizeX, tY + defSizeY * 3, tX + defSizeX * 1.5f, tY + defSizeY * 2.3f);
            workGrph.DrawLine(workPen, tX + defSizeX, tY + defSizeY * 3, tX + defSizeX * 1.5f, tY + defSizeY * 3.7f);
            workGrph.DrawLine(workPen, tX + defSizeX * 3, tY + defSizeY * 3, tX + defSizeX * 2.5f, tY + defSizeY * 2.3f);
            workGrph.DrawLine(workPen, tX + defSizeX * 3, tY + defSizeY * 3, tX + defSizeX * 2.5f, tY + defSizeY * 3.7f);
            workGrph.DrawLine(workPen, tX + defSizeX * 1.5f, tY + defSizeY * 2.3f, tX + defSizeX * 2.5f, tY + defSizeY * 2.3f);
            workGrph.DrawLine(workPen, tX + defSizeX * 1.5f, tY + defSizeY * 3.7f, tX + defSizeX * 2.5f, tY + defSizeY * 3.7f);
        }
    }
    class GraphicShapes
    {
        SimpleFigure simple;
        PictureBox picBox;
        CheckBox checkBox;
        Button button;
        Pen workPen;
        Graphics workGrph;
        bool menu;
        public GraphicShapes(Button tButton, Pen tmpPen) //Для рабочего PictureBox
        {
            button = tButton;
            menu = false;
            Bitmap bmp = new Bitmap(button.Width, button.Height);
            button.Image = bmp;
            iniGraphic(bmp, tmpPen);
        }
        public GraphicShapes(PictureBox tPicBox, Pen tmpPen) //Для рабочего PictureBox
        {
            picBox = tPicBox;
            menu = false;
            Bitmap bmp = new Bitmap(picBox.Width, picBox.Height);
            picBox.Image = bmp;
            iniGraphic(bmp, tmpPen);
        }
        public GraphicShapes(CheckBox tCheckBox, Pen tmpPen) //Для кнопак меню
        {
            checkBox = tCheckBox;
            menu = true;
            Bitmap bmp = new Bitmap(checkBox.Width, checkBox.Height);
            checkBox.Image = bmp;
            iniGraphic(bmp, tmpPen);
        }
        void iniGraphic (Bitmap bmp, Pen tmpPen)
        {
            workGrph = Graphics.FromImage(bmp);
            workPen = tmpPen;
            simple = new SimpleFigure(workGrph, workPen);
        }
        private void drawLeftButton(float tX, float tY, float scaleX, float scaleY) //0
        {
            PointF[] masArrow = new PointF[5];
            masArrow[0] = new PointF(tX, tY + scaleY);
            masArrow[1] = new PointF(tX + scaleX, tY + scaleY * 2);
            masArrow[2] = new PointF(tX + scaleX * 0.5f, tY + scaleY);
            masArrow[3] = new PointF(tX + scaleX, tY);
            masArrow[4] = new PointF(tX, tY + scaleY);
            workGrph.DrawLines(workPen, masArrow);
        }
        private void drawRightButton(float tX, float tY, float scaleX, float scaleY) //13
        {
            PointF[] masArrow = new PointF[5];
            masArrow[0] = new PointF(tX + scaleX * 1.5f, tY + scaleY);
            masArrow[1] = new PointF(tX + scaleX, tY + scaleY * 2);
            masArrow[2] = new PointF(tX + scaleX * 2, tY + scaleY);
            masArrow[3] = new PointF(tX + scaleX, tY);
            masArrow[4] = new PointF(tX + scaleX * 1.5f, tY + scaleY);
            workGrph.DrawLines(workPen, masArrow);
        }
        private float workOper(float tX, float tY, float scaleX, float scaleY) //1
        {
                return simple.drawRect(tX, tY, scaleX, scaleY);
        }
        public float seqWorkOper(float tX, float tY, float scaleX, float scaleY) //2
        {
            tX = simple.drawRect(tX, tY, scaleX, scaleY); //1
            return simple.drawRect(tX, tY, scaleX, scaleY); //2
        }
        public void paralWorkOperAnd(float tX, float tY, float scaleX, float scaleY) //3
        {
            //самые крайние вертикальные линии
            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY, tX + scaleX, tY + scaleY * 5); //вертикальная левая
            workGrph.DrawLine(workPen, tX + scaleX * 9, tY + scaleY, tX + scaleX * 9, tY + scaleY * 5); //вертикальная правая

            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY, tX + scaleX * 2, tY + scaleY);
            simple.drawRect(tX + scaleX * 2, tY, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY, tX + scaleX * 9, tY + scaleY);

            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY * 5, tX + scaleX * 2, tY + scaleY * 5);
            simple.drawRect(tX + scaleX * 2, tY + scaleY * 4, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY * 5, tX + scaleX * 9, tY + scaleY * 5);

            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY * 2.5f, tX + scaleX * 7.5f, tY + scaleY * 3.5f);
            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY * 2.5f, tX + scaleX * 8.5f, tY + scaleY * 3.5f);

            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 3, tX + scaleX * 9, scaleX);
        }

        public void paralWorkOperOr(float tX, float tY, float scaleX, float scaleY) //4
        {
            //самые крайние вертикальные линии
            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY, tX + scaleX, tY + scaleY * 5); //вертикальная левая
            workGrph.DrawLine(workPen, tX + scaleX * 9, tY + scaleY, tX + scaleX * 9, tY + scaleY * 5); //вертикальная правая

            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY, tX + scaleX * 2, tY + scaleY);
            simple.drawRect(tX + scaleX * 2, tY, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY, tX + scaleX * 9, tY + scaleY);

            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY * 5, tX + scaleX * 2, tY + scaleY * 5);
            simple.drawRect(tX + scaleX * 2, tY + scaleY * 4, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY * 5, tX + scaleX * 9, tY + scaleY * 5);

            workGrph.DrawLine(workPen, tX + scaleX * 7.5f, tY + scaleY * 2.5f, tX + scaleX * 8, tY + scaleY * 3.5f);
            workGrph.DrawLine(workPen, tX + scaleX * 8.5f, tY + scaleY * 2.5f, tX + scaleX * 8, tY + scaleY * 3.5f);

            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 3, tX + scaleX * 9, scaleX);
        }
        public void controlWork(float tX, float tY, float scaleX, float scaleY) //5
        {
            workGrph.DrawLine(workPen, tX + scaleX, tY, tX + scaleX * 9, tY); // Верхняя линия
            workGrph.DrawLine(workPen, tX+ scaleX, tY, tX + scaleX, tY + scaleY * 2); // левая боковая
            simple.drawRect(tX + scaleX, tY+ scaleY, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 9, tY, tX + scaleX * 9, tY + scaleY);
            //Ромб//
            workGrph.DrawLine(workPen, tX + scaleX * 7, tY + scaleY * 2, tX + scaleX * 8, tY  + scaleY * 2);
            simple.drawRhombus(tX + scaleX * 8, tY + scaleY, scaleX, scaleY);
            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 2, tX + scaleX * 10, scaleX);
        }
        public void controlFunc(float tX, float tY, float scaleX, float scaleY) //6
        {
            SolidBrush mySe = new SolidBrush(Color.Blue);
            workGrph.DrawLine(workPen, tX + scaleX, tY, tX + scaleX * 9, tY); // Верхняя линия
            simple.drawRect(tX + scaleX, tY + scaleY, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 7, tY + scaleY * 2, tX + scaleX * 8, tY + scaleY * 2);
            workGrph.DrawEllipse(workPen, tX + scaleX * 8, tY + scaleY, scaleX * 2f, scaleY * 2f);

            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY * 2, tX + scaleX, tY ); //вертикальная слева
            workGrph.DrawLine(workPen, tX + scaleX * 9, tY + scaleY, tX + scaleX * 9, tY); //над кругом

            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 2, tX + scaleX * 10, scaleX);
        }
        public void workFork(float tX, float tY, float scaleX, float scaleY) //7
        {
            //ромб
            simple.drawRhombus(tX + scaleX, tY + scaleY * 2, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 2, tY + scaleY, tX + scaleX * 2, tY + scaleY * 2); //верхняя вертикальная
            workGrph.DrawLine(workPen, tX + scaleX * 2, tY + scaleY * 4, tX + scaleX * 2, tY + scaleY * 5); //нижняя вертикальная

            simple.drawRect(tX + scaleX * 2 , tY, scaleX, scaleY); //верхний 
            simple.drawRect(tX + scaleX * 2, tY+ scaleY * 4, scaleX, scaleY); //нижний

            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY, tX + scaleX * 8, tY + scaleY * 5 ); //крайняя правая вертикальная
            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 3, tX + scaleX * 8, scaleX);
        }
        public void checkConditionKR(float tX, float tY, float scaleX, float scaleY)//8
        {
            //ромб
            simple.drawRhombus( tX + scaleX, tY + scaleY * 2, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 2, tY + scaleY * 2, tX + scaleX * 2, tY + scaleY); //верхняя вертикальная
            simple.drawRect(tX + scaleX * 2, tY, scaleX, scaleY); //верхний 
            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY, tX + scaleX * 8, tY + scaleY * 3); //крайняя правая горизонтальная
            workGrph.DrawLine(workPen, tX + scaleX * 3, tY + scaleY*3, tX + scaleX * 8, tY + scaleY*3);
            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 3, tX + scaleX * 8, scaleX);
        }
        public void whiledo(float tX, float tY, float scaleX, float scaleY)//9
        {
            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY * 3, tX + scaleX, tY + scaleY); //верхняя вертикальная
            simple.drawRect(tX + scaleX, tY, scaleX, scaleY); //верхний 
            workGrph.DrawLine(workPen, tX + scaleX * 7, tY + scaleY, tX + scaleX * 7, tY + scaleY * 2); //крайняя правая вертикальн
            //ромб
            simple.drawRhombus(tX + scaleX * 6, tY + scaleY * 2, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX+ scaleX, tY + scaleY * 3 , tX + scaleX * 6, tY + scaleY * 3);
            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 3, tX + scaleX * 8, scaleX);
        }
        public void dowhiledo(float tX, float tY, float scaleX, float scaleY) //10
        {
            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY, tX + scaleX, tY + scaleY * 4); //верхняя вертикальная
            simple.drawRect(tX + scaleX, tY, scaleX, scaleY); //верхний
            simple.drawRect(tX + scaleX, tY + scaleY * 3, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 7, tY + scaleY, tX + scaleX * 8, tY + scaleY); //верхняя горизонтальная
            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY, tX + scaleX * 8, tY + scaleY * 3); //крайняя правая горизонтальная
            //ромб
            simple.drawRhombus(tX + scaleX * 7, tY + scaleY * 3, scaleX, scaleY);
            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 4, tX + scaleX * 9, scaleX);
        }
        public void dowhiledoWITH(float tX, float tY, float scaleX, float scaleY) //11
        {
            workGrph.DrawLine(workPen, tX + scaleX, tY + scaleY, tX + scaleX, tY + scaleY * 4); //верхняя вертикальная
            simple.drawRect(tX + scaleX, tY, scaleX, scaleY); //верхний 
            simple.drawRect(tX + scaleX, tY + scaleY * 3, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 7, tY + scaleY, tX + scaleX * 8, tY + scaleY); //верхняя горизонтальная
            workGrph.DrawLine(workPen, tX + scaleX * 8, tY + scaleY, tX + scaleX * 8, tY + scaleY * 3); //крайняя правая горизонтальная

            workGrph.DrawEllipse(workPen, tX + scaleX * 7, tY + scaleY * 3, scaleX * 2f, scaleY * 2f);
            tX = simple.drawStartAndFinishLine(tX, tY + scaleY * 4, tX + scaleX * 9, scaleX);
        }
        public void checkCondition(float tX, float tY, float scaleX, float scaleY) //12
        {
            workGrph.DrawLine(workPen, tX, tY + scaleY * 3, tX + scaleX, tY + scaleY * 3);
            workGrph.DrawLine(workPen, tX + scaleX * 2, tY + scaleY * 2.3f, tX + scaleX * 2, tY + scaleY); //верхняя вертикальная
            simple.drawHexagon(tX, tY, scaleX, scaleY);
            workGrph.DrawLine(workPen, tX + scaleX * 2, tY + scaleY * 3.7f, tX + scaleX * 2, tY + scaleY * 5); //нижняя вертикальная

            workGrph.DrawLine(workPen, tX + scaleX * 2, tY + scaleY, tX + scaleX * 3, tY + scaleY); //верхняя горизонтальная
            workGrph.DrawLine(workPen, tX + scaleX * 2, tY + scaleY * 5, tX + scaleX * 3, tY + scaleY * 5); //нижняя горизонтальная
            simple.drawRect(tX + scaleX * 3, tY, scaleX, scaleY); //верхний 
            simple.drawRect(tX + scaleX * 3, tY + scaleY * 4, scaleX, scaleY); //нижний

            workGrph.DrawLine(workPen, tX + scaleX * 9, tY + scaleY, tX + scaleX * 9, tY + scaleY * 5); //крайняя правая вертикальная

            workGrph.DrawLine(workPen, tX + scaleX * 9, tY + scaleY * 3, tX + scaleX * 10, tY + scaleY * 3);
        }
        public void drawForNum (int i, float tX, float tY, float scaleX, float scaleY)
        {
            switch (i)
            {
                case 0:
                    drawLeftButton(tX, tY, scaleX, scaleY);
                    break;
                case 1:
                    workOper(tX, tY, scaleX, scaleY);
                    break;
                case 2:
                    seqWorkOper(tX, tY, scaleX, scaleY);
                    break;
                case 3:
                    paralWorkOperAnd(tX, tY, scaleX, scaleY);
                    break;
                case 4:
                    paralWorkOperOr(tX, tY, scaleX, scaleY);
                    break;
                case 5:
                    controlWork(tX, tY, scaleX, scaleY);
                    break;
                case 6:
                    controlFunc(tX, tY, scaleX, scaleY);
                    break;
                case 7:
                    workFork(tX, tY, scaleX, scaleY);
                    break;
                case 8:
                    checkConditionKR(tX, tY, scaleX, scaleY);
                    break;
                case 9:
                    whiledo(tX, tY, scaleX, scaleY);
                    break;
                case 10:
                    dowhiledo(tX, tY, scaleX, scaleY);
                    break;
                case 11:
                    dowhiledoWITH(tX, tY, scaleX, scaleY);
                    break;
                case 12:
                    checkCondition(tX, tY, scaleX, scaleY);
                    break;
                case 13:
                    drawRightButton(tX, tY, scaleX, scaleY);
                    break;
            }
     //       if (menu)
    //            checkBox.Refresh();
     //       else
   //             picBox.Refresh();
        }
    }
}
