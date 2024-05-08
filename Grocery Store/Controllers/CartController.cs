using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grocery_Store.Data_Access_Objects;
using Grocery_Store.Models;
namespace Grocery_Store.Controllers
{
    public class CartController : Controller
    {
        List<CartEntity> cart = new List<CartEntity>();
        // GET: Cart
        [HttpGet]
        public ActionResult LoadCart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {
            CartEntity cartTemp = new CartDao().AddToCart(id, quantity);
            Session["qty"] = true;
            if (cartTemp == null)
            {
                Session["qty"] = false;
                return RedirectToAction("Products", "Products");
            }
            if (Session["cart"]!=null)
            {
                cart.AddRange((List<CartEntity>)Session["cart"]);
                CartEntity c = new CartDao().SearchFromCart(id, cart);
                if (c!=null)
                {
                    cart = ((List<CartEntity>)Session["cart"]);
                    cart = new CartDao().RemoveFromCart(id, cart);
                    Session["cart"] = cart;
                }
            }
            cart.Add(cartTemp);
            Session["cart"] = cart;
            return RedirectToAction("Products","Products");
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            cart = ((List<CartEntity>)Session["cart"]);
            cart = new CartDao().RemoveFromCart(id, cart);
            Session["cart"] = cart;
            return RedirectToAction("LoadCart");
        }
    }
}