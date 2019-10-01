using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TSectionBarSection : TSectionBarBaseItem
    {
        private bool FActive;
        List<TSectionBarButtons> FButtons;
        public TSectionBarButtons Buttons { set; get; }
        public TSectionBarSection()
        {
            Buttons = new TSectionBarButtons();
        }
        /*        int FTopButton;

                void __fastcall SetTopButton(int ATopButton);
                void __fastcall SetButtons(TSectionBarButtons* Value);
                void __fastcall SetActive(bool const Value);

                protected:
            void __fastcall SetVisible(bool AVisible);
                void __fastcall SetEnabled(bool AEnabled);
                void __fastcall SetIndex(int Value);
                int VisibleCount(int StartFrom);
                bool NextVisible(int &ButtonNo);

                public:
            void Changed();
                void __fastcall Assign(TPersistent* Source);
                void InitProperties();
                __fastcall ~TSectionBarSection();
                __property int TopButton = { read = FTopButton, write = SetTopButton };

                __published:
            __property bool Active = { read = FActive, write = SetActive };
                __property TSectionBarButtons* Buttons = {read = FButtons, write = SetButtons
            };*/
    }
}
