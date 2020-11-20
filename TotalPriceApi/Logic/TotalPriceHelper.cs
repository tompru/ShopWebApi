using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotalPriceApi.Models;

namespace TotalPriceApi.Logic
{
    public class TotalPriceHelper
    {
        private readonly int clientId;
        private List<ClientService.PurchasedProductInfo> clientPurchasedProducts = new List<ClientService.PurchasedProductInfo>();

        public TotalPriceHelper(int clientId)
        {
            this.clientId = clientId;
            clientPurchasedProducts = GetClientPurchasedProductInfoList();
        }

        public double CalculateTotalPrice(List<ProductModel> products)
        {
            double totalPrice = 0;

            foreach(var product in products)
            {
                double discountMultiplier = GetDiscountMiltiplier(product.Id);
                totalPrice += product.Price * discountMultiplier;
            }

            return totalPrice;           
        }

        private List<ClientService.PurchasedProductInfo> GetClientPurchasedProductInfoList()
        {
            var clientServiceClient = new ClientService.ClientServiceClient();
            var clientInfoRequest = new ClientService.ClientInfoRequest { ClientId = clientId };
            return clientServiceClient.GetClientPurchasedProductsAsync(clientInfoRequest).GetAwaiter().GetResult().ToList();
        }

        private double GetDiscountMiltiplier(int productId)
        {
            return clientPurchasedProducts.Where(x => x.ProductId == productId).ToList().Count > 1 ? 0.9 : 0.98;
        }
    }
}
