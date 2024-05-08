using Grocery_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.IO;

namespace Grocery_Store.Data_Access_Objects
{
    public class CategoriesDao : Repositories.CategoriesRepository
    {
        string str = @"data source=DELL\SQLEXPRESS; integrated security=true; initial catalog=OnlineGroceryStore;";
        public List<SelectListItem> GetCategories()
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string q = "select * from categories";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader rdr=cmd.ExecuteReader();
            List<SelectListItem> categories = new List<SelectListItem>();
            while (rdr.Read())
            {
                categories.Add(new SelectListItem { Text = rdr["title"].ToString(), Value = rdr["title"].ToString() });
            }
            con.Close();
            return categories;
        }

        public void AddCategory(CategoryEntity category)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string q = "insert into categories values('" + category.ctitle + "','" + category.description + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void RemoveCategory(int id)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "delete from categories where cid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public CategoryEntity GetCategory(int id)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "select * from categories where cid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            CategoryEntity e = null;
            if (rdr.Read())
            {
                e = new CategoryEntity()
                {
                    id = Convert.ToInt32(rdr["cid"].ToString()),
                    ctitle = rdr["title"].ToString(),
                    description = rdr["description"].ToString()
                };
            }
            con.Close();
            return e;
        }

        public void UpdateCategory(CategoryEntity category)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "update categories set title='" + category.ctitle + "',description='" + category.description + "'" +
                "where cid='" + category.id + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<CategoryEntity> ShowCategories()
        {
            List<CategoryEntity> categories = new List<CategoryEntity>();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string query = "select * from categories";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CategoryEntity c = new CategoryEntity();
                c.id = Convert.ToInt32(reader["cid"].ToString());
                c.ctitle = reader["title"].ToString();
                c.description = reader["description"].ToString();
                categories.Add(c);
            }
            return categories;
        }
    }
}