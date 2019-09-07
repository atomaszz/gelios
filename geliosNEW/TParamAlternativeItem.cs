using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    /*

    NUMBER
    PRED_ISTOR
    SOSTAV
    NAME
    FUNCTION
    ELEMENT
    PREDICAT
    B
    T
    V
    A1_B_F
    B_F1N
    B_F1B
    A2_B_F
    B_F2N
    B_F2B
    A3_B_F
    B_F3N
    B_F3B
    A1_T_F
    T_F1N
    T_F1B
    A2_T_F
    T_F2N
    T_F2B
    A3_T_F
    T_F3N
    T_F3B
    A1_V_F
    V_F1N
    V_F1B
    A2_V_F
    V_F2N
    V_F2B
    A3_V_F
    V_F3N
    V_F3B
    K_11
    K_00
    T_F
    V_F
    A1_K11_F
    K11_F1N
    K11_F1B
    A2_K11_F
    K11_F2N
    K11_F2B
    A3_K11_F
    K11_F3N
    K11_F3B
    A1_K00_F
    K00_F1N
    K00_F1B
    A2_K00_F
    K00_F2N
    K00_F2B
    A3_K00_F
    K00_F3N
    K00_F3B
    A1_TF_F
    TF_F1N
    TF_F1B
    A2_TF_F
    TF_F2N
    TF_F2B
    A3_TF_F
    TF_F3N
    TF_F3B
    A1_VF_F
    VF_F1N
    VF_F1B
    A2_VF_F
    VF_F2N
    VF_F2B
    A3_VF_F
    VF_F3N
    VF_F3B
    P_11
    P_00
    T_D
    V_D
    A1_P11_F
    P11_F1N
    P11_F1B
    A2_P11_F
    P11_F2N
    P11_F2B
    A3_P11_F
    P11_F3N
    P11_F3B
    A1_P00_F
    P00_F1N
    P00_F1B
    A2_P00_F
    P00_F2N
    P00_F2B
    A3_P00_F
    P00_F3N
    P00_F3B
    A1_TD_F
    TD_F1N
    TD_F1B
    A2_TD_F
    TD_F2N
    TD_F2B
    A3_TD_F
    TD_F3N
    TD_F3B
    A1_VD_F
    VD_F1N
    VD_F1B
    A2_VD_F
    VD_F2N
    VD_F2B
    A3_VD_F
    VD_F3N
    VD_F3B
    TYPE
    ELEM_DIAGN
    P_DIAGN_EL
    A1_P_EL_F
    P_EL_F1N
    P_EL_F1B
    A2_P_EL_F
    P_EL_F2N
    P_EL_F2B
    A3_P_EL_F
    P_EL_F3N
    P_EL_F3B
    SOVM
    SOVM0
    SOVM1

    */
    class TParamAlternativeItem
    {
        int f_NUMBER;
        string f_PRED_ISTOR;
        string f_SOSTAV;
        string f_NAME;
        string f_FUNCTION;
        string f_ELEMENT;
        string f_PREDICAT;
        double f_B;
        double f_T;
        double f_V;
        double f_A1_B_F;
        double f_B_F1N;
        double f_B_F1B;
        double f_A2_B_F;
        double f_B_F2N;
        double f_B_F2B;
        double f_A3_B_F;
        double f_B_F3N;
        double f_B_F3B;
        double f_A1_T_F;
        double f_T_F1N;
        double f_T_F1B;
        double f_A2_T_F;
        double f_T_F2N;
        double f_T_F2B;
        double f_A3_T_F;
        double f_T_F3N;
        double f_T_F3B;
        double f_A1_V_F;
        double f_V_F1N;
        double f_V_F1B;
        double f_A2_V_F;
        double f_V_F2N;
        double f_V_F2B;
        double f_A3_V_F;
        double f_V_F3N;
        double f_V_F3B;
        double f_K_11;
        double f_K_00;
        double f_T_F;
        double f_V_F;
        double f_A1_K11_F;
        double f_K11_F1N;
        double f_K11_F1B;
        double f_A2_K11_F;
        double f_K11_F2N;
        double f_K11_F2B;
        double f_A3_K11_F;
        double f_K11_F3N;
        double f_K11_F3B;
        double f_A1_K00_F;
        double f_K00_F1N;
        double f_K00_F1B;
        double f_A2_K00_F;
        double f_K00_F2N;
        double f_K00_F2B;
        double f_A3_K00_F;
        double f_K00_F3N;
        double f_K00_F3B;
        double f_A1_TF_F;
        double f_TF_F1N;
        double f_TF_F1B;
        double f_A2_TF_F;
        double f_TF_F2N;
        double f_TF_F2B;
        double f_A3_TF_F;
        double f_TF_F3N;
        double f_TF_F3B;
        double f_A1_VF_F;
        double f_VF_F1N;
        double f_VF_F1B;
        double f_A2_VF_F;
        double f_VF_F2N;
        double f_VF_F2B;
        double f_A3_VF_F;
        double f_VF_F3N;
        double f_VF_F3B;
        double f_P_11;
        double f_P_00;
        double f_T_D;
        double f_V_D;
        double f_A1_P11_F;
        double f_P11_F1N;
        double f_P11_F1B;
        double f_A2_P11_F;
        double f_P11_F2N;
        double f_P11_F2B;
        double f_A3_P11_F;
        double f_P11_F3N;
        double f_P11_F3B;
        double f_A1_P00_F;
        double f_P00_F1N;
        double f_P00_F1B;
        double f_A2_P00_F;
        double f_P00_F2N;
        double f_P00_F2B;
        double f_A3_P00_F;
        double f_P00_F3N;
        double f_P00_F3B;
        double f_A1_TD_F;
        double f_TD_F1N;
        double f_TD_F1B;
        double f_A2_TD_F;
        double f_TD_F2N;
        double f_TD_F2B;
        double f_A3_TD_F;
        double f_TD_F3N;
        double f_TD_F3B;
        double f_A1_VD_F;
        double f_VD_F1N;
        double f_VD_F1B;
        double f_A2_VD_F;
        double f_VD_F2N;
        double f_VD_F2B;
        double f_A3_VD_F;
        double f_VD_F3N;
        double f_VD_F3B;
        int f_TYPE;
        string f_ELEM_DIAGN;
        double f_P_DIAGN_EL;
        double f_A1_P_EL_F;
        double f_P_EL_F1N;
        double f_P_EL_F1B;
        double f_A2_P_EL_F;
        double f_P_EL_F2N;
        double f_P_EL_F2B;
        double f_A3_P_EL_F;
        double f_P_EL_F3N;
        double f_P_EL_F3B;
        double f_SOVM;
        double f_SOVM0;
        double f_SOVM1;
        int f_Tag;
        bool f_CheckPLG;
        public TParamAlternativeItem()
        {
            f_NUMBER = 0;
            f_PRED_ISTOR = "";
            f_SOSTAV = "";
            f_NAME = "";
            f_FUNCTION = "";
            f_ELEMENT = "";
            f_PREDICAT = "";
            f_B = 0.0;
            f_T = 0.0;
            f_V = 0.0;
            f_A1_B_F = 0.0;
            f_B_F1N = 0.0;
            f_B_F1B = 0.0;
            f_A2_B_F = 0.0;
            f_B_F2N = 0.0;
            f_B_F2B = 0.0;
            f_A3_B_F = 0.0;
            f_B_F3N = 0.0;
            f_B_F3B = 0.0;
            f_A1_T_F = 0.0;
            f_T_F1N = 0.0;
            f_T_F1B = 0.0;
            f_A2_T_F = 0.0;
            f_T_F2N = 0.0;
            f_T_F2B = 0.0;
            f_A3_T_F = 0.0;
            f_T_F3N = 0.0;
            f_T_F3B = 0.0;
            f_A1_V_F = 0.0;
            f_V_F1N = 0.0;
            f_V_F1B = 0.0;
            f_A2_V_F = 0.0;
            f_V_F2N = 0.0;
            f_V_F2B = 0.0;
            f_A3_V_F = 0.0;
            f_V_F3N = 0.0;
            f_V_F3B = 0.0;
            f_K_11 = 0.0;
            f_K_00 = 0.0;
            f_T_F = 0.0;
            f_V_F = 0.0;
            f_A1_K11_F = 0.0;
            f_K11_F1N = 0.0;
            f_K11_F1B = 0.0;
            f_A2_K11_F = 0.0;
            f_K11_F2N = 0.0;
            f_K11_F2B = 0.0;
            f_A3_K11_F = 0.0;
            f_K11_F3N = 0.0;
            f_K11_F3B = 0.0;
            f_A1_K00_F = 0.0;
            f_K00_F1N = 0.0;
            f_K00_F1B = 0.0;
            f_A2_K00_F = 0.0;
            f_K00_F2N = 0.0;
            f_K00_F2B = 0.0;
            f_A3_K00_F = 0.0;
            f_K00_F3N = 0.0;
            f_K00_F3B = 0.0;
            f_A1_TF_F = 0.0;
            f_TF_F1N = 0.0;
            f_TF_F1B = 0.0;
            f_A2_TF_F = 0.0;
            f_TF_F2N = 0.0;
            f_TF_F2B = 0.0;
            f_A3_TF_F = 0.0;
            f_TF_F3N = 0.0;
            f_TF_F3B = 0.0;
            f_A1_VF_F = 0.0;
            f_VF_F1N = 0.0;
            f_VF_F1B = 0.0;
            f_A2_VF_F = 0.0;
            f_VF_F2N = 0.0;
            f_VF_F2B = 0.0;
            f_A3_VF_F = 0.0;
            f_VF_F3N = 0.0;
            f_VF_F3B = 0.0;
            f_P_11 = 0.0;
            f_P_00 = 0.0;
            f_T_D = 0.0;
            f_V_D = 0.0;
            f_A1_P11_F = 0.0;
            f_P11_F1N = 0.0;
            f_P11_F1B = 0.0;
            f_A2_P11_F = 0.0;
            f_P11_F2N = 0.0;
            f_P11_F2B = 0.0;
            f_A3_P11_F = 0.0;
            f_P11_F3N = 0.0;
            f_P11_F3B = 0.0;
            f_A1_P00_F = 0.0;
            f_P00_F1N = 0.0;
            f_P00_F1B = 0.0;
            f_A2_P00_F = 0.0;
            f_P00_F2N = 0.0;
            f_P00_F2B = 0.0;
            f_A3_P00_F = 0.0;
            f_P00_F3N = 0.0;
            f_P00_F3B = 0.0;
            f_A1_TD_F = 0.0;
            f_TD_F1N = 0.0;
            f_TD_F1B = 0.0;
            f_A2_TD_F = 0.0;
            f_TD_F2N = 0.0;
            f_TD_F2B = 0.0;
            f_A3_TD_F = 0.0;
            f_TD_F3N = 0.0;
            f_TD_F3B = 0.0;
            f_A1_VD_F = 0.0;
            f_VD_F1N = 0.0;
            f_VD_F1B = 0.0;
            f_A2_VD_F = 0.0;
            f_VD_F2N = 0.0;
            f_VD_F2B = 0.0;
            f_A3_VD_F = 0.0;
            f_VD_F3N = 0.0;
            f_VD_F3B = 0.0;
            f_TYPE = 0;
            f_ELEM_DIAGN = "";
            f_P_DIAGN_EL = 0.0;
            f_A1_P_EL_F = 0.0;
            f_P_EL_F1N = 0.0;
            f_P_EL_F1B = 0.0;
            f_A2_P_EL_F = 0.0;
            f_P_EL_F2N = 0.0;
            f_P_EL_F2B = 0.0;
            f_A3_P_EL_F = 0.0;
            f_P_EL_F3N = 0.0;
            f_P_EL_F3B = 0.0;
            f_SOVM = 0.0;
            f_SOVM0 = 0.0;
            f_SOVM1 = 0.0;
            f_Tag = 0;
            f_CheckPLG = true;
        }
        public TParamAlternativeItem Clone()
        {
            TParamAlternativeItem N = new TParamAlternativeItem();
            N.f_NUMBER = f_NUMBER;
            N.f_PRED_ISTOR = f_PRED_ISTOR;
            N.f_SOSTAV = f_SOSTAV;
            N.f_NAME = f_NAME;
            N.f_FUNCTION = f_FUNCTION;
            N.f_ELEMENT = f_ELEMENT;
            N.f_PREDICAT = f_PREDICAT;
            N.f_B = f_B;
            N.f_T = f_T;
            N.f_V = f_V;
            N.f_A1_B_F = f_A1_B_F;
            N.f_B_F1N = f_B_F1N;
            N.f_B_F1B = f_B_F1B;
            N.f_A2_B_F = f_A2_B_F;
            N.f_B_F2N = f_B_F2N;
            N.f_B_F2B = f_B_F2B;
            N.f_A3_B_F = f_A3_B_F;
            N.f_B_F3N = f_B_F3N;
            N.f_B_F3B = f_B_F3B;
            N.f_A1_T_F = f_A1_T_F;
            N.f_T_F1N = f_T_F1N;
            N.f_T_F1B = f_T_F1B;
            N.f_A2_T_F = f_A2_T_F;
            N.f_T_F2N = f_T_F2N;
            N.f_T_F2B = f_T_F2B;
            N.f_A3_T_F = f_A3_T_F;
            N.f_T_F3N = f_T_F3N;
            N.f_T_F3B = f_T_F3B;
            N.f_A1_V_F = f_A1_V_F;
            N.f_V_F1N = f_V_F1N;
            N.f_V_F1B = f_V_F1B;
            N.f_A2_V_F = f_A2_V_F;
            N.f_V_F2N = f_V_F2N;
            N.f_V_F2B = f_V_F2B;
            N.f_A3_V_F = f_A3_V_F;
            N.f_V_F3N = f_V_F3N;
            N.f_V_F3B = f_V_F3B;
            N.f_K_11 = f_K_11;
            N.f_K_00 = f_K_00;
            N.f_T_F = f_T_F;
            N.f_V_F = f_V_F;
            N.f_A1_K11_F = f_A1_K11_F;
            N.f_K11_F1N = f_K11_F1N;
            N.f_K11_F1B = f_K11_F1B;
            N.f_A2_K11_F = f_A2_K11_F;
            N.f_K11_F2N = f_K11_F2N;
            N.f_K11_F2B = f_K11_F2B;
            N.f_A3_K11_F = f_A3_K11_F;
            N.f_K11_F3N = f_K11_F3N;
            N.f_K11_F3B = f_K11_F3B;
            N.f_A1_K00_F = f_A1_K00_F;
            N.f_K00_F1N = f_K00_F1N;
            N.f_K00_F1B = f_K00_F1B;
            N.f_A2_K00_F = f_A2_K00_F;
            N.f_K00_F2N = f_K00_F2N;
            N.f_K00_F2B = f_K00_F2B;
            N.f_A3_K00_F = f_A3_K00_F;
            N.f_K00_F3N = f_K00_F3N;
            N.f_K00_F3B = f_K00_F3B;
            N.f_A1_TF_F = f_A1_TF_F;
            N.f_TF_F1N = f_TF_F1N;
            N.f_TF_F1B = f_TF_F1B;
            N.f_A2_TF_F = f_A2_TF_F;
            N.f_TF_F2N = f_TF_F2N;
            N.f_TF_F2B = f_TF_F2B;
            N.f_A3_TF_F = f_A3_TF_F;
            N.f_TF_F3N = f_TF_F3N;
            N.f_TF_F3B = f_TF_F3B;
            N.f_A1_VF_F = f_A1_VF_F;
            N.f_VF_F1N = f_VF_F1N;
            N.f_VF_F1B = f_VF_F1B;
            N.f_A2_VF_F = f_A2_VF_F;
            N.f_VF_F2N = f_VF_F2N;
            N.f_VF_F2B = f_VF_F2B;
            N.f_A3_VF_F = f_A3_VF_F;
            N.f_VF_F3N = f_VF_F3N;
            N.f_VF_F3B = f_VF_F3B;
            N.f_P_11 = f_P_11;
            N.f_P_00 = f_P_00;
            N.f_T_D = f_T_D;
            N.f_V_D = f_V_D;
            N.f_A1_P11_F = f_A1_P11_F;
            N.f_P11_F1N = f_P11_F1N;
            N.f_P11_F1B = f_P11_F1B;
            N.f_A2_P11_F = f_A2_P11_F;
            N.f_P11_F2N = f_P11_F2N;
            N.f_P11_F2B = f_P11_F2B;
            N.f_A3_P11_F = f_A3_P11_F;
            N.f_P11_F3N = f_P11_F3N;
            N.f_P11_F3B = f_P11_F3B;
            N.f_A1_P00_F = f_A1_P00_F;
            N.f_P00_F1N = f_P00_F1N;
            N.f_P00_F1B = f_P00_F1B;
            N.f_A2_P00_F = f_A2_P00_F;
            N.f_P00_F2N = f_P00_F2N;
            N.f_P00_F2B = f_P00_F2B;
            N.f_A3_P00_F = f_A3_P00_F;
            N.f_P00_F3N = f_P00_F3N;
            N.f_P00_F3B = f_P00_F3B;
            N.f_A1_TD_F = f_A1_TD_F;
            N.f_TD_F1N = f_TD_F1N;
            N.f_TD_F1B = f_TD_F1B;
            N.f_A2_TD_F = f_A2_TD_F;
            N.f_TD_F2N = f_TD_F2N;
            N.f_TD_F2B = f_TD_F2B;
            N.f_A3_TD_F = f_A3_TD_F;
            N.f_TD_F3N = f_TD_F3N;
            N.f_TD_F3B = f_TD_F3B;
            N.f_A1_VD_F = f_A1_VD_F;
            N.f_VD_F1N = f_VD_F1N;
            N.f_VD_F1B = f_VD_F1B;
            N.f_A2_VD_F = f_A2_VD_F;
            N.f_VD_F2N = f_VD_F2N;
            N.f_VD_F2B = f_VD_F2B;
            N.f_A3_VD_F = f_A3_VD_F;
            N.f_VD_F3N = f_VD_F3N;
            N.f_VD_F3B = f_VD_F3B;
            N.f_TYPE = f_TYPE;
            N.f_ELEM_DIAGN = f_ELEM_DIAGN;
            N.f_P_DIAGN_EL = f_P_DIAGN_EL;
            N.f_A1_P_EL_F = f_A1_P_EL_F;
            N.f_P_EL_F1N = f_P_EL_F1N;
            N.f_P_EL_F1B = f_P_EL_F1B;
            N.f_A2_P_EL_F = f_A2_P_EL_F;
            N.f_P_EL_F2N = f_P_EL_F2N;
            N.f_P_EL_F2B = f_P_EL_F2B;
            N.f_A3_P_EL_F = f_A3_P_EL_F;
            N.f_P_EL_F3N = f_P_EL_F3N;
            N.f_P_EL_F3B = f_P_EL_F3B;
            N.f_SOVM = f_SOVM;
            N.f_SOVM0 = f_SOVM0;
            N.f_SOVM1 = f_SOVM1;
            N.CheckPLG = f_CheckPLG;
            return N;
        }
        public int NUMBER
        {
            set { f_NUMBER = value;  }
            get { return f_NUMBER; }
        }
        public string  PRED_ISTOR
        {
            set { f_PRED_ISTOR = value; }
            get { return f_PRED_ISTOR; }
        }
        public string SOSTAV
        {
            set { f_SOSTAV = value; }
            get { return f_SOSTAV; }
        }
        public string NAME
        {
            set { f_NAME = value; }
            get { return f_NAME; }
        }
        public string FUNCTION2
        {
            set { f_FUNCTION = value; }
            get { return f_FUNCTION; }
        }
 /*       public string ELEMENT 
            
            = {read = f_ELEMENT, write = f_ELEMENT};
        public string PREDICAT 
            
            = {read = f_PREDICAT, write = f_PREDICAT};
        public double B 
            
            = { read = f_B, write = f_B };
        public double T 
            
            = { read = f_T, write = f_T };
        public double V 
            
            = { read = f_V, write = f_V };
        public double A1_B_F 
            
            = { read = f_A1_B_F, write = f_A1_B_F };
        public double B_F1N 
            
            = { read = f_B_F1N, write = f_B_F1N };
        public double B_F1B 
            
            = { read = f_B_F1B, write = f_B_F1B };
        public double A2_B_F 
            
            = { read = f_A2_B_F, write = f_A2_B_F };
        public double B_F2N 
            
            = { read = f_B_F2N, write = f_B_F2N };
        public double B_F2B 
            
            = { read = f_B_F2B, write = f_B_F2B };
        public double A3_B_F 
            
            = { read = f_A3_B_F, write = f_A3_B_F };
        public double B_F3N 
            
            = { read = f_B_F3N, write = f_B_F3N };
        public double B_F3B 
            
            = { read = f_B_F3B, write = f_B_F3B };
        public double A1_T_F 
            
            = { read = f_A1_T_F, write = f_A1_T_F };
        public double T_F1N 
            
            = { read = f_T_F1N, write = f_T_F1N };
        public double T_F1B 
            
            = { read = f_T_F1B, write = f_T_F1B };
        public double A2_T_F 
            
            = { read = f_A2_T_F, write = f_A2_T_F };
        public double T_F2N 
            
            = { read = f_T_F2N, write = f_T_F2N };
        public double T_F2B 
            
            = { read = f_T_F2B, write = f_T_F2B };
        public double A3_T_F 
            
            = { read = f_A3_T_F, write = f_A3_T_F };
        public double T_F3N 
            
            = { read = f_T_F3N, write = f_T_F3N };
        public double T_F3B 
            
            = { read = f_T_F3B, write = f_T_F3B };
        public double A1_V_F 
            
            = { read = f_A1_V_F, write = f_A1_V_F };
        public double V_F1N 
            
            = { read = f_V_F1N, write = f_V_F1N };
        public double V_F1B 
            
            = { read = f_V_F1B, write = f_V_F1B };
        public double A2_V_F 
            
            = { read = f_A2_V_F, write = f_A2_V_F };
        public double V_F2N 
            
            = { read = f_V_F2N, write = f_V_F2N };
        public double V_F2B 
            
            = { read = f_V_F2B, write = f_V_F2B };
        public double A3_V_F 
            
            = { read = f_A3_V_F, write = f_A3_V_F };
        public double V_F3N 
            
            = { read = f_V_F3N, write = f_V_F3N };
        public double V_F3B
            
            = { read = f_V_F3B, write = f_V_F3B };
        public double K_11 
            
            = { read = f_K_11, write = f_K_11 };
        public double K_00 
            
            = { read = f_K_00, write = f_K_00 };
        public double T_F 
            
            = { read = f_T_F, write = f_T_F };
        public double V_F 
            
            = { read = f_V_F, write = f_V_F };
        public double A1_K11_F 
            
            = { read = f_A1_K11_F, write = f_A1_K11_F };
        public double K11_F1N
            
            = { read = f_K11_F1N, write = f_K11_F1N };
        public double K11_F1B
            
            = { read = f_K11_F1B, write = f_K11_F1B };
        public double A2_K11_F
            
            = { read = f_A2_K11_F, write = f_A2_K11_F };
        public double K11_F2N 
            
            = { read = f_K11_F2N, write = f_K11_F2N };
        public double K11_F2B 
            
            = { read = f_K11_F2B, write = f_K11_F2B };
        public double A3_K11_F
            
            = { read = f_A3_K11_F, write = f_A3_K11_F };
        public double K11_F3N
            
            = { read = f_K11_F3N, write = f_K11_F3N };
        public double K11_F3B 
            
            = { read = f_K11_F3B, write = f_K11_F3B };
        public double A1_K00_F
            
            = { read = f_A1_K00_F, write = f_A1_K00_F };
        public double K00_F1N
            
            = { read = f_K00_F1N, write = f_K00_F1N };
        public double K00_F1B
            
            = { read = f_K00_F1B, write = f_K00_F1B };
        public double A2_K00_F
            
            = { read = f_A2_K00_F, write = f_A2_K00_F };
        public double K00_F2N
            
            = { read = f_K00_F2N, write = f_K00_F2N };
        public double K00_F2B
            
            = { read = f_K00_F2B, write = f_K00_F2B };
        public double A3_K00_F
            
            = { read = f_A3_K00_F, write = f_A3_K00_F };
        public double K00_F3N 
            
            = { read = f_K00_F3N, write = f_K00_F3N };
        public double K00_F3B
            
            = { read = f_K00_F3B, write = f_K00_F3B };
        public double A1_TF_F 
            
            = { read = f_A1_TF_F, write = f_A1_TF_F };
        public double TF_F1N 
            
            = { read = f_TF_F1N, write = f_TF_F1N };
        public double TF_F1B 
            
            = { read = f_TF_F1B, write = f_TF_F1B };
        public double A2_TF_F 
            
            = { read = f_A2_TF_F, write = f_A2_TF_F };
        public double TF_F2N 
            
            = { read = f_TF_F2N, write = f_TF_F2N };
        public double TF_F2B 
            
            = { read = f_TF_F2B, write = f_TF_F2B };
        public double A3_TF_F
            
            = { read = f_A3_TF_F, write = f_A3_TF_F };
        public double TF_F3N 
            
            = { read = f_TF_F3N, write = f_TF_F3N };
        public double TF_F3B 
            
            = { read = f_TF_F3B, write = f_TF_F3B };
        public double A1_VF_F
            
            = { read = f_A1_VF_F, write = f_A1_VF_F };
        public double VF_F1N = { read = f_VF_F1N, write = f_VF_F1N };
        public double VF_F1B = { read = f_VF_F1B, write = f_VF_F1B };
        public double A2_VF_F = { read = f_A2_VF_F, write = f_A2_VF_F };
        public double VF_F2N = { read = f_VF_F2N, write = f_VF_F2N };
        public double VF_F2B = { read = f_VF_F2B, write = f_VF_F2B };
        public double A3_VF_F = { read = f_A3_VF_F, write = f_A3_VF_F };
        public double VF_F3N = { read = f_VF_F3N, write = f_VF_F3N };
        public double VF_F3B = { read = f_VF_F3B, write = f_VF_F3B };
        public double P_11 = { read = f_P_11, write = f_P_11 };
        public double P_00 = { read = f_P_00, write = f_P_00 };
        public double T_D = { read = f_T_D, write = f_T_D };
        public double V_D = { read = f_V_D, write = f_V_D };
        public double A1_P11_F = { read = f_A1_P11_F, write = f_A1_P11_F };
        public double P11_F1N = { read = f_P11_F1N, write = f_P11_F1N };
        public double P11_F1B = { read = f_P11_F1B, write = f_P11_F1B };
        public double A2_P11_F = { read = f_A2_P11_F, write = f_A2_P11_F };
        public double P11_F2N = { read = f_P11_F2N, write = f_P11_F2N };
        public double P11_F2B = { read = f_P11_F2B, write = f_P11_F2B };
        public double A3_P11_F = { read = f_A3_P11_F, write = f_A3_P11_F };
        public double P11_F3N = { read = f_P11_F3N, write = f_P11_F3N };
        public double P11_F3B = { read = f_P11_F3B, write = f_P11_F3B };
        public double A1_P00_F = { read = f_A1_P00_F, write = f_A1_P00_F };
        public double P00_F1N = { read = f_P00_F1N, write = f_P00_F1N };
        public double P00_F1B = { read = f_P00_F1B, write = f_P00_F1B };
        public double A2_P00_F = { read = f_A2_P00_F, write = f_A2_P00_F };
        public double P00_F2N = { read = f_P00_F2N, write = f_P00_F2N };
        public double P00_F2B = { read = f_P00_F2B, write = f_P00_F2B };
        public double A3_P00_F = { read = f_A3_P00_F, write = f_A3_P00_F };
        public double P00_F3N = { read = f_P00_F3N, write = f_P00_F3N };
        public double P00_F3B = { read = f_P00_F3B, write = f_P00_F3B };
        public double A1_TD_F = { read = f_A1_TD_F, write = f_A1_TD_F };
        public double TD_F1N = { read = f_TD_F1N, write = f_TD_F1N };
        public double TD_F1B = { read = f_TD_F1B, write = f_TD_F1B };
        public double A2_TD_F = { read = f_A2_TD_F, write = f_A2_TD_F };
        public double TD_F2N = { read = f_TD_F2N, write = f_TD_F2N };
        public double TD_F2B = { read = f_TD_F2B, write = f_TD_F2B };
        public double A3_TD_F = { read = f_A3_TD_F, write = f_A3_TD_F };
        public double TD_F3N = { read = f_TD_F3N, write = f_TD_F3N };
        public double TD_F3B = { read = f_TD_F3B, write = f_TD_F3B };
        public double A1_VD_F = { read = f_A1_VD_F, write = f_A1_VD_F };
        public double VD_F1N = { read = f_VD_F1N, write = f_VD_F1N };
        public double VD_F1B = { read = f_VD_F1B, write = f_VD_F1B };
        public double A2_VD_F = { read = f_A2_VD_F, write = f_A2_VD_F };
        public double VD_F2N = { read = f_VD_F2N, write = f_VD_F2N };
        public double VD_F2B = { read = f_VD_F2B, write = f_VD_F2B };
        public double A3_VD_F = { read = f_A3_VD_F, write = f_A3_VD_F };
        public double VD_F3N = { read = f_VD_F3N, write = f_VD_F3N };
        public double VD_F3B = { read = f_VD_F3B, write = f_VD_F3B };
        public int TYPE = { read = f_TYPE, write = f_TYPE };
        public string  ELEM_DIAGN = {read = f_ELEM_DIAGN, write = f_ELEM_DIAGN};
        public double P_DIAGN_EL = { read = f_P_DIAGN_EL, write = f_P_DIAGN_EL };
        public double A1_P_EL_F = { read = f_A1_P_EL_F, write = f_A1_P_EL_F };
        public double P_EL_F1N = { read = f_P_EL_F1N, write = f_P_EL_F1N };
        public double P_EL_F1B = { read = f_P_EL_F1B, write = f_P_EL_F1B };
        public double A2_P_EL_F = { read = f_A2_P_EL_F, write = f_A2_P_EL_F };
        public double P_EL_F2N = { read = f_P_EL_F2N, write = f_P_EL_F2N };
        public double P_EL_F2B = { read = f_P_EL_F2B, write = f_P_EL_F2B };
        public double A3_P_EL_F = { read = f_A3_P_EL_F, write = f_A3_P_EL_F };
        public double P_EL_F3N = { read = f_P_EL_F3N, write = f_P_EL_F3N };
        public double P_EL_F3B = { read = f_P_EL_F3B, write = f_P_EL_F3B };
        public double SOVM = { read = f_SOVM, write = f_SOVM };
        public double SOVM0 = { read = f_SOVM0, write = f_SOVM0 };
        public double SOVM1 = { read = f_SOVM1, write = f_SOVM1 };
        public int Tag = { read = f_Tag, write = f_Tag };*/
        public bool CheckPLG
        {
            set { f_CheckPLG = value; }
            get { return f_CheckPLG; }
        }
    };
}
