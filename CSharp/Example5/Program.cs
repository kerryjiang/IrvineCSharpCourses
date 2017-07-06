using System;
using System.Collections.Generic;

namespace Example5
{
    class Program
    {
        static void Main(string[] args)
        {
            var scoreSheet = new List<KeyValuePair<string, int>>();

            foreach (var item in args)
            {
                var arr = item.Split(':');
                
                var record = new KeyValuePair<string, int>(arr[0], int.Parse(arr[1]));

                scoreSheet.Add(record);
            }

            Console.WriteLine("Please input a student name to search score:");

            var name = Console.ReadLine();

            foreach (var record in scoreSheet)
            {
                if(record.Key == name)
                {
                    Console.WriteLine("The score of " + name + " is " + record.Value);
                    break;
                }
            }
        }
    }
}
