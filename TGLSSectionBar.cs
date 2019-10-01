using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace geliosNEW
{
    public class TGLSSectionBar
    {
        private Font[] FFonts = new Font[7];
        bool FDestroying;
        string FStoredHint;
        int FLastHintSection;
        int FLastHintButton;
        Bitmap FTmpBitmap;
        bool FMousePressed;
        int FSectionHeaderPressed;
        int FButtonPressed;
        TSectionBarSections FSections;
        //       ImageList FImages;
        int FHeaderHeight;
        int FButtonHeight;
        TSectionBarButton FSelected;
        TSectionBarButton FDown;
        //        TOnSectionBarChanging FOnChanging;
        //        TOnSectionBarChanged FOnChanged;
        //        TNotifyEvent FOnLeftMouseDown;
        //        TNotifyEvent FOnRightMouseDown;
        //        TOnSectionBarButtonApplyDown FOnButtonApplyDown;

        int FUnderlineTextNum;
        int FEnterButton;
        bool FApplyDown;
        void SetSections(TSectionBarSections Value)
        {
            //          FSections.Assign(Value);
        }

        /*     TSectionBarSection* __fastcall GetActiveSection();
             void __fastcall SetActiveSection(TSectionBarSection* ASection);
             void DrawSection(int SectionNumber, TRect R);
             void DrawButton(int SectionNumber, int ButtonNumber, int &Y, int YMax, bool CalcOnly, TRect &TextArea);
             void DrawScrollButton(TRect R, bool Up);
             bool MouseInButton(int X, int Y, int  &Section, int &Button, bool &InTextArea);
             void __fastcall SetSelected(TSectionBarButton* Value);
             void __fastcall SetDown(TSectionBarButton* Value);
             void __fastcall SetApplyDown(const bool Value);
             void SelectFont(TFontIndex Index);
             void ReCreateFonts();
             void DestroyFonts();
             MESSAGE void __fastcall WMEraseBkGnd(TWMEraseBkgnd& M );// message WM_ERASEBKGND;
             MESSAGE void __fastcall WMSetFont(TWMSetFont&  M); //message WM_SETFONT;
             MESSAGE void __fastcall WMMouseMove(TWMMouseMove& Msg ); //message WM_MOUSEMOVE;
             MESSAGE void __fastcall WMLButtonDown(TWMLButtonDown& Msg); //message WM_LBUTTONDOWN;
             MESSAGE void __fastcall WMRButtonDown(TWMRButtonDown& Msg); //message WM_RBUTTONDOWN;
             MESSAGE void __fastcall WMLButtonDblClick(TWMMButtonDblClk& Msg);// message WM_LBUTTONDBLCLK;
             MESSAGE void __fastcall WMLButtonUp(TWMLButtonUp& Msg ); //message WM_LBUTTONUP;
             MESSAGE void __fastcall WMRButtonUp(TWMRButtonUp& Msg ); //message WM_RBUTTONUP;
             MESSAGE void __fastcall WMMouseLeave(TMessage& Msg);// CM_MOUSELEAVE

             protected:
         void __fastcall Paint(void);
             void __fastcall Notification(Classes::TComponent* AComponent, Classes::TOperation Operation);
             void __fastcall Loaded(void);


             __property TOnSectionBarChanging OnChanging = {read = FOnChanging, write = FOnChanging
         };
         __property TOnSectionBarChanged OnChanged = { read = FOnChanged, write = FOnChanged
     };

     public:

         virtual void ButtonChanging(TSectionBarButton* NewButton);
     virtual void ButtonChanged(TSectionBarButton* NewButton);
     virtual void Changed();
     void __fastcall  Assign(TPersistent* Source);
     int LastFullVisible();
     void DownFalse();*/
        public TGLSSectionBar()
        {
            int Index;
            FSections = new TSectionBarSections();
            FHeaderHeight = 17;//19;
            FButtonHeight = -1;
            FSectionHeaderPressed = -1;
            FButtonPressed = -1;
            FLastHintSection = -1;
            FLastHintButton = -1;
            FUnderlineTextNum = -1;
            FEnterButton = -1;
              /*       ControlStyle = ControlStyle << csOpaque;
                     Width = 100;
                     Align = alLeft;
                     FApplyDown = false;
                     FDown = NULL;
                     FOnLeftMouseDown = NULL;
                     FOnRightMouseDown = NULL;
                     FOnButtonApplyDown = NULL;

                     for (Index = fiHeader; Index <= fiButtonUnderline; Index++) FFonts[Index] = NULL;
                     ReCreateFonts();
                     Width = 100;*/
        }
        /*__fastcall ~TGLSSectionBar();
        __property TSectionBarSection* ActiveSection = { read = GetActiveSection, write = SetActiveSection };
        __property TSectionBarButton* Selected = { read = FSelected, write = SetSelected };
        __property TImageList* Images = { read = FImages, write = FImages };
        __property TSectionBarButton* Down = { read = FDown, write = SetDown };
        __property bool ApplyDown = { read = FApplyDown, write = SetApplyDown };
        __property TNotifyEvent LeftMouseDown  = {read = FOnLeftMouseDown, write = FOnLeftMouseDown};
            __property TNotifyEvent RightMouseDown = {read = FOnRightMouseDown, write = FOnRightMouseDown};
            __property TOnSectionBarButtonApplyDown OnButtonApplyDown = {read = FOnButtonApplyDown, write = FOnButtonApplyDown};


         __published:*/
        public TSectionBarSections Sections
        {
            get { return FSections; }
            set
            {
                SetSections(value);
            }
        }
        /*
        BEGIN_MESSAGE_MAP
          MESSAGE_HANDLER(WM_ERASEBKGND, TWMEraseBkgnd, WMEraseBkGnd)
            MESSAGE_HANDLER(WM_SETFONT, TWMSetFont, WMSetFont)
            MESSAGE_HANDLER(WM_MOUSEMOVE, TWMMouseMove, WMMouseMove)
            MESSAGE_HANDLER(WM_LBUTTONDOWN, TWMLButtonDown, WMLButtonDown)
            MESSAGE_HANDLER(WM_RBUTTONDOWN, TWMRButtonDown, WMRButtonDown)
            MESSAGE_HANDLER(WM_LBUTTONDBLCLK, TWMMButtonDblClk, WMLButtonDblClick)
            MESSAGE_HANDLER(WM_LBUTTONUP, TWMLButtonUp, WMLButtonUp)
            MESSAGE_HANDLER(WM_RBUTTONUP, TWMRButtonUp, WMRButtonUp)
            MESSAGE_HANDLER(CM_MOUSELEAVE, TMessage, WMMouseLeave)
          END_MESSAGE_MAP(TCustomControl);*/
    }
}
