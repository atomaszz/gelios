using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TSectionBarButtons
    {
        List<TSectionBarButton> Items;
        public int Count()
        {
            return Items.Count;
        }
        public TSectionBarButton GetItem(int i)
        {
            return Items[i];
        }
        /*
     TSectionBarButton __fastcall GetItem(int Index);
        void __fastcall SetItem(int Index, TSectionBarButton* Value);

        protected:
     DYNAMIC TPersistent* __fastcall GetOwner(void);

        public:
     void ButtonChanging(TSectionBarButton* NewButton);
        void ButtonChanged(TSectionBarButton* NewButton);
        void Changed();
        TSectionBarSection* FSection;
        __fastcall TSectionBarButtons(TSectionBarSection* Section);
        TSectionBarButton* Add();
        __property TSectionBarButton* Items[int Index] = { read =  GetItem, write = SetItem
            */
    };
}

