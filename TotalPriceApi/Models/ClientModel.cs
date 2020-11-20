using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TotalPriceApi.Models
{
    public class ClientModel
    {
        public int Id { get;set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public AddressModel Address { get; set; }

        [Required]
        public string Tim { get; set; }
    }
}
