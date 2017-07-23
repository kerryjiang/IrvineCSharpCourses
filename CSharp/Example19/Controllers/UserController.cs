using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Example19.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Example19.Controllers
{
    //[Authorize(Roles = "Administrator")]
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
                var user = db.Users.Include("Roles").FirstOrDefault(s => s.ID == id);

                if (user == null)
                    return NotFound();                

                ViewData["Title"] = user.UserName;

                var userRoles = user.Roles?.Select(r => r.RoleID).ToArray();

                if (userRoles == null)
                    userRoles = new short[0];

                var roles = db.Roles.Select(r => new SelectListItem{
                    Text = r.Name,
                    Value = r.ID.ToString(),
                    Selected = userRoles.Contains(r.ID)
                }).ToList();

                return View(new EditUserViewModel
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    AllRoles = roles
                });
            }
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            using (var db = new SchoolDbContext())
            {
                var userInDB = db.Users.Include("Roles").FirstOrDefault(s => s.ID == user.ID);

                if (userInDB == null)
                    return NotFound();

                userInDB.Email = user.Email;

                var roles = userInDB.Roles.ToArray();

                var selectedRoles = user.SelectedRoles;

                foreach (var r in roles)
                {
                    if (!selectedRoles.Any() || !selectedRoles.Contains(r.RoleID))
                        userInDB.Roles.Remove(r);
                }

                foreach (var r in selectedRoles)
                {
                    if (!userInDB.Roles.Any() || !userInDB.Roles.Any(x => x.RoleID == r))
                    {
                        userInDB.Roles.Add(new UserRole
                        {
                            UserID = userInDB.ID,
                            RoleID = r
                        });
                    }                        
                }

                db.SaveChanges();

                // return to the list page
                return RedirectToAction("Index");
            }
        }
    }
}