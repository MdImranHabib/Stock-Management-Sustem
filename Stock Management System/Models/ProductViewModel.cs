using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Management_System.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Item { get; set; }

        public string Category { get; set; }

        public string Company { get; set; }

        public double Quantity { get; set; }

        public double ReorderLevel { get; set; }
    }
}