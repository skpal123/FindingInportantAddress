using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class TravelHotel
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string DivisionId { set; get; }
        public string DistrictId { set; get; }
        public string ThanaId { set; get; }
        public string Description { set; get; }
        public decimal EstimatedPrice { set; get; }
        public string TourSpotId { set; get; }
        public string HotelWebsitesUrl { set; get; }
        public string locationId { set; get; }
        public string Email { set; get; }
        public DateTime PostedDate { set; get; }
        public string Address { set; get; }
        
    }
}