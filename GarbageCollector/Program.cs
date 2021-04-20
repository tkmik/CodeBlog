using System;

namespace GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"memory {GC.GetTotalMemory(false)}");
            for (int i = 0; i < 100000; i++)
            {
                var obj = (object)i;
                int j = (int)obj;
            }
                        
            Console.WriteLine($"memory {GC.GetTotalMemory(false)}");
            GC.Collect(1);
            Console.WriteLine($"memory {GC.GetTotalMemory(false)}");
            Console.WriteLine($"count of GC.Collect(1st generation) {GC.CollectionCount(1)}");
            Console.WriteLine($"count of GC.Collect(2nd generation) {GC.CollectionCount(2)}");
            Console.WriteLine($"max generation {GC.MaxGeneration}");
            Console.WriteLine($"total allocated bytes {GC.GetTotalAllocatedBytes()}");
            Console.ReadKey();
        }
    }
}
