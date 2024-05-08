using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grocery_Store.Models;
using Grocery_Store.Data_Access_Objects;
using System.Data.SqlClient;

namespace Grocery_Store.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SignupEntity user)
        {
            int i=new UserDao().SignupUser(user);
            if (i>0)
            {
                return RedirectToAction("Login"); 
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies["Login"];
            if (cookie!=null)
            {
                return RedirectToAction("Products","Products");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginEntity user)
        {
            Session["qty"] = true;
            SignupEntity check = new UserDao().LoginUser(user);
            Session["user"] = check;
            if (check!=null)
            {
                if (user.RememberMe)
                {
                    HttpCookie cookie = new HttpCookie("Login");
                    cookie["Email"] = user.Email;
                    cookie.Expires = DateTime.Now.AddDays(20);
                    Response.Cookies.Add(cookie);
                }
                if (user.Email.Equals("Admin1@gmail.com"))
                {
                    return RedirectToAction("AdminProducts", "Products");
                }
                else
                {
                    return RedirectToAction("Products", "Products");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies["Login"];
            if (cookie!=null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            return RedirectToAction("Login");
        }
    }
}