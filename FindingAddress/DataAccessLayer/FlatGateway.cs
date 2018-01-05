using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FindingAddress.Models;
namespace FindingAddress.DataAccessLayer
{
    public class FlatGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveFlat(Flat flat)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoFlat", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BuildingName", flat.BuildingName);
                cmd.Parameters.AddWithValue("@imagePath", "images/image");
                cmd.Parameters.AddWithValue("@DistrictId", flat.DistrictId);
                cmd.Parameters.AddWithValue("@DivisionId", flat.DivisionId);
                cmd.Parameters.AddWithValue("@ThanaId", flat.ThanaId);
                cmd.Parameters.AddWithValue("@ContactNumber", flat.ContactNumber);
                cmd.Parameters.AddWithValue("@CityId", flat.CityId);
                cmd.Parameters.AddWithValue("@LocationId", flat.LocationId);
                cmd.Parameters.AddWithValue("@Description", flat.Description);
                cmd.Parameters.AddWithValue("@Address", flat.Address);
                cmd.Parameters.AddWithValue("@EstimatedFlatFare", flat.EstimatedFlatFare);
                cmd.Parameters.AddWithValue("@Advance", flat.Advance);
                cmd.Parameters.AddWithValue("@PostingDate", flat.PostingDate);
                cmd.Parameters.AddWithValue("@PostedDate", flat.PostedDate);
                cmd.Parameters.AddWithValue("@AvailableMonth", flat.AvailableMonth);
                cmd.Parameters.AddWithValue("@DeadlineDate", flat.DeadlineDate);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Flat> getAllFlat()
        {
            List<Flat> FlatList = new List<Flat>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblFlat", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Flat flat = new Flat();
                    flat.Id = rdr["Id"].ToString();
                    cmd.Parameters.AddWithValue("@BuildingName", flat.BuildingName);
                    flat.DivisionId = rdr["DivisionId"].ToString();
                    flat.DistrictId = rdr["DistrictId"].ToString();
                    flat.ThanaId = rdr["ThanaId"].ToString();
                    flat.Address = rdr["Address"].ToString();
                    flat.Advance = Convert.ToInt32(rdr["Advance"].ToString());
                    flat.AvailableMonth = rdr["AvailableMonth"].ToString();
                    flat.CityId = rdr["CityId"].ToString();
                    flat.ContactNumber = rdr["ContactNumber"].ToString();
                    flat.DeadlineDate = Convert.ToDateTime(rdr["DeadlineDate"].ToString());
                    flat.Description = rdr["Description"].ToString();
                    flat.EstimatedFlatFare =Convert.ToInt32( rdr["EstimatedFlatFare"].ToString());
                    flat.imagePath = rdr["imagePath"].ToString();
                    flat.LocationId = rdr["LocationId"].ToString();
                    flat.PostedDate = Convert.ToDateTime(rdr["PostedDate"].ToString());
                    FlatList.Add(flat);
                }
            }
            return FlatList;
        }
        public Flat getAllFlatById(int Id)
        {
            Flat flat = new Flat();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblFlat where Id=@id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    flat.Id = rdr["Id"].ToString();
                    cmd.Parameters.AddWithValue("@BuildingName", flat.BuildingName);
                    flat.DivisionId = rdr["DivisionId"].ToString();
                    flat.DistrictId = rdr["DistrictId"].ToString();
                    flat.ThanaId = rdr["ThanaId"].ToString();
                    flat.Address = rdr["Address"].ToString();
                    flat.Advance = Convert.ToInt32(rdr["Advance"].ToString());
                    flat.AvailableMonth = rdr["AvailableMonth"].ToString();
                    flat.CityId = rdr["CityId"].ToString();
                    flat.ContactNumber = rdr["ContactNumber"].ToString();
                    flat.DeadlineDate = Convert.ToDateTime(rdr["DeadlineDate"].ToString());
                    flat.Description = rdr["Description"].ToString();
                    flat.EstimatedFlatFare = Convert.ToInt32(rdr["EstimatedFlatFare"].ToString());
                    flat.imagePath = rdr["imagePath"].ToString();
                    flat.LocationId = rdr["LocationId"].ToString();
                    flat.PostedDate = Convert.ToDateTime(rdr["PostedDate"].ToString());
                }
            }
            return flat;
        }
    }
}