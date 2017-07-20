using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example19.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Example19.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new SchoolDbContext())
            {
                return View(db.Users.Include("Roles.Role").ToArray());
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new SchoolDbContext())
            {
                var user = db.Users.FirstOrDefault(s => s.ID == id);

                if (user == null)
                    return NotFound();

                ViewData["Title"] = user.UserName;

                return View(user);
            }
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            using (var db = new SchoolDbContext())
            {
                var userInDB = db.Users.FirstOrDefault(s => s.ID == user.ID);

                if (userInDB == null)
                    return NotFound();

                userInDB.Email = user.Email;

                db.SaveChanges();

                // return to the list page
                return RedirectToAction("Index");
            }
        }
    }
}