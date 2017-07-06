using System;

namespace Example10
{
    class Program
    {
        static void Main(string[] args)
        {
            var stu = new Student();
            
            stu.FirstName = "Kerry";
            stu.LastName = "Jiang";

            //Console.WriteLine(stu.score); // cannot access private field
            //Console.WriteLine(stu.GetFullName()); // cannot access Person's protected method

            stu.Read(5);      
            Console.WriteLine($"{stu.GetStudentName()}'s score: {stu.GetScore()}");
        }
    }
}
