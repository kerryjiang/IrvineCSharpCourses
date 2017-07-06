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

            string maxName = string.Empty;
            int maxLen = 0;

            foreach (var name in names)
            {
                var newMaxLen = Math.Max(name.Length, maxLen);

                if (maxLen != newMaxLen)
                {
                    maxName = name;
                    maxLen = newMaxLen;
                }
            }

            Console.WriteLine("The longest name is " + maxName + ", which has " + maxLen + " characters");
        }
    }
}
