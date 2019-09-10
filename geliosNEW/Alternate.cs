using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; 

namespace geliosNEW
{
    public class TAlternateItem
    {
        int f_IdAlt;
        int f_NumAlt;
        int f_ParentIdAlt;
        int f_ParentNumAlt;
        bool f_First;
        TBaseWorkShape f_WorkShape;
        TBaseWorkShape f_OtherWorkShape;
   //     TArrowWorkShape f_ArrowWorkShape;
        Color f_ArrowColor;
        Color f_EnterArrowColor;
        bool f_Entered;
        bool f_Visible;
        void SetArrowColor(Color AValue)
        {
            f_ArrowColor = AValue;
        }
        void SetEnterArrowColor(Color AValue)
        {
            f_EnterArrowColor = AValue;
        }
        public TAlternateItem(TBaseWorkShape AWorkShape, int AIdAlt, int ANumAlt,
       int AParentIdAlt, int AParentNumAlt, bool AFirst)
        {
            int m_step;
            f_IdAlt = AIdAlt;
            f_NumAlt = ANumAlt;
            f_ParentIdAlt = AParentIdAlt;
            f_ParentNumAlt = AParentNumAlt;
            f_WorkShape = AWorkShape;
  //          m_step = f_WorkShape.Step;
            f_First = AFirst;
 /*           if (AFirst)
                f_ArrowWorkShape = new TArrowWorkShape(f_WorkShape.StartPoint.x, f_WorkShape.StartPoint.y, m_step, 0, 0, 0);
            else
                f_ArrowWorkShape = new TArrowWorkShape(f_WorkShape.EndPoint.x, f_WorkShape.EndPoint.y, m_step, 0, 0, 0);*/
  /*          f_ArrowWorkShape.BrushStyle = new SolidBrush(Color.Black);
            f_ArrowWorkShape.Init();
            f_ArrowWorkShape.AddNodeHint(f_IdAlt);*/
            f_Entered = false;
            f_Visible = true;
            f_OtherWorkShape = null;

        }
        ~TAlternateItem() { }
/*        public TArrowWorkShape ArrowWorkShape 
        {
            get { return f_ArrowWorkShape; }
        }*/
        public TBaseWorkShape WorkShape 
        {
            get { return f_WorkShape; }
            set { f_WorkShape = value; }
        }
        public TBaseWorkShape OtherWorkShape 
        {
            get { return f_OtherWorkShape; }
            set { f_OtherWorkShape = value; }
        }
        public bool First
        {
            get { return f_First; }
            set { f_First = value; }
        }
        public Color EnterArrowColor
        {
            get { return f_EnterArrowColor; }
            set { SetEnterArrowColor(value); }
        }
        public Color ArrowColor
        {
            get { return f_ArrowColor; }
            set { SetArrowColor(value); }
        }
        public bool Entered
        {
            get { return f_Entered; }
            set { f_Entered = value; }
        }
        public bool Visible 
        {
            get { return f_Visible; }
            set { f_Visible = value; }
        }
        public int IdAlt
        {
            get { return f_IdAlt; }
        }
        public int NumAlt
        {
            get { return f_NumAlt; }
        }
        public int IdAltParent
        {
            get { return f_ParentIdAlt; }
        }
        public int NumAltParent
        {
            get { return f_ParentNumAlt; }
        }
    }
    class TAlternateList
    {
        List<object> f_List;
        int f_pos;
 /*       int GetCount();
        public TAlternateList();
        ~TAlternateList() { }
        public TAlternateItem First();
        public TAlternateItem Next();
        public TAlternateItem Prior();
        public TAlternateItem Last();
        public bool EnterByShape(TBaseShape AFlagShape);
        public bool LeaveByShape(TBaseShape* AFlagShape);
        public void ClearAll();
        public int Count = { read = GetCount };*/
    }


    class TAlternateController
    {
        //  HWND f_OwnerForm;
        /*        TList* f_List;
                TColor f_ArrowColor;
                TColor f_EnterArrowColor;
                TColor f_PenColor;
                int f_PenWidth;
                TListChange FOnListChange;
                TClipPath* f_ClipPath;
                bool f_LEControl;
                HWND f_WndHandler;
                TControl* f_UnderControl;
                bool f_UpdateAlternateList;

                void FreeList();
                int FindAlternateItem(TBaseWorkShape* AWorkShape, bool AFirst);
                TBaseWorkShape* FindNextWorkShape(TBaseWorkShape* W);
                TBaseWorkShape* FindPriorWorkShape(TBaseWorkShape* W);
                void DoAddAlternateItem(TBaseWorkShape* AWorkShape, int AId, int ANumAlt, int AParentId, int AParentNumAlt, bool AFirst);
                void DoDeleteAlternateItem(TBaseWorkShape* AWorkShape, int AId, int ANumAlt, bool AFirst);
                void __fastcall SetArrowColor(TColor AValue);
                void __fastcall SetEnterArrowColor(TColor AValue);
                void __fastcall SetPenColor(TColor AValue);
                void __fastcall SetPenWidth(int AValue);
                void RecalcCoordArrow();
                public:
             TAlternateController(HWND AOwnerForm);
                ~TAlternateController();

                bool AddAlternateItem(TBaseWorkShape* AWSFirst, TBaseWorkShape* AWSLast, int AId, int ANumAlt,
                  int AParentId, int AParentNumAlt);
                void DeleteAlternateItem(TBaseWorkShape* AWSFirst, TBaseWorkShape* AWSLast, int AId, int ANum);
                void DeleteAlternateItem2(int AId, bool ASendMessage = true);
                void FillAlternateList(TAlternateList* AlternateList, int AParentShapeID,
                    int AId, int ANumAlt);
                void VisibleArrow(TBaseWorkShape* W, bool AVisible);
                void VisibleArrowAll(bool AVisible);
                int IsExistsAlternate(TBaseWorkShape* AWSFirst, TBaseWorkShape* AWSLast);
                void CoordinateCorrect();
                void RecalcPosition(int AParentShapeID, int AId, int ANumAlt);
                bool GetWSToAlternate(int AId, TBaseWorkShape** AWSFirst, TBaseWorkShape** AWSLast);
                void ClearAll();
                bool DeleteWorkShape(TBaseWorkShape* AWS);

                __property TListChange  OnListChange = {read = FOnListChange, write = FOnListChange
            };
            __property TColor ArrowColor = {read = f_ArrowColor, write = SetArrowColor
        };
        __property TColor EnterArrowColor = {read = f_EnterArrowColor, write = SetEnterArrowColor};
             __property TColor PenColor = {read = f_PenColor, write = SetPenColor};
             __property int PenWidth = { read = f_PenWidth, write = SetPenWidth };
        __property bool LEControl = { read = f_LEControl, write = f_LEControl };
        __property HWND WndHandler = {read = f_WndHandler, write = f_WndHandler};
             __property TControl* UnderControl = { read = f_UnderControl, write = f_UnderControl };
        __property bool UpdateAlternateList = { read = f_UpdateAlternateList, write = f_UpdateAlternateList };
        */
    }
}
