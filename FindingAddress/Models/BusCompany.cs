using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FindingAddress.Models
{
    public class BusCompany
    {
        public string Id { set; get; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { set; get; }
        [Required]
        [Display(Name="Bus Name")]
        public string BusName { set; get; }
        [Required]
        public string Route { set; get; }
        [Required]
        [Display(Name = "Owner Name")]
        public string OwnerName { set; get; }
        [Required]
        [Display(Name = "Owner Contact Information")]
        public string OwnerContactInformation { set; get; }
    }
}