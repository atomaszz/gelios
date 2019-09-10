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
        List<object> List;
        void FreeList()
        {
            for (int i = List.Count - 1; i >= 0; i--)
            {
                List.RemoveAt(i);
            }
        }
        TListForPaintItem GetItem(int AIndex)
        {
            TListForPaintItem res = null;
            if ((AIndex > f_Count - 1) || (AIndex < 0)) return res;
            res = (TListForPaintItem)List.ElementAt(AIndex);
            return res;
        }
        bool IsExist(object AClassPoint)
        {
            TListForPaintItem Item;
            for (int i = List.Count - 1; i >= 0; i--)
            {
                Item = (TListForPaintItem)List.ElementAt(i);
                if (Item.ClassPoint == AClassPoint) return true;
            }
            return false;
        }
        public TListForPaint()
        {
            List = new List<object>();
            f_Count = 0;
        }
        ~TListForPaint() { }
        public bool AddForPaint(object AClassPoint, int AType)
        {
            bool res = IsExist(AClassPoint);
            if (res) return false;
            TListForPaintItem Item = new TListForPaintItem(AClassPoint, AType);
            List.Add(Item);
            f_Count++;
            return true;
        }
        public void Clear()
        {
            FreeList();
            f_Count = 0;
        }
        // public  TListForPaintItem Items[int AIndex] = { read =  GetItem
        public int Count
        {
            get { return f_Count; }
        }
    }
}
