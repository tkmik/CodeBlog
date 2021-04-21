using System;

namespace Pointer
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 30;
            unsafe
            {
                int* address = &i;
                Console.WriteLine(*address);
                Console.WriteLine((long)address);
                int a = 5;
                int b = 7;
                Calc(a, &b);
                Console.WriteLine(a);
                Console.WriteLine(b);
                Calc(a, ref b);
                Console.WriteLine(a);
                Console.WriteLine(b);

                int* address2 = address + 4;
                *address2 = 777;
                Console.WriteLine(*address2);

                var guid = Guid.NewGuid();
                Guid* addGuid = &guid;
                Console.WriteLine(guid.GetHashCode());
                Console.WriteLine((long)addGuid);

            }
        }
        static unsafe void Calc(int i, int* j)
        {
            i = 500; 
            *j = 700;
        }

        static void Calc(int i, ref int j)
        {
            i = 500;
            j = 1400;
        }
    }
}
