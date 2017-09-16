using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
namespace FindingAddress.Connection
{
    public class ConnectionString
    {
       public static string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
    }
}