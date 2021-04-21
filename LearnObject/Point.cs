using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnObject
{
    class Point
    {
        public int X { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is Point point)
            {
                return point.X == X;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return X; 
        }

        public override string ToString()
        {
            return $"{X}";
        }


        //public new Type GetType()
        //{
        //    return typeof(Int32);
        //}
    }
}
