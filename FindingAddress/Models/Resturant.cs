using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class Resturant
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string DivisionId { set; get; }
        public string DistrictId { set; get; }
        public string ThanaId { set; get; }
        public string Description { set; get; }
        public string ImagePath { set; get; }
        public string ResturantWebsiteUrl { set; get; }
        public string locationId { set; get; }
        public string ResturantTypeId { set; get; }
        public DateTime PostedDate { set; get; }
        public string Address { set; get; }
    }
}