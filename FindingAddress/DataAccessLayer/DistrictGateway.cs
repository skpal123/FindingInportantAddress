using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using FindingAddress.Models;
namespace FindingAddress.DataAccessLayer
{
    public class DistrictGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveDistrict(District district)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoDistrict", con);
                cmd.Parameters.AddWithValue("@Name", district.Name);
                cmd.Parameters.AddWithValue("@Description", district.Description);
                cmd.Parameters.AddWithValue("@DivisionId", district.DivisionName);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<District> getAllDistrict()
        {
            List<District> districtList = new List<District>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDistrict", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    District district = new District();
                    district.Id = rdr["Id"].ToString();
                    district.Name = rdr["Name"].ToString();
                    district.DivisionName = rdr["DivisionName"].ToString();
                    district.Description = rdr["Description"].ToString();
                    districtList.Add(district);
                }
            }
            return districtList;
        }

        public District getDistrictByDistrictId(int DistrictId)
        {
            District district = new District();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetDistrictByDistrictId", con);
                cmd.Parameters.AddWithValue("@DistrictId", DistrictId);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    district.Id = rdr["Id"].ToString();
                    district.Name = rdr["Name"].ToString();
                    district.Description = rdr["Description"].ToString();
                }
            }
            return district;

        }
        public int updateDistrictByDistrictId(District ditrict)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("update tblDistrict set Name=@Name,Description=@Description where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", ditrict.Id);
                cmd.Parameters.AddWithValue("@Name", ditrict.Name);
                cmd.Parameters.AddWithValue("@Description", ditrict.Description);
                con.Open();
                return cmd.ExecuteNonQuery();
            }


        }
    }
}