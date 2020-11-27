using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTestApp.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public AddressModel Address { get; set; }

        public string Tim { get; set; }
    }
}
