using System;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            var op = args[0];

            var a = int.Parse(args[1]);
            var b = int.Parse(args[2]);

            switch (op.ToLower())
            {
                case ("add"):
                    Console.WriteLine(a + b);
                    break;
                case ("subtract"):
                    Console.WriteLine(a - b);
                    break;
                case ("multiply"):
                    Console.WriteLine(a * b);
                    break;
                case ("devide"):
                    Console.WriteLine(a / b);
                    break;
                default:
                    Console.WriteLine("Unknonw operator:" + op);
                    break;
            }
        }
    }
}
