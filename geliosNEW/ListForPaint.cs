using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TListForPaintItem
    {
        object f_point; //указатель на класс, который нужно перерисовать
        int f_type; //тип класса 
        public TListForPaintItem(object AClassPoint, int AType)
        {
            f_point = AClassPoint;
            f_type = AType;
        }
        public object ClassPoint
        {
            get { return f_point; }
        }
        public int Type
        {
            get { return f_type; }
        }
    }

    class TListForPaint
    {
        int f_Count;
        public List<object> Items;
        void FreeList()
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                Items.RemoveAt(i);
            }
        }
        TListForPaintItem GetItem(int AIndex)
        {
            TListForPaintItem res = null;
            if ((AIndex > f_Count - 1) || (AIndex < 0)) return res;
            res = (TListForPaintItem)Items.ElementAt(AIndex);
            return res;
        }
        bool IsExist(object AClassPoint)
        {
            TListForPaintItem Item;
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                Item = (TListForPaintItem)Items.ElementAt(i);
                if (Item.ClassPoint == AClassPoint) return true;
            }
            return false;
        }
        public TListForPaint()
        {
            Items = new List<object>();
            f_Count = 0;
        }
        ~TListForPaint() { }
        public bool AddForPaint(object AClassPoint, int AType)
        {
            bool res = IsExist(AClassPoint);
            if (res) return false;
            TListForPaintItem Item = new TListForPaintItem(AClassPoint, AType);
            Items.Add(Item);
            f_Count++;
            return true;
        }
        public void Clear()
        {
            FreeList();
            f_Count = 0;
        }
        public int Count
        {
            get { return f_Count; }
        }
    }
}
