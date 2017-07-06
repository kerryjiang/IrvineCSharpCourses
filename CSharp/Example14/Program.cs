using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Example14
{
    class Program
    {
        static void List()
        {
            Console.WriteLine("List all");

            using(var dbContext = new SchoolDbContext())
            {
                foreach (var student in dbContext.Students.ToArray())
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}, EnglishScore: {student.EnglishScore}, MathScore: {student.MathScore}");
                }
            }
        }

        static void AddStudent(string firstName, string lastName, int englishScore, int mathScore)
        {
            using(var dbContext = new SchoolDbContext())
            {
                var newStudent = new Student();

                newStudent.FirstName = firstName;
                newStudent.LastName = lastName;
                newStudent.EnglishScore = englishScore;
                newStudent.MathScore = mathScore;

                dbContext.Students.Add(newStudent);
                
                dbContext.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            List();
            
            AddStudent("Debao", "Wang", 88, 99);
            AddStudent("Philips", "Zhang", 77, 98);

            List();

            Console.ReadKey();
        }
    }
}
