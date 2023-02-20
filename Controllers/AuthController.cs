using Clocker.Helpers;
using Clocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace Clocker.Controllers
{
    public class AuthController : ParentController
    {
        public AuthController(ClockerDbContext dbContext) : base(dbContext) { }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string txtEmail,string txtPassword)
        {
            string hashedPassword = Hasher.MD5Hash(txtPassword);

            var user = _context.Users.Where(a=>a.Email.Equals(txtEmail)).FirstOrDefault();

            if(user != null)
            {
                if(user.Password.Equals(hashedPassword))
                {
                    HttpContext.Session.SetString("AUTHSESSION", JsonSerializer.Serialize(user));
                    return Success("You have logged in successfully");
                }
                else
                {
                    return Error("Wrong Password");
                }
            }
            else
            {
                return Error("User Not Found");
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AUTHSESSION");
            return Success("You are logged out of system!");
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult ChangePassowrdPost(string currentPassword,string newPassword,string confirmPassword)
        {
            var jsonUser = HttpContext.Session.GetString("AUTHSESSION");
            if(jsonUser != null)
            {
                var user = JsonSerializer.Deserialize<User>(jsonUser);
                if (user != null)
                {
                    var hashedPassword = Hasher.MD5Hash(currentPassword);
                    if (hashedPassword != user.Password)
                    {
                        var dbUser = _context.Users.Where(a => a.Id == user.Id).FirstOrDefault();
                        dbUser.Password = Hasher.MD5Hash(newPassword);
                        _context.Update(dbUser);
                        _context.SaveChanges();
                        return Success("Password has been changed");

                    }
                    else
                    {
                        return Error("Wrong Password! Try again");
                    }
                }
                else
                {
                    return Error("Somethin went wrong");
                }
            }
            else
            {
                return Error("You are logged out of system. Please login again");
            }
        }


    }
}
