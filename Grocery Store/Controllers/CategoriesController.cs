using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grocery_Store.Models;
using Grocery_Store.Data_Access_Objects;

namespace Grocery_Store.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        [HttpGet]
        public ActionResult Category()
        {
            return View(new CategoriesDao().ShowCategories());
        }
        [HttpPost]
        public ActionResult Category(CategoryEntity category)
        {
            new CategoriesDao().AddCategory(category);
            return View(new CategoriesDao().ShowCategories());
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            new CategoriesDao().RemoveCategory(id);
            return RedirectToAction("Category");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            return View(new CategoriesDao().GetCategory(id));
        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryEntity category)
        {
            new CategoriesDao().UpdateCategory(category);
            return RedirectToAction("Category");
        }
    }
}