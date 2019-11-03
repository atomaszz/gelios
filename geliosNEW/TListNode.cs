using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{

    class TListNode
    {
        public delegate void TListChange();

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

        TListChange FOnListChange;
        TStackDustController f_StackDustController;

        TNodeAlt CheckFirstNodeAlt()
        {
            TNodeAlt Alt;
            if (AlternateList.Count == 1)
            {
                Alt = (TNodeAlt)(AlternateList.ElementAt(0));
                if (Alt.NodeStart == null) return Alt;
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
            void CheckDeleteAlternate(TBaseWorkShape AWS);*/
        TNodeAncestor IsExistsNodeAncestor(int AIdBlock, int AIdShapeAncestor)
        {
            TNodeAncestor currNode;
            for (int i = AncestorList.Count - 1; i >= 0; i--)
            {
                currNode = (TNodeAncestor)AncestorList.ElementAt(i);
                if ((currNode.IdBlock == AIdBlock) && (currNode.IdShapeAncestor == AIdShapeAncestor))
                    return currNode;
            }
            return null;
        }

        TNodeAncestor DoAddNodeAncestor(int AIdBlock, int AIdShapeAncestor)
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
<<<<<<< HEAD
        int GetAlternateCount()
        {
            return AlternateList.Count;
        }

    /*    TNodeAlt GetAlternateItem(int AIndex)
        {
      /*      if (AIndex >= 0 && AIndex <= AlternateList.Count - 1)
                return (TNodeAlt)(AlternateList.Items[AIndex]);
            else
                return null;
        }*/
    /*        void SaveParamAlternateToXML(TBaseShape ATFE, TGlsXmlElement AElement);
            void SaveParamAlternateToBin(TBaseShape ATFE, SF_TFE A_tfe, THandle AFile);
            void SaveOgrSovmToXML(TDischargedMassiv AOgrSovm, TGlsXmlElement AElement);
            void SaveTypeDecision(TGlsXmlElement AElement);
            void SaveOgrSovmToBin(TDischargedMassiv AOgrSovm, THandle AFile);
            void SaveTypeDecisionToBin(THandle AFile);*/
  /*      public TListNode()
=======
    /*    int GetAlternateCount();
        TNode GetAlternateItem(int AIndex);
        void SaveParamAlternateToXML(TBaseShape ATFE, TGlsXmlElement AElement);
        void SaveParamAlternateToBin(TBaseShape ATFE, SF_TFE A_tfe, THandle AFile);
        void SaveOgrSovmToXML(TDischargedMassiv AOgrSovm, TGlsXmlElement AElement);
        void SaveTypeDecision(TGlsXmlElement AElement);
        void SaveOgrSovmToBin(TDischargedMassiv AOgrSovm, THandle AFile);
        void SaveTypeDecisionToBin(THandle AFile);*/
        public TListNode()
>>>>>>> parent of 7032bbe... next gen
        {
            TNodeAlt Alt;
            MainList = new List<object>();
            AncestorList = new List<object>();
            AlternateList = new List<object>();
            Searcher = new TNodeSearchController();
            Searcher.SetMainList(this);
            FOnListChange = null;
            f_Update = false;
            f_Changes = false;
            f_StackDustController = new TStackDustController();
        }*/
        ~TListNode() { }
        public TNodeMain FindLastNodeToAlternate(int AltId, int ANumAlt, int AIdParenShape)
        {
            TNodeMain TempN;
            for (int i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = (TNodeMain)MainList.ElementAt(i);
                if ((TempN.IdAlternate == AltId) && (TempN.NumAlt == ANumAlt)
                  && (TempN.IdParentShape == AIdParenShape))
                    if (TempN.Next==null) return TempN;
            }
            return null;
        }
        public void FillPainterList(TPainterList PainterList, int AltId, int ANumAlt, int IdParentShape)
        {
            TBaseWorkShape WShape;
            int uid = 0;
            PainterList.List.Clear();
            WShape = FindFirstChild(AltId, ANumAlt, IdParentShape, ref uid);
            while (WShape!=null)
            {
                PainterList.List.Add(WShape);
                WShape = FindNextChild(uid);
            }
            DisableFind(uid);
        }
        public void AddShapeToList(int AltId, int ANumAlt, TBaseWorkShape WShape, int IdParentShape)
        {
            TNodeMain Nd;
            TNodeMain NPrior;
            TNodeAncestor NAc;
            int ParentBlock;
            int pos = 0;
            if (!CheckAlternateNode(AltId, ANumAlt)) return;
            NPrior = FindLastNodeToAlternate(AltId, ANumAlt, IdParentShape);

            Nd = new TNodeMain();
            Nd.IdBlock = WShape.BlockId;  //s
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

            TNodeAlt NAlt = CheckFirstNodeAlt();
            if ((NAlt!=null) && (AltId == 0))
                NAlt.NodeStart = Nd;

            if (IdParentShape != 0)
            {
                DoAddNodeAncestor(Nd.IdBlock, Nd.IdParentShape);
                while (true)
                {
                    if (Nd.IdParentShape == 0) return;
                    ParentBlock = FindBlockOutShape(Nd.IdParentShape);


                    Nd = FindNode(ParentBlock, ref pos);
                    if (Nd.IdParentShape != 0)
                        DoAddNodeAncestor(Nd.IdBlock, Nd.IdParentShape);
                }
            }
        }
    /*         public void InsertShapeToList(int AltId, int ANumAlt, TBaseWorkShape WBefore, TBaseWorkShape WShape, int IdParentShape);
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
        public TNodeMain FindNode(int IdBlock, ref int pos)
        {
            int i = -1;
            pos = i;
            TNodeMain TempN;
            for (i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = (TNodeMain)MainList.ElementAt(i);
                if (TempN.IdBlock == IdBlock)
                {
                    pos = i;
                    return (TempN);
                }
            }
            return (null);
        }
        public TNodeMain FindNode(TBaseWorkShape WShape)
        {
            TNodeMain TempN;
            for (int i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = (TNodeMain)MainList.ElementAt(i);
                if (TempN.WorkShape == WShape)
                    return (TempN);
            }
            return (null);
        }
        public int FindBlockOutShape(int IdShape)
        {
            int i, j, mn, mx;
            TNodeMain TempN;
            for (i = 0; i <= MainList.Count - 1; i++)
            {
                TempN = (TNodeMain)MainList.ElementAt(i);
                mn = TempN.WorkShape.FirstShapeId;
                mx = TempN.WorkShape.LastShapeId;
                if ((IdShape >= mn) && (IdShape <= mx))
                    return TempN.IdBlock;
            }
            return 0;
        }
        public TBaseWorkShape FindFirstChild(int AltId, int ANumAlt, int IdParentShape, ref int AUid)
        {
            return Searcher.FindFirstChild(AltId, ANumAlt, IdParentShape, ref AUid);
        }
        public TBaseWorkShape FindNextChild(int AUid)
        {
            return Searcher.FindNextChild(AUid);
        }
        public bool DisableFind(int AUid)
        {
            return Searcher.DisableFind(AUid);
        }
   /*     public bool IsFirstWorkShape(TBaseWorkShape WShape, int AltId, int ANumAlt, int IdParentShape);
        public TBaseWorkShape GetLastWorkShape(int AltId, int ANumAlt, int IdParentShape);
        public bool IsEmpty();
        public int DecayWorkShape(TBaseWorkShape WDecay, TBaseWorkShape WN1, TBaseWorkShape WN2);
        public void FusionWorkShape(TBaseWorkShape WFusion, TBaseWorkShape WN1, TBaseWorkShape WN2);
        public TBaseWorkShape FindWorkShapeOutBaseShape(TBaseShape Shape, int &ShapeId);
        public TBaseWorkShape FindWorkShapeOutBaseShapeID(int ShapeID, TBaseShape Shape);*/
        public bool CreateAlternate(TBaseWorkShape WS, TBaseWorkShape WE, int AID, int ANumAlt)
        {
            TNodeAlt Alt;
            TNodeMain NS, NE;
            if (WS==null && WE == null)
            {
                Alt = new TNodeAlt();
                Alt.ID = AID;
                Alt.NodeStart = null;
                Alt.NodeEnd = null;
                Alt.Num = ANumAlt;
          //      AlternateList.Add(Alt);
                return true;
            }
            NS = FindNode(WS);
            NE = FindNode(WE);
            if ((NS==null) || (NE == null)) return false;
            for (int i = 0; i <= AlternateList.Count - 1; i++)
            {
                Alt = (TNodeAlt)AlternateList.ElementAt(i);
                if (Alt.ID == AID)
                    return false;
            }
            Alt = new TNodeAlt();
            Alt.ID = AID;
            Alt.NodeStart = NS;
            Alt.NodeEnd = NE;
            Alt.Num = ANumAlt;
            AlternateList.Add(Alt);
            return true;
        }
  /*      public int AddAlternate(TBaseWorkShape WS, TBaseWorkShape WE, int AID);
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


<<<<<<< HEAD
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
            public TNode CheckAlternateWSEnd(TBaseWorkShape AWS);*/
        public void LoadInfoForAlternate(TAltInfo AltIfo, int AParentShapeID)
        {
            TNodeAlt Itm;
            TNodeMain Node, First, Last;
            TAltInfoItem AI;
            AltIfo.Clear();
            for (int i = 0; i <= AlternateCount - 1; i++)
            {
         //       Itm = GetAlternateItem(i);
            /*    if (Itm.NodeStart.IdParentShape == AParentShapeID)
                {
         /*           AI = AltIfo.AddAltIfo(Itm.ID, Itm.Num, AParentShapeID, Itm.NodeStart, Itm.NodeEnd);
                    if (AI && (Itm.ID == 0) && (Itm.Num == 0) && (AParentShapeID == 0))
                        AI.Main = true;

                }*/
            }
            for (int i = 0; i <= MainList.Count - 1; i++)
            {
         /*       Node = static_cast<TNodeMain*>(MainList.Items[i]);
                if (Node && Node.IdParentShape == AParentShapeID)
                {
                    AI = AltIfo.AddAltIfo(Node.IdAlternate, Node.NumAlt, AParentShapeID, First, Last);
                    if (AI!=null)
                    {
                        AI.Main = true;
                        First = Node;
                        while (First.Prior != null)
                            First = First.Prior;

                        Last = Node;
                        while (Last.Next != null)
                            Last = Last.Next;

                        AI.NodeStart = First;
                        AI.NodeEnd = Last;
                    }
                }*/
            }
        }
        /*   public  bool GetAlternateInfo(int AShapeID, int &AltID, int &NumAlt, int &IDParent);*/
=======
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
        public  bool GetAlternateInfo(int AShapeID, int &AltID, int &NumAlt, int &IDParent);*/
>>>>>>> parent of 7032bbe... next gen
        public void GetAllWorkShape(TDynamicArray AMass)
        {
            if (AMass!=null)
            {
                AMass.Clear();
                for (int i = 0; i <= MainList.Count - 1; i++)
                    AMass.Append(((TNodeMain)(MainList.ElementAt(i))).WorkShape);
            }

        }
        /*    public void SaveAllToFileBin(AnsiString AFileName, int ATypeParam, TDischargedMassiv AOgrSovm);


            public TStackDustController* StackDustController = {read = f_StackDustController*/
        public TListChange OnListChange
        {
            set { FOnListChange = value; }
            get { return FOnListChange;  }
        }

/*        public int NodeMaxID = { read = GetNodeMaxID };
        public int TFEMaxID = { read = GetTFEMaxID };
        public int AlternateMaxID = { read = GetAlternateMaxID };
        public int AlternateCount = { read = GetAlternateCount };
        public TNode AlternateItem[int AIndex] = { read = GetAlternateItem };
        public bool Changes = { read = f_Changes, write = f_Changes }; */
    }
}
