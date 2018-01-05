using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class HospitalServiceAllocation
    {
        public string Id { set; get; }
        public string DivisionId { set; get; }
        public string DistrictId { set; get; }
        public string ThanaId { set; get; }
        public string HospitalId { set; get; }
        public string ServiceId { set; get; }
        public double EstimatedPrice { set; get; }
    }
}