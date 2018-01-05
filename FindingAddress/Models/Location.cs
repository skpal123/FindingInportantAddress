using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class Location
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string CityName { set; get; }
    }
}