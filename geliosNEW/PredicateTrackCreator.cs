﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TPredicateTrackCreatorItem
    {
        List<object> f_List;
        /*    int __fastcall GetCount();
            TPredicateScannerItemKnot* __fastcall GetItems(int AIndex);
            AnsiString __fastcall GetText();
            public:
         TPredicateTrackCreatorItem();
            ~TPredicateTrackCreatorItem();
            bool FindKnot(TPredicateScannerItemKnot* AKnot);
            void AddKnot(TPredicateScannerItemKnot* AKnot);
            void PushKnot(TPredicateScannerItemKnot* AKnot);
            void DeleteKnot(TPredicateScannerItemKnot* AKnot);*/
            public void Clear() { f_List.Clear(); }
     /*       int CountKnotByParentID(int AID);
            void GetBadKnot(TDynamicArray* OutKnot);
            __property int Count = { read = GetCount };
            __property TPredicateScannerItemKnot* Items[int AIndex] = {read = GetItems
        };
        __property AnsiString Text = {read = GetText*/
    }
    class TPredicateTrackCreator
    {
        List<object> f_List;
        List<object> f_ListBase;
        TPredicateTrackCreatorItem f_BaseTrack;
        /*int __fastcall GetCount();*/
        void FreeList()
        {
            f_List.Clear();
        }
        /*     TPredicateTrackCreatorItem* __fastcall GetItems(int AIndex);
             public:
              TPredicateTrackCreator();
             ~TPredicateTrackCreator();*/
        public void ClearTrack()
        {
            FreeList();
        }
        public void ClearBase()
        {
            f_BaseTrack.Clear();
        }
        /*       TPredicateScannerItemKnot* CreateKnotToBase();
               TPredicateTrackCreatorItem* CreateItem();
               TPredicateTrackCreatorItem* CloneItem(TPredicateTrackCreatorItem* ASource);
               void GetAllTrack(TPredicateTrackCreatorItem* AItem, TDynamicArray* OutTrack);
               void GetNegativeDecidedKnot(TPredicateTrackCreatorItem* AItem, TDynamicArray* OutKnot);

               __property int Count = { read = GetCount };
               __property TPredicateTrackCreatorItem* Items[int AIndex] = {read = GetItems
           };
           __property TPredicateTrackCreatorItem* BaseTrack = { read = f_BaseTrack };*/
    }
}