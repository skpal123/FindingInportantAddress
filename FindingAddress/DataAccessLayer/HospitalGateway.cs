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
    public class HospitalGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveHospital(Hospital hospital)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoHospital", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", hospital.Name);
                cmd.Parameters.AddWithValue("@HospitaltypeId", hospital.HospitalTypeId);
                cmd.Parameters.AddWithValue("@Address", hospital.Address);
                cmd.Parameters.AddWithValue("@DivisionId", hospital.DivisionId);
                cmd.Parameters.AddWithValue("@DistrictId", hospital.DistrictId);
                cmd.Parameters.AddWithValue("@ThanaId", hospital.ThanaId);
                cmd.Parameters.AddWithValue("@CityId", hospital.CityId);
                cmd.Parameters.AddWithValue("@LocationId", hospital.LocationId);
                cmd.Parameters.AddWithValue("@Description", hospital.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int updateHospitalById(Hospital hospital)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblHospital", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", hospital.Id);
                cmd.Parameters.AddWithValue("@Name", hospital.Name);
                cmd.Parameters.AddWithValue("@HospitaltypeId", hospital.HospitalTypeId);
                cmd.Parameters.AddWithValue("@Address", hospital.Address);
                cmd.Parameters.AddWithValue("@DivisionId", hospital.DivisionId);
                cmd.Parameters.AddWithValue("@DistrctId", hospital.DistrictId);
                cmd.Parameters.AddWithValue("@ThanaId", hospital.ThanaId);
                cmd.Parameters.AddWithValue("@CityId", hospital.CityId);
                cmd.Parameters.AddWithValue("@LocationId", hospital.LocationId);
                cmd.Parameters.AddWithValue("@Address", hospital.Address);
                cmd.Parameters.AddWithValue("@Description", hospital.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Hospital> GetAllHospitals()
        {
            List<Hospital> hospitals = new List<Hospital>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblHospital", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Hospital hospital = new Hospital();
                    hospital.Id = rdr["Id"].ToString();
                    hospital.Name = rdr["Name"].ToString();
                    hospital.DivisionId = rdr["DivisionId"].ToString();
                    hospital.DistrictId = rdr["DistrictId"].ToString();
                    hospital.ThanaId = rdr["ThanaId"].ToString();
                    hospital.Address = rdr["Address"].ToString();
                    hospital.CityId = rdr["CityId"].ToString();
                    hospital.LocationId = rdr["LocationId"].ToString();
                    hospital.HospitalTypeId = rdr["HospitalTypeId"].ToString();
                    hospital.LocationId = rdr["LocationId"].ToString();
                    hospitals.Add(hospital);
                }
            }
            return hospitals;
        }
        public Hospital GetHospitalById(int Id)
        {
            Hospital hospital = new Hospital();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblHospital where Id=@id", con);
                cmd.Parameters.AddWithValue("@id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    hospital.Name = rdr["Name"].ToString();
                    hospital.DivisionId = rdr["DivisionId"].ToString();
                    hospital.DistrictId = rdr["DistrictId"].ToString();
                    hospital.ThanaId = rdr["ThanaId"].ToString();
                    hospital.Address = rdr["Address"].ToString();
                    hospital.CityId = rdr["CityId"].ToString();
                    hospital.LocationId = rdr["LocationId"].ToString();
                    hospital.HospitalTypeId = rdr["HospitalTypeId"].ToString();
                    hospital.LocationId = rdr["LocationId"].ToString();
                }
            }
            return hospital;
        }
        public int saveHospitalService(HospitalService hospitalService)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoHospitalService", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", hospitalService.Name);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int savehospitalServiceAllocation(HospitalServiceAllocation hospitalServiceAllocation)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertHospitalServiceAllocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HospitalId", hospitalServiceAllocation.HospitalId);
                cmd.Parameters.AddWithValue("@ServiceId", hospitalServiceAllocation.ServiceId);
                cmd.Parameters.AddWithValue("@EstimatedPrice", hospitalServiceAllocation.EstimatedPrice);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<HospitalServiceAllocation> GetHospitalServiceAllocations()
        {
            List<HospitalServiceAllocation> hospitalServiceAllocations = new List<HospitalServiceAllocation>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllServiceAllocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    HospitalServiceAllocation hospitalServiceAllocation = new HospitalServiceAllocation();
                    hospitalServiceAllocation.Id = rdr["Id"].ToString();
                    hospitalServiceAllocation.HospitalId = rdr["HospitalName"].ToString();
                    hospitalServiceAllocation.ServiceId = rdr["ServiceName"].ToString();
                    hospitalServiceAllocation.EstimatedPrice = Convert.ToDouble(rdr["EstimatedPrice"].ToString());
                    hospitalServiceAllocations.Add(hospitalServiceAllocation);
                }
            }
            return hospitalServiceAllocations;
        }
        public int saveHospitalType(HospitalType hospitalType)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoHospitalType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", hospitalType.Name);
                cmd.Parameters.AddWithValue("@Description", hospitalType.Description);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<HospitalType> GetHospitalTypes()
        {
            List<HospitalType> hospitalTypes = new List<HospitalType>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblHospitalType", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    HospitalType hospitalType = new HospitalType();
                    hospitalType.Id = rdr["Id"].ToString();
                    hospitalType.Name = rdr["Name"].ToString();
                    hospitalType.Description = rdr["Description"].ToString();
                    hospitalTypes.Add(hospitalType);
                }
            }
            return hospitalTypes;
        }
        public List<HospitalService> getHospitalServices()
        {
            List<HospitalService> hospitalServices = new List<HospitalService>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblHospitalService", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    HospitalService hospitalService = new HospitalService();
                    hospitalService.Id = rdr["Id"].ToString();
                    hospitalService.Name = rdr["Name"].ToString();
                    hospitalServices.Add(hospitalService);
                }
            }
            return hospitalServices;
        }
    }
}