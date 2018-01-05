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
    public class DivisionGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveDivision(Division division)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoDivision", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", division.Name);
                cmd.Parameters.AddWithValue("@Description", division.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Division> getAllDivision()
        {
            List<Division> divisionList = new List<Division>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDivision", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Division division = new Division();
                    division.Id = rdr["Id"].ToString();
                    division.Name = rdr["Name"].ToString();
                    division.Description = rdr["Description"].ToString();
                    divisionList.Add(division);
                }
            }
            return divisionList;
        }
        public Division getDivisionByDivisonId(int DivisonId)
        {
            Division division = new Division();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblDivision where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", DivisonId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {                  
                    division.Id = rdr["Id"].ToString();
                    division.Name = rdr["Name"].ToString();
                    division.Description = rdr["Description"].ToString();                   
                }
            }
            return division;
           
        }
        public int updateDivisionByDivisionId(Division division)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("update tblDivision set Name=@Name,Description=@Description where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", division.Id);
                cmd.Parameters.AddWithValue("@Name", division.Name);
                cmd.Parameters.AddWithValue("@Description", division.Description);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
          

        }
    }
}