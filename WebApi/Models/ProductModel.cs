using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal zero.")]
        public double Price { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string IBAN { get; set; }

    }
}
