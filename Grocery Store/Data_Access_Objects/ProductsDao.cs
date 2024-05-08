using Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
namespace Grocery_Store.Data_Access_Objects
{
    public class ProductsDao : Repositories.ProductsRepository
    {
        string str = @"data source=DELL\SQLEXPRESS; integrated security=true; initial catalog=OnlineGroceryStore;";
        public void AddProduct(ProductEntity product)
        {
            BinaryReader Br = new BinaryReader(product.fileAttachment.InputStream);
            product.image = Convert.ToBase64String(Br.ReadBytes(product.fileAttachment.ContentLength));
            product.imageType = product.fileAttachment.ContentType;
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string q = "insert into products values('" + product.ptitle + "','"+product.category+"','" + product.price + "','" + product.image + "','" + product.imageType + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void RemoveProduct(int id)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "delete from products where pid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<ProductEntity> ShowProducts()
        {
            List<ProductEntity> products = new List<ProductEntity>();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ProductEntity p = new ProductEntity();
                p.id = Convert.ToInt32(reader["pid"].ToString());
                p.ptitle = reader["title"].ToString();
                p.category = reader["category"].ToString();
                p.price = Convert.ToDouble(reader["price"].ToString());
                p.quantity = Convert.ToInt32(reader["quantity"].ToString());
                p.image = reader["image"].ToString();
                p.imageType = reader["imageType"].ToString();
                products.Add(p);
            }
            return products;
        }

        public ProductEntity GetProduct(int id)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "select * from products where pid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            ProductEntity e = null;
            if (rdr.Read())
            {
                e = new ProductEntity()
                {
                    id = Convert.ToInt32(rdr["pid"].ToString()),
                    ptitle = rdr["title"].ToString(),
                    category = rdr["category"].ToString(),
                    price = Convert.ToDouble(rdr["price"].ToString()),
                    quantity = Convert.ToInt32(rdr["quantity"].ToString()),
                    image = rdr["image"].ToString(),
                    imageType = rdr["imageType"].ToString()
                };
            }
            con.Close();
            return e;
        }

        public void UpdateProduct(ProductEntity p)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "update products set title='" + p.ptitle + "',category='" + p.category + "'" +
                ",price='" + p.price + "' where pid='" + p.id + "'";
            /*if (p.fileAttachment!=null)
            {
                BinaryReader Br = new BinaryReader(p.fileAttachment.InputStream);
                p.image = Convert.ToBase64String(Br.ReadBytes(p.fileAttachment.ContentLength));
                p.imageType = p.fileAttachment.ContentType;
                query = "update products set title='" + p.ptitle + "',category='" + p.category + "'" +
                ",price='" + p.price + "',image'"+p.image+"',imageType='"+p.imageType+"' where pid='" + p.id + "'";
            }*/
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}