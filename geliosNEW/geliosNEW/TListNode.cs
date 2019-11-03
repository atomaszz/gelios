using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    delegate void TListChange();
    class TListNode
    {
        bool f_Update;
        bool f_Changes;
  /*      TNodeSearchController* Searcher;*/
        List<TNodeMain> MainList;
        List<TNodeAncestor> AncestorList;
        List<TNodeAlt> AlternateList;
        TListChange FOnListChange;
      /*        TStackDustController* f_StackDustController;


              TNodeAlt* CheckFirstNodeAlt();
              TNodeMain* FindPriorNodeToAlternate(int AltId, TBaseWorkShape* WBefore);

              void FreeListMain();
              void FreeListAncestor();
              void FreeListAlternate();
              int __fastcall GetNodeMaxID();
              int __fastcall GetTFEMaxID();
              int __fastcall GetAlternateMaxID();
              void CheckDeleteAlternate(TBaseWorkShape* AWS);
              TNodeAncestor* IsExistsNodeAncestor(int AIdBlock, int AIdShapeAncestor);
              TNodeAncestor* DoAddNodeAncestor(int AIdBlock, int AIdShapeAncestor);
              int __fastcall GetAlternateCount();
              TNodeAlt* __fastcall GetAlternateItem(int AIndex);
              void SaveParamAlternateToXML(TBaseShape* ATFE, TGlsXmlElement* AElement);
              void SaveParamAlternateToBin(TBaseShape* ATFE, SF_TFE A_tfe, THandle AFile);
              void SaveOgrSovmToXML(TDischargedMassiv* AOgrSovm, TGlsXmlElement* AElement);
              void SaveTypeDecision(TGlsXmlElement* AElement);
              void SaveOgrSovmToBin(TDischargedMassiv* AOgrSovm, THandle AFile);
              void SaveTypeDecisionToBin(THandle AFile);
           TListNode();
              ~TListNode();*/
        TNodeMain FindLastNodeToAlternate(int AltId, int ANumAlt, int AIdParenShape)
        {
          TNodeMain TempN;
            for (int i = 0; i <= MainList.Count - 1 ; i++)
            {
                TempN = MainList[i];
                if ((TempN.IdAlternate == AltId) && (TempN.NumAlt == ANumAlt)
                    && (TempN.IdParentShape == AIdParenShape))
                    if (TempN.Next!=null) return TempN;
            }
            return null;
        }
         /*      void FillPainterList(TPainterList* PainterList, int AltId, int ANumAlt, int IdParentShape);*/
        bool CheckAlternateNode(int ID, int ANumAlt)
        {
            TNodeAlt Alt;
            for (int i = 0; i < AlternateList.Count; i++)
            {
                Alt = AlternateList[i];
                if ((Alt.ID == ID) && (Alt.Num == ANumAlt)) return true;
            }
            return false;
        }
        public void AddShapeToList(int AltId, int ANumAlt, TBaseWorkShape WShape, int IdParentShape)
        {
            TNodeMain Nd;
            TNodeMain NPrior;
            TNodeAncestor NAc;
            int ParentBlock;
            int pos;
            if (!CheckAlternateNode(AltId, ANumAlt)) return;
            NPrior = FindLastNodeToAlternate(AltId, ANumAlt, IdParentShape);

            Nd = new TNodeMain();
            Nd.IdBlock = WShape.F_BlockId;  //s
            Nd.IdParentShape = IdParentShape;
            Nd.WorkShape = WShape;
            Nd.IdAlternate = AltId;
            Nd.NumAlt = ANumAlt;
            if (NPrior!=null) //не первый узел
            {
                NPrior.Next = Nd;
                Nd.Prior = NPrior;
            }

            MainList.Add(Nd);
            if ((FOnListChange!=null) && (!f_Update)) OnListChange();
            f_Changes = true;

            if (IdParentShape != 0)
            {
                DoAddNodeAncestor(Nd.IdBlock, Nd.IdParentShape);
                while (true)
                {
                    if (Nd.IdParentShape == 0) return;
                    ParentBlock = FindBlockOutShape(Nd.IdParentShape);


                    Nd = FindNode(ParentBlock, out pos);
                    if (Nd.IdParentShape != 0)
                        DoAddNodeAncestor(Nd.IdBlock, Nd.IdParentShape);
                }
            }
        }
     /*   void InsertShapeToList(int AltId, int ANumAlt, TBaseWorkShape* WBefore, TBaseWorkShape* WShape, int IdParentShape);
        int DeleteBlock(int IdBlock);
        void ClearDeleteBlock();
        bool IsContainsChildBlock(int IdBlock);
        bool IsContainsChildShape(int IdShape);
        TNodeMain* FindNode(int IdBlock, int &pos);
        TNodeMain* FindNode(TBaseWorkShape* WShape);
        int FindBlockOutShape(int IdShape);
        TBaseWorkShape* FindFirstChild(int AltId, int ANumAlt, int IdParentShape, int &AUid);
        TBaseWorkShape* FindNextChild(int AUid);
        bool DisableFind(int AUid);
        bool IsFirstWorkShape(TBaseWorkShape* WShape, int AltId, int ANumAlt, int IdParentShape);
        TBaseWorkShape* GetLastWorkShape(int AltId, int ANumAlt, int IdParentShape);
        bool IsEmpty();
        int DecayWorkShape(TBaseWorkShape* WDecay, TBaseWorkShape* WN1, TBaseWorkShape* WN2);
        void FusionWorkShape(TBaseWorkShape* WFusion, TBaseWorkShape* WN1, TBaseWorkShape* WN2);
        TBaseWorkShape* FindWorkShapeOutBaseShape(TBaseShape* Shape, int &ShapeId);
        TBaseWorkShape* FindWorkShapeOutBaseShapeID(int ShapeID, TBaseShape** Shape);
        bool CreateAlternate(TBaseWorkShape* WS, TBaseWorkShape* WE, int AID, int ANumAlt);
        int AddAlternate(TBaseWorkShape* WS, TBaseWorkShape* WE, int AID);
        bool AddAlternate(int AID, int ANumAlt);
        int DeleteAlternate(int AID, int ANum);
        TNodeMain* SearchFirstNodeToAlternate(int AltId, int ANumAlt, int IdParentShape);
        TNodeMain* SearchNextNodeToAlternate(int AltId, int ANumAlt, TNodeMain* Node);
        TNodeMain* SearchFirstNodeToAlternate2(int AltId, int IdParentShape);
        TNodeMain* SearchNextNodeToAlternate2(int AltId, TNodeMain* Node);
        TNodeMain* SearchFirstNodeToAlternate3(int AltId, int ANumAlt);
        TNodeMain* SearchNextNodeToAlternate3(int AltId, TNodeMain* Node);


        bool PrepareLinksBeforeDelete(TBaseWorkShape* AWS);
        void FillNodeAncestor(TNodeMain* ANode);


        TBaseWorkShape* FindNextNode(TBaseWorkShape* W);
        TBaseWorkShape* FindPriorNode(TBaseWorkShape* W);
        TNodeMain* FindNextNode2(TBaseWorkShape* W);
        TNodeMain* FindPriorNode2(TBaseWorkShape* W);

        bool CompareWorkShape(TBaseWorkShape** WS, TBaseWorkShape** WE);
        bool GetWSToAlternate(int AId, TBaseWorkShape** AWSFirst, TBaseWorkShape** AWSLast);
        void BeginUpdate();
        void EndUpdate();
        void ClearAll();
        void PrepareDeleteWorkShape(TBaseWorkShape* AWS);
        int DeleteWorkShape();
        void SaveAllToFile(AnsiString AFileName, int ATypeParam, TDischargedMassiv* AOgrSovm);
        TNodeMain* CreateNode(TBaseWorkShape* WS);
        TNodeAncestor* CreateNodeAncestor(int AId, int AIdAncestor);
        void PrepareAddNode(TNodeMain* Nd);
        void ClearNodeTypeCreate();
        TNodeAlt* CheckAlternateWSFirst(TBaseWorkShape* AWS);
        TNodeAlt* CheckAlternateWSEnd(TBaseWorkShape* AWS);
        void LoadInfoForAlternate(TAltInfo* AltIfo, int AParentShapeID);
        bool GetAlternateInfo(int AShapeID, int &AltID, int &NumAlt, int &IDParent);
        void GetAllWorkShape(TDynamicArray* AMass);
        void SaveAllToFileBin(AnsiString AFileName, int ATypeParam, TDischargedMassiv* AOgrSovm);*/


      /*  __property TStackDustController* StackDustController = {read = f_StackDustController};*/
    TListChange  OnListChange { set; get; }
        /*__property int NodeMaxID = { read = GetNodeMaxID };
        __property int TFEMaxID = { read = GetTFEMaxID };
        __property int AlternateMaxID = { read = GetAlternateMaxID };
        __property int AlternateCount = { read = GetAlternateCount };
        __property TNodeAlt* AlternateItem[int AIndex] = { read = GetAlternateItem };
        __property bool Changes = { read = f_Changes, write = f_Changes }; */
        public TNodeAncestor DoAddNodeAncestor(int AIdBlock, int AIdShapeAncestor)
        {
            TNodeAncestor Res = IsExistsNodeAncestor(AIdBlock, AIdShapeAncestor);
            if (Res==null)
            {
                TNodeAncestor NAc = new TNodeAncestor();
                NAc.IdBlock = AIdBlock;
                NAc.IdShapeAncestor = AIdShapeAncestor;
                AncestorList.Add(NAc);
                Res = NAc;
            }
            return Res;
        }
        TNodeAncestor IsExistsNodeAncestor(int AIdBlock, int AIdShapeAncestor)
        {
            TNodeAncestor currNode;
            for (int i = AncestorList.Count - 1; i >= 0; i--)
            {
                currNode = AncestorList[i];
                if ((currNode.IdBlock == AIdBlock) && (currNode.IdShapeAncestor == AIdShapeAncestor))
                    return currNode;
            }
            return null;
        }
        int FindBlockOutShape(int IdShape)
        {
            int i, j, mn, mx;
            TNodeMain TempN;
            for (i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = MainList[i];
                mn = TempN.WorkShape.F_NumberShapeId;
                mx = TempN.WorkShape.F_LastShapeId;
                if ((IdShape >= mn) && (IdShape <= mx))
                    return TempN.IdBlock;
            }
            return 0;
        }
        TNodeMain FindNode(int IdBlock, out int pos)
        {
            int i = -1;
            pos = i;
            TNodeMain TempN;
            for (i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = MainList[i];
                if (TempN.IdBlock == IdBlock)
                {
                    pos = i;
                    return (TempN);
                }
            }
            return null;
        }
    }


}
