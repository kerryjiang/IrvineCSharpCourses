using System;
using System.Collections.Generic;

namespace Example4
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>();

            while (true)
            {
                Console.WriteLine("Please input a student name:");

                var name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                    break;

                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name + ":" + name.Length);
            }
        }
    }
}
