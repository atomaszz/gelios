using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TSectionBarSections
    {
        TSectionBarSection FActiveItem;
        public List<TSectionBarSection> Items { set; get; }
        /*            TSectionBarSection* __fastcall GetItem(int Index);
                    void __fastcall SetItem(int Index, TSectionBarSection* Value);
                    void SetActiveItem(TSectionBarSection* AActiveItem);

                    protected:
                 DYNAMIC TPersistent* __fastcall GetOwner(void);
                    public:
                 TGLSSectionBar* FSectionBar;
                    __fastcall TSectionBarSections(TGLSSectionBar* SectionBar);
                    void ButtonChanging(TSectionBarButton* NewButton);
                    void ButtonChanged(TSectionBarButton* NewButton);
                    void Changed();*/
        public void Add()
        {
            Items.Add(new TSectionBarSection());
        }
        /*       int VisibleCount();*/


        //         __property TSectionBarSection * ActiveItem = { read = FActiveItem, write = SetActiveItem };*/
        public TSectionBarSections ()
        {
            Items = new List<TSectionBarSection>(); 
        }
    }
}
