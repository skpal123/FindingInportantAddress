using FindingAddress.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FindingAddress.DataAccessLayer
{
    public class HomeStayGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveHomeStay(HomeStay homeStay)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", homeStay.Name);
                cmd.Parameters.AddWithValue("@Description", homeStay.Description);
                cmd.Parameters.AddWithValue("@EstimatedPrice", homeStay.EstimatedPrice);
                cmd.Parameters.AddWithValue("@TourSpotId", homeStay.TourSpotId);
                cmd.Parameters.AddWithValue("@HotelWebsitesUrl", homeStay.HotelWebsitesUrl);
                cmd.Parameters.AddWithValue("@location", homeStay.location);
                cmd.Parameters.AddWithValue("@Email", homeStay.Email);
                cmd.Parameters.AddWithValue("@PostedDate", homeStay.PostedDate);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}