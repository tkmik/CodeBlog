using System;

namespace DelegatesEvents
{

    class Program
    {
        public delegate void MyDelegate();
        static void Main(string[] args)
        {
            #region delegate
            MyDelegate myDelegate = new MyDelegate(PrintHello);
            myDelegate += PrintHello;
            myDelegate();

            Action action = PrintHello;
            action();

            Predicate<DateTime> predicate = IsMorning;
            Console.WriteLine(predicate(DateTime.Now));

            Func<int, int, int> func = Sum;
            Console.WriteLine(func(1, 2));
            Console.WriteLine();
            #endregion


            Person person = new Person { Name = "Mikita" };
            person.ToGoSleeping += Person_ToGoSleeping;
            person.ToGoWorking += Person_ToGoWorking;
            person.TakeTime(DateTime.Now);


            Console.ReadKey();
        }

        private static void Person_ToGoWorking(object sender, EventArgs e)
        {
            if (sender is Person)
            {
                Console.WriteLine($"{((Person)sender).Name} is going working");
            }
        }

        private static void Person_ToGoSleeping(object sender, EventArgs e)
        {
            if (sender is Person)
            {
                Console.WriteLine($"{((Person)sender).Name} is going sleeping");
            }
        }

        public static void PrintHello()
        {
            Console.WriteLine($"Hello");
        }

        public static bool IsMorning(DateTime now)
        {
            if (now.Hour<12 && now.Hour > 5)
            {
                return true;
            }
            return false;
        }

        public static int Sum(int x1, int x2)
        {
            return x1 + x2;
        }
    }
}
