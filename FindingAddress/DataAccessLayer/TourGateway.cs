using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FindingAddress.Models;

namespace FindingAddress.DataAccessLayer
{
    public class TourGateway
    {
        private string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();

        public int saveTourSpot(TourSpot tourSpot)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoTourSpot", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", tourSpot.Name);
                cmd.Parameters.AddWithValue("@CategoryId", tourSpot.CategoryId);
                cmd.Parameters.AddWithValue("@DivisionId", tourSpot.DivisionId);
                cmd.Parameters.AddWithValue("@DistrictId", tourSpot.DistrictId);
                cmd.Parameters.AddWithValue("@CityId", tourSpot.CityId);
                cmd.Parameters.AddWithValue("@ThanaId", tourSpot.ThanaId);
                cmd.Parameters.AddWithValue("@LocationId", tourSpot.LocationId);
                cmd.Parameters.AddWithValue("@Address", tourSpot.Address);
                cmd.Parameters.AddWithValue("@Description", tourSpot.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int updateTourSpotByTourSpotId(TourSpot tourSpot)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateTourSpotById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", tourSpot.Id);
                cmd.Parameters.AddWithValue("@Name", tourSpot.Name);
                cmd.Parameters.AddWithValue("@CategoryId", tourSpot.CategoryId);
                cmd.Parameters.AddWithValue("@DivisionId", tourSpot.DivisionId);
                cmd.Parameters.AddWithValue("@DistrctId", tourSpot.DistrictId);
                cmd.Parameters.AddWithValue("@CityId", tourSpot.CityId);
                cmd.Parameters.AddWithValue("@ThanaId", tourSpot.ThanaId);
                cmd.Parameters.AddWithValue("@LocationId", tourSpot.LocationId);
                cmd.Parameters.AddWithValue("@Address", tourSpot.Address);
                cmd.Parameters.AddWithValue("@Description", tourSpot.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<TourSpot> GetTourSpots()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<TourSpot> tourSpots = new List<TourSpot>();
                SqlCommand cmd = new SqlCommand("spGetallTourSpotByIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TourSpot tourSpot = new TourSpot();
                    tourSpot.Id = rdr["Id"].ToString();
                    tourSpot.Name = rdr["Name"].ToString();
                    tourSpot.DivisionId = rdr["DivisionId"].ToString();
                    tourSpot.DistrictId = rdr["DistrictId"].ToString();
                    tourSpot.ThanaId = rdr["ThanaId"].ToString();
                    tourSpot.LocationId = rdr["LocationId"].ToString();
                    tourSpot.Address = rdr["Address"].ToString();
                    tourSpot.CategoryId = rdr["CategoryName"].ToString();
                    tourSpot.Description = rdr["Description"].ToString();
                    tourSpot.CityId = rdr["CityId"].ToString();
                    tourSpots.Add(tourSpot);
                }
                return tourSpots;
            }
        }
        public TourSpot GetTourSpotById( int TourSpotId)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                TourSpot tourSpot = new TourSpot();
                SqlCommand cmd = new SqlCommand("spGetallTourSpotByIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", TourSpotId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tourSpot.Id = rdr["Id"].ToString();
                    tourSpot.Name = rdr["Name"].ToString();
                    tourSpot.DivisionId = rdr["DivisionId"].ToString();
                    tourSpot.DistrictId = rdr["DistrctId"].ToString();
                    tourSpot.ThanaId = rdr["ThanaId"].ToString();
                    tourSpot.LocationId = rdr["LocationId"].ToString();
                    tourSpot.Address = rdr["Address"].ToString();
                    tourSpot.CategoryId = rdr["CategoryName"].ToString();
                    tourSpot.Description = rdr["Description"].ToString();
                    tourSpot.CityId = rdr["CityId"].ToString();

                }
                return tourSpot;
            }
        }
        public int saveTourSpotImage(TourSpotImage tourSpotImage)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", tourSpotImage.ImagePath);
                cmd.Parameters.AddWithValue("@CategoryId", tourSpotImage.TourSpotId);
                cmd.Parameters.AddWithValue("@DivisionId", tourSpotImage.PhotoCreditName);
                cmd.Parameters.AddWithValue("@DistrctId", DateTime.Now);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        
    }
}