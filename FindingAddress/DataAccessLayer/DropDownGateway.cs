using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindingAddress.Models;
using FindingAddress.Connection;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace FindingAddress.DataAccessLayer
{
    public class DropDownGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public List<SelectListItem> getDivisionDopdownList()
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblDivision", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getDistrictDopdownList()
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDistrict", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getDistrictDopdownListByDiisionId(int DivisionId)
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDistrictByDivisionId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DivisionId", DivisionId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getThanaDopdownListByDistrictId(int DistrictId)
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllThanaByDistrictId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DistrictId", DistrictId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getCityDopdownList()
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllCity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getLocationDopdownListByThanaId(int ThanaId)
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllLocationByThanaId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThanaId", ThanaId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getLocationDopdownListByCityId(int CityId)
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityId", CityId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getHospitalTypeDopdownList()
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getDoctorTypeDopdownList()
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getLawerTypeDopdownList()
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> getBusCompanyDopdownList()
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllBBusCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["BusName"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
        public List<SelectListItem> gertBusStationDropdownList()
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from tblBusStaion", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SelectListItem selectList = new SelectListItem
                    {
                        Value = rdr["Id"].ToString(),
                        Text = rdr["Name"].ToString()
                    };
                    selectListitemList.Add(selectList);
                }
            }
            return selectListitemList;
        }
    }
}