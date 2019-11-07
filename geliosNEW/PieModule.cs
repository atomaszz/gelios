using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TPieModule
    {
        /*      HINSTANCE f_Hinstan;
              Trun1 f_Run1;*/
        public TPieModule()
        {
            /*       f_Run1 = 0;
                   f_Hinstan = LoadLibrary("pie.dll");
                   if (f_Hinstan > 0)
                   {
                       FARPROC Fpointer = GetProcAddress(f_Hinstan, "run1");
                       if (Fpointer != null)
                           f_Run1 = Trun1(Fpointer);
                   }*/
        }
        ~TPieModule() { }
        bool CheckModule()
        {
            return false;//(f_Hinstan && f_Run1);
        }
        public void RefreshModule()
        {
            /*    if (f_Hinstan > 0)
                {
                    FreeLibrary(f_Hinstan);
                    f_Run1 = 0;
                    f_Hinstan = LoadLibrary("pie.dll");
                    if (f_Hinstan > 0)
                    {
                        FARPROC Fpointer = GetProcAddress(f_Hinstan, "run1");
                        if (Fpointer != null)
                            f_Run1 = Trun1(Fpointer);
                    }*/
                }
        public int Run1(string ARunStr)
        {
                int res = -1;
                /*        if (CheckModule())
                            f_Run1(ARunStr.c_str(), &res);*/
                return res;
        }
    }
}
