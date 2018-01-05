using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class Lawyer
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public string imagePath { set; get; }
        public string CourtId { set; get; }
        public string LawyerTypeId { set; get; }
        public string DivisionId { set; get; }
        public string CityId { set; get; }
        public string DistrictId { set; get; }
        public string ThanaId { set; get; }
        public string LocationId { set; get; }
        public Double EstimatedFee { set; get; }
        public string PersonalEmailaddress { set; get; }
        public string PersonalWebsite { set; get; }
        public string PersonalChamber { set; get; }
        public string ContactNumber { set; get; }        
        public string ChamberTime { set; get; }
        public string Education { set; get; }
        public string Description { set; get; }
        public string Address { set; get; }
    }
}