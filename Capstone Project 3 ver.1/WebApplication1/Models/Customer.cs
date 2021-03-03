using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required] // validation is in the model
        public string customerName { get; set; }
        [Required]
        public string address { get; set; }
        public List<Product> products { get; set; }
    }
}
