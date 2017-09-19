using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FindingAddress.Models;
namespace FindingAddress.DataAccessLayer
{
    public class TravelGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public List<TravelCategory> getAllTravelCategory()
        {
            List<TravelCategory> travelCategoryList = new List<TravelCategory>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TravelCategory travelCategory = new TravelCategory();
                    travelCategory.Id = rdr["Id"].ToString();
                    travelCategory.Name = rdr["Name"].ToString();
                    travelCategoryList.Add(travelCategory);
                }
            }
            return travelCategoryList;
        }
    }
}