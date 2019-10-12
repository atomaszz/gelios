using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TPredicateTrackCreatorItem
    {
        private List<object> f_List;
    /*    int GetCount();
        TPredicateScannerItemKnot GetItems(int AIndex);
        string GetText();
        public TPredicateTrackCreatorItem();
        ~TPredicateTrackCreatorItem() { }
        public bool FindKnot(TPredicateScannerItemKnot* AKnot);
        public void AddKnot(TPredicateScannerItemKnot* AKnot);
        public void PushKnot(TPredicateScannerItemKnot* AKnot);
        void DeleteKnot(TPredicateScannerItemKnot* AKnot);
        public void Clear() { f_List->Clear(); }
        public int CountKnotByParentID(int AID);
        public void GetBadKnot(TDynamicArray* OutKnot);
        public int Count = { read = GetCount };
        public TPredicateScannerItemKnot* Items[int AIndex] = {read = GetItems
        public AnsiString Text = {read = GetText*/
    }
    public class TPredicateTrackCreator
    {
        private List<object> f_List;
        private List<object> f_ListBase;
        TPredicateTrackCreatorItem f_BaseTrack;
     /*         int  GetCount();
              void FreeList();
              publicTPredicateTrackCreatorItem  GetItems(int AIndex);*/

        public TPredicateTrackCreator()
        {
            f_List = new List<object>();
            f_ListBase = new List<object>();
            f_BaseTrack = new TPredicateTrackCreatorItem ();
        }
        ~TPredicateTrackCreator() { }
   /*     public void ClearTrack();
        public void ClearBase();
        public TPredicateScannerItemKnot* CreateKnotToBase();
        public TPredicateTrackCreatorItem* CreateItem();
        public TPredicateTrackCreatorItem* CloneItem(TPredicateTrackCreatorItem* ASource);
        public void GetAllTrack(TPredicateTrackCreatorItem* AItem, TDynamicArray* OutTrack);
        public void GetNegativeDecidedKnot(TPredicateTrackCreatorItem* AItem, TDynamicArray* OutKnot);

        public int Count = { read = GetCount };
        public TPredicateTrackCreatorItem* Items[int AIndex] = {read = GetItems

        public TPredicateTrackCreatorItem* BaseTrack = { read = f_BaseTrack };*/
    }
}
