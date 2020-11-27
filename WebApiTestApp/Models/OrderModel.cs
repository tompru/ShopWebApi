using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiTestApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public ClientModel Client { get; set; }

        public List<ProductModel> Products { get; set; }

        public double TotalPrice { get; set; }
    }
}
