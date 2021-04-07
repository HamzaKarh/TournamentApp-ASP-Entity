using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class loginController : Controller
    {
        DBmodel db = new DBmodel();
        
        public string EncryptPassword(string simpleString)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(simpleString);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public string DecryptPassword(string encrypString)
        {
            byte[] b;
            string decrypted;

            try
            {
                b = Convert.FromBase64String(encrypString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }

            return decrypted;
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user user)
        {
            
            var pwd = EncryptPassword(user.password);
            user.password = pwd;
            db.users.Add(user);
            db.SaveChanges();
            ModelState.Clear();
            
            return RedirectToAction("Login");

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(login login)
        {
            
            var pwd = EncryptPassword(login.Password);
                var user = db.users.Where(a => a.email == login.Email && a.password == pwd).FirstOrDefault();
                if(user != null)
                {
                    var Ticket = new FormsAuthenticationTicket(login.Email, true, 3000);
                    string Encrypt = FormsAuthentication.Encrypt(Ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                    cookie.Expires = DateTime.Now.AddHours(3000);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    if (user.role_id == 1)
                    {
                        return RedirectToAction("User_page", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Admin_page", "Home");
                    }
                }
            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}