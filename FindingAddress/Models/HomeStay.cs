using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class HomeStay
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public float EstimatedPrice { set; get; }
        public string TourSpotId { set; get; }
        public string HotelWebsitesUrl { set; get; }
        public string location { set; get; }
        public string Email { set; get; }
        public string PostedDate { set; get; }
    }
}