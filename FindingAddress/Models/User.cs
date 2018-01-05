using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class User
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string UserName { set; get; }
        public float Email { set; get; }
        public string Password { set; get; }
        public string Confirmpassword { set; get; }
    }
}