﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grocery_Store.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Navbar()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminSidebar()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
    }
}