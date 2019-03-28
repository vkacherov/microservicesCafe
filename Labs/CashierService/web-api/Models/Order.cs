using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CashierServices.Models
{
    public class Order
    {
        public Guid orderid { get; set; } 
        [Required]
        public string name { get; set; }
        [Required]
        public string phone { get; set; }
        public string status { get; set; }
        public DateTime orderdate {get; set;}
    }
}