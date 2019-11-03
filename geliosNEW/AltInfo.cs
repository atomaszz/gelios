using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAltInfoItem
    {
        int f_Id;
        int f_Num;
        int f_ParentShapeId;
        TNodeMain f_NodeStart;
        TNodeMain f_NodeEnd;
        bool f_Main;
        public TAltInfoItem()
        {
            f_Id = 0;
            f_Num = 0;
            f_ParentShapeId = 0;
            f_NodeStart = null;
            f_NodeEnd = null;
            f_Main = false;
        }
       public int ID
        {
            get { return f_Id; }
        }
        public int Num
        {
            get { return f_Num; }
        }
        public int ParentShapeId
        {
            get { return f_ParentShapeId; }
        }

        public TNodeMain NodeStart
        {
            set { f_NodeStart = value; }
            get { return f_NodeStart; }
        }

        public TNodeMain NodeEnd
        {
            set { f_NodeEnd = value; }
            get { return f_NodeEnd; }
        }
        public bool Main
        {
            set { f_Main = value; }
            get { return f_Main; }
        }
    }
    class TAltInfo
    {
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
        int  GetItemCount()
        {
            return f_List.Count;
        }
     /*       TAltInfoItem  GetItem(int AIndex);
            TAltInfoItem FindItem(int AId, int ANum, int AParentShapeId);*/

        public TAltInfo()
        {
            f_List = new List<object>();
        }
           ~TAltInfo() { }
        public void Clear()
        {
            FreeList();
        }
      /*     TAltInfoItem* AddAltIfo(int AId, int ANum, int AParentShapeId, TNodeMain* ANodeStart, TNodeMain* ANodeEnd);*/
           public  int ItemCount
        {
            get { return GetItemCount(); }
        }

     /*      __property TAltInfoItem* Item[int AIndex] = {read = GetItem*/
    }
}
