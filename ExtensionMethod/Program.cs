using System;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                if (result.IsEven())
                {
                    Console.WriteLine("even");
                }
                else
                {
                    Console.WriteLine("odd");
                }
            }

            Person person1 = new Person
            {
                Name = "Mik",
                Age = 20
            };
            Person person2 = new Person
            {
                Name = "Dasha",
                Age = 20
            };
            var person = person1.Sum(person2);
            Console.WriteLine($"{person.ToString()}");

            Console.ReadKey();
        }
    }
}
