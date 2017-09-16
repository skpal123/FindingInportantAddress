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
                SqlCommand cmd = new SqlCommand("", con);
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
                SqlCommand cmd = new SqlCommand("", con);
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
        public List<SelectListItem> getThanaDopdownListByDiisionId(int DistrictId)
        {
            List<SelectListItem> selectListitemList = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("", con);
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
    }
}