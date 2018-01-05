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
    public class TourSpotImageGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveTourSpotImage(TourSpotImage tourSpotImage)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoTourSpotImage", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ImagePath", tourSpotImage.ImagePath);
                cmd.Parameters.AddWithValue("@PhotoCreditName", tourSpotImage.PhotoCreditName);
                cmd.Parameters.AddWithValue("@TourSpotId", tourSpotImage.TourSpotId);
                cmd.Parameters.AddWithValue("@UploadDate", DateTime.Now);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}