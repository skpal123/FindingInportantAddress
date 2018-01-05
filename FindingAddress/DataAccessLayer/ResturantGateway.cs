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
    public class ResturantGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveResturantType(ResturantType resturantType)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoTravelHotel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", resturantType.Name);
                cmd.Parameters.AddWithValue("@Description", resturantType.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int saveResturant(Resturant resturant)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoTravelHotel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", resturant.Name);
                cmd.Parameters.AddWithValue("@Description", resturant.Description);
                cmd.Parameters.AddWithValue("@DivisionId", resturant.DivisionId);
                cmd.Parameters.AddWithValue("@DistrictId", resturant.DistrictId);
                cmd.Parameters.AddWithValue("@ThanaId", resturant.ThanaId);
                cmd.Parameters.AddWithValue("@ResturantTypeId", resturant.ResturantTypeId);
                cmd.Parameters.AddWithValue("@ResturantWebsiteUrl", resturant.ResturantWebsiteUrl);
                cmd.Parameters.AddWithValue("@locationId", resturant.locationId);
                cmd.Parameters.AddWithValue("@PostedDate", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Address", resturant.Address);
                cmd.Parameters.AddWithValue("@ImagePath", resturant.ImagePath);

                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Resturant> GetResturants()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Resturant> resturants = new List<Resturant>();
                SqlCommand cmd = new SqlCommand("spGetallTourSpotByIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Resturant resturant = new Resturant();
                    resturant.Id = rdr["Id"].ToString();
                    resturant.Name = rdr["Name"].ToString();
                    resturant.DivisionId = rdr["DivisionId"].ToString();
                    resturant.DistrictId = rdr["DistrictId"].ToString();
                    resturant.ThanaId = rdr["ThanaId"].ToString();
                    resturant.locationId = rdr["LocationId"].ToString();
                    resturant.Address = rdr["Address"].ToString();
                    resturant.ResturantWebsiteUrl = rdr["ResturantWebsiteUrl"].ToString();
                    resturant.Description = rdr["Description"].ToString();
                    resturant.PostedDate =Convert.ToDateTime( rdr["PostedDate"].ToString());
                    resturant.ImagePath = rdr["ImagePath"].ToString();
                    resturants.Add(resturant);
                }
                return resturants;
            }
        }
    }
}