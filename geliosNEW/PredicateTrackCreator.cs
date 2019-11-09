using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TPredicateTrackCreatorItem
    {
        List<object> f_List;
        /*    int __fastcall GetCount();
            TPredicateScannerItemKnot* __fastcall GetItems(int AIndex);
            AnsiString __fastcall GetText();*/
        public TPredicateTrackCreatorItem()
        {
            f_List = new List<object>();
        }

        ~TPredicateTrackCreatorItem() { }
        bool FindKnot(TPredicateScannerItemKnot AKnot)
        {
            return f_List.IndexOf(AKnot) >= 0;
        }
        public void AddKnot(TPredicateScannerItemKnot AKnot)
        {
            if (!FindKnot(AKnot))
                f_List.Add(AKnot);
        }
        /*        void PushKnot(TPredicateScannerItemKnot* AKnot);
                void DeleteKnot(TPredicateScannerItemKnot* AKnot);*/
        public void Clear() { f_List.Clear(); }
     /*       int CountKnotByParentID(int AID);
            void GetBadKnot(TDynamicArray* OutKnot);
            __property int Count = { read = GetCount };
            __property TPredicateScannerItemKnot* Items[int AIndex] = {read = GetItems
        };
        __property AnsiString Text = {read = GetText*/
    }
    public class TPredicateTrackCreator
    {
        List<object> f_List;
        List<object> f_ListBase;
        TPredicateTrackCreatorItem f_BaseTrack;
        public int GetCount()
        {
            return f_List.Count;
        }

        void FreeList()
        {
            f_List.Clear();
        }
        public TPredicateTrackCreatorItem GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TPredicateTrackCreatorItem)(f_List.ElementAt(AIndex));
            else
                return null;
        }
        public TPredicateTrackCreator()
        {
            f_List = new List<object>();
            f_ListBase = new List<object>();
            f_BaseTrack = new TPredicateTrackCreatorItem();
        }
        ~TPredicateTrackCreator() { }
        public void ClearTrack()
        {
            FreeList();
        }
        public void ClearBase()
        {
            f_BaseTrack.Clear();
        }
        public TPredicateScannerItemKnot CreateKnotToBase()
        {
            TPredicateScannerItemKnot N = new TPredicateScannerItemKnot();
            f_ListBase.Add(N);
            f_BaseTrack.AddKnot(N);
            return N;
        }
        /*          TPredicateTrackCreatorItem* CreateItem();
                  TPredicateTrackCreatorItem* CloneItem(TPredicateTrackCreatorItem* ASource);
                  void GetAllTrack(TPredicateTrackCreatorItem* AItem, TDynamicArray* OutTrack);
                  void GetNegativeDecidedKnot(TPredicateTrackCreatorItem* AItem, TDynamicArray* OutKnot);

                  __property int Count = { read = GetCount };
                  __property TPredicateTrackCreatorItem* Items[int AIndex] = {read = GetItems
              };
              __property TPredicateTrackCreatorItem* BaseTrack = { read = f_BaseTrack };*/
    }
}
