using FindingAddress.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FindingAddress.DataAccessLayer
{
    public class UserGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int verifyUserAccount(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select count(Name) from tblUser where UserName=@UserName and Password=@Password", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public string findRollNameByUsername(string username)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select tblRole.Name from tblRole inner join tblUser on tblUser.RoleId=tblRole.Id  where UserName=@UserName", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", username);
                con.Open();
                return (string)cmd.ExecuteScalar();
            }
        }
    }
}