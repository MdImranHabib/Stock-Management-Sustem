using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stock_Management_System.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public double ReorderLevel { get; set; }

        [Required]
        public double Quantity { get; set; }
    }
}