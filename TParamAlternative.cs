using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TParamAlternative
    {
        public List<object> Items;
        void FreeList()
        {
            Items.Clear();
        }
        int GetCount()
        {
            return Items.Count;
        }

        TParamAlternativeItem GetItems(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= Items.Count - 1)
                return (TParamAlternativeItem)Items.ElementAt(AIndex);
            else
                return null;
        }
        public TParamAlternative()
        {
            Items = new List<object>();
        }
        ~TParamAlternative() { }
        public void AddItem(TParamAlternativeItem AItem)
        {
            Items.Add(AItem);
        }
        public void Delete(int AIndex)
        {
            TParamAlternativeItem Item = GetItems(AIndex);
            if (Item!=null)
            {
                Items.RemoveAt(AIndex);
            }
        }
        public void Delete2(object APointer)
        {
            int index = Items.IndexOf(APointer);
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
