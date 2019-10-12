using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    class TOzenkTFE
    {
        private TPartialDecision f_PartialDecision;
        private List<object> f_ListPredicateTreeItem;
        private TDischargedMassiv f_ozenk;
        private TDischargedMassiv f_ozenk1;
        private TDischargedMassiv f_ozenk0;
        private void FillMassiv(TBaseShape ATFE)
        {
            TParamAlternative Alt;
            TParamAlternativeItem OI;
            TPartialDecisionItem Item = new TPartialDecisionItem(f_PartialDecision);
            Alt = Item.ParamAlt;
            TParamAlternative S = ATFE.ParamAlt;
            if (S!=null)
            {
                for (int i = 0; i <= S.Count - 1; i++)
                {
                    OI = S.Items[i];
                    Alt.AddItem(OI.Clone());
                }
                Item.Proverka_NUOpt();

                f_ozenk.Val[ATFE.ID] = Alt.Count;
                f_ozenk0.Val[ATFE.ID] = Alt.Count;
                f_ozenk1.Val[ATFE.ID] = 0.0;
            }
         //   delete Item;
        }
        private void OzenkItem(TPredicateTreeItem AItem)
        {
            double M3 = 1, M1, M2, M22, N1, N2, N22, min, max, r2, K=1, K1, K2, MM3, MM1, MM2, MM22;
            int n1, n2, n3, inn, i5, D = 0;

            n1 = AItem.GetTFE_ID(0);
            n2 = AItem.GetTFE_ID(1);
            n3 = AItem.GetTFE_ID(2);
            M1 = f_ozenk.DoubleValue(n1); M2 = f_ozenk.DoubleValue(n2); M22 = f_ozenk.DoubleValue(n3);
            MM1 = f_ozenk0.DoubleValue(n1); MM2 = f_ozenk0.DoubleValue(n2); MM22 = f_ozenk0.DoubleValue(n3);
            N1 = f_ozenk1.DoubleValue(n1); N2 = f_ozenk1.DoubleValue(n2); N22 = f_ozenk1.DoubleValue(n3);
            if (f_PartialDecision.Type_Char == SharedConst.PROP)
                K1 = 1;
            else K1 = 1.4;

            int num_parent = AItem.ParentID;

            switch (SharedConst.opt_sadacha.type_sadacha)
            {
                case SharedConst.ZAD_1:
                case SharedConst.ZAD_2:
                case SharedConst.ZAD_3:
                    switch (SharedConst.opt_sadacha.type_ogr)//задача по В
                    {
                        case 0: D = 1; break;//только по В
                        case 1:
                        case 2: D = 2; break;//критерий T
                        case 3: D = 3; break;//критерий V и T
                        case 4: D = 1; break;//только по В
                        case 5:
                        case 6: D = 2; break;//критерий T
                        case 7: D = 3; break;//критерий V и T
                    }
                    break;

                case SharedConst.ZAD_4://обобщенные задачи
                case SharedConst.ZAD_5:
                case SharedConst.ZAD_6: D = 3; break;
            }

            if (D == 1)
            {
                f_ozenk.Val[num_parent] = 1.0;
                return;
            }

            switch (AItem.TypeWorkShape)
            {
                case SharedConst.RAB:
                case SharedConst.RAB_FAKE:

                    if ((int)f_ozenk.Val[num_parent] != 0)
                        f_ozenk.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)(D))) * (M1 + f_ozenk.DoubleValue(num_parent));
                    else f_ozenk.Val[num_parent] = M1;
                    M3 = M1;
                    if ((int)f_ozenk0.Val[num_parent] != 0)
                        f_ozenk0.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)(D))) * (MM1 + f_ozenk0.DoubleValue(num_parent));
                    else f_ozenk0.Val[num_parent] = MM1;
                    MM3 = MM1; K = 1;
                    break;
                case SharedConst.RAB_POSL:
                case SharedConst.RAB_2par_AND:
                case SharedConst.RAB_2par_OR:
                    M3 = M1 * M2;
                    if (M2 < M1) { min = M2; max = M1; }
                    else { min = M1; max = M2; }
                    r2 = Math.Pow(0.57, Math.Log(min) / (double)(D - 1.0));
                    if (max != min) r2 = M3 * (r2 - 0.02 * r2 * (1 - Math.Pow(0.5, max - min)));
                    else r2 = r2 * M3;
                    //    M5=r2+f_ozenk.Val[num_parent];
                    if ((int)f_ozenk.Val[num_parent] != 0)
                        f_ozenk.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)(D))) * (r2 + f_ozenk.DoubleValue(num_parent));
                    else f_ozenk.Val[num_parent] = r2;
                    MM3 = MM1 * MM2;
                    if (MM2 < MM1) { min = MM2; max = MM1; }
                    else { min = MM1; max = MM2; }
                    r2 = Math.Pow(0.57, Math.Log(min) / (double)(D - 1.0));
                    if (max != min) r2 = MM3 * (r2 - 0.02 * r2 * (1 - Math.Pow(0.5, max - min)));
                    else r2 = r2 * MM3;
                    //    M5=r2+f_ozenk.Val[num_parent];
                    if ((int)f_ozenk0.Val[num_parent] != 0)
                        f_ozenk0.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)(D))) * (r2 + f_ozenk0.DoubleValue(num_parent));
                    else f_ozenk0.Val[num_parent] = r2;
                    K = 1.2;
                    break;
                case SharedConst.DIAGN:
                case SharedConst.DIAGN_2:
                case SharedConst.PROV_IF:
                case SharedConst.WHILE_DO:
                case SharedConst.WHILE_DO_2:
                case SharedConst.DO_UNTIL:
                case SharedConst.DO_UNTIL_2:
                    M3 = M1 * M22;
                    if (M1 == 1) r2 = Math.Pow(0.49 + 0.04 * (double)D, Math.Log(M22)) * M3;
                    else r2 = M3 * Math.Pow(0.333, Math.Log(M22) / Math.Log((double)D * 3.0)) * (1.0 - (0.9 / (double)D) * (1 - Math.Pow(0.8, Math.Log(M1))));
                    if ((int)f_ozenk.Val[num_parent] != 0)
                        f_ozenk.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)D)) * (r2 + f_ozenk.DoubleValue(num_parent));
                    else f_ozenk.Val[num_parent] = r2;
                    MM3 = MM1 * MM22;
                    if (MM1 == 1) r2 = Math.Pow(0.49 + 0.04 * (double)D, Math.Log(MM22)) * MM3;
                    else r2 = MM3 * Math.Pow(0.333, Math.Log(MM22) / Math.Log((double)D * 3.0)) * (1.0 - (0.9 / (double)D) * (1 - Math.Pow(0.8, Math.Log(MM1))));
                    if ((int)f_ozenk0.Val[num_parent] != 0)
                        f_ozenk0.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)D)) * (r2 + f_ozenk0.DoubleValue(num_parent));
                    else f_ozenk0.Val[num_parent] = r2;
                    K = 1.3;
                    break;
                case SharedConst.RASV:
                case SharedConst.DO_WHILE_DO:
                case SharedConst.DO_WHILE_DO_2:
                    M3 = M1 * M2 * M22;
                    if (M1 == 1) r2 = Math.Pow(0.49 + 0.04 * (double)D, Math.Log(M22)) * M3;
                    else r2 = M3 * Math.Pow(0.333, Math.Log(M22) / Math.Log((double)D * 3.0)) * (1.0 - (0.9 / (double)D) * (1.0 - Math.Pow(0.8, Math.Log(M1)))) * (1 - (1.4 / (double)D) * (1 - Math.Pow(0.8, Math.Log(M2))));  //4.4
                    if (M22 == 1) r2 = 0.97 * M3;
                    if ((int)f_ozenk.Val[num_parent] != 0)
                        f_ozenk.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)D)) * (r2 + f_ozenk.DoubleValue(num_parent));
                    else f_ozenk.Val[num_parent] = r2;
                    MM3 = MM1 * MM2 * MM22;
                    if (MM1 == 1) r2 = Math.Pow(0.49 + 0.04 * (double)D, Math.Log(MM22)) * MM3;
                    else r2 = MM3 * Math.Pow(0.333, Math.Log(MM22) / Math.Log((double)D * 3.0)) * (1.0 - (0.9 / (double)D) * (1.0 - Math.Pow(0.8, Math.Log(MM1)))) * (1 - (1.4 / (double)D) * (1 - Math.Pow(0.8, Math.Log(MM2))));  //4.4
                    if (MM22 == 1) r2 = 0.97 * MM3;
                    if ((int)f_ozenk0.Val[num_parent] != 0)
                        f_ozenk0.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)D)) * (r2 + f_ozenk0.DoubleValue(num_parent));
                    else f_ozenk0.Val[num_parent] = r2;
                    K = 1.3;
                    break;

                case SharedConst.RASV_SIM: //для подмножеств альтернатив
                    i5 = 0;
                    TBaseShape B = AItem.GetTFE(2);
                    if (B!=null && B.ParamAlt != null)
                    {
                        if (B.ParamAlt.Items[0].CheckPLG)
                            i5 = 1;
                    }
                    if (i5 == 1)
                    {
                        if ((double)f_ozenk.Val[num_parent] != 0)
                            f_ozenk.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)(D))) * (M1 + f_ozenk.DoubleValue(num_parent));
                        else f_ozenk.Val[num_parent] = M1; M3 = M1;
                    }
                    else
                    {
                        if ((double)f_ozenk.Val[num_parent] != 0)
                            f_ozenk.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)(D))) * (M2 + f_ozenk.DoubleValue(num_parent));
                        else f_ozenk.Val[num_parent] = M2; M3 = M2;
                    }
                    //      if(strcmp(s.c_str(),"1")==0)
                    if (i5 == 0)
                    {
                        if ((double)f_ozenk0.Val[num_parent] != 0)
                            f_ozenk0.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)(D))) * (MM1 + f_ozenk0.DoubleValue(num_parent));
                        else f_ozenk0.Val[num_parent] = MM1; MM3 = MM1;
                    }
                    else
                    {
                        if ((double)f_ozenk0.Val[num_parent] != 0)
                            f_ozenk0.Val[num_parent] = (1.0 - Math.Pow(0.5, (double)(D))) * (MM2 + f_ozenk.DoubleValue(num_parent));
                        else f_ozenk0.Val[num_parent] = MM2; MM3 = MM2;
                    }
                    K = 1;
                    //         char_form.Table1.Edit();
                    //       if(ozenk1[n1]>ozenk1[n2])
                    //          char_form.Table1.FieldByName("PREDICAT").AsString="0";
                    //        else char_form.Table1.FieldByName("PREDICAT").AsString="1";
                    break;
            }
            if (num_parent != 0 && (M3 < 5 || M3 / f_ozenk.DoubleValue(num_parent) < 1.2))
            {
                f_ozenk.Val[num_parent] = M3;
                f_ozenk1.Val[num_parent] = f_ozenk1.DoubleValue(num_parent) + N1 + N2 + N22 + D * K * K1 * M3 * 0.004 / 3;  //021106
            }
            else
            {
                M3 = M3 * (f_ozenk0.DoubleValue(num_parent) * 1.0) / (f_ozenk.DoubleValue(num_parent) * 1.0);
                f_ozenk.Val[num_parent] = f_ozenk0.DoubleValue(num_parent);
                f_ozenk1.Val[num_parent] = f_ozenk1.DoubleValue(num_parent) + N1 + N2 + N22 + D * K * K1 * M3 * 0.004;
            }
        }
        public TOzenkTFE(TPartialDecision APartialDecision)
        {
            f_PartialDecision = APartialDecision;
            f_ozenk = new TDischargedMassiv(0.0);
            f_ozenk1 = new TDischargedMassiv(0.0);
            f_ozenk0 = new TDischargedMassiv(0.0);
            f_ListPredicateTreeItem = new List<object>();
        }
        ~TOzenkTFE() { }
        public void AddPredicateTree(TPredicateTreeItem ANode)
        {
            f_ListPredicateTreeItem.Add(ANode);
        }
        public void InitMassiv()
        {
            TPredicateTreeItem Item;
            for (int i = 0; i <= f_ListPredicateTreeItem.Count - 1; i++)
            {
                Item = (TPredicateTreeItem)(f_ListPredicateTreeItem.ElementAt(i));
                for (int j = 0; j <= Item.Count - 1; j++)
                {
                    TBaseShape C = Item.GetTFE(j);
                    if (C != null)
                        FillMassiv(C);
                }
            }
        }
        public  double ValueOzenk(int APos)
        {
            return f_ozenk.DoubleValue(APos);
        }
        public double ValueOzenk1(int APos)
        {
            return f_ozenk1.DoubleValue(APos);
        }
        public void Ozenk()
        {
            TPredicateTreeItem Item;
            for (int i = 0; i <= f_ListPredicateTreeItem.Count - 1; i++)
            {
                Item = (TPredicateTreeItem)(f_ListPredicateTreeItem.ElementAt(i));
                OzenkItem(Item);
            }
        }
    }
}
