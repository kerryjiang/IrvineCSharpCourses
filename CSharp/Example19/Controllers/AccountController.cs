using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings;
using System.Threading.Tasks;
using Example19.Models;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example19.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        public static string HashPassword(string password)
        {
            var sha1 = SHA1.Create();
            var data = Encoding.ASCII.GetBytes(password);
            return Convert.ToBase64String(sha1.ComputeHash(data));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginInfo, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return View(loginInfo);

            User user;

            using (var db = new SchoolDbContext())
            {
                user = db.Users.FirstOrDefault(u => u.UserName == loginInfo.UserName || u.Email == loginInfo.UserName);

                if (user == null || user.Password != HashPassword(loginInfo.Password))
                {
                    ModelState.AddModelError("", "Username or password incorrect");
                    return View(loginInfo);
                }
            }

            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString(), ClaimValueTypes.Integer));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName, ClaimValueTypes.String));
            claims.Add(new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email));

            if (user.Roles != null && user.Roles.Any())
            {
                foreach (var role in user.Roles.Select(r => r.Role.Name).ToArray())
                {
                    claims.Add(new Claim(ClaimTypes.Role, role, ClaimValueTypes.String));
                }
            }
            
            var userIdentity = new ClaimsIdentity("Login");
            userIdentity.AddClaims(claims);

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            return RedirectToLocal(returnUrl);
        }

        public async Task<IActionResult> LogOff(string returnUrl = null)
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");
            return RedirectToLocal(returnUrl);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            using (var db = new SchoolDbContext())
            {
                var newUser = new User();
                newUser.UserName = user.UserName;
                newUser.Password = HashPassword(user.Password);
                newUser.DateCreated = newUser.DateUpdated = DateTime.Now;
                newUser.Email = user.Email;
                db.Users.Add(newUser);
                db.SaveChanges();
            }

            return RedirectToAction("Login");
        }
    }
}
