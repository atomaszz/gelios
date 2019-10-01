using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

namespace geliosNEW
{
    public class TSectionBarButtons : TSectionBarBaseCollection
    {
        public List<TSectionBarButton> Items { set; get; }
        public TSectionBarButtons()
        {
            Items = new List<TSectionBarButton>();
        }
        public void Add()
        {
            Items.Add(new TSectionBarButton());
        }
        /*        private:
             TSectionBarButton* __fastcall GetItem(int Index);
                void __fastcall SetItem(int Index, TSectionBarButton* Value);

                protected:
             DYNAMIC TPersistent* __fastcall GetOwner(void);

                public:
             void ButtonChanging(TSectionBarButton* NewButton);
                void ButtonChanged(TSectionBarButton* NewButton);
                void Changed();
                TSectionBarSection* FSection;
                __fastcall TSectionBarButtons(TSectionBarSection* Section);
                __property TSectionBarButton* Items[int Index] = { read =  GetItem, write = SetItem
            };*/
    }
}
