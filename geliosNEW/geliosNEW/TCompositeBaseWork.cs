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
        List<TCompositeBaseWorkItem> f_ListItem;
     /*   TList* f_ListBL;
        TList* f_ListRectLine;
        int f_TopBorder;
        int f_OffsetTop;
        bool f_Selected;
        TPoint f_StartPoint;
        TColorSetup* f_ColorSetup;
        unsigned int f_Ref;
        TCompositeStack2* f_History;
        TBaseLine* __fastcall GetBaseLineItem(int AIndex);
        int __fastcall GetBaseLineCount();
        TBaseWorkShape* f_ConvertedBWS;
        protected:
     int f_step;
        int f_LastLineBend;*/
        int f_FirstLineBend;
    /*    TPoint f_EndPoint;
        void FreeListItem();
        void FreeListBL();
        void HideLines();
        void FreeListRectLine();
        void __fastcall virtual SetTopBorder(int AValue);
        void __fastcall SetLineColor(TColor AValue);
        int __fastcall GetItemCount();
        TPoint __fastcall virtual GetEndPoint();
        TPoint __fastcall virtual GetStartPoint();
        virtual TBaseLine* __fastcall GetEndLine();
        void __fastcall virtual SetStartPoint(TPoint AValue);
        void __fastcall SetSelected(bool AValue);
        TBaseLine* GetBaseLine(int AIndex);
        TBaseLine* GetNewLine();
        virtual TRectLine* __fastcall  GetFirstLine();
        public:
     TCompositeBaseWork();
        virtual ~TCompositeBaseWork();
        TCompositeBaseWorkItem* GetItem(int ANum);
        void AddBaseShape(TBaseShape* ABaseShape, bool IsHaveChild);
        void AddWorkItemShape(TCompositeBaseWorkItem* ABaseWorkItem);
        void AddBaseLine(TBaseLine* BL);
        void AddRectLine(TRectLine* ARectLine);
        TPoint OffsetEndCoordinate(TPoint AStart);
        //     TSubstWork* GetSubstWork(int ANum);*/
        public virtual void Prepare()
        {
            TBaseLine Line;
  /*          TCompositeBaseWorkItem Item = GetItem(0);
            Item->StartPoint = f_FirstRectLine->PointEnd;
            TPoint RHV = Item->EndPoint;
            //Line->ApplyOffset(x_offs, y_offs);
            for (int i = 0; i <= f_LastRCT->Count - 1; i++)
            {
                Line = static_cast<TBaseLine*>(f_LastRCT->Items[i]);
                Line->Visible = true;
                Line->MoveTo(RHV);*/
            }


 /*           if (!f_FirstRectLine || f_FirstRectLine->PaintLine)
            {
                for (int i = 0; i <= f_FirstRCT->Count - 1; i++)
                {
                    Line = static_cast<TBaseLine*>(f_FirstRCT->Items[i]);
                    Line->Visible = true;
                }
            }
            PrepareDrawFlags();*/
        }
 /*       virtual void Paint(TCanvas* ACanvas);
        virtual void ReplaceShape(int IdShapeReplace, TCompositeBaseWork* ANew);
        virtual void Appearance();
        virtual bool ConvertWorkShape(TAlternateViewItemTFS* AWS, TAlternateView* AV);
        virtual void ConvertWorkShapeFromBase(TBaseWorkShape* AWS, TAlternateView* AV);*/
/*        public Rectangle GetMaxRect()
        {
            TCompositeBaseWorkItem Item;
            Rectangle R;
            Rectangle Res = new Rectangle(0, 0, 0, 0);
            TBaseLine bLine;
            if (f_ListItem.Count > 0)
            {
                Item = f_ListItem[0];
                Res = Item.MaxRect;
                for (int i = 1; i <= f_ListItem->Count - 1; i++)
                {
                    Item = static_cast<TCompositeBaseWorkItem*>(f_ListItem->Items[i]);
                    R = Item->MaxRect;
                    if (R.Right > Res.Right) Res.Right = R.Right;
                    if (R.Bottom > Res.Bottom) Res.Bottom = R.Bottom;
                    if (R.Left < Res.Left) Res.Left = R.Left;
                    if (R.Top < Res.Top) Res.Top = R.Top;
                }
            }
            for (int i = 0; i <= f_ListBL->Count - 1; i++)
            {
                bLine = static_cast<TBaseLine*>(f_ListBL->Items[i]);
                if (bLine->X0 < Res.Left) Res.Left = bLine->X0;
                if (bLine->X1 < Res.Left) Res.Left = bLine->X1;
                if (bLine->X0 > Res.Right) Res.Right = bLine->X0;
                if (bLine->X1 > Res.Right) Res.Right = bLine->X1;

                if (bLine->Y0 < Res.Top) Res.Top = bLine->Y0;
                if (bLine->Y1 < Res.Top) Res.Top = bLine->Y1;
                if (bLine->Y0 > Res.Bottom) Res.Bottom = bLine->Y0;
                if (bLine->Y1 > Res.Bottom) Res.Bottom = bLine->Y1;
            }
            return Res;
        }
   /*     //     void SetOffsetPosition(int Ax, int Ay);
        TBaseShape* FindTFE(int Ax, int Ay);
        TBaseShape* CloneShape(TBaseShape* ADest);
        virtual void ApplyOffset(int Ax, int Ay);
        TRect GetAnyRect();
        TRect GetRectSummary(TRect ARect);
        TCompositeBaseWorkItem* FindItem(int ABaseShapeID, TCompositeBaseWork** AFind);
        bool ContainedShape(int ABaseShapeID);
        TCompositeBaseWork* CopyRef();
        void FreeRef();
        void GetAllLines(TDynamicArray* R, bool AMarkFirst);
        void GetAllShapes(TDynamicArray* R);
        virtual void MakeFirstLine(TPoint AStart, int ABend);
        void SetColorAll(TColor AColor);
        void SetBrushColorAll(TColor AColor);
        void SetBrushStyleAll(TBrushStyle AStyle);
        virtual void TrimFirstLine(TPoint APStart, TPoint APEnd);
        void DeleteLine(void* Line);


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
__property bool Selected = { read = f_Selected, write = SetSelected };*/
//public TRectLine FirstLine { set; get; }
/*__property TCompositeStack2* History = { read = f_History };
__property TBaseWorkShape * ConvertedBWS = { read = f_ConvertedBWS, write = f_ConvertedBWS };*/
    }

