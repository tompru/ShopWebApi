using ClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.Utils
{
    public static class ClientUtil
    {
        public static List<PurchasedProductInfo> GetPurchasedProductInfoListBasingAtClientOrderList(List<OrderModel> orderModelList)
        {
            var purchasedProductList = new List<PurchasedProductInfo>();

            foreach(var order in orderModelList)
            {
                AddOrderedProductsToPurchasedProductList(order.Products, purchasedProductList);
            }

            return purchasedProductList;
        }

        private static void AddOrderedProductsToPurchasedProductList(List<ProductModel> orderProductList, List<PurchasedProductInfo> purchasedProductInfoList)
        {
            try
            {
                orderProductList.ForEach(product =>
                {
                    var purchasedProduct = purchasedProductInfoList.SingleOrDefault(p => p.ProductId == product.Id);
                    if (purchasedProduct != null)
                    {
                        purchasedProduct.PurchasedProductsQuantity++;
                    }
                    else
                    {
                        purchasedProductInfoList.Add(new PurchasedProductInfo { ProductId = product.Id, PurchasedProductsQuantity = 1 });
                    }
                }
                );
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occured while adding products to purchased product list {ex.Message}");
            }
        }
    }
}
