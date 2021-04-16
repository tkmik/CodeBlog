using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    class Car
    {
        public string Name { get; set; }
        public string NumberPlate { get; set; }

        public override string ToString()
        {
            return $"{Name} - {NumberPlate}";
        }
    }
}
