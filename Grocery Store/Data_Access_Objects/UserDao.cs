using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Grocery_Store.Models;
using System.Data.SqlClient;
using Grocery_Store.Models;
namespace Grocery_Store.Data_Access_Objects
{
    public class UserDao : Repositories.UserRepository
    {
        public bool IsEmailUnique(string email)
        {
            throw new NotImplementedException();
        }

        public SignupEntity LoginUser(LoginEntity user)
        {
            Connection con = new Connection();
            SqlConnection connection = con.getConnection();
            string query = "select * from signup where email='"+user.Email+"' and password='"+user.Password+"'";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                SignupEntity u = new SignupEntity()
                {
                    id=Convert.ToInt32(rdr["id"].ToString()),
                    Name=rdr["Name"].ToString(),
                    Password=rdr["Password"].ToString(),
                    Email = rdr["Email"].ToString(),
                    Address = rdr["Address"].ToString(),
                    Contact=rdr["Contact"].ToString(),
                };
                return u;
            }
            connection.Close();
            return null;
        }

        public int SignupUser(SignupEntity user)
        {
            Connection con = new Connection();
            SqlConnection connection = con.getConnection();
            string query = "insert into signup values('"+user.Name+"','"+user.Email+"'," +
                "'"+user.Password+"','"+user.Contact+"','"+user.Address+"')";
            SqlCommand cmd = new SqlCommand(query, connection);
            int i=cmd.ExecuteNonQuery();
            connection.Close();
            return i;
        }

        public void UpdateUser(LoginEntity user)
        {
            throw new NotImplementedException();
        }
    }
}