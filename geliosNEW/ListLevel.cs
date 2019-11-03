using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TLevelItem
    {
        int f_IdParentShape;
        int f_X_offsSum, f_Y_offsSum;
        public TLevelItem()
        {
            f_IdParentShape = 0;
            f_X_offsSum = f_Y_offsSum = 0;
        }
        public  int IdParentShape
        {
            set { f_IdParentShape = value; }
            get { return f_IdParentShape; }
        }
        public  int X_offsSum
        {
            set { f_X_offsSum = value; }
            get { return f_X_offsSum; }
        }
        public  int Y_offsSum
        {
            set { f_Y_offsSum = value; }
            get { return f_Y_offsSum; }
        }
    };

    class TLevelController
    {
        List<object> f_List;
        TLevelItem f_CurrentLevel;
        void FreeList()
        {
            for (int i = f_List.Count - 1; i >= 0; i--)
            {
                f_List.RemoveAt(i);
            }
        }
        TLevelItem FindLevel(int AIdParentShape)
        {
            TLevelItem Item;
            for (int i = f_List.Count - 1; i >= 0; i--)
            {
                Item = (TLevelItem)f_List.ElementAt(i);
                if (Item.IdParentShape == AIdParentShape)
                    return Item;
            }
            return null;
        }
        int GetParentShapeID()
        {
            if (f_CurrentLevel != null)
                return f_CurrentLevel.IdParentShape;
            return 0;
        }
        void DeleteLastLevel()
        {
            int idx = f_List.Count;
            if (idx >= 0)
            {
                TLevelItem Item = (TLevelItem)f_List.ElementAt(idx - 1);
                if (f_CurrentLevel == Item) f_CurrentLevel = null;
                Item = null;
                f_List.RemoveAt(idx - 1);
            }
        }
        public TLevelController()
        {
            f_List = new List<object>();
            f_CurrentLevel = null;
        }
        ~TLevelController() { }
        public TLevelItem Push(int AIdParentShape)
        {
            TLevelItem Item = FindLevel(AIdParentShape);
            if (Item == null)
            {
                Item = new TLevelItem();
                Item.IdParentShape = AIdParentShape;
                f_List.Add(Item);
            }
            f_CurrentLevel = Item;
            return Item;
        }
        public TLevelItem Pop()
        {
            TLevelItem Item = null;
            int idx = f_List.Count;
            if (idx > 1)
            {
                Item = (TLevelItem)f_List.ElementAt(idx - 2);
                f_CurrentLevel = Item;
                DeleteLastLevel();
            }
            return Item;
        }
        public void ClearAll()
        {
            FreeList();
        }
        public TLevelItem CurrentLevel
        {
            get { return f_CurrentLevel; }
        }
        public int ParentShapeID
        {
            get { return GetParentShapeID(); }
        }
    }
}
