using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{

    class TListNode
    {
        bool f_Update;
        bool f_Changes;
        TNodeSearchController Searcher;
        List<object> MainList;
        List<object> AncestorList;
        List<object> AlternateList;
        bool CheckAlternateNode(int ID, int ANumAlt)
        {
            TNodeAlt Alt;
            for (int i = 0; i <= AlternateList.Count - 1; i++)
            {
                Alt = (TNodeAlt)AlternateList.ElementAt(i);
                if ((Alt.ID == ID) && (Alt.Num == ANumAlt)) return true;
            }
            return false;
        }

     /*   TListChange FOnListChange;*/
        TStackDustController f_StackDustController;

        TNodeAlt CheckFirstNodeAlt()
        {
            TNodeAlt Alt;
            if (AlternateList.Count == 1)
            {
                Alt = (TNodeAlt)(AlternateList.ElementAt(0));
                if (Alt.NodeStart==null) return Alt;
            }
            return null;
        }
        TNodeMain FindPriorNodeToAlternate(int AltId, TBaseWorkShape WBefore)
        {
            TNodeMain TempN;
            for (int i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = (TNodeMain)(MainList.ElementAt(i));
                if (TempN.IdAlternate == AltId)
                    if (TempN.WorkShape == WBefore) return TempN;
            }
            return null;
        }

        void FreeListMain()
        {
            for (int i = MainList.Count - 1; i >= 0; i--)
            {
                MainList.RemoveAt(i);
            }
        }
    /*    void FreeListAncestor();
        void FreeListAlternate();
        int GetNodeMaxID();
        int GetTFEMaxID();
        int GetAlternateMaxID();
        void CheckDeleteAlternate(TBaseWorkShape AWS);
        TNodeAncestor IsExistsNodeAncestor(int AIdBlock, int AIdShapeAncestor);
        TNodeAncestor DoAddNodeAncestor(int AIdBlock, int AIdShapeAncestor);
        int GetAlternateCount();
        TNode GetAlternateItem(int AIndex);
        void SaveParamAlternateToXML(TBaseShape ATFE, TGlsXmlElement AElement);
        void SaveParamAlternateToBin(TBaseShape ATFE, SF_TFE A_tfe, THandle AFile);
        void SaveOgrSovmToXML(TDischargedMassiv AOgrSovm, TGlsXmlElement AElement);
        void SaveTypeDecision(TGlsXmlElement AElement);
        void SaveOgrSovmToBin(TDischargedMassiv AOgrSovm, THandle AFile);
        void SaveTypeDecisionToBin(THandle AFile);*/
        public TListNode()
        {
            TNodeAlt Alt;
            MainList = new List<object>();
            AncestorList = new List<object>();
            AlternateList = new List<object>();
            Searcher = new TNodeSearchController();
            Searcher.SetMainList(this);
       //     FOnListChange = null;
            f_Update = false;
            f_Changes = false;
            f_StackDustController = new TStackDustController();
        }
        ~TListNode() { }
        /*     public TNodeMain FindLastNodeToAlternate(int AltId, int ANumAlt, int AIdParenShape);
             public void FillPainterList(TPainterList PainterList, int AltId, int ANumAlt, int IdParentShape);
             public void AddShapeToList(int AltId, int ANumAlt, TBaseWorkShape WShape, int IdParentShape);
             public void InsertShapeToList(int AltId, int ANumAlt, TBaseWorkShape WBefore, TBaseWorkShape WShape, int IdParentShape);
             public int DeleteBlock(int IdBlock);
             public void ClearDeleteBlock();
             public bool IsContainsChildBlock(int IdBlock);*/
        public bool IsContainsChildShape(int IdShape)
        {
            int i;
            TNodeAncestor currNode;
            for (i = AncestorList.Count - 1; i >= 0; i--)
            {
                currNode = (TNodeAncestor)AncestorList.ElementAt(i);
                if (currNode.IdShapeAncestor == IdShape)
                    return true;
            }
            return false;
        }
     /*   public TNodeMain FindNode(int IdBlock, int &pos);
        public TNodeMain FindNode(TBaseWorkShape WShape);
        public int FindBlockOutShape(int IdShape);
        public TBaseWorkShape FindFirstChild(int AltId, int ANumAlt, int IdParentShape, int &AUid);
        public TBaseWorkShape FindNextChild(int AUid);
        public bool DisableFind(int AUid);
        public bool IsFirstWorkShape(TBaseWorkShape WShape, int AltId, int ANumAlt, int IdParentShape);
        public TBaseWorkShape GetLastWorkShape(int AltId, int ANumAlt, int IdParentShape);
        public bool IsEmpty();
        public int DecayWorkShape(TBaseWorkShape WDecay, TBaseWorkShape WN1, TBaseWorkShape WN2);
        public void FusionWorkShape(TBaseWorkShape WFusion, TBaseWorkShape WN1, TBaseWorkShape WN2);
        public TBaseWorkShape FindWorkShapeOutBaseShape(TBaseShape Shape, int &ShapeId);
        public TBaseWorkShape FindWorkShapeOutBaseShapeID(int ShapeID, TBaseShape Shape);
        public bool CreateAlternate(TBaseWorkShape WS, TBaseWorkShape WE, int AID, int ANumAlt);
        public int AddAlternate(TBaseWorkShape WS, TBaseWorkShape WE, int AID);
        public bool AddAlternate(int AID, int ANumAlt);
        public int DeleteAlternate(int AID, int ANum);*/
        public TNodeMain SearchFirstNodeToAlternate(int AltId, int ANumAlt, int IdParentShape)
        {
            TNodeMain TempN;
            for (int i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = (TNodeMain)(MainList.ElementAt(i));
                if ((TempN.IdAlternate == AltId) && (TempN.NumAlt == ANumAlt) && (TempN.IdParentShape == IdParentShape))
                    if (TempN.Prior==null) return TempN;
            }
            return null;
        }
        public TNodeMain SearchNextNodeToAlternate(int AltId, int ANumAlt, TNodeMain Node)
        {
            TNodeMain TempN;
            if (Node==null) return null;
            for (int i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = (TNodeMain)MainList.ElementAt(i);
                if ((TempN.IdAlternate == AltId) && (TempN.NumAlt == ANumAlt))
                    if (TempN.Prior!=null)
                        if (TempN.Prior == Node) return TempN;
            }
            return null;
        }
    /*    public TNodeMain SearchFirstNodeToAlternate2(int AltId, int IdParentShape);
        public TNodeMain SearchNextNodeToAlternate2(int AltId, TNodeMain Node);
        public TNodeMain SearchFirstNodeToAlternate3(int AltId, int ANumAlt);
        public TNodeMain SearchNextNodeToAlternate3(int AltId, TNodeMain Node);


        public bool PrepareLinksBeforeDelete(TBaseWorkShape AWS);
        public void FillNodeAncestor(TNodeMain ANode);


        public TBaseWorkShape FindNextNode(TBaseWorkShape W);
        public TBaseWorkShape FindPriorNode(TBaseWorkShape W);
        public TNodeMain FindNextNode2(TBaseWorkShape W);
        public TNodeMain FindPriorNode2(TBaseWorkShape W);

        public bool CompareWorkShape(TBaseWorkShape WS, TBaseWorkShape WE);
        public bool GetWSToAlternate(int AId, TBaseWorkShape AWSFirst, TBaseWorkShape AWSLast);
        public void BeginUpdate();
        public void EndUpdate();
        public void ClearAll();
        public void PrepareDeleteWorkShape(TBaseWorkShape AWS);
        public int DeleteWorkShape();
        public void SaveAllToFile(AnsiString AFileName, int ATypeParam, TDischargedMassiv AOgrSovm);
        public TNodeMain CreateNode(TBaseWorkShape WS);
        public TNodeAncestor CreateNodeAncestor(int AId, int AIdAncestor);
        public void PrepareAddNode(TNodeMain Nd);
        public void ClearNodeTypeCreate();
        public TNode CheckAlternateWSFirst(TBaseWorkShape AWS);
        public TNode CheckAlternateWSEnd(TBaseWorkShape AWS);
        public void LoadInfoForAlternate(TAltInfo AltIfo, int AParentShapeID);
        public  bool GetAlternateInfo(int AShapeID, int &AltID, int &NumAlt, int &IDParent);
        public void GetAllWorkShape(TDynamicArray AMass);
        public void SaveAllToFileBin(AnsiString AFileName, int ATypeParam, TDischargedMassiv AOgrSovm);


        public TStackDustController* StackDustController = {read = f_StackDustController
        public TListChange  OnListChange = {read = FOnListChange, write = FOnListChange
        public int NodeMaxID = { read = GetNodeMaxID };
        public int TFEMaxID = { read = GetTFEMaxID };
        public int AlternateMaxID = { read = GetAlternateMaxID };
        public int AlternateCount = { read = GetAlternateCount };
        public TNode AlternateItem[int AIndex] = { read = GetAlternateItem };
        public bool Changes = { read = f_Changes, write = f_Changes }; */
    }
}
