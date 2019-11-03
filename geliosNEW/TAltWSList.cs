using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAltWSList
    {
        public List<TBaseWorkShape> Items;
        TBaseWorkShape GetItem(int AIndex)
        {
            if (AIndex >= 0 && AIndex <= Items.Count - 1)
                return (Items.ElementAt(AIndex));
            else
                return null;
        }
        int GetCount()
        {
            return Items.Count;
        }
        public TAltWSList()
        {
            Items = new List<TBaseWorkShape>();
        }
        ~TAltWSList() { }
        public void Add(TBaseWorkShape AWs)
        {
            Items.Add(AWs);
        }
        public void Clear()
        {
            Items.Clear();
        }
        public bool Find(TBaseWorkShape AWs)
        {
            return (Items.IndexOf(AWs) > -1);
        }
        public int Count
        {
            get { return GetCount(); }
        }
    }
}
