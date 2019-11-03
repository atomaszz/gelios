using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public delegate int TMsgFunc(int Param1, int Param2);

    class TMessangersItem
    {
        public int Message;
        public TMsgFunc Func;
    };

    public class TMessangers
    {
        List<object> f_List;
        public TMessangers()
        {
            f_List = new List<object>();
        }
        ~TMessangers() { }
        public bool RegistrMessage(int AMessage, TMsgFunc AFunc)
        {
            TMessangersItem Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TMessangersItem)f_List.ElementAt(i);
                if (Item.Message == AMessage)
                    return false;
            }
            Item = new TMessangersItem();
            Item.Message = AMessage;
            Item.Func = AFunc;
            f_List.Add(Item);
            return true;
        }
        public int SendMess(int AMessage, int Param1, int Param2)
        {
            TMessangersItem Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TMessangersItem)f_List.ElementAt(i);
                if (Item.Message == AMessage)
                    return Item.Func(Param1, Param2);
            }
            return -1;
        }
    };
}
