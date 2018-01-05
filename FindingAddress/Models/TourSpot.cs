using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class TourSpot
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string CategoryId { set; get; }
        public string DivisionId { set; get; }
        public string DistrictId { set; get; }
        public string CityId { set; get; }
        public string ThanaId { set; get; }
        public string LocationId { set; get; }
        public string Description { set; get; }
        public string Address { set; get; }
    }
}