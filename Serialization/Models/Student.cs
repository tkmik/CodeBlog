using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serialization.Models
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Group Group { get; set; }
        public Student(string name, int age)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();   
            }
            if (age < 0 && age > 110)
            {
                throw new ArgumentOutOfRangeException();
            }
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"{Name}({Age})";
        }
    }
}
