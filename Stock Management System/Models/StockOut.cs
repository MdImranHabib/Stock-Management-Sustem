using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stock_Management_System.Models
{
    public class StockOut
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime Date { get; set; }
    }
}