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

    };

    class TListForPaint
    {
        int f_Count;
        List<object> List;
        void FreeList();
        TListForPaintItem GetItem(int AIndex);
        bool IsExist(object AClassPoint);
        public TListForPaint();
        ~TListForPaint() { }
        public bool AddForPaint(object AClassPoint, int AType);
        public void Clear();
        public  TListForPaintItem Items[int AIndex] = { read =  GetItem
        public  int Count = { read = f_Count };
}
