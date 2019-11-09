using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TPredicateScannerItemKnot
    {
        int f_ParentID;
        int f_NumAlt;
        int f_TypeKnot;
        int f_TFE_ID1;
        int f_TFE_ID2;
        int f_TFE_ID3;
        public TPredicateScannerItemKnot() { f_ParentID = f_NumAlt = f_TypeKnot = f_TFE_ID1 = f_TFE_ID2 = f_TFE_ID3 = 0; }
        string  ItemName()
        {
            string Knot, Res, Ls;
            switch (f_TypeKnot)
            {
                case 1:
                    {
                        Knot = "rab_oper";
                        break;
                    }
                case 2:
                    {
                        Knot = "rab_oper_par_AND";
                        break;
                    }
                case 3:
                    {
                        Knot = "rab_oper_par_OR";
                        break;
                    }

                case 4:
                    {
                        Knot = "diagn_control_rab";
                        break;
                    }
                case 5:
                    {
                        Knot = "diagn_func_coltrol";
                        break;
                    }
                case 6:
                    {
                        Knot = "rasvilka";
                        break;
                    }

                case 7:
                    {
                        Knot = "proverka_if";
                        break;
                    }

                case 8:
                    {
                        Knot = "while_do_control_rab";
                        break;
                    }

                case 9:
                    {
                        Knot = "do_while_do_control_rab";
                        break;
                    }

                case 10:
                    {
                        Knot = "do_while_do_control_func";
                        break;
                    }

                case 11:
                    {
                        Knot = "proverka_uslovia";
                        break;
                    }

                case 13:
                    {
                        Knot = "rab_oper_posl";
                        break;
                    }

                default:
                    {
                        Knot = "unknown";
                        break;
                    }
            }
            Ls = "[";
            if (f_TFE_ID1 != 0)
                Ls = Ls + f_TFE_ID1.ToString();
            if (f_TFE_ID2 != 0)
                Ls = Ls + ", " + f_TFE_ID2.ToString();
            if (f_TFE_ID3 != 0)
                Ls = Ls + ", " + f_TFE_ID3.ToString();
            Ls = Ls + "]";

            Res = "tfs(" + f_ParentID.ToString() + ", " + f_NumAlt.ToString() + ", " + Knot + ", " + Ls + ").";
            return Res;
        }
        public int ParentID
        {
            set { f_ParentID = value; }
            get { return f_ParentID; }
        }
        public int NumAlt
        {
            set { f_NumAlt = value; }
            get { return f_NumAlt; }
        }
        public int TypeKnot
        {
            set { f_TypeKnot = value; }
            get { return f_TypeKnot; }
        }
        public int TFE_ID1
        {
            set { f_TFE_ID1 = value; }
            get { return f_TFE_ID1; }
        }
        public int TFE_ID2
        {
            set { f_TFE_ID2 = value; }
            get { return f_TFE_ID2; }
        }
        public int TFE_ID3
        {
            set { f_TFE_ID3 = value; }
            get { return f_TFE_ID3; }
        }
    }

    public class TPredicateScanner
    {
        bool f_Prop;
        /*     char f_Simv[256];
             char f_Scan[256];
             string f_Str;
             int f_Pos;
             int f_Len;
             TList* f_ListKnot;
             void FreeListKnot();
             void InitScanner(bool* AProp, ...);
             int ScanItem();
             bool IsContainChar(char AChar);
             bool Eof();
             int DoScanKnot();
             int ScanComment();
             int ScanPredicate();
             void IncPos() { f_Pos++; }
             int GetTypePredicate(char* AStr);
             int DoScanListID(int AType, int &AId1, int &AId2, int &AId3);
             int __fastcall GetCountKnot();
             TPredicateScannerItemKnot* __fastcall GetItemsKnot(int AIndex);
             TPredicateScannerItemKnot* CreateKnot();
             public:
          TPredicateScanner();
             ~TPredicateScanner();
             bool Scan(char* AStr);
             AnsiString Error;
             __property int CountKnot = { read = GetCountKnot };
             __property TPredicateScannerItemKnot* ItemsKnot[int AIndex] = {read = GetItemsKnot*/
    }
}
