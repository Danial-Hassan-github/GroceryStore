using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grocery_Store.Data_Access_Objects;
using Grocery_Store.Models;

namespace Grocery_Store.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [HttpGet]
        public ActionResult Products()
        {
            return View(new ProductsDao().ShowProducts());
        }
        [HttpGet]
        public ActionResult AdminProducts()
        {
            ViewBag.categories = new CategoriesDao().GetCategories();
            return View(new ProductsDao().ShowProducts());
        }
        [HttpPost]
        public ActionResult AdminProducts(ProductEntity product)
        {
            ViewBag.categories = new CategoriesDao().GetCategories();
            new ProductsDao().AddProduct(product);
            return RedirectToAction("AdminProducts");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            new ProductsDao().RemoveProduct(id);
            return RedirectToAction("AdminProducts");
        }
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            ViewBag.categories = new CategoriesDao().GetCategories();
            return View(new ProductsDao().GetProduct(id));
        }
        [HttpPost]
        public ActionResult UpdateProduct(ProductEntity product)
        {
            ViewBag.categories = new CategoriesDao().GetCategories();
            new ProductsDao().UpdateProduct(product);
            return RedirectToAction("AdminProducts");
        }
    }
}