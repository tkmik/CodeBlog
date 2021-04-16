using System;

namespace LambdaAnonymousMethod
{
    class Program
    {
        delegate int MyDelegate(int i);
        static void Main(string[] args)
        {
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                MyDelegate handler = delegate (int i)
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return r;
                };
                handler += Method;

                MyDelegate lambda = (i) => 
                {
                    var r = i * i * i * i;
                    Console.WriteLine(r);
                    return r;
                }; 
            }

            Console.ReadKey();
        }

        public static int Method(int i)
        {
            int r = i * i * i;
            Console.WriteLine(r);
            return r;
        }
    }
}
