using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Models
{
    public class ClientModel
    {
        public int Id { get;set; }

        public string Name { get; set; }


        public AddressModel Address { get; set; }

        public string Tim { get; set; }
    }
}
