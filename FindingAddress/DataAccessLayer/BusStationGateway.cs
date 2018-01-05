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
    public class BusStationGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveBusStation(BusStation busStation)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoBusStation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", busStation.Name);
                cmd.Parameters.AddWithValue("@Location", busStation.Location);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<BusStation> getAllBusstation()
        {
            List<BusStation> BusStationList = new List<BusStation>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllBusStation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BusStation busStation = new BusStation();
                    busStation.Id = rdr["Id"].ToString();
                    busStation.Name = rdr["Name"].ToString();
                    busStation.Location = rdr["Location"].ToString();
                    BusStationList.Add(busStation);
                }
            }
            return BusStationList;
        }
        public BusStation getBusstationById( int Id)
        {
            BusStation busStation = new BusStation();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllBusStation", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    busStation.Id = rdr["Id"].ToString();
                    busStation.Name = rdr["Name"].ToString();
                    busStation.Location = rdr["Location"].ToString();
                }
            }
            return busStation;
        }
        public int updateBusstationById(BusStation busStation)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateBusStationById", con);
                cmd.Parameters.AddWithValue("Id", busStation.Id);
                cmd.Parameters.AddWithValue("@Name", busStation.Name);
                cmd.Parameters.AddWithValue("@Location", busStation.Location);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        
        public List<BusAssignStation> getBusAssignStation()
        {
            List<BusAssignStation> BusAssignStations = new List<BusAssignStation>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDataFromFareAllocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BusAssignStation busAssignStation = new BusAssignStation();
                    busAssignStation.Id = rdr["Id"].ToString();
                    busAssignStation.BusId = rdr["BusName"].ToString();
                    busAssignStation.SourceId = rdr["SourceName"].ToString();
                    busAssignStation.DestinationId = getStationNameById(Convert.ToInt32(rdr["DestinationId"].ToString()));
                    busAssignStation.Fare =Convert.ToInt32( rdr["Fare"].ToString());
                    BusAssignStations.Add(busAssignStation);
                }
            }
            return BusAssignStations;
        }

        public string getStationNameById(int Id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select Name from tblBusStaion where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                return cmd.ExecuteScalar().ToString();
            }
        }
        public int saveBusAssignStation(BusAssignStation busAssignStation)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoBusFareallocation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BusId", busAssignStation.BusId);
                cmd.Parameters.AddWithValue("@SourceId", busAssignStation.SourceId);
                cmd.Parameters.AddWithValue("@DestinationId", busAssignStation.DestinationId);
                cmd.Parameters.AddWithValue("@Fare", busAssignStation.Fare);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
         public List<string> getBusstationNameByName( string Name)
        {
            List<string> stringList = new List<string>();
            using (SqlConnection con = new SqlConnection(cs))
            {
  
                SqlCommand cmd = new SqlCommand("spgetNameFromStationByName", con);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string StaionName = "";
                  StaionName= rdr["Name"].ToString();
                    stringList.Add(StaionName);
                   
                }
            }
            return stringList;
        }
         public List<BusAssignStation> getAllBusCompanyBySourceAndDestination(BusAssignStation busAssign)
         {
             List<BusAssignStation> BusAssignStations = new List<BusAssignStation>();
             using (SqlConnection con = new SqlConnection(cs))
             {
                 SqlCommand cmd = new SqlCommand("spGetAllDataFromFareAllocation", con);
                 cmd.Parameters.AddWithValue("@SourceName", busAssign.SourceId);
                 cmd.Parameters.AddWithValue("@DestinationName", busAssign.DestinationId);
                 cmd.CommandType = CommandType.StoredProcedure;
                 con.Open();
                 SqlDataReader rdr = cmd.ExecuteReader();
                 while (rdr.Read())
                 {
                     BusAssignStation busAssignStation = new BusAssignStation();
                     busAssignStation.Id = rdr["Id"].ToString();
                     busAssignStation.BusId = rdr["BusName"].ToString();
                     busAssignStation.SourceId = rdr["SourceName"].ToString();
                     busAssignStation.DestinationId = getStationNameById(Convert.ToInt32(rdr["DestinationId"].ToString()));
                     busAssignStation.Fare = Convert.ToInt32(rdr["Fare"].ToString());
                     BusAssignStations.Add(busAssignStation);
                 }
             }
             return BusAssignStations;
         }
    }
}