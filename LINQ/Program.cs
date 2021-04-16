using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                collection.Add(i);
            }
            var result = from item in collection
                         where item < 5
                         select item;
            var result2 = collection.Where(item => item < 5);
            foreach (var item in result)
            {
                Console.WriteLine($"{item}");
            }


            var products = new List<Product>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                Product product = new Product
                {
                    Name = $"Product{i}",
                    Energy = rand.Next(0, 11)
                };
                products.Add(product);
            }
            var result3 = products.GroupBy(item => item.Name);
            foreach (var key in result3)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var product in key)
                {
                    Console.WriteLine($"\t{product.Energy}");
                }
            }
            products.Reverse();

            Console.WriteLine(products.All(item => item.Energy == 10));
            Console.WriteLine(products.Any(item => item.Energy == 10));
            Console.WriteLine(products.Contains(products[5]));

            var list = new int[] { 1, 2, 3, 4 };
            var list2 = new int[] { 1, 2, 5, 6 };
            var union = list.Union(list2);
            foreach (var item in union)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
            union = list.Intersect(list2);
            foreach (var item in union)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();
            union = list.Except(list2);
            foreach (var item in union)
            {
                Console.WriteLine($"{item}");
            }
            var aggregate = list.Aggregate((x, y) => x * y);
            var skip = list.Skip(2).Take(1);
            var elementAt = products.ElementAt(5);

            Console.ReadKey();
        }
    }
}
