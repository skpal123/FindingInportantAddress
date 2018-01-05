using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FindingAddress.Models
{
    public class Doctor
    {
        public  string Id {set;get;}
        [Required]
        public  string Name {set;get;}
        [Required]
        public string Gender { set; get; }
        [Required]
        public  string imagePath {set;get;}
        [Required]
        [Display(Name="Hospital Name")]
        public string HospitalId { set; get; }
        [Required]
        [Display(Name="Doctor Type Name")]
        public string DoctorTypeId { set; get; }
        [Required]
        [Display(Name = "City Name")]
        public string CityId { set; get; }
        [Required]
        [Display(Name="Division Name")]
        public string DivisionId { set; get; }
        [Required]
        [Display(Name="District Name")]
        public string DistrictId { set; get; }
        [Required]
        [Display(Name="Thana Name")]
        public string ThanaId { set; get; }
        [Required]
        [Display(Name="Location")]
        public string LocationId { set; get; }
        [Required]
        [Display(Name = "First Time Visit")]
        public  double VisitAmountFirstTime {set;get;}
        [Display(Name = "Second Time Visit")]
        public  double VisitAmountSecondTime {set;get;}
        [Display(Name = "Personal Email")]
        public  string PersonalEmailaddress {set;get;}
        [Display(Name = "Personal Website")]
        public  string PersonalWebsite {set;get;}
        [Display(Name = "Personal Chamber")]
        public  string PersonalChamber {set;get;}
        [Required]
        [Display(Name = "Contact Number")]
        public  string ContactNumber {set;get;}
        [Display(Name = "Serial Number")]
        public  string SerialNumber {set;get;}
        [Display(Name = "Visiting Time")]
        public  string HealthCareTime {set;get;}
        [Required]
        public  string Education {set;get;}
        public  string Description {set;get;}
        [Required]
        public  string Address {set;get;}
    }
}