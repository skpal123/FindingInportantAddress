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
    public class DoctorGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();

        public int saveDoctor(Doctor doctor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoDoctor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HospitalId", doctor.HospitalId);
                cmd.Parameters.AddWithValue("@Name", doctor.Name);
                cmd.Parameters.AddWithValue("@imagePath", "images/image");
                cmd.Parameters.AddWithValue("@DoctorTypeId", doctor.DoctorTypeId);
                cmd.Parameters.AddWithValue("@DistrictId", doctor.DistrictId);
                cmd.Parameters.AddWithValue("@DivisionId", doctor.DivisionId);
                cmd.Parameters.AddWithValue("@ThanaId", doctor.ThanaId);
                cmd.Parameters.AddWithValue("@ContactNumber", doctor.ContactNumber);
                cmd.Parameters.AddWithValue("@CityId", doctor.CityId);
                cmd.Parameters.AddWithValue("@LocationId", doctor.LocationId);
                cmd.Parameters.AddWithValue("@Description", doctor.Description);
                cmd.Parameters.AddWithValue("@Address", doctor.Address);
                cmd.Parameters.AddWithValue("@PersonalChamber", doctor.PersonalChamber);
                cmd.Parameters.AddWithValue("@PersonalEmailaddress", doctor.PersonalEmailaddress);
                cmd.Parameters.AddWithValue("@PersonalWebsite", doctor.PersonalWebsite);
                cmd.Parameters.AddWithValue("@SerialNumber", doctor.SerialNumber);
                cmd.Parameters.AddWithValue("@VisitAmountFirstTime", doctor.VisitAmountFirstTime);
                cmd.Parameters.AddWithValue("@VisitAmountSecondTime", doctor.VisitAmountSecondTime);
                cmd.Parameters.AddWithValue("@Education", doctor.Education);
                cmd.Parameters.AddWithValue("@Gender", doctor.Gender);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> hospitals = new List<Doctor>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetDoctorDetaisByIdOrWithOutId", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Doctor doctor = new Doctor();
                    doctor.Id = rdr["Id"].ToString();
                    doctor.Name = rdr["Name"].ToString();
                    doctor.Gender = rdr["Gender"].ToString();
                    doctor.DivisionId = rdr["DivisionId"].ToString();
                    doctor.DistrictId = rdr["DisrtictId"].ToString();
                    doctor.ThanaId = rdr["ThanaId"].ToString();
                    doctor.Address = rdr["Address"].ToString();
                    doctor.CityId = rdr["CityId"].ToString();
                    doctor.LocationId = rdr["LocationId"].ToString();
                    doctor.DoctorTypeId = rdr["DoctorTypeId"].ToString();
                    doctor.VisitAmountFirstTime = Convert.ToDouble(rdr["VisitAmountFirstTime"].ToString());
                    doctor.VisitAmountSecondTime = Convert.ToDouble(rdr["VisitAmountSecondTime"].ToString());
                    doctor.Education = rdr["Education"].ToString();
                    doctor.DoctorTypeId = rdr["DoctorTypeId"].ToString();
                    doctor.SerialNumber = rdr["SerialNumber"].ToString();
                    doctor.PersonalChamber = rdr["PersonalChamber"].ToString();
                    doctor.PersonalEmailaddress = rdr["PersonalEmailaddress"].ToString();
                    doctor.PersonalWebsite = rdr["PersonalWebsite"].ToString();
                    doctor.HospitalId = rdr["HospitalId"].ToString();
                    hospitals.Add(doctor);
                }
            }
            return hospitals;
        }
        public Doctor GetDoctorsDetailsByid(int id)
        {
            Doctor doctor = new Doctor();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetDoctorDetaisByIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    doctor.Id = rdr["Id"].ToString();
                    doctor.Name = rdr["Name"].ToString();
                    doctor.Gender = rdr["Gender"].ToString();
                    doctor.DivisionId = rdr["DivisionId"].ToString();
                    doctor.DistrictId = rdr["DisrtictId"].ToString();
                    doctor.ThanaId = rdr["ThanaId"].ToString();
                    doctor.Address = rdr["Address"].ToString();
                    doctor.CityId = rdr["CityId"].ToString();
                    doctor.LocationId = rdr["LocationId"].ToString();
                    doctor.DoctorTypeId = rdr["DoctorTypeId"].ToString();
                    doctor.VisitAmountFirstTime = Convert.ToDouble(rdr["VisitAmountFirstTime"].ToString());
                    doctor.VisitAmountSecondTime = Convert.ToDouble(rdr["VisitAmountSecondTime"].ToString());
                    doctor.Education = rdr["Education"].ToString();
                    doctor.DoctorTypeId = rdr["DoctorTypeId"].ToString();
                    doctor.SerialNumber = rdr["SerialNumber"].ToString();
                    doctor.PersonalChamber = rdr["PersonalChamber"].ToString();
                    doctor.PersonalEmailaddress = rdr["PersonalEmailaddress"].ToString();
                    doctor.PersonalWebsite = rdr["PersonalWebsite"].ToString();
                    doctor.HospitalId = rdr["HospitalId"].ToString();
                    
                }
            }
            return doctor;
        }
    }
}