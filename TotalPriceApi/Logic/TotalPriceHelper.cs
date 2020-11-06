using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotalPriceApi.Models;

namespace TotalPriceApi.Logic
{
    public class TotalPriceHelper
    {
        public double CalculateTotalPrice(List<ProductModel> products)
        {
            double totalPrice = 0;
            if (!products.Any())
            {
                return totalPrice;
            }
            totalPrice = products.Sum(x => x.Price);
            bool discount = products.Count > 1;

            return discount ? totalPrice * 0.9 : totalPrice;        
        }
    }
}
