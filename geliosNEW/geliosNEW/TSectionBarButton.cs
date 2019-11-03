using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TSectionBarButton
    {
        bool FSelected;
        bool FDown;
        int FImageIndex;
        int FTag1, FTag2;
     /*   void __fastcall  SetImageIndex(int AImageIndex);
        void __fastcall  SetSelected(const bool Value);

        protected:
     void __fastcall  SetVisible(bool AVisible);
        void __fastcall  SetEnabled(bool AEnabled);
        void InitProperties();

        public:
     void __fastcall Assign(TPersistent* Source);
        void MakeVisible();

        __published:
    __property int ImageIndex = { read = FImageIndex, write = SetImageIndex };
        __property bool Selected = { read = FSelected, write = SetSelected, default = false };*/
        public bool Down { set; get; }
  /*      __property int Tag1 = { read = FTag1, write = FTag1 };
        __property int Tag2 = { read = FTag2, write = FTag2 };*/
    }
}
