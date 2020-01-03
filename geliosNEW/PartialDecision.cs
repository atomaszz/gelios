using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class PARAM
    {
        public double[] par;
        public double[,] par_fuz;
        public string stv;
        public double sovm0;
        public double sovm1;

        public PARAM()
        {
            par = new double[12];
            par_fuz = new double[13,9];
        }
    }
    class TPartialDecisionItem
    {
        TPartialDecision f_Parent;
        TPredicateTreeItem f_WorkItem;
        TParamAlternative f_ParamAlt;
        TParamAlternative f_Apd;
        public void FreeApd()
        {
            if (f_Apd!=null)
                f_Apd = null;
        }

        public void DoDecision()
        {
            PARAM [] param1, param2, param3, param_rez; //для результирующих параметров
            TParamAlternativeItem AI;
            int i1, i2, i3, i_rez; //количество альтернатив
            int n1, n2, n3, n_rez; //номер подблоков
            double s_b, s_t, s_v, s_k11, s_k00, s_tf, s_vf, s_p11, s_p00, s_td, s_vd, s_diagn_el,
                a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b,
                a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b,
                a1_k11_f, k11_f1n, k11_f1b, a2_k11_f, k11_f2n, k11_f2b, a3_k11_f, k11_f3n, k11_f3b,
                a1_k00_f, k00_f1n, k00_f1b, a2_k00_f, k00_f2n, k00_f2b, a3_k00_f, k00_f3n, k00_f3b,
                a1_tf_f, tf_f1n, tf_f1b, a2_tf_f, tf_f2n, tf_f2b, a3_tf_f, tf_f3n, tf_f3b,
                a1_vf_f, vf_f1n, vf_f1b, a2_vf_f, vf_f2n, vf_f2b, a3_vf_f, vf_f3n, vf_f3b,
                a1_p11_f, p11_f1n, p11_f1b, a2_p11_f, p11_f2n, p11_f2b, a3_p11_f, p11_f3n, p11_f3b,
                a1_p00_f, p00_f1n, p00_f1b, a2_p00_f, p00_f2n, p00_f2b, a3_p00_f, p00_f3n, p00_f3b,
                a1_td_f, td_f1n, td_f1b, a2_td_f, td_f2n, td_f2b, a3_td_f, td_f3n, td_f3b,
                a1_vd_f, vd_f1n, vd_f1b, a2_vd_f, vd_f2n, vd_f2b, a3_vd_f, vd_f3n, vd_f3b,
                a1_p_el_f, p_el_f1n, p_el_f1b, a2_p_el_f, p_el_f2n, p_el_f2b, a3_p_el_f, p_el_f3n, p_el_f3b,
                sovmest, sovmest0, sovmest1;
            string s_name, s_el, s_func, s_predicat, add_name, sostav;
            i1 = 0;
            i2 = 0;
            i3 = 0;
            i_rez = 0;
            int type, work_type = f_WorkItem.TypeWorkShape;
            TParamAlternative PA;
            n_rez = f_WorkItem.Count;
            n1 = f_WorkItem.GetTFE_ID(i_rez);
            //pull
            PA = GetParamAlternativeByID(n1);
            i1 = PA.Count;
 /* param1 = (struct PARAM *)malloc(sizeof(struct PARAM)*i1);
  memset(param1, 0, sizeof(struct PARAM)*i1);
  for (int i = 0; i <= i1 - 1; i++)
  {
    AI = PA.Items[i];
    param1[i].par[0] = AI.B;
    param1[i].par[1] = AI.T;
    param1[i].par[2] = AI.V;
    param1[i].par_fuz[0][0] = AI.A1_B_F;
    param1[i].par_fuz[0][1] = AI.B_F1N;
    param1[i].par_fuz[0][2] = AI.B_F1B;
    param1[i].par_fuz[0][3] = AI.A2_B_F;
    param1[i].par_fuz[0][4] = AI.B_F2N;
    param1[i].par_fuz[0][5] = AI.B_F2B;
    param1[i].par_fuz[0][6] = AI.A3_B_F;
    param1[i].par_fuz[0][7] = AI.B_F3N;
    param1[i].par_fuz[0][8] = AI.B_F3B;

    param1[i].par_fuz[1][0] = AI.A1_T_F;
    param1[i].par_fuz[1][1] = AI.T_F1N;
    param1[i].par_fuz[1][2] = AI.T_F1B;
    param1[i].par_fuz[1][3] = AI.A2_T_F;
    param1[i].par_fuz[1][4] = AI.T_F2N;
    param1[i].par_fuz[1][5] = AI.T_F2B;
    param1[i].par_fuz[1][6] = AI.A3_T_F;
    param1[i].par_fuz[1][7] = AI.T_F3N;
    param1[i].par_fuz[1][8] = AI.T_F3B;

    param1[i].par_fuz[2][0] = AI.A1_V_F;
    param1[i].par_fuz[2][1] = AI.V_F1N;
    param1[i].par_fuz[2][2] = AI.V_F1B;
    param1[i].par_fuz[2][3] = AI.A2_V_F;
    param1[i].par_fuz[2][4] = AI.V_F2N;
    param1[i].par_fuz[2][5] = AI.V_F2B;
    param1[i].par_fuz[2][6] = AI.A3_V_F;
    param1[i].par_fuz[2][7] = AI.V_F3N;
    param1[i].par_fuz[2][8] = AI.V_F3B;

    StrLCopy(param1[i].stv, AI.SOSTAV.c_str(), StrMemSize);
        param1[i].stv[StrMemSize] = '\0';
    param1[i].sovm = AI.SOVM;
    param1[i].sovm0 = AI.SOVM0;
    param1[i].sovm1 = AI.SOVM1;
  }
    i_rez++;

  if(n_rez >= 2)
  {
    n2 = f_WorkItem.TFE_ID[i_rez];
    type = 5;
    if(f_WorkItem.TFE[i_rez] )
      type =  f_WorkItem.TFE[i_rez].TypeShape;
    if (type == 5)
    {
      PA = GetParamAlternativeByID(n2);
    i2 = PA.Count;
      param2 = (struct PARAM *)malloc(sizeof(struct PARAM)* i2);
      memset(param2, 0, sizeof(struct PARAM)* i2);
      for (int i = 0; i <= i2 - 1; i++)
      {
        AI = PA.Items[i];
        param2[i].par[0] = AI.B;
        param2[i].par[1] = AI.T;
        param2[i].par[2] = AI.V;
        param2[i].par_fuz[0][0] = AI.A1_B_F;
        param2[i].par_fuz[0][1] = AI.B_F1N;
        param2[i].par_fuz[0][2] = AI.B_F1B;
        param2[i].par_fuz[0][3] = AI.A2_B_F;
        param2[i].par_fuz[0][4] = AI.B_F2N;
        param2[i].par_fuz[0][5] = AI.B_F2B;
        param2[i].par_fuz[0][6] = AI.A3_B_F;
        param2[i].par_fuz[0][7] = AI.B_F3N;
        param2[i].par_fuz[0][8] = AI.B_F3B;

        param2[i].par_fuz[1][0] = AI.A1_T_F;
        param2[i].par_fuz[1][1] = AI.T_F1N;
        param2[i].par_fuz[1][2] = AI.T_F1B;
        param2[i].par_fuz[1][3] = AI.A2_T_F;
        param2[i].par_fuz[1][4] = AI.T_F2N;
        param2[i].par_fuz[1][5] = AI.T_F2B;
        param2[i].par_fuz[1][6] = AI.A3_T_F;
        param2[i].par_fuz[1][7] = AI.T_F3N;
        param2[i].par_fuz[1][8] = AI.T_F3B;

        param2[i].par_fuz[2][0] = AI.A1_V_F;
        param2[i].par_fuz[2][1] = AI.V_F1N;
        param2[i].par_fuz[2][2] = AI.V_F1B;
        param2[i].par_fuz[2][3] = AI.A2_V_F;
        param2[i].par_fuz[2][4] = AI.V_F2N;
        param2[i].par_fuz[2][5] = AI.V_F2B;
        param2[i].par_fuz[2][6] = AI.A3_V_F;
        param2[i].par_fuz[2][7] = AI.V_F3N;
        param2[i].par_fuz[2][8] = AI.V_F3B;

        StrLCopy(param2[i].stv, AI.SOSTAV.c_str(), StrMemSize);
    param2[i].stv[StrMemSize] = '\0';
        param2[i].sovm = AI.SOVM;
        param2[i].sovm0 = AI.SOVM0;
        param2[i].sovm1 = AI.SOVM1;

      }
i_rez++;
    }
  }


  if (n_rez >= 2)
  {
    n3 = f_WorkItem.TFE_ID[i_rez];
    type = 5;
    if(f_WorkItem.TFE[i_rez] )
      type =  f_WorkItem.TFE[i_rez].TypeShape;
    if (type != 5)
    {
      PA = GetParamAlternativeByID(n3);
i3 = PA.Count;
      param3 = (struct PARAM *)malloc(sizeof(struct PARAM)* i3);
      memset(param3, 0, sizeof(struct PARAM)* i3);
      for (int i = 0; i <= i3 - 1; i++)
      {
        AI = PA.Items[i];

        param3[i].par[3] = AI.P_11;
        param3[i].par[4] = AI.P_00;
        param3[i].par[5] = AI.T_D;
        param3[i].par[6] = AI.V_D;
        param3[i].par[7] = AI.P_DIAGN_EL;
        param3[i].par[8] = AI.K_11;
        param3[i].par[9] = AI.K_00;
        param3[i].par[10] = AI.T_F;
        param3[i].par[11] = AI.V_F;

        param3[i].par_fuz[3][0] = AI.A1_P11_F;
        param3[i].par_fuz[3][1] = AI.P11_F1N;
        param3[i].par_fuz[3][2] = AI.P11_F1B;
        param3[i].par_fuz[3][3] = AI.A2_P11_F;
        param3[i].par_fuz[3][4] = AI.P11_F2N;
        param3[i].par_fuz[3][5] = AI.P11_F2B;
        param3[i].par_fuz[3][6] = AI.A3_P11_F;
        param3[i].par_fuz[3][7] = AI.P11_F3N;
        param3[i].par_fuz[3][8] = AI.P11_F3B;

        param3[i].par_fuz[4][0] = AI.A1_P00_F;
        param3[i].par_fuz[4][1] = AI.P00_F1N;
        param3[i].par_fuz[4][2] = AI.P00_F1B;
        param3[i].par_fuz[4][3] = AI.A2_P00_F;
        param3[i].par_fuz[4][4] = AI.P00_F2N;
        param3[i].par_fuz[4][5] = AI.P00_F2B;
        param3[i].par_fuz[4][6] = AI.A3_P00_F;
        param3[i].par_fuz[4][7] = AI.P00_F3N;
        param3[i].par_fuz[4][8] = AI.P00_F3B;

        param3[i].par_fuz[5][0] = AI.A1_TD_F;
        param3[i].par_fuz[5][1] = AI.TD_F1N;
        param3[i].par_fuz[5][2] = AI.TD_F1B;
        param3[i].par_fuz[5][3] = AI.A2_TD_F;
        param3[i].par_fuz[5][4] = AI.TD_F2N;
        param3[i].par_fuz[5][5] = AI.TD_F2B;
        param3[i].par_fuz[5][6] = AI.A3_TD_F;
        param3[i].par_fuz[5][7] = AI.TD_F3N;
        param3[i].par_fuz[5][8] = AI.TD_F3B;

        param3[i].par_fuz[6][0] = AI.A1_VD_F;
        param3[i].par_fuz[6][1] = AI.VD_F1N;
        param3[i].par_fuz[6][2] = AI.VD_F1B;
        param3[i].par_fuz[6][3] = AI.A2_VD_F;
        param3[i].par_fuz[6][4] = AI.VD_F2N;
        param3[i].par_fuz[6][5] = AI.VD_F2B;
        param3[i].par_fuz[6][6] = AI.A3_VD_F;
        param3[i].par_fuz[6][7] = AI.VD_F3N;
        param3[i].par_fuz[6][8] = AI.VD_F3B;

        param3[i].par_fuz[7][0] = AI.A1_P_EL_F;
        param3[i].par_fuz[7][1] = AI.P_EL_F1N;
        param3[i].par_fuz[7][2] = AI.P_EL_F1B;
        param3[i].par_fuz[7][3] = AI.A2_P_EL_F;
        param3[i].par_fuz[7][4] = AI.P_EL_F2N;
        param3[i].par_fuz[7][5] = AI.P_EL_F2B;
        param3[i].par_fuz[7][6] = AI.A3_P_EL_F;
        param3[i].par_fuz[7][7] = AI.P_EL_F3N;
        param3[i].par_fuz[7][8] = AI.P_EL_F3B;

        param3[i].par_fuz[8][0] = AI.A1_K11_F;
        param3[i].par_fuz[8][1] = AI.K11_F1N;
        param3[i].par_fuz[8][2] = AI.K11_F1B;
        param3[i].par_fuz[8][3] = AI.A2_K11_F;
        param3[i].par_fuz[8][4] = AI.K11_F2N;
        param3[i].par_fuz[8][5] = AI.K11_F2B;
        param3[i].par_fuz[8][6] = AI.A3_K11_F;
        param3[i].par_fuz[8][7] = AI.K11_F3N;
        param3[i].par_fuz[8][8] = AI.K11_F3B;

        param3[i].par_fuz[9][0] = AI.A1_K00_F;
        param3[i].par_fuz[9][1] = AI.K00_F1N;
        param3[i].par_fuz[9][2] = AI.K00_F1B;
        param3[i].par_fuz[9][3] = AI.A2_K00_F;
        param3[i].par_fuz[9][4] = AI.K00_F2N;
        param3[i].par_fuz[9][5] = AI.K00_F2B;
        param3[i].par_fuz[9][6] = AI.A3_K00_F;
        param3[i].par_fuz[9][7] = AI.K00_F3N;
        param3[i].par_fuz[9][8] = AI.K00_F3B;

        param3[i].par_fuz[10][0] = AI.A1_TF_F;
        param3[i].par_fuz[10][1] = AI.TF_F1N;
        param3[i].par_fuz[10][2] = AI.TF_F1B;
        param3[i].par_fuz[10][3] = AI.A2_TF_F;
        param3[i].par_fuz[10][4] = AI.TF_F2N;
        param3[i].par_fuz[10][5] = AI.TF_F2B;
        param3[i].par_fuz[10][6] = AI.A3_TF_F;
        param3[i].par_fuz[10][7] = AI.TF_F3N;
        param3[i].par_fuz[10][8] = AI.TF_F3B;

        param3[i].par_fuz[11][0] = AI.A1_VF_F;
        param3[i].par_fuz[11][1] = AI.VF_F1N;
        param3[i].par_fuz[11][2] = AI.VF_F1B;
        param3[i].par_fuz[11][3] = AI.A2_VF_F;
        param3[i].par_fuz[11][4] = AI.VF_F2N;
        param3[i].par_fuz[11][5] = AI.VF_F2B;
        param3[i].par_fuz[11][6] = AI.A3_VF_F;
        param3[i].par_fuz[11][7] = AI.VF_F3N;
        param3[i].par_fuz[11][8] = AI.VF_F3B;
        if (AI.CheckPLG)
          s_predicat = "1";
        else
          s_predicat = "0";
        StrLCopy(param3[i].stv, AI.SOSTAV.c_str(), StrMemSize);
param3[i].stv[StrMemSize]='\0';
        param3[i].sovm = AI.SOVM;
        param3[i].sovm0 = AI.SOVM0;
        param3[i].sovm1 = AI.SOVM1;
      }
    }*/
        }
        void proverka_type_krit(int type_krit)
        {
            //Алгоритм
            //признак удаления в FALSE
            //Начинаем с начала отфильтрованной таблицы
            //Цикл (  пока признак удаления = = TRUE )
            //1. Берем ПА (параметрическую альтернативу)
            //2. Сравниваем с остальными ПА
            //   Если для текущей ПА не выполняется НУОпт - удаляем эту ПА и признак удаления в TRUE
            //   Иначе идем дальше по таблице
            //3. Если конец таблицы, то снова в начало

            //фильтр для текущего подблока
            string str, str_next;
            double b, t, v, b_next, t_next, v_next; //,sovm,sovm_next;

            TParamAlternativeItem AI, AJ;

            TDynamicArray mDel = new TDynamicArray();
            for (int i = 0; i <= f_ParamAlt.Count - 1; i++)
            {
                AI = f_ParamAlt.Items[i];
                if (mDel.Find(AI)==null)
                {
                    b = AI.B;
                    t = AI.T;
                    v = AI.V;
                    str = AI.SOSTAV;
                    for (int j = 0; j <= f_ParamAlt.Count - 1; j++)
                    {
                        AJ = f_ParamAlt.Items[j];
                        if ((i != j) && (mDel.Find(AJ)==null))
                        {
                            b_next = AJ.B;
                            t_next = AJ.T;
                            v_next = AJ.V;
                            str_next = AJ.SOSTAV;

                            //если частичное решение с b_next доминирует частичное решение с b, то удаляем решение b
                            switch (type_krit)
                            {
                                case SharedConst.BB: if (domin_P_B(b_next, b)) mDel.Append(AI); break;
                                case SharedConst.BT: if (domin_P_BT(b_next, b, t_next, t)) mDel.Append(AI); break;
                                case SharedConst.BV: if (domin_P_BV(b_next, b, v_next, v)) mDel.Append(AI); break;
                                case SharedConst.BTV: if (domin_P_BTV(b_next, b, t_next, t, v_next, v)) mDel.Append(AI); break;
                                case SharedConst.BBS: if (domin_P_B_S(b_next, b, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BTS: if (domin_P_BT_S(b_next, b, t_next, t, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BVS: if (domin_P_BV_S(b_next, b, v_next, v, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BTVS: if (domin_P_BTV_S(b_next, b, t_next, t, v_next, v, str_next, str)) mDel.Append(AI); break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i <= mDel.Count - 1; i++)
                f_ParamAlt.Delete2((TParamAlternativeItem)mDel.GetItems(i));
            proverka_priblj(SharedConst.opt_sadacha.Rate);
            if (f_Parent.CheckNud)
                proverka_nud();
        }
        bool domin_P_BTV(double b1, double b2, double t1, double t2, double v1, double v2)
        {
            if (b1 >= b2 && t1 <= t2 && v1 <= v2) return true;
            else return false;
        }
        bool domin_P_BT(double b1, double b2, double t1, double t2)
        {
            /*if((b1 >= b2  && t1<=t2)  ||
                  (b1 >= b2 && t1<t2)) */
            if (b1 >= b2 && t1 <= t2) return true;
            else return false;
        }
        bool domin_P_B(double b1, double b2)
        {
            //если частичное решение с b1 доминирует
            //частичное решение с b2, то удаляем част. решение b2
            if (b1 >= b2) return true;
            else return false;
        }
        bool domin_P_BV(double b1, double b2, double v1, double v2)
        {
            if (b1 >= b2 && v1 <= v2)
                return true;
            else return false;
        }
        bool domin_P_BTV_S(double b1, double b2, double t1, double t2, double v1, double v2, string S1, string S2)
        {

            if (domin_S(S1, S2) == 2) return true;
            if (domin_S(S1, S2) == 0) return false;
            if ((domin_S(S1, S2) == 1 || domin_S(S1, S2) == 3) && (b1 >= b2 && t1 <= t2 && v1 <= v2)) return true;
            else return false;
        }
        bool domin_P_B_S(double b1, double b2, string S1, string S2)
        {
            //если частичное решение с b1 доминирует
            //частичное решение с b2, то удаляем част. решение b2
            if (domin_S(S1, S2) == 2) return true;
            if (domin_S(S1, S2) == 0) return false;
            if ((domin_S(S1, S2) == 1 || domin_S(S1, S2) == 3) && (b1 >= b2)) return true;
            else return false;
        }
        bool domin_P_BT_S(double b1, double b2, double t1, double t2, string S1, string S2)
        {
            if (domin_S(S1, S2) == 2) return true;
            if (domin_S(S1, S2) == 0) return false;
            if ((domin_S(S1, S2) == 1 || domin_S(S1, S2) == 3) && (b1 >= b2 && t1 <= t2)) return true;
            else return false;
        }
        bool domin_P_BV_S(double b1, double b2, double v1, double v2, string S1, string S2)
        {

            if (domin_S(S1, S2) == 2) return true;
            if (domin_S(S1, S2) == 0) return false;
            if ((domin_S(S1, S2) == 1 || domin_S(S1, S2) == 3) && (b1 >= b2 && v1 <= v2)) return true;
            else return false;
        }
        bool domin_P_BV_fuz(double a1_b1_f, double b1_f1n, double b1_f1b,
            double a2_b1_f, double b1_f2n, double b1_f2b, double a3_b1_f, double b1_f3n, double b1_f3b,
            double a1_b2_f, double b2_f1n, double b2_f1b,
            double a2_b2_f, double b2_f2n, double b2_f2b, double a3_b2_f, double b2_f3n, double b2_f3b,
            double a1_v1_f, double v1_f1n, double v1_f1b,
            double a2_v1_f, double v1_f2n, double v1_f2b, double a3_v1_f, double v1_f3n, double v1_f3b,
            double a1_v2_f, double v2_f1n, double v2_f1b,
            double a2_v2_f, double v2_f2n, double v2_f2b, double a3_v2_f, double v2_f3n, double v2_f3b)
        {

            double B1, B2, V1, V2;
            B1 = b1_f1n + b1_f1b + b1_f2n + b1_f2b + b1_f3n + b1_f3b; //(s11+s21+s31+s41+s51+s61);
            B2 = b2_f1n + b2_f1b + b2_f2n + b2_f2b + b2_f3n + b2_f3b; //(s12+s22+s32+s42+s52+s62);
            V1 = v1_f1n + v1_f1b + v1_f2n + v1_f2b + v1_f3n + v1_f3b; //(d11+d21+d31+d41+d51+d61);
            V2 = v2_f1n + v2_f1b + v2_f2n + v2_f2b + v2_f3n + v2_f3b; //(d12+d22+d32+d42+d52+d62);

            if (B1 >= B2 && V1 <= V2)
                return true;
            else return false;
        }
        int domin_S(string S1, string S2)
        {
            int i1, I, J;
            char[] n1 = new char[1024], n2 = new char[1024];
            int[] n3 = new int[1024], n4 = new int[1024], n40 = new int[1024], n30 = new int[1024];
            string p;
            n1[0] = '\0';
            n2[0] = '\0';
            for (i1 = 0; i1 < SharedConst.opt_sadacha.OptSovm.HiCol() + 1; i1++)
            {
                n3[i1] = 0; n4[i1] = 0;
                n30[i1] = 0; n40[i1] = 0;
            }
            p = S1;
            int q = 0;
            for (; ; )
            {
                i1 = 0; while (p[q] != ';' && p[q] != ':' && p[q] != '\0') n1[i1++] = p[q++]; n1[i1] = '\0';
                q++; i1 = 0; while (p[q] != ';' && p[q] != ':' && p[q] != '\0') n2[i1++] =  p[q++]; n2[i1] = '\0';
                n3[Int32.Parse(n1.ToString())] = Int32.Parse(n2.ToString());
                if (p[q] != '\0') { q++; continue; }
                else break;
            }
            p = S2;
            q = 0;
            for (; ; )
            {
                i1 = 0; while (p[q] != ';' && p[q] != ':' && p[q] != '\0') n1[i1++] = p[q++]; n1[i1] = '\0';
                q++; i1 = 0; while (p[q] != ';' && p[q] != ':' && p[q] != '\0') n2[i1++] = p[q++]; n2[i1] = '\0';
                n4[Int32.Parse(n1.ToString())] = Int32.Parse(n2.ToString());
                if (p[q] != '\0') { q++; continue; }
                else break;
            }

            int k = 0, k1 = 0, k2;
            for (I = 0; I < SharedConst.opt_sadacha.OptSovm.HiRow() + 1; I++)
            {
                for (J = 0; J < SharedConst.opt_sadacha.OptSovm.HiCol() + 1; J++)
                {
                    if ((int)SharedConst.opt_sadacha.OptSovm.GetItems(I,J) != 0) k++;
                    if (((int)SharedConst.opt_sadacha.OptSovm.GetItems(I, J) != 0) && ((int)SharedConst.opt_sadacha.OptSovm.GetItems(I, J) == n4[J])) { n40[J] = n4[J]; k1++; }
                }
                if ((k1 != k) || (k == 0)) { k = 0; k1 = 0; continue; }
                else return 2;  //надо удалять безусловно
            }
            k = 0; k1 = 0;
            for (I = 0; I < SharedConst.opt_sadacha.OptSovm.HiRow() + 1; I++)
            {
                for (J = 0; J < SharedConst.opt_sadacha.OptSovm.HiCol() + 1; J++)
                {
                    if ((int)SharedConst.opt_sadacha.OptSovm.GetItems(I, J) != 0) k++;
                    if (((int)SharedConst.opt_sadacha.OptSovm.GetItems(I, J) != 0) && ((int)SharedConst.opt_sadacha.OptSovm.GetItems(I,J) == n3[J])) { n30[J] = n3[J]; k1++; }
                }
                if ((k1 != k) || (k == 0)) { k = 0; k1 = 0; continue; }
                else return 0;  //нельзя удалять
            }

            k = 0;  k1 = 0; k2 = 0;
            for (J = 0; J < SharedConst.opt_sadacha.OptSovm.HiCol() + 1; J++)
            {
                if (n30[J] != 0) k++;
                if (n30[J] != n40[J]) k2++;
                if ((n30[J] != 0) && (n30[J] == n40[J])) k1++;
            }
            if (k2 == 0) return 3;
            if (k1 != k) return 0;
            else return 1; // надо проверить условие на параметры
        }
        void proverka_type_krit_fuz(int type_krit)
        {
            //Алгоритм
            //признак удаления в FALSE
            //Начинаем с начала отфильтрованной таблицы
            //Цикл (  пока признак удаления = = TRUE )
            //1. Берем ПА (параметрическую альтернативу)
            //2. Сравниваем с остальными ПА
            //   Если для текущей ПА не выполняется НУОпт - удаляем эту ПА и признак удаления в TRUE
            //   Иначе идем дальше по таблице
            //3. Если конец таблицы, то снова в начало

            string str, str_next;
            double a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
              a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b,
              a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b,
              a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
              a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
              a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b;

            TParamAlternativeItem AI, AJ;

            TDynamicArray mDel = new TDynamicArray();
            for (int i = 0; i <= f_ParamAlt.Count - 1; i++)
            {
                AI = f_ParamAlt.Items[i];
                if (mDel.Find(AI)==null)
                {

                    a1_b_f = AI.A1_B_F;
                    b_f1n = AI.B_F1N;
                    b_f1b = AI.B_F1B;
                    a2_b_f = AI.A2_B_F;
                    b_f2n = AI.B_F2N;
                    b_f2b = AI.B_F2B;
                    a3_b_f = AI.A3_B_F;
                    b_f3n = AI.B_F3N;
                    b_f3b = AI.B_F3B;

                    a1_t_f = AI.A1_T_F;
                    t_f1n = AI.T_F1N;
                    t_f1b = AI.T_F1B;
                    a2_t_f = AI.A2_T_F;
                    t_f2n = AI.T_F2N;
                    t_f2b = AI.T_F2B;
                    a3_t_f = AI.A3_T_F;
                    t_f3n = AI.T_F3N;
                    t_f3b = AI.T_F3B;

                    a1_v_f = AI.A1_V_F;
                    v_f1n = AI.V_F1N;
                    v_f1b = AI.V_F1B;
                    a2_v_f = AI.A2_V_F;
                    v_f2n = AI.V_F2N;
                    v_f2b = AI.V_F2B;
                    a3_v_f = AI.A3_V_F;
                    v_f3n = AI.V_F3N;
                    v_f3b = AI.V_F3B;
                    str = AI.SOSTAV;

                    for (int j = 0; j <= f_ParamAlt.Count - 1; j++)
                    {
                        AJ = f_ParamAlt.Items[j];
                        if ((i != j) && (mDel.Find(AJ)==null))
                        {
                            a1_b_n_f = AJ.A1_B_F;
                            b_n_f1n = AJ.B_F1N;
                            b_n_f1b = AJ.B_F1B;
                            a2_b_n_f = AJ.A2_B_F;
                            b_n_f2n = AJ.B_F2N;
                            b_n_f2b = AJ.B_F2B;
                            a3_b_n_f = AJ.A3_B_F;
                            b_n_f3n = AJ.B_F3N;
                            b_n_f3b = AJ.B_F3B;

                            a1_t_n_f = AJ.A1_T_F;
                            t_n_f1n = AJ.T_F1N;
                            t_n_f1b = AJ.T_F1B;
                            a2_t_n_f = AJ.A2_T_F;
                            t_n_f2n = AJ.T_F2N;
                            t_n_f2b = AJ.T_F2B;
                            a3_t_n_f = AJ.A3_T_F;
                            t_n_f3n = AJ.T_F3N;
                            t_n_f3b = AJ.T_F3B;

                            a1_v_n_f = AJ.A1_V_F;
                            v_n_f1n = AJ.V_F1N;
                            v_n_f1b = AJ.V_F1B;
                            a2_v_n_f = AJ.A2_V_F;
                            v_n_f2n = AJ.V_F2N;
                            v_n_f2b = AJ.V_F2B;
                            a3_v_n_f = AJ.A3_V_F;
                            v_n_f3n = AJ.V_F3N;
                            v_n_f3b = AJ.V_F3B;
                            str_next = AJ.SOSTAV;

                            //если частичное решение с b_next доминирует частичное решение с b, то удаляем решение b
                            switch (type_krit)
                            {
                                case SharedConst.BB:
                                    if (domin_P_B_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                               a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b)) mDel.Append(AI); break;
                                case SharedConst.BT:
                                    if (domin_P_BT_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                     a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                     a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
                                     a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b)) mDel.Append(AI); break;
                                case SharedConst.BV:
                                    if (domin_P_BV_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                     a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                     a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b,
                                     a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b)) mDel.Append(AI); break;
                                case SharedConst.BTV:
                                    if (domin_P_BTV_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                    a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                    a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
                                    a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b,
                                    a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b,
                                    a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b)) mDel.Append(AI); break;
                                case SharedConst.BBS:
                                    if (domin_P_BS_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                              a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BTS:
                                    if (domin_P_BTS_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                    a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                    a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
                                    a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BVS:
                                    if (domin_P_BVS_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                    a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                    a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b,
                                    a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b, str_next, str)) mDel.Append(AI); break;
                                case SharedConst.BTVS:
                                    if (domin_P_BTVS_fuz(a1_b_n_f, b_n_f1n, b_n_f1b, a2_b_n_f, b_n_f2n, b_n_f2b, a3_b_n_f, b_n_f3n, b_n_f3b,
                                   a1_b_f, b_f1n, b_f1b, a2_b_f, b_f2n, b_f2b, a3_b_f, b_f3n, b_f3b,
                                   a1_t_n_f, t_n_f1n, t_n_f1b, a2_t_n_f, t_n_f2n, t_n_f2b, a3_t_n_f, t_n_f3n, t_n_f3b,
                                   a1_t_f, t_f1n, t_f1b, a2_t_f, t_f2n, t_f2b, a3_t_f, t_f3n, t_f3b,
                                   a1_v_n_f, v_n_f1n, v_n_f1b, a2_v_n_f, v_n_f2n, v_n_f2b, a3_v_n_f, v_n_f3n, v_n_f3b,
                                   a1_v_f, v_f1n, v_f1b, a2_v_f, v_f2n, v_f2b, a3_v_f, v_f3n, v_f3b, str_next, str)) mDel.Append(AI); break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i <= mDel.Count - 1; i++)
                f_ParamAlt.Delete2((TParamAlternativeItem)mDel.GetItems(i));
            proverka_priblj_fuz(SharedConst.opt_sadacha.Rate);
            if (f_Parent.CheckNud)
                proverka_nud_fuz();

        }
        bool domin_P_B_fuz(double a1_b1_f, double b1_f1n, double b1_f1b,
            double a2_b1_f, double b1_f2n, double b1_f2b, double a3_b1_f, double b1_f3n, double b1_f3b,
            double a1_b2_f, double b2_f1n, double b2_f1b,
            double a2_b2_f, double b2_f2n, double b2_f2b, double a3_b2_f, double b2_f3n, double b2_f3b)
        {
            if ((b1_f1n + b1_f1b + b1_f2n + b1_f2b + b1_f3n + b1_f3b) >= (b2_f1n + b2_f1b + b2_f2n + b2_f2b + b2_f3n + b2_f3b))
                //if( (s11+s21+s31+s41+s51+s61) > (s12+s22+s32+s42+s52+s62) )
                return true;
            else return false;
        }
        bool domin_P_BS_fuz(double a1_b1_f, double b1_f1n, double b1_f1b,
            double a2_b1_f, double b1_f2n, double b1_f2b, double a3_b1_f, double b1_f3n, double b1_f3b,
            double a1_b2_f, double b2_f1n, double b2_f1b,
            double a2_b2_f, double b2_f2n, double b2_f2b, double a3_b2_f, double b2_f3n, double b2_f3b, string S1, string S2)
        {

            if (domin_S(S1, S2) == 2) return true;
            if (domin_S(S1, S2) == 0) return false;
            if ((domin_S(S1, S2) == 1 || domin_S(S1, S2) == 3) && ((b1_f1n + b1_f1b + b1_f2n + b1_f2b + b1_f3n + b1_f3b) >= (b2_f1n + b2_f1b + b2_f2n + b2_f2b + b2_f3n + b2_f3b)))
                return true;
            else return false;
        }
        bool domin_P_BVS_fuz(double a1_b1_f, double b1_f1n, double b1_f1b,
            double a2_b1_f, double b1_f2n, double b1_f2b, double a3_b1_f, double b1_f3n, double b1_f3b,
            double a1_b2_f, double b2_f1n, double b2_f1b,
            double a2_b2_f, double b2_f2n, double b2_f2b, double a3_b2_f, double b2_f3n, double b2_f3b,
            double a1_v1_f, double v1_f1n, double v1_f1b,
            double a2_v1_f, double v1_f2n, double v1_f2b, double a3_v1_f, double v1_f3n, double v1_f3b,
            double a1_v2_f, double v2_f1n, double v2_f1b,
            double a2_v2_f, double v2_f2n, double v2_f2b, double a3_v2_f, double v2_f3n, double v2_f3b, string S1, string S2)
        {

            double B1, B2, V1, V2;
            B1 = b1_f1n + b1_f1b + b1_f2n + b1_f2b + b1_f3n + b1_f3b; //(s11+s21+s31+s41+s51+s61);
            B2 = b2_f1n + b2_f1b + b2_f2n + b2_f2b + b2_f3n + b2_f3b; //(s12+s22+s32+s42+s52+s62);
            V1 = v1_f1n + v1_f1b + v1_f2n + v1_f2b + v1_f3n + v1_f3b; //(d11+d21+d31+d41+d51+d61);
            V2 = v2_f1n + v2_f1b + v2_f2n + v2_f2b + v2_f3n + v2_f3b; //(d12+d22+d32+d42+d52+d62);


            if (domin_S(S1, S2) == 2) return true;
            if (domin_S(S1, S2) == 0) return false;
            if ((domin_S(S1, S2) == 1 || domin_S(S1, S2) == 3) && (B1 >= B2 && V1 <= V2))
                return true;
            else return false;
        }
        bool domin_P_BT_fuz(double a1_b1_f, double b1_f1n, double b1_f1b,
            double a2_b1_f, double b1_f2n, double b1_f2b, double a3_b1_f, double b1_f3n, double b1_f3b,
            double a1_b2_f, double b2_f1n, double b2_f1b,
            double a2_b2_f, double b2_f2n, double b2_f2b, double a3_b2_f, double b2_f3n, double b2_f3b,
            double a1_t1_f, double t1_f1n, double t1_f1b,
            double a2_t1_f, double t1_f2n, double t1_f2b, double a3_t1_f, double t1_f3n, double t1_f3b,
            double a1_t2_f, double t2_f1n, double t2_f1b,
            double a2_t2_f, double t2_f2n, double t2_f2b, double a3_t2_f, double t2_f3n, double t2_f3b)
        {

            double B1, B2, T1, T2;
            B1 = b1_f1n + b1_f1b + b1_f2n + b1_f2b + b1_f3n + b1_f3b; //(s11+s21+s31+s41+s51+s61);
            B2 = b2_f1n + b2_f1b + b2_f2n + b2_f2b + b2_f3n + b2_f3b; //(s12+s22+s32+s42+s52+s62);
            T1 = t1_f1n + t1_f1b + t1_f2n + t1_f2b + t1_f3n + t1_f3b; //(d11+d21+d31+d41+d51+d61);
            T2 = t2_f1n + t2_f1b + t2_f2n + t2_f2b + t2_f3n + t2_f3b; //(d12+d22+d32+d42+d52+d62);

            //если сумма по всем альфа-уровням больше , то решение доминирует
            if (B1 >= B2 && T1 <= T2) return true;
            else return false;
        }
        bool domin_P_BTV_fuz(double a1_b1_f, double b1_f1n, double b1_f1b,
            double a2_b1_f, double b1_f2n, double b1_f2b, double a3_b1_f, double b1_f3n, double b1_f3b,
            double a1_b2_f, double b2_f1n, double b2_f1b,
            double a2_b2_f, double b2_f2n, double b2_f2b, double a3_b2_f, double b2_f3n, double b2_f3b,
            double a1_t1_f, double t1_f1n, double t1_f1b,
            double a2_t1_f, double t1_f2n, double t1_f2b, double a3_t1_f, double t1_f3n, double t1_f3b,
            double a1_t2_f, double t2_f1n, double t2_f1b,
            double a2_t2_f, double t2_f2n, double t2_f2b, double a3_t2_f, double t2_f3n, double t2_f3b,
            double a1_v1_f, double v1_f1n, double v1_f1b,
            double a2_v1_f, double v1_f2n, double v1_f2b, double a3_v1_f, double v1_f3n, double v1_f3b,
            double a1_v2_f, double v2_f1n, double v2_f1b,
            double a2_v2_f, double v2_f2n, double v2_f2b, double a3_v2_f, double v2_f3n, double v2_f3b)
        {

            double B1, B2, V1, V2, T1, T2;
            B1 = b1_f1n + b1_f1b + b1_f2n + b1_f2b + b1_f3n + b1_f3b; //(s11+s21+s31+s41+s51+s61);
            B2 = b2_f1n + b2_f1b + b2_f2n + b2_f2b + b2_f3n + b2_f3b; //(s12+s22+s32+s42+s52+s62);
            T1 = t1_f1n + t1_f1b + t1_f2n + t1_f2b + t1_f3n + t1_f3b; //(d11+d21+d31+d41+d51+d61);
            T2 = t2_f1n + t2_f1b + t2_f2n + t2_f2b + t2_f3n + t2_f3b;
            V1 = v1_f1n + v1_f1b + v1_f2n + v1_f2b + v1_f3n + v1_f3b; //(d11+d21+d31+d41+d51+d61);
            V2 = v2_f1n + v2_f1b + v2_f2n + v2_f2b + v2_f3n + v2_f3b;


            if (B1 >= B2 && T1 <= T2 && V1 <= V2) return true;
            else return false;
        }
        bool domin_P_BTS_fuz(double a1_b1_f, double b1_f1n, double b1_f1b,
            double a2_b1_f, double b1_f2n, double b1_f2b, double a3_b1_f, double b1_f3n, double b1_f3b,
            double a1_b2_f, double b2_f1n, double b2_f1b,
            double a2_b2_f, double b2_f2n, double b2_f2b, double a3_b2_f, double b2_f3n, double b2_f3b,
            double a1_t1_f, double t1_f1n, double t1_f1b,
            double a2_t1_f, double t1_f2n, double t1_f2b, double a3_t1_f, double t1_f3n, double t1_f3b,
            double a1_t2_f, double t2_f1n, double t2_f1b,
            double a2_t2_f, double t2_f2n, double t2_f2b, double a3_t2_f, double t2_f3n, double t2_f3b, string S1, string S2)
        {
            double B1, B2, T1, T2;
            B1 = b1_f1n + b1_f1b + b1_f2n + b1_f2b + b1_f3n + b1_f3b; //(s11+s21+s31+s41+s51+s61);
            B2 = b2_f1n + b2_f1b + b2_f2n + b2_f2b + b2_f3n + b2_f3b; //(s12+s22+s32+s42+s52+s62);
            T1 = t1_f1n + t1_f1b + t1_f2n + t1_f2b + t1_f3n + t1_f3b; //(d11+d21+d31+d41+d51+d61);
            T2 = t2_f1n + t2_f1b + t2_f2n + t2_f2b + t2_f3n + t2_f3b; //(d12+d22+d32+d42+d52+d62);

            if (domin_S(S1, S2) == 2) return true;
            if (domin_S(S1, S2) == 0) return false;
            if ((domin_S(S1, S2) == 1 || domin_S(S1, S2) == 3) && (B1 >= B2 && T1 <= T2)) return true;
            else return false;
        }
        bool domin_P_BTVS_fuz(double a1_b1_f, double b1_f1n, double b1_f1b,
            double a2_b1_f, double b1_f2n, double b1_f2b, double a3_b1_f, double b1_f3n, double b1_f3b,
            double a1_b2_f, double b2_f1n, double b2_f1b,
            double a2_b2_f, double b2_f2n, double b2_f2b, double a3_b2_f, double b2_f3n, double b2_f3b,
            double a1_t1_f, double t1_f1n, double t1_f1b,
            double a2_t1_f, double t1_f2n, double t1_f2b, double a3_t1_f, double t1_f3n, double t1_f3b,
            double a1_t2_f, double t2_f1n, double t2_f1b,
            double a2_t2_f, double t2_f2n, double t2_f2b, double a3_t2_f, double t2_f3n, double t2_f3b,
            double a1_v1_f, double v1_f1n, double v1_f1b,
            double a2_v1_f, double v1_f2n, double v1_f2b, double a3_v1_f, double v1_f3n, double v1_f3b,
            double a1_v2_f, double v2_f1n, double v2_f1b,
            double a2_v2_f, double v2_f2n, double v2_f2b, double a3_v2_f, double v2_f3n, double v2_f3b, string S1, string S2)
        {

            double B1, B2, V1, V2, T1, T2;
            B1 = b1_f1n + b1_f1b + b1_f2n + b1_f2b + b1_f3n + b1_f3b; //(s11+s21+s31+s41+s51+s61);
            B2 = b2_f1n + b2_f1b + b2_f2n + b2_f2b + b2_f3n + b2_f3b; //(s12+s22+s32+s42+s52+s62);
            T1 = t1_f1n + t1_f1b + t1_f2n + t1_f2b + t1_f3n + t1_f3b; //(d11+d21+d31+d41+d51+d61);
            T2 = t2_f1n + t2_f1b + t2_f2n + t2_f2b + t2_f3n + t2_f3b;
            V1 = v1_f1n + v1_f1b + v1_f2n + v1_f2b + v1_f3n + v1_f3b; //(d11+d21+d31+d41+d51+d61);
            V2 = v2_f1n + v2_f1b + v2_f2n + v2_f2b + v2_f3n + v2_f3b;

            if (domin_S(S1, S2) == 2) return true;
            if (domin_S(S1, S2) == 0) return false;
            if ((domin_S(S1, S2) == 1 || domin_S(S1, S2) == 3) && (B1 >= B2 && T1 <= T2 && V1 <= V2)) return true;
            else return false;
        }
        TParamAlternative GetParamAlternativeByID(int AID)
        {
            TBaseShape B;
            TPartialDecisionItem PDI;
            if (AID > 0)
            {
                for (int i = 0; i <= f_WorkItem.Count - 1; i++)
                {
                    B = f_WorkItem.GetTFE(i);
                    if (B!=null && (B.ID == AID))
                    {
                        FreeApd();
                        f_Apd = new TParamAlternative();
                        CopyAlternateParam2(f_Apd, B.ParamAlt, B.TypeShape == 8);

                        PDI = f_Parent.FindPartialDecisionItemByParentID(AID);
                        if (PDI!=null)
                            CopyAlternateParam2(f_Apd, PDI.ParamAlt, false);
                        return f_Apd;
                    }

                }
            }
            else
            {
                PDI = f_Parent.FindPartialDecisionItemByParentID(AID);
                return PDI.ParamAlt;
            }
            return null;
        }
        void proverka_priblj(double ARate)
        {
            Random rnd = new Random();
            TParamAlternativeItem AI;
            int in_zad = -1, paramCnt;
            double b, t, v, I11, I1;
            double b_cr, t_cr, v_cr;

            b_cr = 0;
            t_cr = 0;
            v_cr = 0;
            I11 = 0.0;

            int type_metod = SharedConst.opt_sadacha.get_type_metod();
            TDynamicArray mDel = new TDynamicArray();
            if (type_metod == SharedConst.PRIBLJ2)
            {
                paramCnt = f_ParamAlt.Count;
                for (int i = 0; i <= paramCnt - 1; i++)
                {
                    AI = f_ParamAlt.Items[i];
                    b = AI.B;
                    t = AI.T;
                    v = AI.V;
                    switch (SharedConst.opt_sadacha.type_sadacha)//не ищем экстрему среди записей, не подходящих по ограничениям
                    {
                        case SharedConst.ZAD_1:
                            switch (SharedConst.opt_sadacha.type_ogr)//задача по В
                            {
                                case 1:
                                    v_cr = v_cr + v;//критерий V
                                    in_zad = 3;
                                    break;
                                case 2:
                                    t_cr = t_cr + t;//критерий T
                                    in_zad = 2;
                                    break;
                                case 3:
                                    v_cr = v_cr + v;
                                    t_cr = t_cr + t;
                                    in_zad = 6;
                                    break;
                                case 4: break;
                                case 5:
                                    v_cr = v_cr + v;
                                    in_zad = 3;
                                    break;
                                case 6:
                                    t_cr = t_cr + t;
                                    in_zad = 2;
                                    break;
                                case 7:
                                    v_cr = v_cr + v;
                                    t_cr = t_cr + t;
                                    in_zad = 6;
                                    break;
                            }
                            break;
                        case SharedConst.ZAD_2:
                            switch (SharedConst.opt_sadacha.type_ogr)//задача по Т
                            {
                                case 1:
                                    v_cr = v_cr + v;
                                    in_zad = 3;
                                    break;
                                case 2:
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 1;
                                    break;
                                case 3:
                                    v_cr = v_cr + v;
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 5;
                                    break;
                                case 4: break;
                                case 5:
                                    v_cr = v_cr + v;
                                    in_zad = 3;
                                    break;
                                case 6:
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 1;
                                    break;
                                case 7:
                                    v_cr = v_cr + v;
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 5;
                                    break;
                            }
                            break;
                        case SharedConst.ZAD_3:
                            switch (SharedConst.opt_sadacha.type_ogr)//задача по V
                            {
                                case 1:
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 1;
                                    break;
                                case 2:
                                    t_cr = t_cr + t;
                                    in_zad = 2;
                                    break;
                                case 3:
                                    b_cr = b_cr + (1 - b);
                                    t_cr = t_cr + t;
                                    in_zad = 4;
                                    break;
                                case 4: break;
                                case 5:
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 1;
                                    break;
                                case 6:
                                    t_cr = t_cr + t;
                                    in_zad = 2;
                                    break;
                                case 7:
                                    b_cr = b_cr + (1 - b);
                                    t_cr = t_cr + t;
                                    in_zad = 4;
                                    break;
                            }
                            break;
                    }

                }
                if (paramCnt > 0)
                {
                    b_cr = b_cr / paramCnt;
                    t_cr = t_cr / paramCnt;
                    v_cr = v_cr / paramCnt;
                }

                for (int i = 0; i <= paramCnt - 1; i++)
                {
                    AI = f_ParamAlt.Items[i];
                    b = AI.B;
                    t = AI.T;
                    v = AI.V;
                    if (in_zad == 1)
                    {
                        if (b_cr == 0) continue;
                        I11 = (1 - b) / b_cr;
                    }
                    if (in_zad == 2)
                    {
                        if (t_cr == 0) continue;
                        I11 = t / t_cr;
                    }
                    if (in_zad == 3)
                    {
                        if (v_cr == 0) continue;
                        I11 = v / v_cr;
                    }
                    if (in_zad == 4)
                    {
                        if ((b_cr == 0) || (t_cr == 0)) continue;
                        I11 = 0.5 * ((1 - b) / b_cr + t / t_cr);
                    }
                    if (in_zad == 5)
                    {
                        if ((b_cr == 0) || (v_cr == 0)) continue;
                        I11 = 0.5 * ((1 - b) / b_cr + v / v_cr);
                    }
                    if (in_zad == 6)
                    {
                        if ((v_cr == 0) || (t_cr == 0)) continue;
                        I11 = 0.5 * (v / v_cr + t / t_cr);
                    }
                    I1 = rnd.Next(100);
                    if ((I1 - I11 * ARate) < 0.0)
                        mDel.Append(AI);
                }
            }
            if (type_metod == SharedConst.PRIBLJ1)
            {
                paramCnt = f_ParamAlt.Count;
                for (int i = 0; i <= paramCnt - 1; i++)
                {
                    AI = f_ParamAlt.Items[i];
                    I1 = rnd.Next(100);
                    if ((I1 - ARate) < 0.0)
                        mDel.Append(AI);
                }
            }

            for (int i = 0; i <= mDel.Count - 1; i++)
            {
                if (f_ParamAlt.Count > 1)
                    f_ParamAlt.Delete2((TParamAlternativeItem)mDel.GetItems(i));
            }
        }
        void proverka_priblj_fuz(double ARate)
        {
            Random rnd = new Random();
            TParamAlternativeItem AI;
            int in_zad = -1, paramCnt;
            double b, t, v, I11, I1;
            double b_cr, t_cr, v_cr;

            double b_n_f1n, b_n_f1b, b_n_f2n, b_n_f2b, b_n_f3n, b_n_f3b;
            double t_n_f1n, t_n_f1b, t_n_f2n, t_n_f2b, t_n_f3n, t_n_f3b;
            double v_n_f1n, v_n_f1b, v_n_f2n, v_n_f2b, v_n_f3n, v_n_f3b;

            b_cr = 0;
            t_cr = 0;
            v_cr = 0;
            I11 = 0.0;

            int type_metod = SharedConst.opt_sadacha.get_type_metod();
            TDynamicArray mDel = new TDynamicArray();
            if (type_metod == SharedConst.PRIBLJ2)
            {
                paramCnt = f_ParamAlt.Count;
                for (int i = 0; i <= paramCnt - 1; i++)
                {
                    AI = f_ParamAlt.Items[i];
                    b_n_f1n = AI.B_F1N;
                    b_n_f1b = AI.B_F1B;
                    b_n_f2n = AI.B_F2N;
                    b_n_f2b = AI.B_F2B;
                    b_n_f3n = AI.B_F3N;
                    b_n_f3b = AI.B_F3B;

                    t_n_f1n = AI.T_F1N;
                    t_n_f1b = AI.T_F1B;
                    t_n_f2n = AI.T_F2N;
                    t_n_f2b = AI.T_F2B;
                    t_n_f3n = AI.T_F3N;
                    t_n_f3b = AI.T_F3B;

                    v_n_f1n = AI.V_F1N;
                    v_n_f1b = AI.V_F1B;
                    v_n_f2n = AI.V_F2N;
                    v_n_f2b = AI.V_F2B;
                    v_n_f3n = AI.V_F3N;
                    v_n_f3b = AI.V_F3B;

                    b = (b_n_f1n + b_n_f1b + b_n_f2n + b_n_f2b + b_n_f3n + b_n_f3b) / 6.0;

                    t = (t_n_f1n + t_n_f1b + t_n_f2n + t_n_f2b + t_n_f3n + t_n_f3b) / 6.0;

                    v = (v_n_f1n + v_n_f1b + v_n_f2n + v_n_f2b + v_n_f3n + v_n_f3b) / 6.0;

                    switch (SharedConst.opt_sadacha.type_sadacha)
                    {
                        case SharedConst.ZAD_1:
                            switch (SharedConst.opt_sadacha.type_ogr)
                            {
                                case 1:
                                    v_cr = v_cr + v;
                                    in_zad = 3;
                                    break;
                                case 2:
                                    t_cr = t_cr + t;
                                    in_zad = 2;
                                    break;
                                case 3:
                                    v_cr = v_cr + v;
                                    t_cr = t_cr + t;
                                    in_zad = 6;
                                    break;
                                case 4: break;
                                case 5:
                                    v_cr = v_cr + v;
                                    in_zad = 3;
                                    break;
                                case 6:
                                    t_cr = t_cr + t;
                                    in_zad = 2;
                                    break;
                                case 7:
                                    v_cr = v_cr + v;
                                    t_cr = t_cr + t;
                                    in_zad = 6;
                                    break;
                            }
                            break;
                        case SharedConst.ZAD_2:
                            switch (SharedConst.opt_sadacha.type_ogr)
                            {
                                case 1:
                                    v_cr = v_cr + v;
                                    in_zad = 3;
                                    break;
                                case 2:
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 1;
                                    break;
                                case 3:
                                    v_cr = v_cr + v;
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 5;
                                    break;
                                case 4: break;
                                case 5:
                                    v_cr = v_cr + v;
                                    in_zad = 3;
                                    break;
                                case 6:
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 1;
                                    break;
                                case 7:
                                    v_cr = v_cr + v;
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 5;
                                    break;
                            }
                            break;
                        case SharedConst.ZAD_3:
                            switch (SharedConst.opt_sadacha.type_ogr)
                            {
                                case 1:
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 1;
                                    break;
                                case 2:
                                    t_cr = t_cr + t;
                                    in_zad = 2;
                                    break;
                                case 3:
                                    b_cr = b_cr + (1 - b);
                                    t_cr = t_cr + t;
                                    in_zad = 4;
                                    break;
                                case 4: break;
                                case 5:
                                    b_cr = b_cr + (1 - b);
                                    in_zad = 1;
                                    break;
                                case 6:
                                    t_cr = t_cr + t;
                                    in_zad = 2;
                                    break;
                                case 7:
                                    b_cr = b_cr + (1 - b);
                                    t_cr = t_cr + t;
                                    in_zad = 4;
                                    break;
                            }
                            break;
                    }
                }
                if (paramCnt > 0)
                {
                    b_cr = b_cr / paramCnt;
                    t_cr = t_cr / paramCnt;
                    v_cr = v_cr / paramCnt;
                }
                for (int i = 0; i <= paramCnt - 1; i++)
                {
                    AI = f_ParamAlt.Items[i];
                    b_n_f1n = AI.B_F1N;
                    b_n_f1b = AI.B_F1B;
                    b_n_f2n = AI.B_F2N;
                    b_n_f2b = AI.B_F2B;
                    b_n_f3n = AI.B_F3N;
                    b_n_f3b = AI.B_F3B;

                    t_n_f1n = AI.T_F1N;
                    t_n_f1b = AI.T_F1B;
                    t_n_f2n = AI.T_F2N;
                    t_n_f2b = AI.T_F2B;
                    t_n_f3n = AI.T_F3N;
                    t_n_f3b = AI.T_F3B;

                    v_n_f1n = AI.V_F1N;
                    v_n_f1b = AI.V_F1B;
                    v_n_f2n = AI.V_F2N;
                    v_n_f2b = AI.V_F2B;
                    v_n_f3n = AI.V_F3N;
                    v_n_f3b = AI.V_F3B;

                    b = (b_n_f1n + b_n_f1b + b_n_f2n + b_n_f2b + b_n_f3n + b_n_f3b) / 6.0;

                    t = (t_n_f1n + t_n_f1b + t_n_f2n + t_n_f2b + t_n_f3n + t_n_f3b) / 6.0;

                    v = (v_n_f1n + v_n_f1b + v_n_f2n + v_n_f2b + v_n_f3n + v_n_f3b) / 6.0;

                    if (in_zad == 1)
                    {
                        if (b_cr == 0) continue;
                        I11 = (1 - b) / b_cr;
                    }
                    if (in_zad == 2)
                    {
                        if (t_cr == 0) continue;
                        I11 = t / t_cr;
                    }
                    if (in_zad == 3)
                    {
                        if (v_cr == 0) continue;
                        I11 = v / v_cr;
                    }
                    if (in_zad == 4)
                    {
                        if ((b_cr == 0) || (t_cr == 0)) continue;
                        I11 = 0.5 * ((1 - b) / b_cr + t / t_cr);
                    }
                    if (in_zad == 5)
                    {
                        if ((b_cr == 0) || (v_cr == 0)) continue;
                        I11 = 0.5 * ((1 - b) / b_cr + v / v_cr);
                    }
                    if (in_zad == 6)
                    {
                        if ((v_cr == 0) || (t_cr == 0)) continue;
                        I11 = 0.5 * (v / v_cr + t / t_cr);
                    }

                    I1 = rnd.Next(100);
                    if ((I1 - I11 * ARate) < 0.0)
                        mDel.Append(AI);
                }
            }
            if (type_metod == SharedConst.PRIBLJ1)
            {
                paramCnt = f_ParamAlt.Count;
                for (int i = 0; i <= paramCnt - 1; i++)
                {
                    AI = f_ParamAlt.Items[i];
                    I1 = rnd.Next(100);
                    if ((I1 - ARate) < 0.0)
                        mDel.Append(AI);
                }
            }

            for (int i = 0; i <= mDel.Count - 1; i++)
            {
                if (f_ParamAlt.Count > 1)
                    f_ParamAlt.Delete2((TParamAlternativeItem)mDel.GetItems(i));
            }

        }
        void proverka_nud()
        {
            double t, v;
            TParamAlternativeItem AI;

            TDynamicArray mDel = new TDynamicArray();
            for (int i = 0; i <= f_ParamAlt.Count - 1; i++)
            {
                AI = f_ParamAlt.Items[i];
                if (mDel.Find(AI)==null)
                {
                    t = AI.T;
                    v = AI.V;
                    switch (SharedConst.opt_sadacha.type_t_v())
                    {
                        case 1:
                            if (f_Parent.CheckOzenk_TFE_t(this, t))
                                mDel.Append(AI);
                            break;

                        case 2:
                            if (f_Parent.CheckOzenk_TFE_v(this, v))
                                mDel.Append(AI);
                            break;

                        case 3:
                            if (f_Parent.CheckOzenk_TFE_t(this, t) || f_Parent.CheckOzenk_TFE_v(this, v))
                                mDel.Append(AI);
                            break;
                    }
                }
            }
            for (int i = 0; i <= mDel.Count - 1; i++)
                f_ParamAlt.Delete2((TParamAlternativeItem)mDel.GetItems(i));
        }
        void proverka_nud_fuz()
        {
            double t, v;
            double t_n_f1n, t_n_f1b, t_n_f2n, t_n_f2b, t_n_f3n, t_n_f3b;
            double v_n_f1n, v_n_f1b, v_n_f2n, v_n_f2b, v_n_f3n, v_n_f3b;
            TParamAlternativeItem AI;

            TDynamicArray mDel = new TDynamicArray();
            for (int i = 0; i <= f_ParamAlt.Count - 1; i++)
            {
                AI = f_ParamAlt.Items[i];
                if (mDel.Find(AI)==null)
                {
                    t_n_f1n = AI.T_F1N;
                    t_n_f1b = AI.T_F1B;
                    t_n_f2n = AI.T_F2N;
                    t_n_f2b = AI.T_F2B;
                    t_n_f3n = AI.T_F3N;
                    t_n_f3b = AI.T_F3B;
                    t = (t_n_f1n + t_n_f1b + t_n_f2n + t_n_f2b + t_n_f3n + t_n_f3b) / 6;

                    v_n_f1n = AI.V_F1N;
                    v_n_f1b = AI.V_F1B;
                    v_n_f2n = AI.V_F2N;
                    v_n_f2b = AI.V_F2B;
                    v_n_f3n = AI.V_F3N;
                    v_n_f3b = AI.V_F3B;
                    v = (v_n_f1n + v_n_f1b + v_n_f2n + v_n_f2b + v_n_f3n + v_n_f3b) / 6;

                    switch (SharedConst.opt_sadacha.type_t_v())
                    {
                        case 1:
                            if (f_Parent.CheckOzenk_TFE_t(this, t))
                                mDel.Append(AI);
                            break;

                        case 2:
                            if (f_Parent.CheckOzenk_TFE_v(this, v))
                                mDel.Append(AI);
                            break;

                        case 3:
                            if (f_Parent.CheckOzenk_TFE_t(this, t) || f_Parent.CheckOzenk_TFE_v(this, v))
                                mDel.Append(AI);
                            break;
                    }
                }
            }
            for (int i = 0; i <= mDel.Count - 1; i++)
                f_ParamAlt.Delete2((TParamAlternativeItem)mDel.GetItems(i));
        }
        /*          void sovm_naz(int ind);
                  public:*/
        public TPartialDecisionItem(TPartialDecision AParent)
        {
            f_Apd = null;
            f_WorkItem = null;
            f_Parent = AParent;
            f_ParamAlt = new TParamAlternative();
        }
        ~TPartialDecisionItem() { }
        public void InitDecision(TPredicateTreeItem AWorkItem)
        {
            f_WorkItem = AWorkItem;
            f_ParamAlt.Clear();
        }
        public void Make()
        {
            DoDecision();
            Proverka_NUOpt();
        }
        void Proverka_NUOpt()
        {
            if (f_Parent.Type_Char == SharedConst.PROP)
            {
                switch (SharedConst.opt_sadacha.type_sadacha)
                {
                    case SharedConst.ZAD_1:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по В
                        {
                            case 0: proverka_type_krit(SharedConst.BB); break;//только по В
                            case 1: proverka_type_krit(SharedConst.BV); break;//критерий V
                            case 2: proverka_type_krit(SharedConst.BT); break;//критерий T
                            case 3: proverka_type_krit(SharedConst.BTV); break;//критерий V и T
                            case 4: proverka_type_krit(SharedConst.BBS); break;//только по В
                            case 5: proverka_type_krit(SharedConst.BVS); break;//критерий V
                            case 6: proverka_type_krit(SharedConst.BTS); break;//критерий T
                            case 7: proverka_type_krit(SharedConst.BTVS); break;//критерий V и T
                        }
                        break;
                    case SharedConst.ZAD_2:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по Т
                        {
                            case 0: proverka_type_krit(SharedConst.BT); break;//только по Т (плюс всегда В)
                            case 1: proverka_type_krit(SharedConst.BTV); break;//критерий V
                            case 2: proverka_type_krit(SharedConst.BT); break;//критерий B
                            case 3: proverka_type_krit(SharedConst.BTV); break;////критерий V и B
                            case 4: proverka_type_krit(SharedConst.BTS); break;//только по Т (плюс всегда В)
                            case 5: proverka_type_krit(SharedConst.BTVS); break;//критерий V
                            case 6: proverka_type_krit(SharedConst.BTS); break;//критерий B
                            case 7: proverka_type_krit(SharedConst.BTVS); break;////критерий V и B
                        }
                        break;
                    case SharedConst.ZAD_3:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по V
                        {
                            case 0: proverka_type_krit(SharedConst.BV); break;//нет критериев
                            case 1: proverka_type_krit(SharedConst.BV); break;//критерий B
                            case 2: proverka_type_krit(SharedConst.BTV); break;//критерий T
                            case 3: proverka_type_krit(SharedConst.BTV); break;//критерий T и B
                            case 4: proverka_type_krit(SharedConst.BVS); break;//нет критериев
                            case 5: proverka_type_krit(SharedConst.BVS); break;//критерий B
                            case 6: proverka_type_krit(SharedConst.BTVS); break;//критерий T
                            case 7: proverka_type_krit(SharedConst.BTVS); break;//критерий T и B
                        }
                        break;

                    case SharedConst.ZAD_4://обобщенные задачи
                    case SharedConst.ZAD_5:
                    case SharedConst.ZAD_6:
                        if (SharedConst.opt_sadacha.type_ogr < 4)
                        {
                            proverka_type_krit(SharedConst.BTV);
                            break;
                        }
                        else
                        {
                            proverka_type_krit(SharedConst.BTVS);
                            break;
                        }
                }
            }

            if (f_Parent.Type_Char == SharedConst.FUZZY)
            {
                switch (SharedConst.opt_sadacha.type_sadacha)
                {
                    case SharedConst.ZAD_1:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по В
                        {
                            case 0: proverka_type_krit_fuz(SharedConst.BB); break;//только по В
                            case 1: proverka_type_krit_fuz(SharedConst.BV); break;//критерий V
                            case 2: proverka_type_krit_fuz(SharedConst.BT); break;//критерий T
                            case 3: proverka_type_krit_fuz(SharedConst.BTV); break;//критерий V и T
                            case 4: proverka_type_krit_fuz(SharedConst.BBS); break;//только по В
                            case 5: proverka_type_krit_fuz(SharedConst.BVS); break;//критерий V
                            case 6: proverka_type_krit_fuz(SharedConst.BTS); break;//критерий T
                            case 7: proverka_type_krit_fuz(SharedConst.BTVS); break;//критерий V и T
                        }
                        break;
                    case SharedConst.ZAD_2:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по Т
                        {
                            case 0: proverka_type_krit_fuz(SharedConst.BT); break;//только по Т (плюс всегда В)
                            case 1: proverka_type_krit_fuz(SharedConst.BTV); break;//критерий V
                            case 2: proverka_type_krit_fuz(SharedConst.BT); break;//критерий B
                            case 3: proverka_type_krit_fuz(SharedConst.BTV); break;////критерий V и B
                            case 4: proverka_type_krit_fuz(SharedConst.BTS); break;//только по Т (плюс всегда В)
                            case 5: proverka_type_krit_fuz(SharedConst.BTVS); break;//критерий V
                            case 6: proverka_type_krit_fuz(SharedConst.BTS); break;//критерий B
                            case 7: proverka_type_krit_fuz(SharedConst.BTVS); break;////критерий V и B
                        }
                        break;
                    case SharedConst.ZAD_3:
                        switch (SharedConst.opt_sadacha.type_ogr)//задача по V
                        {
                            case 0: proverka_type_krit_fuz(SharedConst.BV); break;//нет критериев
                            case 1: proverka_type_krit_fuz(SharedConst.BV); break;//критерий B
                            case 2: proverka_type_krit_fuz(SharedConst.BTV); break;//критерий T
                            case 3: proverka_type_krit_fuz(SharedConst.BTV); break;//критерий T и B
                            case 4: proverka_type_krit_fuz(SharedConst.BVS); break;//нет критериев
                            case 5: proverka_type_krit_fuz(SharedConst.BVS); break;//критерий B
                            case 6: proverka_type_krit_fuz(SharedConst.BTVS); break;//критерий T
                            case 7: proverka_type_krit_fuz(SharedConst.BTVS); break;//критерий T и B
                        }
                        break;

                    case SharedConst.ZAD_4://обобщенные задачи
                    case SharedConst.ZAD_5:
                    case SharedConst.ZAD_6:
                        if (SharedConst.opt_sadacha.type_ogr < 4) { proverka_type_krit_fuz(SharedConst.BTVS); break; }
                        else { proverka_type_krit_fuz(SharedConst.BTVS); break; }

                }
            }
        }


       /*        __property TPartialDecision* Parent = {read = f_Parent
           };*/
        public TParamAlternative ParamAlt
        {
            get { return f_ParamAlt; }
        }
        public TPredicateTreeItem WorkItem
        {
            get { return f_WorkItem;  }
        }
        void CopyAlternateParam2(TParamAlternative ADest, TParamAlternative ASource, bool AByPassGPL)
        {
            if (ADest != null && ASource != null)
            {
                TParamAlternativeItem OI;
                for (int i = 0; i <= ASource.Count - 1; i++)
                {
                    OI = ASource.Items[i];
                    if (AByPassGPL || OI.CheckPLG)
                        ADest.AddItem(OI.Clone());
                }
            }
        }
    }

    class TPartialDecision
    {
        TZadacha f_Owner;
        bool f_CheckNud;
        int f_Type_Char;
        List<object> f_List;
        void FreeList()
        {
            f_List.Clear();
        }
  /*      int __fastcall GetCount();*/
        public TPartialDecisionItem GetItems(int AIndex)
        {
            TPartialDecisionItem res = null;
            if ((AIndex >= 0) && (AIndex <= f_List.Count - 1))
                res = (TPartialDecisionItem)(f_List.ElementAt(AIndex));
            return res;
        }
        public TPartialDecision(TZadacha AOwner)
        {
            f_Type_Char = 0;
            f_CheckNud = false;
            f_List = new List<object>();
            f_Owner = AOwner;
        }
          ~TPartialDecision() { }
        public void Clear()
        {
            FreeList();
        }
        public TPartialDecisionItem FindPartialDecisionItemByParentID(int AID)
        {
            TPartialDecisionItem Item;
            for (int i = 0; i <= f_List.Count - 1; i++)
            {
                Item = (TPartialDecisionItem)(f_List.ElementAt(i));
                if (Item.WorkItem.ParentID == AID)
                    return Item;
            }
            return null;
        }
        /*       TPartialDecisionItem* FindPartialDecisionItemByTFEID(int AID);*/
        public TPartialDecisionItem GetNew(TPredicateTreeItem APTItem)
        {
            TPartialDecisionItem Item = new TPartialDecisionItem(this);
            Item.InitDecision(APTItem);
            f_List.Add(Item);
            return Item;
        }
        public bool FreeItem(TPartialDecisionItem AItem)
        {
            int idx = f_List.IndexOf(AItem);
            if (idx >= 0)
            {
                f_List.RemoveAt(idx);
            }
            return (idx >= 0);
        }
        public TPartialDecisionItem PullAlternate(TPartialDecisionItem AItem)
        {
            int m_id;
            TPartialDecisionItem Item;
            m_id = AItem.WorkItem.ParentID;
            for (int j = 0; j <= f_List.Count - 1; j++)
            {
                Item = (TPartialDecisionItem)(f_List.ElementAt(j));
                if ((Item.WorkItem.ParentID == m_id) && (Item != AItem))
                {
                    CopyAlternateParam(AItem, Item);
                    return Item;
                }
            }
            return null;
        }
        public bool CheckOzenk_TFE_t(TPartialDecisionItem AI, double AValue)
        {
            return f_Owner.CheckOzenk_TFE_t(AI.WorkItem, AValue);
        }
        public bool CheckOzenk_TFE_v(TPartialDecisionItem AI, double AValue)
        {
            return f_Owner.CheckOzenk_TFE_v(AI.WorkItem, AValue);
        }

        public int Type_Char
        {
            set { f_Type_Char = value; }
            get { return f_Type_Char;  }
        }
            
        public bool CheckNud
        {
            set { f_CheckNud = value; }
            get { return f_CheckNud; }
        }
        /*     __property int Count = { read = GetCount };
             __property TPartialDecisionItem* Items[int AIndex] = { read =  GetItems*/

        void CopyAlternateParam(TPartialDecisionItem ADest, TPartialDecisionItem ASource)
        {
            TParamAlternative S = ASource.ParamAlt;
            TParamAlternative D = ADest.ParamAlt;
            TParamAlternativeItem OI;
            for (int i = S.Count - 1; i >= 0; i--)
            {
                OI = S.Items[i];
                D.AddItem(OI.Clone());
                S.Delete2(OI);
            }
        }
    }
}
