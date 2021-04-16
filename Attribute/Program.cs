using System;
using System.Linq;

namespace AttributeReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var photo = new Photo("test.jpg")
            {
                Path = "C:\\hello.png"
            };

            var type = typeof(Photo);
            var attributes = type.GetCustomAttributes(false);

            foreach (var item in attributes)
            {
                Console.WriteLine($"{item}");
            }

            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                //Console.Write($"{item.PropertyType} {item.Name}");

                var attr = item.GetCustomAttributes(false);
                if (attr.Any(a => a.GetType() == typeof(GeoAttribute)))
                {
                    Console.Write($"{item.PropertyType} {item.Name}");
                }

                //foreach (var at in attr)
                //{
                //    Console.Write($" {at}");
                //}
                //Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
