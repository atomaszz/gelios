using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace geliosNEW
{
    public class SharedConst
    {
        /*---------------------*/
        public static  FmOptSadacha opt_sadacha;
        /*--------------------*/

        public const int D_FRAME = 1;
        public const int OFFS_FRAME = 2;

        public const int BL_HORIZONTAL = 0;
        public const int BL_VERTICAL = 1;
        public const int BL_OTHER = 2;
        public const int BL_POINT = 3;


        /*---------------------------------------------------*/

        //значения для типов блоков
        public const int RAB = 1;  //рабоч
        public const int RAB_FAKE = 12;  //рабоч фиктивная
        public const int RAB_POSL = 13;  //послед рабоч
        public const int RAB_2par_AND = 2; // парал И
        public const int RAB_2par_OR = 3; // парал ИЛИ
        public const int DIAGN = 4;  //  диагност РО-ДК
        public const int DIAGN_2 = 5;  //  функцио контр РО-ФК
        public const int RASV = 6;  //  развилк ДК - "1 - РО1 "0 - РО2
        public const int PROV_IF = 7;  //  контроль работосп (с предусловием) ДК "0 - РО
        public const int WHILE_DO = 8;  // контр работ с постусловием РО - ДК "0 - РО
        public const int WHILE_DO_2 = 9999; //   ФК с постусловием (не применяется)
        public const int DO_UNTIL = 109999; //  контроль Работспос как 7
        public const int DO_UNTIL_2 = 119999; //     ФК как 5
        public const int DO_WHILE_DO = 9; //  ДК с востановл работосп РО1 ДК РО2
        public const int DO_WHILE_DO_2 = 10; // ФК с доработкой РО1 - ФК - РО2
        public const int RASV_SIM = 11;  // развилка для альтернативных подмножеств

        //значения признака открытого файла
        public const int NO_OPEN = 0;    //нет открытого файла
        public const int YES_OPEN = 1;    //есть открытый файл (не измененный)
        public const int YES_OPEN_MOD = 2; //есть открытый файл (измененный)

        public const int YES_TABLE = 1;  //признаки наличия таблицы
        public const int NO_TABLE = 0;

        public const int RADIUS = 20; //отклонение от центра ТФЕ при определении попадания мыши

        public const long FNULL = -1L; //обозначение нуля в файле
        public const long BEGIN = 4L;  //указатель на начало данных в файле

        public const string CFG_NAME = "graphtfe.cfg"; //имя файла-конфигурации, в нашем случае
        //набор имен файлов, созданных в процессе работы

        public const string DEC_ARH = "arhive.arh"; //имя файла, хранящего архив решений

        public const int PROP = 0; //для настройки типа характеристик
        public const int FUZZY = 1;

        public const int WIN = 0; //для настройки типа кодировки
        public const int DOS = 1;

        public const int BLOCK = 0; //для настройки типа оптимизации
        public const int UROV = 1;

        public const int TOHN = 0; //для настройки метода оптимизации (точный или приближ.)
        public const int PRIBLJ1 = 1;
        public const int PRIBLJ2 = 2;

        //константы для определения типа выбранной задачи оптимизации
        public const int ZAD_1 = 0;
        public const int ZAD_2 = 1;
        public const int ZAD_3 = 2;
        public const int ZAD_4 = 3;
        public const int ZAD_5 = 4;
        public const int ZAD_6 = 5;
        public const int NONE = 6;

        //типы элементов
        public const int SIMP = 0; //простой
        public const int COMP = 1; //составной

        //типы типовых операций
        public const int LABOUR = 0; //рабочая
        public const int CONTROL = 1; //КР
        public const int FUNCTION = 2; //КФ
        public const int PROVERKA = 3; //Проверка

        public const string LABOUR_T = "rab"; //рабочая
        public const string CONTROL_T = "cont"; //КР
        public const string FUNCTION_T = "func"; //КФ
        public const string PROVERKA_T = "prov"; //Проверка

        public const int BB = 1;
        public const int BT = 2;
        public const int BV = 3;
        public const int BTV = 4;
        public const int BBS = 5;
        public const int BTS = 6;
        public const int BVS = 7;
        public const int BTVS = 8;

        /*-------------------------------------*/


        /*---------------------------------------*/


        public static TMessangers GMess;

        public static int MyMin(int A1, int A2)
        {
            if (A1 < A2)
                return A1;
            else
                return A2;
        }

        public static int MyMax(int A1, int A2)
        {
            if (A1 > A2)
                return A1;
            else
                return A2;
        }
        public static void PaintVShape(Graphics ACanvas, Point ACenter, int AX, int AY, bool AOR)
        {
            Point P0;
            Point P1;
            Point P2;
            if (AOR)
            {
                P0 = new Point(ACenter.X - AX, ACenter.Y - AY);
                P1 = new Point(ACenter.X, AY + ACenter.Y);
                //    if (ACanvas.Pen.Width == 1)
                //       P2 = new Point(ACenter.X + AX + 1, ACenter.Y - AY - 1);
                //      else
                P2 = new Point(ACenter.X + AX, ACenter.Y - AY);
            }
            else
            {
                P0 = new Point(ACenter.X - AX, AY + ACenter.Y);
                P1 = new Point(ACenter.X, ACenter.Y - AY);
                //   if (ACanvas.Pen.Width == 1)
                //       P2 = new Point(ACenter.X + AX + 1, AY + ACenter.Y + 1);
                //    else
                P2 = new Point(ACenter.X + AX, AY + ACenter.Y);
            }
            ACanvas.DrawLine(new Pen(Color.Black, 2), P0, P1);
            ACanvas.DrawLine(new Pen(Color.Black, 2), P1, P2);
        }

        public static bool PtInRect(Rectangle rec, Point pnt)
        {
            if (rec.X > pnt.X || rec.Y > pnt.Y) return false;
            if ((rec.X+rec.Width)<pnt.X || (rec.Y + rec.Height) < pnt.Y) return false;
            return true;
        }

        /*------------------------------------------------------------*/
        public static int PredicatePathCnt;
        public static void PredicatePathInit()
        {
            PredicatePathCnt = 0;
        }
        public static int PredicatePathNextNum()
        {
            --PredicatePathCnt;
            return PredicatePathCnt;
        }

        public static int g_TrashCounter;
        public static void InitTrashCounter()
        {
            g_TrashCounter = 0;
        }

        public static int NextTrashItemID()
        {
            return (++g_TrashCounter);
        }

        public static TGlsList lcList;
        public static void InitTFEConvertor()
        {
            lcList = new TGlsList();
        }

        public static void FreeTFEConvertor()
        {
            lcList.clear();
        }
        public static void CopyDynamicArray(TDynamicArray ASource, TDynamicArray ADest, bool AInsertToFirst)
        {
            for (int i = 0; i <= ASource.Count - 1; i++)
            {
                if (AInsertToFirst)
                    ADest.InsertToFirst(ASource.GetItems(i));
                else
                    ADest.Append(ASource.GetItems(i));
            }
        }
        /*-----------*/
        public static List<object> lc;
        public static int APC_CompareNode(object A, object B)
        {
            TAlternativeParserGrpItemTFS m_A = (TAlternativeParserGrpItemTFS)(A);
            TAlternativeParserGrpItemTFS m_B = (TAlternativeParserGrpItemTFS)(B);
            int res = -100; /*** GMess.SendMess(3, int(m_A.TFS.BaseWorkShape), int(m_B.TFS.BaseWorkShape));*/ //НУКЖНО ДЕБАЖИТЬ ИСХОДНИКИ 
            if (res == -100)
                MessageBox.Show("Исключителная ошибка в алгоритме программы. Обратитесь к разработчику");
            return res;
        }

        public static bool APC_Inorder(object A)
        {
            lc.Add(A);
            return true;
        }
    }
}
