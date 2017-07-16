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
        public IActionResult View(int id)
        {
            using (var db = new SchoolDbContext())
            {
                var student = db.Students.FirstOrDefault(s => s.ID == id);
                //var student = db.Students.Where(s => s.ID == id).FirstOrDefault();

                if (student == null)
                    return NotFound();

                ViewData["Title"] = student.FirstName + " " + student.LastName;

                return View(student);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new SchoolDbContext())
            {
                var student = db.Students.FirstOrDefault(s => s.ID == id);
                //var student = db.Students.Where(s => s.ID == id).FirstOrDefault();

                if (student == null)
                    return NotFound();

                ViewData["Title"] = student.FirstName + " " + student.LastName + " - Edit";

                return View(student);
            }
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            using (var db = new SchoolDbContext())
            {
                var studentInDB = db.Students.FirstOrDefault(s => s.ID == student.ID);

                if (student == null)
                    return NotFound();

                studentInDB.FirstName = student.FirstName;
                studentInDB.LastName = student.LastName;
                studentInDB.MathScore = student.MathScore;
                studentInDB.EnglishScore = student.EnglishScore;

                db.SaveChanges();

                // return to the list page
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new SchoolDbContext())
            {
                var student = db.Students.FirstOrDefault(s => s.ID == id);
                //var student = db.Students.Where(s => s.ID == id).FirstOrDefault();

                if (student == null)
                    return NotFound();

                ViewData["Title"] = student.FirstName + " " + student.LastName + " - Delete";

                return View(student);
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            using (var db = new SchoolDbContext())
            {
                var student = db.Students.FirstOrDefault(s => s.ID == id);
                //var student = db.Students.Where(s => s.ID == id).FirstOrDefault();

                if (student == null)
                    return NotFound();

                db.Students.Remove(student);
                db.SaveChanges();

                // return to the list page
                return RedirectToAction("Index", "Home");
            }
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            using (var db = new SchoolDbContext())
            {
                db.Students.Add(student);
                db.SaveChanges();

                // return to the list page
                return RedirectToAction("Index", "Home");
            }
        }
    }
}