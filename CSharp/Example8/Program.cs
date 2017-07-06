using System;

namespace Example8
{
    class Program
    {
        static void Main(string[] args) 
        {
            var student = new Student();

            student.FirstName = "Kerry";
            student.LastName = "Jiang";

            Console.WriteLine("Score: " + student.Score);

            student.Read(1);
            Console.WriteLine("Score: " + student.Score);

            student.Write(3);
            Console.WriteLine("Score: " + student.Score);
        }
    }

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Score { get; private set; }

        public void Read(int hours)
        {
            Score += hours * 5;
        }

        public void Write(int hours)
        {
            Score += hours * 10;
        }
    }
}
