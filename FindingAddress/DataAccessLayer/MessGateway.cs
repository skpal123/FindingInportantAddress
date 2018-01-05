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
    public class MessGateway
    {
        string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
        public int saveMess(Mess mess)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoMess", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name",mess.BuildingName);
                cmd.Parameters.AddWithValue("@imagePath", mess.imagePath);
                cmd.Parameters.AddWithValue("@ContactNumber", mess.ContactNumber);
                cmd.Parameters.AddWithValue("@DistrictId",mess.DistrictId);
                cmd.Parameters.AddWithValue("@ThanaId", mess.ThanaId);
                cmd.Parameters.AddWithValue("@DivisionId", mess.DivisionId);
                cmd.Parameters.AddWithValue("@ManagerName", mess.ManagerName);
                cmd.Parameters.AddWithValue("@AvailableSit", mess.LocationId);
                cmd.Parameters.AddWithValue("@TotalSit", mess.TotalSit);
                cmd.Parameters.AddWithValue("@Advance", mess.Advance);
                cmd.Parameters.AddWithValue("@EstimatedSitFare", mess.EstimatedSitFare);
                cmd.Parameters.AddWithValue("@CityId", mess.CityId);
                cmd.Parameters.AddWithValue("@LocationId", mess.LocationId);
                cmd.Parameters.AddWithValue("@Address", mess.Address);
                cmd.Parameters.AddWithValue("@Description", mess.Description);
                cmd.Parameters.AddWithValue("@PostedDate", mess.PostingDate);
                cmd.Parameters.AddWithValue("@DeadlineDate", mess.DeadlineDate);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Mess> getAllMess()
        {
           
                using (SqlConnection con = new SqlConnection(cs))
                {
                    List<Mess> messes = new List<Mess>();
                    SqlCommand cmd = new SqlCommand("spGetAllMessDetaisByIdOrWithOutId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Mess mess = new Mess();
                        mess.Id = rdr["Id"].ToString();
                        mess.BuildingName = rdr["Name"].ToString();
                        mess.ContactNumber = rdr["ContactNumber"].ToString();
                        mess.imagePath = rdr["imagePath"].ToString();
                        mess.DivisionId = rdr["DivisionId"].ToString();
                        mess.DistrictId = rdr["DistrictId"].ToString();
                        mess.ThanaId = rdr["ThanaId"].ToString();
                        mess.LocationId = rdr["LocationId"].ToString();
                        mess.Address = rdr["Address"].ToString();
                        mess.ManagerName = rdr["ManagerName"].ToString();
                        mess.Description = rdr["Description"].ToString();
                        mess.TotalSit = Convert.ToInt32(rdr["TotalSit"].ToString());
                        mess.AvailableSit = Convert.ToInt32(rdr["AvailableSit"].ToString());
                        mess.EstimatedSitFare = Convert.ToInt32(rdr["EstimatedSitFare"]);
                        mess.Advance = Convert.ToInt32(rdr["Advance"].ToString());
                        mess.DeadlineDate = Convert.ToDateTime(rdr["DeadlineDate"].ToString());
                        messes.Add(mess);
                    }
                    return messes;
                }
            
        }
        public Mess getMessById(int Id)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                Mess mess = new Mess();
                SqlCommand cmd = new SqlCommand("spGetAllMessDetaisByIdOrWithOutId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    mess.Id = rdr["Id"].ToString();
                    mess.BuildingName = rdr["Name"].ToString();
                    mess.ContactNumber = rdr["ContactNumber"].ToString();
                    mess.imagePath = rdr["imagePath"].ToString();
                    mess.DivisionId = rdr["DivisionId"].ToString();
                    mess.DistrictId = rdr["DistrictId"].ToString();
                    mess.ThanaId = rdr["ThanaId"].ToString();
                    mess.LocationId = rdr["LocationId"].ToString();
                    mess.Address = rdr["Address"].ToString();
                    mess.ManagerName = rdr["ManagerName"].ToString();
                    mess.Description = rdr["Description"].ToString();
                    mess.TotalSit = Convert.ToInt32(rdr["TotalSit"].ToString());
                    mess.AvailableSit = Convert.ToInt32(rdr["AvailableSit"].ToString());
                    mess.EstimatedSitFare = Convert.ToInt32(rdr["EstimatedSitFare"]);
                    mess.Advance = Convert.ToInt32(rdr["Advance"].ToString());
                    mess.DeadlineDate = Convert.ToDateTime(rdr["DeadlineDate"].ToString());
                }
                return mess;
            }

        }
        public int updateMessById(Mess mess)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertIntoMess", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", mess.Id);
                cmd.Parameters.AddWithValue("@Name", mess.BuildingName);
                cmd.Parameters.AddWithValue("@imagePath", mess.imagePath);
                cmd.Parameters.AddWithValue("@ContactNumber", mess.ContactNumber);
                cmd.Parameters.AddWithValue("@DistrictId", mess.DistrictId);
                cmd.Parameters.AddWithValue("@DivisionId", mess.DivisionId);
                cmd.Parameters.AddWithValue("@ManagerName", mess.ManagerName);
                cmd.Parameters.AddWithValue("@AvailableSit", mess.LocationId);
                cmd.Parameters.AddWithValue("@TotalSit", mess.TotalSit);
                cmd.Parameters.AddWithValue("@Advance", mess.Address);
                cmd.Parameters.AddWithValue("@EstimatedSitFare", mess.EstimatedSitFare);
                cmd.Parameters.AddWithValue("@CityId", mess.CityId);
                cmd.Parameters.AddWithValue("@LocationId", mess.LocationId);
                cmd.Parameters.AddWithValue("@Address", mess.Address);
                cmd.Parameters.AddWithValue("@Description", mess.Description);
                cmd.Parameters.AddWithValue("@PostedDate", mess.PostingDate);
                cmd.Parameters.AddWithValue("@DeadlineDate", mess.DeadlineDate);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public List<Mess> getAllmessByCityId(int CityId)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Mess> messes = new List<Mess>();
                
                SqlCommand cmd = new SqlCommand("spGetAllMessDetaisByCityId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CityId", CityId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Mess mess=new Mess();
                    mess.BuildingName = rdr["Name"].ToString();
                    mess.ContactNumber = rdr["ContactNumber"].ToString();
                    mess.imagePath = rdr["imagePath"].ToString();
                    mess.DivisionId = rdr["DivisionId"].ToString();
                    mess.DistrictId = rdr["DistrictId"].ToString();
                    mess.ThanaId = rdr["ThanaId"].ToString();
                    mess.LocationId = rdr["LocationId"].ToString();
                    mess.Address = rdr["Address"].ToString();
                    mess.ManagerName = rdr["ManagerName"].ToString();
                    mess.Description = rdr["Description"].ToString();
                    mess.TotalSit = Convert.ToInt32(rdr["TotalSit"].ToString());
                    mess.AvailableSit = Convert.ToInt32(rdr["AvailableSit"].ToString());
                    mess.EstimatedSitFare = Convert.ToInt32(rdr["EstimatedSitFare"]);
                    mess.Advance = Convert.ToInt32(rdr["Advance"].ToString());
                    //mess.AvailableMonth = rdr["AvailableMonth"].ToString();
                    mess.DeadlineDate = Convert.ToDateTime(rdr["DeadlineDate"].ToString());
                    messes.Add(mess);
                }
                return messes;
            }

        }

        public List<Mess> getAllmessByThanaId(int ThanaId)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Mess> messes = new List<Mess>();
                SqlCommand cmd = new SqlCommand("spGetAllMessDetaisByThanaId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThanaId", ThanaId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Mess mess = new Mess();
                    mess.BuildingName = rdr["Name"].ToString();
                    mess.ContactNumber = rdr["ContactNumber"].ToString();
                    mess.imagePath = rdr["imagePath"].ToString();
                    mess.DivisionId = rdr["DivisionId"].ToString();
                    mess.DistrictId = rdr["DistrictId"].ToString();
                    mess.ThanaId = rdr["ThanaId"].ToString();
                    mess.LocationId = rdr["LocationId"].ToString();
                    mess.Address = rdr["Address"].ToString();
                    mess.ManagerName = rdr["ManagerName"].ToString();
                    mess.Description = rdr["Description"].ToString();
                    mess.TotalSit = Convert.ToInt32(rdr["TotalSit"].ToString());
                    mess.AvailableSit = Convert.ToInt32(rdr["AvailableSit"].ToString());
                    mess.EstimatedSitFare = Convert.ToInt32(rdr["EstimatedSitFare"]);
                    mess.Advance = Convert.ToInt32(rdr["Advance"].ToString());
                    mess.DeadlineDate = Convert.ToDateTime(rdr["DeadlineDate"].ToString());
                    messes.Add(mess);
                }
                return messes;
            }
        }

        public List<Mess> getAllmessByLocationId(int LocationId)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Mess> messes = new List<Mess>();
                SqlCommand cmd = new SqlCommand("spGetAllMessDetaisByLocationId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LocationId", LocationId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Mess mess = new Mess();
                    mess.BuildingName = rdr["Name"].ToString();
                    mess.ContactNumber = rdr["ContactNumber"].ToString();
                    mess.imagePath = rdr["imagePath"].ToString();
                    mess.DivisionId = rdr["DivisionId"].ToString();
                    mess.DistrictId = rdr["DistrictId"].ToString();
                    mess.ThanaId = rdr["ThanaId"].ToString();
                    mess.LocationId = rdr["LocationId"].ToString();
                    mess.Address = rdr["Address"].ToString();
                    mess.ManagerName = rdr["ManagerName"].ToString();
                    mess.Description = rdr["Description"].ToString();
                    mess.TotalSit = Convert.ToInt32(rdr["TotalSit"].ToString());
                    mess.AvailableSit = Convert.ToInt32(rdr["AvailableSit"].ToString());
                    mess.EstimatedSitFare = Convert.ToInt32(rdr["EstimatedSitFare"]);
                    mess.Advance = Convert.ToInt32(rdr["Advance"].ToString());
                    mess.DeadlineDate = Convert.ToDateTime(rdr["DeadlineDate"].ToString());
                    messes.Add(mess);
                }
                return messes;
            }

        }
        public List<Mess> getAllmessByStartAndEnddate(DateTime? startDate,DateTime? endDate)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Mess> messes = new List<Mess>();
                SqlCommand cmd = new SqlCommand("spGetAllmessByDate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", endDate);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Mess mess = new Mess();
                    mess.BuildingName = rdr["Name"].ToString();
                    mess.ContactNumber = rdr["ContactNumber"].ToString();
                    mess.imagePath = rdr["imagePath"].ToString();
                    mess.DivisionId = rdr["DivisionId"].ToString();
                    mess.DistrictId = rdr["DistrictId"].ToString();
                    mess.ThanaId = rdr["ThanaId"].ToString();
                    mess.LocationId = rdr["LocationId"].ToString();
                    mess.Address = rdr["Address"].ToString();
                    mess.ManagerName = rdr["ManagerName"].ToString();
                    mess.Description = rdr["Description"].ToString();
                    mess.TotalSit = Convert.ToInt32(rdr["TotalSit"].ToString());
                    mess.AvailableSit = Convert.ToInt32(rdr["AvailableSit"].ToString());
                    mess.EstimatedSitFare = Convert.ToInt32(rdr["EstimatedSitFare"]);
                    mess.Advance = Convert.ToInt32(rdr["Advance"].ToString());
                    mess.DeadlineDate = Convert.ToDateTime(rdr["DeadlineDate"].ToString());
                    messes.Add(mess);
                }
                return messes;
            }

        }
    }
}