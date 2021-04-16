using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeReflection
{
    class GeoAttribute : Attribute
    {
        public int X { get; set; }
        public int Y { get; set; }
        public GeoAttribute() { }

        public GeoAttribute(int x, int y)
        {
            if (int.TryParse(x.ToString(), out x) 
                && int.TryParse(y.ToString(), out y))
            {
                X = x;
                Y = y;
            }           
        }
        public override string ToString()
        {
            return $"{X} - {Y}";
        }
    }
}
