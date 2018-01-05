using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindingAddress.Models
{
    public class ResturantMenuAllocation
    {
        public string Id { set; get; }
        public string ResturantId { set; get; }
        public string MenuItemId { set; get; }

        public decimal Price { set; get; }

    }
}