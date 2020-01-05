using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TAltStackItem
    {
        int f_IdAlternative;
        int f_NumAlternative;
        int f_IdAlternativeParent;
        int f_NumAlternativeParent;
        public TAltStackItem(int AIdAlternative, int ANumAlternative, int AIdAlternativeParent,
         int ANumAlternativeParent)
        {
            f_IdAlternative = AIdAlternative;
            f_NumAlternative = ANumAlternative;
            f_IdAlternativeParent = AIdAlternativeParent;
            f_NumAlternativeParent = ANumAlternativeParent;
        }
     /*   public int IdAlternative = { read = f_IdAlternative, write = f_IdAlternative };
        public int NumAlternative = { read = f_NumAlternative, write = f_NumAlternative };
        public int IdAlternativeParent = { read = f_IdAlternativeParent, write = f_IdAlternativeParent };
        public int NumAlternativeParent = { read = f_NumAlternativeParent, write = f_NumAlternativeParent };*/
    }


    class TAltStackController
    {
        List<object> f_List;
        TAltStackItem f_CurrentItem;
     /*   void FreeList();
        void DeleteLastLevel();*/
        public TAltStackController()
        {
            f_List = new List<object>();
        }
        ~TAltStackController() { }
        public TAltStackItem Push(int AIdAlternative, int ANumAlternative,
          int AIdAlternativeParent, int ANumAlternativeParent)
        {
            TAltStackItem Item = new TAltStackItem(AIdAlternative, ANumAlternative,
                                        AIdAlternativeParent, ANumAlternativeParent);
            f_List.Add(Item);
            f_CurrentItem = Item;
            return Item;
        }
    /*    public TAltStackItem Pop();*/
        public void ClearAll()
        {
            f_List.Clear();
        }
/*       public TAltStackItem CurrentItem = {read = f_CurrentItem*/
        }
}
