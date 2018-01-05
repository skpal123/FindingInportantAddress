using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class Flat
    {
        public string Id { set; get; }
        public string BuildingName { set; get; }
        public string imagePath { set; get; }
        public string ContactNumber { set; get; }
        public string DivisionId { set; get; }
        public string DistrictId { set; get; }
        public string ThanaId { set; get; }
        public string CityId { set; get; }
        public string LocationId { set; get; }
        public string Address { set; get; }
        public string Description { set; get; }
        public float EstimatedFlatFare { set; get; }
        public float Advance { set; get; }
        public DateTime PostingDate { set; get; }
        public DateTime PostedDate { set; get; }
        public string AvailableMonth { set; get; }
        public DateTime DeadlineDate { set; get; }
    }
}