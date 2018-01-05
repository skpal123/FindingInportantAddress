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
    public class BUsCompanyGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveBusCompany(BusCompany busCompany)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoBusCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", busCompany.CompanyName);
                cmd.Parameters.AddWithValue("@BusName", busCompany.BusName);
                cmd.Parameters.AddWithValue("@Route", busCompany.Route);
                cmd.Parameters.AddWithValue("@OwnerName", busCompany.OwnerName);
                cmd.Parameters.AddWithValue("@OwnerContactInformation", busCompany.OwnerContactInformation);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<BusCompany> getAllBusCompany()
        {
            List<BusCompany> busCompanyList = new List<BusCompany>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllBBusCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BusCompany busCompany =new BusCompany();
                    busCompany.Id = rdr["Id"].ToString();
                    busCompany.CompanyName = rdr["CompanyName"].ToString();
                    busCompany.BusName = rdr["BusName"].ToString();
                    busCompany.Route = rdr["Route"].ToString();
                    busCompany.OwnerName = rdr["OwnerName"].ToString();
                    busCompany.OwnerContactInformation = rdr["OwnerContactInformation"].ToString();
                    busCompanyList.Add(busCompany);
                }
            }
            return busCompanyList;
        }
        public BusCompany getBusCompanyById(int Id)
        {
            BusCompany busCompany = new BusCompany();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllBBusCompany", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {                
                    busCompany.Id = rdr["Id"].ToString();
                    busCompany.CompanyName = rdr["CompanyName"].ToString();
                    busCompany.BusName = rdr["BusName"].ToString();
                    busCompany.Route = rdr["Route"].ToString();
                    busCompany.OwnerName = rdr["OwnerName"].ToString();
                    busCompany.OwnerContactInformation = rdr["OwnerContactInformation"].ToString();                 
                }
            }
            return busCompany;
        }
        public int updateBusCompanyById(BusCompany busCompany)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpadteBusCompanyById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", busCompany.Id);
                cmd.Parameters.AddWithValue("@CompanyName", busCompany.CompanyName);
                cmd.Parameters.AddWithValue("@BusName", busCompany.BusName);
                cmd.Parameters.AddWithValue("@Route", busCompany.Route);
                cmd.Parameters.AddWithValue("@OwnerName", busCompany.OwnerName);
                cmd.Parameters.AddWithValue("@OwnerContactInformation", busCompany.OwnerContactInformation);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}