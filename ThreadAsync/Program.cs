using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsAsync
{
    class Program
    {
        public static object locker = new object();
        static void Main(string[] args)
        {
            #region Thread
            //Thread thread = new Thread(new ThreadStart(DoWorking));
            //thread.Start();


            //Thread thread2 = new Thread(new ParameterizedThreadStart(DoWorking2));
            //thread2.Start(int.MaxValue);

            //int j = 0;
            //for (int i = 0; i < int.MaxValue; i++)
            //{
            //    j++;
            //    if (j % 10000 == 0)
            //    {
            //        Console.WriteLine($"Main");
            //    }
            //}
            #endregion

            #region async/await
            DoWorkingAsync();

            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine($"Main");
                }
            }
            #endregion

            Console.ReadKey();
        }

        static async Task DoWorkingAsync()
        {
            await Task.Run(() => 
            {
                DoWorking();
            });
        }

        static void DoWorking()
        {
            lock (locker)
            {
                int j = 0;
                for (int i = 0; i < int.MaxValue; i++)
                {
                    j++;
                    if (j % 10000 == 0)
                    {
                        Console.WriteLine($"DoWorking");
                    }
                }
            }           
        }

        static void DoWorking2(object max)
        {
            int j = 0;
            for (int i = 0; i < (int)max; i++)
            {
                j++;
                if (j % 10000 == 0)
                {
                    Console.WriteLine($"DoWorking2");
                }
            }
        }
    }
}
