using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grocery_Store.Models;
using System.Data.SqlClient;
namespace Grocery_Store.Controllers
{
    public class OrdersController : Controller
    {
        string str = @"data source=DELL\SQLEXPRESS; integrated security=true; initial catalog=OnlineGroceryStore;";
        // GET: Orders
        public ActionResult Orders()
        {
            return View();
        }

        public ActionResult AdminOrders()
        {
            List<OrderEntity> orders = new List<OrderEntity>();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SignupEntity u = (SignupEntity)Session["user"];
            string q = "select * from orders1";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader rdr=cmd.ExecuteReader();
            while (rdr.Read())
            {
                OrderEntity order = new OrderEntity()
                {
                    id=Convert.ToInt32(rdr["oid"].ToString()),
                    pid= Convert.ToInt32(rdr["pid"].ToString()),
                    pName=rdr["pName"].ToString(),
                    quantity = Convert.ToInt32(rdr["quantity"].ToString()),
                    price = Convert.ToInt32(rdr["price"].ToString()),
                    bill = Convert.ToInt32(rdr["total"].ToString()),
                    address= rdr["address"].ToString(),
                    contact=rdr["contact"].ToString()
                };
                orders.Add(order);
            }
            con.Close();
            return View(orders);
        }

        public ActionResult PlaceOrder()
        {
            double total = 0;
            List<CartEntity> cart = (List<CartEntity>)Session["cart"];
            List<OrderEntity> orders = new List<OrderEntity>();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            int count = 0;
            int oid = 1;
            OrderEntity order = new OrderEntity();
            if (cart != null)
            {
                foreach (var item in cart)
                {
                    order = new OrderEntity()
                    {
                        pid = item.pid,
                        pName = item.pName,
                        price = item.price,
                        quantity = item.quantity,
                        bill = item.bill,
                    };
                    orders.Add(order);
                    total += item.bill;
                    SignupEntity u = (SignupEntity)Session["user"];
                    
                    if (count < 1)
                    {
                        string q1 = "select top 1 oid from orders1 order by oid desc";
                        SqlCommand cmd1 = new SqlCommand(q1, con);
                        SqlDataReader reader = cmd1.ExecuteReader();
                        if (reader.Read())
                        {
                            oid = Convert.ToInt32(reader["oid"])+1;
                        }
                        reader.Close();
                        count++;
                    }
                    
                    string q = "insert into orders1 values('"+oid+"','" + order.pid + "','" + order.pName + "','" + order.quantity + "','" + order.price + "','" + item.bill + "','" + u.Address + "','" + u.Contact + "')";
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                    Session["orders"] = orders;
                }
                
                con.Close();
            }
            return RedirectToAction("Orders");
        }
    }
}