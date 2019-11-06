using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TDischargedMassivItem
    {
        public int f_Col;
        public int f_Row;
        public object f_Value;
        public TDischargedMassivItem()
        {
            f_Col = 0;
            f_Row = 0;
        }
    };

    class TDischargedMassiv
    {
        object f_Def;
        public List<object> Val;
        public void FreeList()
        {
            Val.Clear();
        }
        public object GetItems(int ARow, int ACol)
        {
            TDischargedMassivItem Item = DoFind(ARow, ACol);
            if (Item!=null)
                return Item.f_Value;
            return f_Def;
        }
        public void SetItems(int ARow, int ACol, object Value)
        {
            TDischargedMassivItem Item = DoFind(ARow, ACol);
            bool m_def = (f_Def == Value);
            if (Item!=null)
            {
                if (m_def)
                    DeleteItem(Item);
                else
                    Item.f_Value = Value;
            }
            else
            {
                if (!m_def)
                {
                    Item = new TDischargedMassivItem();
                    Item.f_Col = ACol;
                    Item.f_Row = ARow;
                    Item.f_Value = Value;
                    Val.Add(Item);
                }
            }
        }
        public TDischargedMassivItem DoFind(int ARow, int ACol)
        {
            TDischargedMassivItem Item;
            for (int i = 0; i <= Val.Count - 1; i++)
            {
                Item = (TDischargedMassivItem)(Val.ElementAt(i));
                if ((Item.f_Col == ACol) && (Item.f_Row == ARow))
                    return Item;
            }
            return null;
        }
        public void DeleteItem(TDischargedMassivItem ADel)
        {
            int idx = Val.IndexOf(ADel);
            if (idx >= 0)
            {
                Val.RemoveAt(idx);
            }
        }
        public object GetVal(int AIndex)
        {
            return GetItems(0, AIndex);
        }
        public void SetVal(int Row, int AIndex, object Value)
        {
            SetItems(Row, AIndex, Value);
        }
        public TDischargedMassiv( object ADef)
        {
            f_Def = ADef;
            Val = new List<object>();
        }
        ~TDischargedMassiv() { }
        public int HiRow()
        {
            int Res = 0;
            TDischargedMassivItem Item;

            if (Val.Count > 0)
            {
                Item = (TDischargedMassivItem)(Val.ElementAt(0));
                Res = Item.f_Row;
            }

            for (int i = 1; i <= Val.Count - 1; i++)
            {
                Item = (TDischargedMassivItem)(Val.ElementAt(i));
                if (Item.f_Row > Res)
                    Res = Item.f_Row;
            }
            return Res;
        }
        public int HiCol()
        {
            int Res = 0;
            TDischargedMassivItem Item;

            if (Val.Count > 0)
            {
                Item = (TDischargedMassivItem)(Val.ElementAt(0));
                Res = Item.f_Col;
            }

            for (int i = 1; i <= Val.Count - 1; i++)
            {
                Item = (TDischargedMassivItem)(Val.ElementAt(i));
                if (Item.f_Col > Res)
                    Res = Item.f_Col;
            }
            return Res;
        }
        /*       int LoRow();
               int LoCol();*/
        public void Clear()
        {
            FreeList();
        }
        /*        bool IsEmpty();
                Variant ActualValue(int ARow, int ACol, ref bool Actual);
                double DoubleValue(int ARow, int ACol);
                double DoubleValue(int AIndex);
                __property Variant Items[int ARow][int ACol] = {read=GetItems, write=SetItems
            };/
            */
    }
}
