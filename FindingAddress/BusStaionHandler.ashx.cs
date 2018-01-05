using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using FindingAddress.DataAccessLayer;

namespace FindingAddress
{
    /// <summary>
    /// Summary description for BusStaionHandler
    /// </summary>
    public class BusStaionHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string term = context.Request["term"]??"";
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
            List<BusStation> busStationList = new List<BusStation>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spgetNameFromStationByName", con);
                cmd.Parameters.AddWithValue("@term", term);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BusStation busStation=new BusStation();
                    busStation.Name = rdr["term"].ToString();
                    busStationList.Add(busStation);
                }
            }
            JavaScriptSerializer js=new JavaScriptSerializer();
            context.Response.Write(js.Serialize(busStationList));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}