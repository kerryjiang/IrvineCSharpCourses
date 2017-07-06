using System;
using System.IO;
using System.Text;

namespace Example7
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fileStream = new FileStream("score.csv", FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(fileStream, Encoding.UTF8, true))
                {
                    while (reader.Peek() >= 0)
                    {
                        Console.WriteLine(reader.ReadLine());
                    }
                }
            }            
        }
    }
}
