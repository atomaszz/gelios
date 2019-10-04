using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    class TRect
    {
        public int m_Top, m_Left, m_Right, m_Bottom, m_Height, m_Width;
        public TRect (int tx, int ty)
        {
            m_Top = tx;
            m_Left = ty;
        }
        public TRect(Rectangle rec)
        {
            m_Top = rec.Y; 
            m_Left = rec.X;
            m_Right = rec.X + rec.Width;
            m_Bottom = rec.Y + rec.Height;
            m_Height = rec.Height;
            m_Width = rec.Width;
        }
        public void SetWidthHeight(int w, int h)
        {
            m_Width = w;
            m_Height = h;
            m_Right = Left + m_Width;
            m_Bottom = Top + m_Height;

        }
        public void SetRightButtom(int r, int b)
        {
            m_Width = r - Left;
            m_Height = b - Top;
            m_Right = r;
            m_Bottom = b;

        }
        public TRect()
        {
            m_Top = 0;
            m_Left = 0;
            m_Right = 0;
            m_Bottom = 0;
            m_Width = 0;
            m_Height = 0;
        }
        public int Top
        {
            set
            {
                m_Top = value;
                m_Height = m_Top - m_Bottom;
            }
            get { return m_Top; }
        }
        public int Y
        {
            set
            {
                m_Top = value;
                m_Height = m_Top - m_Bottom;
            }
        }
        public int Bottom
        {
            set
            {
                m_Bottom = value;
                m_Height =  m_Bottom - m_Top;
            }
            get { return m_Bottom; }
        }
        public int Left
        {
            set
            {
                m_Left = value;
                m_Width = m_Right - m_Left;
            }
            get { return m_Left; }
        }
        public int X
        {
            set
            {
                m_Left = value;
                m_Width = m_Right - m_Left;
            }
        }
        public int Right
        {
            set
            {
                m_Right = value;
                m_Width = m_Right - m_Left;
            }
            get { return m_Right; }
        }
        public int Width
        {
            set
            {
                m_Width = value;
                m_Right = m_Left + m_Width;
            }
            get { return m_Width; }
        }
        public int Height
        {
            set
            {
                m_Height = value;
                m_Bottom = m_Top + m_Height;
            }
            get { return m_Height; }
        }
        public Rectangle GetRec()
        {
            return new Rectangle (m_Left, m_Top, m_Width, m_Height);
        }

    }
    class CommonGraph
    {
        public static string float_2_string(double ff, int pr)
        {
            string sResult;
     /*       DecimalSeparator = '.';
            sResult = FloatToStrF(ff, ffFixed, pr, 5);
            if (sResult == "NAN" || sResult == "INF" || sResult == "-INF")*/
                sResult = "0.00000][test";
            return sResult;
        }
        public static void SGCells(DataGridView AStringGrid, int ARow, int ACol, string AValue)
        {
            AStringGrid.Columns[ACol].HeaderCell.Value = AValue;
        }
        public static void SGCellsByName(DataGridView AStringGrid, int ARow, string AColName, object AValue)
        {
            for (int i = 0; i <= AStringGrid.ColumnCount - 1; i++)
            {
                // if (String.Compare(AColName, (AStringGrid.Rows[ARow].Cells[i].Value).ToString())!=0)
                if (String.Compare(AColName, (AStringGrid.Columns[i].HeaderCell.Value).ToString()) == 0)
                {
                    AStringGrid.Rows[ARow].Cells[i].Value = AValue.ToString();
                    return;
                }
            }
        }
    }
    public class DrawObject
    {
        public Graphics gr;
        public Bitmap bmp;
        public DrawObject (PictureBox tobj)
        {
            bmp = new Bitmap(tobj.Width, tobj.Height);
            gr = Graphics.FromImage(bmp);
        }
        public DrawObject()
        {
            bmp = new Bitmap(10, 10);
            gr = Graphics.FromImage(bmp);
        }
        public void  SetBitMap(int x, int y)
        {
            bmp = new Bitmap(x, y);
            gr = Graphics.FromImage(bmp);
        }
    }
}
