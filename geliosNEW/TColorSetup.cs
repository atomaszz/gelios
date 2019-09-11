using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TColorSetup
    {
        Color f_FonColor;
        bool f_BoldTFELine;
        Color f_LineColor;
        bool f_BrushTFE;
        Color f_BrushColor;
        Font f_FontTFE;
        Color f_FrameColorTFE;
        Color f_FrameColorTFS;
        Color f_HaveChildColor;
        Color f_AltParamLineColor;
        Color f_AltParamShapeColor;
        bool f_AltParamShapeColorEnable;

        public TColorSetup()
        {
            f_FonColor = Color.Black;
            f_BoldTFELine = false;
            f_LineColor = Color.Black;
            f_BrushTFE = false;
            f_BrushColor = Color.White;
            f_FrameColorTFE = Color.Red;
            f_FrameColorTFS = Color.Red;
            f_HaveChildColor = Color.Green;
    //        f_FontTFE = new Graphics::TFont;
        }
        ~TColorSetup() { }
     /*   public void SetFont(Graphics::TFont* AFont);
        public void GetFont(Graphics::TFont* AFont);
        public Color FonColor = {read = f_FonColor, write = f_FonColor
        public bool BoldTFELine = { read = f_BoldTFELine, write = f_BoldTFELine };
        public Color LineColor = {read = f_LineColor, write = f_LineColor
        public bool BrushTFE = { read = f_BrushTFE, write = f_BrushTFE };
        public Color BrushColor = {read = f_BrushColor, write = f_BrushColor};
        public Color FrameColorTFE = {read = f_FrameColorTFE, write = f_FrameColorTFE};*/
        public Color FrameColorTFS
        {
            set { f_FrameColorTFS = value; }
            get { return f_FrameColorTFS; }
        }
     /*   public Color HaveChildColor = {read = f_HaveChildColor, write = f_HaveChildColor};
        public Color AltParamLineColor = {read = f_AltParamLineColor, write = f_AltParamLineColor};
        public Color AltParamShapeColor = {read = f_AltParamShapeColor, write = f_AltParamShapeColor};
        public bool AltParamShapeColorEnable = { read = f_AltParamShapeColorEnable, write = f_AltParamShapeColorEnable };*/
    }
}
