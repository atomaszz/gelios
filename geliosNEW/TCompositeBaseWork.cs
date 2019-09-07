using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    class TCompositeBaseWork
    {
  //      TList f_ListItem;
 //       TList f_ListBL;
 //       TList f_ListRectLine;
        int f_TopBorder;
        int f_OffsetTop;
        bool f_Selected;
        Point f_StartPoint;
      //  ColorSetup f_ColorSetup;
        long f_Ref;
 //       TCompositeStack2 f_History;
  /*      TBaseLine GetBaseLineItem(int AIndex);
        int GetBaseLineCount();*/
        TBaseWorkShape f_ConvertedBWS;
        protected int f_step;
        protected int f_LastLineBend;
        protected int f_FirstLineBend;
        protected Point f_EndPoint;
  /*      protected void FreeListItem();
        protected void FreeListBL();
        protected void HideLines();
        protected void FreeListRectLine();
        protected void virtual SetTopBorder(int AValue);
        protected void  SetLineColor(TColor AValue);
        protected int  GetItemCount();
        Point  virtual GetEndPoint();
        Point  virtual GetStartPoint();
        virtual TBaseLine  GetEndLine();
        void  virtual SetStartPoint(Point AValue);
        void  SetSelected(bool AValue);
        TBaseLine GetBaseLine(int AIndex);
        TBaseLine GetNewLine();
        virtual TRectLine   GetFirstLine();*/

        public TCompositeBaseWork()
        {
    //        f_ListItem = new TList;
    //        f_ListBL = new TList;
    //        f_ListRectLine = new TList;
            f_TopBorder = 0;
            f_OffsetTop = 0;
            f_LastLineBend = 0;
            f_FirstLineBend = 0;
     //       f_ColorSetup = NULL;
            f_Selected = false;
            f_Ref = 1;
     //       f_History = new TCompositeStack2;
            f_ConvertedBWS = null;
        }

        ~TCompositeBaseWork() { }
    /*    public TCompositeBaseWorkItem* GetItem(int ANum);
        public void AddBaseShape(TBaseShape* ABaseShape, bool IsHaveChild);
        public void AddWorkItemShape(TCompositeBaseWorkItem* ABaseWorkItem);
        public void AddBaseLine(TBaseLine* BL);
        public void AddRectLine(TRectLine* ARectLine);
        public TPoint OffsetEndCoordinate(TPoint AStart);*/
        virtual public void Prepare()
        {
   /*         TCompositeBaseWorkItem Item;
            for (int i = 0; i <= f_ListItem.Count - 1; i++)
            {
                Item = static_cast<TCompositeBaseWorkItem*>(f_ListItem->Items[i]);
                Item.Prepare();
            }*/
        }

     /*   virtual public void Paint(TCanvas* ACanvas);
        virtual public void ReplaceShape(int IdShapeReplace, TCompositeBaseWork* ANew);
        virtual public void Appearance();
        virtual public bool ConvertWorkShape(TAlternateViewItemTFS* AWS, TAlternateView* AV);
        virtual public void ConvertWorkShapeFromBase(TBaseWorkShape* AWS, TAlternateView* AV);
        public TRect GetMaxRect();
        public TBaseShape FindTFE(int Ax, int Ay);
        public TBaseShape CloneShape(TBaseShape* ADest);
        virtual public void ApplyOffset(int Ax, int Ay);
        public TRect GetAnyRect();
        public TRect GetRectSummary(TRect ARect);
        public TCompositeBaseWorkItem* FindItem(int ABaseShapeID, TCompositeBaseWork** AFind);
        public bool ContainedShape(int ABaseShapeID);
        public TCompositeBaseWork CopyRef();
        public void FreeRef();
        public void GetAllLines(TDynamicArray* R, bool AMarkFirst);
        public void GetAllShapes(TDynamicArray* R);
        virtual public void MakeFirstLine(TPoint AStart, int ABend);
        public void SetColorAll(TColor AColor);
        public void SetBrushColorAll(TColor AColor);
        public void SetBrushStyleAll(TBrushStyle AStyle);
        virtual public void TrimFirstLine(TPoint APStart, TPoint APEnd);
        public void DeleteLine(void Line);


        __property int TopBorder = { read = f_TopBorder, write = SetTopBorder };
        __property int OffsetTop = { read = f_OffsetTop };
        __property TBaseLine* BaseLineItem[int AIndex] = {read = GetBaseLineItem
    };
    __property int BaseLineCount = { read = GetBaseLineCount };
    __property int ItemCount = { read = GetItemCount };
    __property int LastLineBend = { read = f_LastLineBend };
    __property int FirstLineBend = { read = f_FirstLineBend };
    __property TPoint StartPoint = {read = GetStartPoint, write = SetStartPoint
};
__property TPoint EndPoint = {read = GetEndPoint};
     __property TBaseLine* EndLine = { read = GetEndLine };
__property TColorSetup* ColorSetup = { read = f_ColorSetup, write = f_ColorSetup };
__property bool Selected = { read = f_Selected, write = SetSelected };
__property TRectLine* FirstLine = { read = GetFirstLine };
__property TCompositeStack2* History = { read = f_History };
__property TBaseWorkShape * ConvertedBWS = { read = f_ConvertedBWS, write = f_ConvertedBWS };*/
    }
}
