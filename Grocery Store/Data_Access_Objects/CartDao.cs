using Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Grocery_Store.Data_Access_Objects
{
    public class CartDao : Repositories.CartRepository
    {
        string str = @"data source=DELL\SQLEXPRESS; integrated security=true; initial catalog=OnlineGroceryStore;";
        public CartEntity AddToCart(int id, int quantity)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "select * from products where pid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            CartEntity c = null;
            if (rdr.Read())
            {
                double price = Convert.ToDouble(rdr["price"].ToString());
                c = new CartEntity()
                {
                    pid = Convert.ToInt32(rdr["pid"].ToString()),
                    pName = rdr["title"].ToString(),
                    price = price,
                    quantity = quantity,
                    bill = price * quantity
                };
                if (quantity > Convert.ToDouble(rdr["quantity"].ToString()) || quantity<0)
                {
                    return null;
                }
                if (quantity < Convert.ToDouble(rdr["quantity"].ToString()) && quantity > 0)
                {
                    rdr.Close();
                    string query1 = "update products set quantity-='" + quantity + "' where pid='" + id + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();
                }
            }
            con.Close();
            return c;
        }

        public List<CartEntity> RemoveFromCart(int id,List<CartEntity> cart)
        {
            for(int i = 0; i < cart.Count; i++)
            {
                if (cart[i].pid==id)
                {
                    cart.RemoveAt(i);
                }
            }
            return cart;
        }

        public CartEntity SearchFromCart(int id, List<CartEntity> cart)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].pid == id)
                {
                    return cart[i];
                }
            }
            return null;
        }
    }
}