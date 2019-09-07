using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TParamAlternative
    {
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
        int GetCount()
        {
            return f_List.Count;
        }

        TParamAlternativeItem GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                return (TParamAlternativeItem)f_List.ElementAt(AIndex);
            else
                return null;
        }
        public TParamAlternative()
        {
            f_List = new List<object>();
        }
        ~TParamAlternative() { }
        public void AddItem(TParamAlternativeItem AItem)
        {
            f_List.Add(AItem);
        }
        public void Delete(int AIndex)
        {
            TParamAlternativeItem Item = GetItems(AIndex);
            if (Item!=null)
            {
                f_List.RemoveAt(AIndex);
            }
        }
        public void Delete2(object APointer)
        {
            int index = f_List.IndexOf(APointer);
            Delete(index);
        }

        public void Clear()
        {
            FreeList();
        }
        public  int Count
        {
            get { return GetCount(); } 
        }
    }
}
