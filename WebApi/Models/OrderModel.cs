using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class OrderModel
    {
        public int Id { get;set; }
        [Required]
        public ClientModel Client { get; set; }
        [Required]
        public List<ProductModel> Products { get; set; }
        [Required]
        public double TotalPrice { get; set; }
    }
}
