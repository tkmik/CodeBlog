using System;
using System.Collections.Generic;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car { Name = "Tesla", NumberPlate = "1234 AA-1" },
                new Car { Name = "Tesla", NumberPlate = "1235 AA-1" }
            };

            var parking = new Parking();

            foreach (var car in cars)
            {
                parking.Add(car);
            }

            foreach (var item in parking)
            {
                Console.WriteLine($"{item.ToString()}");
            }

            foreach (var name in parking.GetNames())
            {
                Console.WriteLine($"{name}");
            }
        }
    }
}
