using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FindingAddress.Models
{
    public class District
    {
        
        public string Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Description { set; get; }
        [Required]
        public string DivisionName { set; get; }
    }
}