using System;

namespace Example9
{
    class Program
    {
        static void Main(string[] args)
        {
            var stu = new Student();
            
            stu.FirstName = "Kerry";
            stu.LastName = "Jiang";

            stu.Read(5);            
            Console.WriteLine($"{stu.GetFullName()}'s score: {stu.Score}");
        }
    }
}
