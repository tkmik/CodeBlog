using System;

namespace LearnObject
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point() { X = 5 };
            var p2 = new Point() { X = 5 };

            object box = (int)42;
            long unbox = (long)box;

            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1 == p2);
            var s1 = "te st";
            var s2 = "te " + "st";
            var s3 = s2;
            Console.WriteLine(s1 == s2);
            Console.WriteLine(s1.Equals(s2));
            Console.WriteLine(s3.Equals(s1));
            //Console.WriteLine(p1.GetType());
            Console.WriteLine();
            Console.WriteLine(Object.Equals(s1, s2));
            Console.WriteLine(Object.ReferenceEquals(s1, s2));
            Console.WriteLine();
            Console.WriteLine(Object.Equals(p1, p2));
            Console.WriteLine(Object.ReferenceEquals(p1, p2));
        }
    }
}
