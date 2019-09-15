using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geliosNEW
{
    public class TFlag
    {
        int F_Position;
        TBaseShape F_Shape;
        TRectLine F_Line;
        TFlagShape F_Flag;
        public TFlag()
        {
            F_Position = -1;
            F_Shape = null;
            F_Line = null;
            F_Flag = null;
        }
        public int Position
        {
            set { F_Position = value; }
            get { return F_Position; }
        }
        public TBaseShape Shape
        {
            set { F_Shape = value; }
            get { return F_Shape; }
        }
        public TRectLine Line
        {
            set { F_Line = value; }
            get { return F_Line; }
        }
        public TFlagShape Flag
        {
            set { F_Flag = value; }
            get { return F_Flag; }
        }
};

public class TListFlag
{
        List<object> List;
        void FreeList()
        {
            List.Clear();
        }
        int GetCount()
        {
            return List.Count;
        }
        TFlag GetItem(int AIndex)
        {
            TFlag res = null;
            if ((AIndex >= 0) && (AIndex <= List.Count - 1))
                res = (TFlag)List.ElementAt(AIndex);
            return res;
        }
        public TListFlag()
        {
            List = new List<object>();
        }
        ~TListFlag() { }
   /*     public TFlag AddFlag(TFlagShape AFlag, TBaseShape AShape, TRectLine ALine,
              int APosition, ref bool AFlagExits );
        public TFlag* DeleteFlagByShape(TFlagShape* AFlag);
        public bool DeleteFlagByFlag(TFlag* AFlag);
        public int Count = { read = GetCount };
        public TFlag* Items[int AIndex] = { read =  GetItem*/
    }
}
