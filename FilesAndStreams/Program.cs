using System;
using System.IO;
using System.Text;

namespace FilesStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("test.txt", true, Encoding.UTF8))
            {
                writer.WriteLine("Hello");
                writer.Write("Привет");
            }
            using (StreamReader reader = new StreamReader("test.txt", Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    Console.WriteLine(reader.ReadLine());
                }

                reader.DiscardBufferedData();
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                string text = reader.ReadToEnd();
                Console.WriteLine($"{text}");
            }
        }
    }
}
