using FindingAddress.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
namespace FindingAddress.DataAccessLayer
{
    public class CityGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveDistrict(City city)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", city.Name);
                cmd.Parameters.AddWithValue("@Description", city.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}