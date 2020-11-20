using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotalPriceApi.Models
{
    public class AddOrderModel
    {
        [Required]
        public ClientModel Client { get; set; }
        [Required]
        public List<ProductModel> Products { get; set; }
    }
}
