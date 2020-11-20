using ClientService.Models;
using ClientService.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientService
{
    public class ClientService : IClientService
    {

        public List<PurchasedProductInfo> GetClientPurchasedProducts(ClientInfoRequest clientInfoRequest)
        {
            var url = $@"http://localhost:51790/api/order/?{clientInfoRequest.ClientId}";

            using (HttpClient client = new HttpClient())
            {
                var jsonResult = client.GetStringAsync(url).GetAwaiter().GetResult();
                var clientOrderList = JsonConvert.DeserializeObject<List<OrderModel>>(jsonResult);

                var purchasedProductInfoList = ClientUtil.GetPurchasedProductInfoListBasingAtClientOrderList(clientOrderList);
                return purchasedProductInfoList;
            }            
        }
    }
}
