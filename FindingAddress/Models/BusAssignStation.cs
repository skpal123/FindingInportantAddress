using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FindingAddress.Models
{
    public class BusAssignStation
    {
        public string Id { set; get; }
        [Required]
        [Display(Name="Bus Name")]
        public string BusId { set; get; }
        [Required]
        [Display(Name="Source Name")]
        public string SourceId { set; get; }
        [Required]
        [Display(Name = "Destination Name")]
        public string DestinationId { set; get; }
        [Required]
        [Display(Name = "Fare")]
        public int Fare { set; get; }
    }
}