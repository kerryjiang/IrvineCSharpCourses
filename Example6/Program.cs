using System;

namespace Example6
{
    // Fibonacci Numbers: F(n) = F(n-1) + F(n-2)
    class Program
    {
        public static int CalculateFibonacci(int n)  
        {  
                if (n == 0)
                    return 0; //To return the first Fibonacci number

                if (n == 1)
                    return 1; //To return the second Fibonacci number

                return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);  
        }  

        static void Main(string[] args)
        {
            // CalculateFibonacci base on the first parameter
            var num = int.Parse(args[0]);
            
            Console.WriteLine(CalculateFibonacci(num));
        }
    }
}
