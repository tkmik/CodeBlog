using System;

namespace AnonymousType
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = new 
            {
                Name = "Milk",
                Energy = 10
            };


            Tuple<int, string> tuple = new Tuple<int, string>(5, "hello");
                       
            var tuple2 = (5, 5);

            var tuple3 = (Name: "Product", Count: 20, Price: 100);

            var result = GetData();
            Console.WriteLine(result.Name);
            Console.ReadKey();
        }

        public static (int Id, string Name, bool IsEnough) GetData()
        {
            var number = 324;
            var name = Guid.NewGuid().ToString();
            bool b = number > 500;

            return (number, name, b);
        }
    }
}
