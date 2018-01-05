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
    public class TravelHotelGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveTravelHotel(TravelHotel travelHotel)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoTravelHotel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", travelHotel.Name);
                cmd.Parameters.AddWithValue("@Description", travelHotel.Description);
                cmd.Parameters.AddWithValue("@DistrictId", travelHotel.DistrictId);
                cmd.Parameters.AddWithValue("@ThanaId", travelHotel.ThanaId);
                cmd.Parameters.AddWithValue("@EstimatedPrice", travelHotel.EstimatedPrice);
                cmd.Parameters.AddWithValue("@TourSpotId", travelHotel.TourSpotId);
                cmd.Parameters.AddWithValue("@HotelWebsitesUrl", travelHotel.HotelWebsitesUrl);
                cmd.Parameters.AddWithValue("@locationId", travelHotel.locationId);
                cmd.Parameters.AddWithValue("@Email", travelHotel.Email);
                cmd.Parameters.AddWithValue("@Address", travelHotel.Address);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<TravelHotel> GetTravelHotelList()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<TravelHotel> tourSpots = new List<TravelHotel>();
                SqlCommand cmd = new SqlCommand("spGetallTravelHotelIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TravelHotel travelHotel = new TravelHotel();
                    travelHotel.Id = rdr["Id"].ToString();
                    travelHotel.Name = rdr["Name"].ToString();
                    travelHotel.EstimatedPrice = Convert.ToDecimal(rdr["EstimatedPrice"].ToString());
                    travelHotel.DistrictId = rdr["DistrictId"].ToString();
                    travelHotel.ThanaId = rdr["ThanaId"].ToString();
                    travelHotel.locationId = rdr["LocationId"].ToString();
                    travelHotel.Address = rdr["Address"].ToString();
                    travelHotel.HotelWebsitesUrl = rdr["HotelWebsitesUrl"].ToString();
                    travelHotel.Description = rdr["Description"].ToString();
                    travelHotel.Email = rdr["Email"].ToString();
                    travelHotel.TourSpotId = rdr["TourSpotId"].ToString();
                    tourSpots.Add(travelHotel);
                }
                return tourSpots;
            }
        }
        public TravelHotel GetTravelHotelById( int Id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                TravelHotel travelHotel = new TravelHotel();
                SqlCommand cmd = new SqlCommand("spGetallTravelHotelIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    travelHotel.Id = rdr["Id"].ToString();
                    travelHotel.Name = rdr["Name"].ToString();
                    travelHotel.EstimatedPrice = Convert.ToDecimal(rdr["EstimatedPrice"].ToString());
                    travelHotel.DistrictId = rdr["DistrictId"].ToString();
                    travelHotel.ThanaId = rdr["ThanaId"].ToString();
                    travelHotel.locationId = rdr["LocationId"].ToString();
                    travelHotel.Address = rdr["Address"].ToString();
                    travelHotel.HotelWebsitesUrl = rdr["HotelWebsitesUrl"].ToString();
                    travelHotel.Description = rdr["Description"].ToString();
                    travelHotel.Email = rdr["Email"].ToString();
                    travelHotel.TourSpotId = rdr["TourSpotId"].ToString();
                }
                return travelHotel;
            }
        }
        public int updateTravelHotelById(TravelHotel travelHotel)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("updateTravelHotelById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", travelHotel.Id);
                cmd.Parameters.AddWithValue("@Name", travelHotel.Name);
                cmd.Parameters.AddWithValue("@Description", travelHotel.Description);
                cmd.Parameters.AddWithValue("@DistrictId", travelHotel.DistrictId);
                cmd.Parameters.AddWithValue("@ThanaId", travelHotel.ThanaId);
                cmd.Parameters.AddWithValue("@EstimatedPrice", travelHotel.EstimatedPrice);
                cmd.Parameters.AddWithValue("@TourSpotId", travelHotel.TourSpotId);
                cmd.Parameters.AddWithValue("@HotelWebsitesUrl", travelHotel.HotelWebsitesUrl);
                cmd.Parameters.AddWithValue("@locationId", travelHotel.locationId);
                cmd.Parameters.AddWithValue("@Email", travelHotel.Email);
                cmd.Parameters.AddWithValue("@PostedDate", travelHotel.PostedDate);
                cmd.Parameters.AddWithValue("@Address", travelHotel.Address);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
       
    }
}