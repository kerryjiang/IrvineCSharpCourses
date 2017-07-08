using System;
using System.Linq;

namespace Example14A
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new OnlineStoreDbContext();

            var orderCount = context.Orders.Count();
            
            Console.WriteLine($"We have {orderCount} online order");
        }
    }
}
