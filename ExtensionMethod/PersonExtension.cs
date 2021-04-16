using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public static class PersonExtension
    {
        public static Person Sum(this Person person1, Person person2)
        {
            Person result = new Person();
            result.Name = $"{person1.Name} {person2.Name}";
            result.Age = person1.Age + person2.Age;
            return result;
        }
    }
}
