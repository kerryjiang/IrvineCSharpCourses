using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example19.Models;
using Microsoft.AspNetCore.Mvc;

namespace Example19.Controllers
{
    public class StudentController : Controller
    {
        private SchoolDbContext _schoolDbContext;

        public StudentController(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public IActionResult Details(int id)
        {
            var student = _schoolDbContext.Students.FirstOrDefault(s => s.ID == id);

            if (student == null)
                return NotFound();

            ViewData["Title"] = student.FirstName + " " + student.LastName;

            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _schoolDbContext.Students.FirstOrDefault(s => s.ID == id);

            if (student == null)
                return NotFound();

            ViewData["Title"] = student.FirstName + " " + student.LastName + " - Edit";

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var studentInDB = _schoolDbContext.Students.FirstOrDefault(s => s.ID == student.ID);

            if (student == null)
                return NotFound();

            studentInDB.FirstName = student.FirstName;
            studentInDB.LastName = student.LastName;
            studentInDB.MathScore = student.MathScore;
            studentInDB.EnglishScore = student.EnglishScore;

            _schoolDbContext.SaveChanges();

            // return to the list page
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _schoolDbContext.Students.FirstOrDefault(s => s.ID == id);

            if (student == null)
                return NotFound();

            ViewData["Title"] = student.FirstName + " " + student.LastName + " - Delete";

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _schoolDbContext.Students.FirstOrDefault(s => s.ID == id);

            if (student == null)
                return NotFound();

            _schoolDbContext.Students.Remove(student);
            _schoolDbContext.SaveChanges();

            // return to the list page
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            
            _schoolDbContext.Students.Add(student);
            _schoolDbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}