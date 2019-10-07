using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TDynamicArrayItem
    {
        public int Index;
        public object P;
        public string Name;
        public int Int_Value;
    };

    public class TDynamicArray
    {
        int f_PosStak;
        List<object> f_List;
        void FreeList()
        {
            for (int i = f_List.Count - 1; i >= 0; i--)
            {
                f_List.RemoveAt(i);
            }
        }
        object  GetArray(int AIndex)
        {
            TDynamicArrayItem Item, FindItem = null;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TDynamicArrayItem)f_List.ElementAt(i);
                if (Item.Index == AIndex)
                    FindItem = Item;
            }
            if (FindItem!=null)
                return FindItem.P;
            return null;
        }
        void  SetArray(int AIndex, object AValue)
        {
            TDynamicArrayItem Item, FindItem = null;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TDynamicArrayItem)f_List.ElementAt(i);
                if (Item.Index == AIndex)
                    FindItem = Item;
            }
            if (FindItem==null)
            {
                FindItem = new TDynamicArrayItem();
                FindItem.Index = AIndex;
                f_List.Add(FindItem);
            }
            FindItem.P = AValue;
        }
        int  GetCount()
        {
            return f_List.Count;
        }
        public object  GetItems(int AIndex)
        {
            TDynamicArrayItem Item = null;
            if (AIndex >= 0 && AIndex <= f_List.Count - 1)
                Item = (TDynamicArrayItem)f_List.ElementAt(AIndex);
            if (Item!=null)
                return Item.P;
            return null;
        }
        object  GetNamed(string AIndex)
        {
            TDynamicArrayItem Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TDynamicArrayItem)f_List.ElementAt(i);
                if (String.Compare(Item.Name, AIndex)==0)
                    return Item.P;
            }
            return null;
        }
        void  SetNamed(string AIndex, object AValue)
        {
        //    AppendNamed(AIndex, AValue);
        }
        object  GetInteger(int APos)
        {
            TDynamicArrayItem Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TDynamicArrayItem)f_List.ElementAt(i);
                if (Item.Int_Value == APos)
                    return Item.P;
            }
            return null;
        }
        void  SetInteger(int APos, object AValue)
        {
        //    AppendInteger(APos, AValue);
        }
        TDynamicArrayItem  GetPosition(int APos)
        {
            if (APos >= 0 && APos <= f_List.Count - 1)
                return (TDynamicArrayItem)f_List.ElementAt(APos);
            return null;
        }
        public TDynamicArray()
        {
            f_List = new List<object>();
            f_PosStak = 0;
        }
        ~TDynamicArray() { }
        public void Clear()
        {
            FreeList();
        }
        public void Append(object P)
        {
            int m = -1;
            TDynamicArrayItem Item;
            if (f_List.Count > 0)
                m = ((TDynamicArrayItem)f_List.ElementAt(0)).Index;
            for (int i = 1; i <= f_List.Count - 1; i++)
            {
                Item = (TDynamicArrayItem)f_List.ElementAt(i);
                if (Item.Index > m)
                    m = Item.Index;
            }
            m++;
            Item = new TDynamicArrayItem();
            Item.Index = m;
            Item.P = P;
            f_List.Add(Item);
            f_PosStak++;
        }
        public void InsertToFirst(object P)
        {
            int m = -1;
            TDynamicArrayItem Item;

            if (f_List.Count > 0)
                m = ((TDynamicArrayItem)f_List.ElementAt(0)).Index;
            for (int i = 1; i <= f_List.Count - 1; i++)
            {
                Item = (TDynamicArrayItem)f_List.ElementAt(i);
                if (Item.Index > m)
                    m = Item.Index;
            }
            m++;
            Item = new TDynamicArrayItem();
            Item.Index = m;
            Item.P = P;
            f_List.Insert(0, Item);
            f_PosStak++;
        }
    /*    public void AppendNamed(string AName, object P = NULL);
        public bool DeleteNamed(AnsiString AName);
        public  void AppendInteger(int APos, object AValue);
        public bool DeleteInteger(int APos);
        public bool Delete(object P);
        public void InitStack();
        public object Pop();*/
        public TDynamicArrayItem Find(object P)
        {
            TDynamicArrayItem Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TDynamicArrayItem)(f_List.ElementAt(i));
                if (Item.P == P)
                    return Item;
            }
            return null;
        }
    /*    public TDynamicArrayItem Last();
        public int DeleteArray(TDynamicArray AList);*/
        public int Count
        {
            get { return GetCount(); }
        }
  
  /*      public object Array[int AIndex] = { read = GetArray, write = SetArray };
        public object Named[AnsiString AIndex] = { read = GetNamed, write = SetNamed };
        public object Integer[int APos] = { read = GetInteger, write = SetInteger };
        public TDynamicArrayItem Position[int APos] = {read = GetPosition*/
        }
}
