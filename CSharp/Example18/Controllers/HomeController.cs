using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Example18.Models;

namespace Example18.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            return View(new School
                {
                    Name = "Northwood High",
                    Address = "4515 Portola Pkwy, Irvine, CA 92620",
                    Score = 10
                });
        }

        public IActionResult Students()
        {
            var students = new List<Student>();
            
            students.Add(new Student
            {
                FirstName = "Kerry",
                LastName = "Jiang",
                Score = 100
            });

            students.Add(new Student
            {
                FirstName = "Leo",
                LastName = "Zhang",
                Score = 97
            });

            students.Add(new Student
            {
                FirstName = "Ao",
                LastName = "Shen",
                Score = 98
            });

            students.Add(new Student
            {
                FirstName = "Ryan",
                LastName = "Liang",
                Score = 97
            });

            students.Add(new Student
            {
                FirstName = "David",
                LastName = "Wang",
                Score = 99
            });

            students.Add(new Student
            {
                FirstName = "XXX",
                LastName = "YYYY",
                Score = 97
            });

            return View(students);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
