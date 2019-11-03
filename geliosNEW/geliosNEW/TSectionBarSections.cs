using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TSectionBarSections
    {
        List<TSectionBarSection> Items;
        TSectionBarSection FActiveItem;
        public int Count()
        {
            return Items.Count;
        }
        public TSectionBarSection GetItem(int i)
        {
            return Items[i];
        }
        /*     TSectionBarSection* __fastcall GetItem(int Index);
             void __fastcall SetItem(int Index, TSectionBarSection* Value);
             void SetActiveItem(TSectionBarSection* AActiveItem);

             protected:
          DYNAMIC TPersistent* __fastcall GetOwner(void);
             public:
          TGLSSectionBar* FSectionBar;
             __fastcall TSectionBarSections(TGLSSectionBar* SectionBar);
             void ButtonChanging(TSectionBarButton* NewButton);
             void ButtonChanged(TSectionBarButton* NewButton);
             void Changed();
             TSectionBarSection* Add();
             int VisibleCount();*/
    };
    /*     __property TSectionBarSection * ActiveItem = { read = FActiveItem, write = SetActiveItem };*/
}

