using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Models
{
    [Serializable]
    public class Group
    {
        [NonSerialized]
        private Random rnd = new Random(DateTime.Now.Millisecond);
        public int Number { get; set; }
        public string Name { get; set; }
        public Group() { }
        public Group(int number, string name)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }
            Number = number;
            Name = name;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
