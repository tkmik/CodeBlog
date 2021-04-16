using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeReflection
{
    
    class Photo
    {
        [Geo(10, 20)]
        public string Name { get; set; }
        public string Path { get; set; }
        public Photo(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }
            Name = name;
        }
    }
}
