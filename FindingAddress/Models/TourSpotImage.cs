using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class TourSpotImage
    {
        public string Id { set; get; }
        public string ImagePath { set; get; }
        public string PhotoCreditName { set; get; }
        public float TourSpotId { set; get; }
        public string UploadDate { set; get; }
    }
}