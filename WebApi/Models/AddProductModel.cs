using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class AddProductModel
    {
        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be bigger than zero.")]
        public double Price { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string IBAN { get; set; }
    }
}
