using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stock_Management_System.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}