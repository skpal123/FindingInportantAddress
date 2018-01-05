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
    public class LawyerGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();

        public int saveLawyer(Lawyer lawyer)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoLaywer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CourtId", lawyer.CourtId);
                cmd.Parameters.AddWithValue("@Name", lawyer.Name);
                cmd.Parameters.AddWithValue("@imagePath", "images/image");
                cmd.Parameters.AddWithValue("@LawyerTypeId", lawyer.LawyerTypeId);
                cmd.Parameters.AddWithValue("@DistrictId", lawyer.DistrictId);
                cmd.Parameters.AddWithValue("@DivisionId", lawyer.DivisionId);
                cmd.Parameters.AddWithValue("@ThanaId", lawyer.ThanaId);
                cmd.Parameters.AddWithValue("@ContactNumber", lawyer.ContactNumber);
                cmd.Parameters.AddWithValue("@CityId", lawyer.CityId);
                cmd.Parameters.AddWithValue("@LocationId", lawyer.LocationId);
                cmd.Parameters.AddWithValue("@Description", lawyer.Description);
                cmd.Parameters.AddWithValue("@Address", lawyer.Address);
                cmd.Parameters.AddWithValue("@PersonalChamber", lawyer.PersonalChamber);
                cmd.Parameters.AddWithValue("@PersonalEmailaddress", lawyer.PersonalEmailaddress);
                cmd.Parameters.AddWithValue("@PersonalWebsite", lawyer.PersonalWebsite);
                cmd.Parameters.AddWithValue("@EstimatedFee", lawyer.EstimatedFee);
                cmd.Parameters.AddWithValue("@Education", lawyer.Education);
                cmd.Parameters.AddWithValue("@Gender", lawyer.Gender);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Lawyer> GetAllLayers()
        {
            List<Lawyer> lawyers = new List<Lawyer>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetLawyerDetaisByIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Lawyer lawyer = new Lawyer();
                    lawyer.Id = rdr["Id"].ToString();
                    lawyer.Name = rdr["Name"].ToString();
                    lawyer.Gender = rdr["Gender"].ToString();
                    lawyer.EstimatedFee = Convert.ToDouble(rdr["DivisionId"].ToString());
                    lawyer.Education = rdr["Education"].ToString();
                    lawyer.PersonalChamber = rdr["PersonalChamber"].ToString();
                    lawyers.Add(lawyer);
                }
            }
            return lawyers;
        }
        public Lawyer GetLawyerDetails(int Id)
        {
            Lawyer lawyer = new Lawyer();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetLawyerDetaisByIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lawyer.Name = rdr["Name"].ToString();
                    lawyer.Gender = rdr["Gender"].ToString();
                    lawyer.DivisionId = rdr["DivisionId"].ToString();
                    lawyer.DistrictId = rdr["DistrictId"].ToString();
                    lawyer.ThanaId = rdr["ThanaId"].ToString();
                    lawyer.Address = rdr["Address"].ToString();
                    lawyer.CityId = rdr["CityId"].ToString();
                    lawyer.LocationId = rdr["LocationId"].ToString();
                    lawyer.LawyerTypeId = rdr["LawyerTypeId"].ToString();
                    lawyer.EstimatedFee = Convert.ToDouble(rdr["EstimatedFee"].ToString());
                    lawyer.CourtId = rdr["CourtId"].ToString();
                    lawyer.Education = rdr["Education"].ToString();
                    lawyer.PersonalChamber = rdr["PersonalChamber"].ToString();
                    lawyer.PersonalEmailaddress = rdr["PersonalEmailaddress"].ToString();
                    lawyer.PersonalWebsite = rdr["PersonalWebsite"].ToString();
                    lawyer.Description = rdr["Description"].ToString();
                  
                }
            }
            return lawyer;
        }
    }
}