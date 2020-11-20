using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotalPriceApi.Models
{
    public class AddressModel
    {
        public string StreetName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Wrong lenght of postal code(5 digits required).",MinimumLength =5)]
        public string PostalCode { get; set; }
    }
}
