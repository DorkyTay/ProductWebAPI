using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebAPI.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int productID { get; set; }

        public string productName { get; set; }

        public string serving { get; set; }

        public string package { get; set; }

        public string prices { get; set; }

        public string qty { get; set; }

    }
}