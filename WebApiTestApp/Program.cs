using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using WebApiTestApp.Models;

namespace WebApiTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var accessToken = GetToken(new LoginModel() { Login = "Tomasz", Password = "secret" });

            var clientOrders = GetClientPurchasedProducts(1, accessToken.Token);
        }

        public static AccessToken GetToken(LoginModel loginModel)
        {
            var url = $@"http://localhost:51790/api/auth/token";

            var contentJson = JsonConvert.SerializeObject(loginModel);
            var buffer = System.Text.Encoding.UTF8.GetBytes(contentJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                var res = client.PostAsync(url, byteContent).GetAwaiter().GetResult();
                if (res.IsSuccessStatusCode)
                {
                    //var responseObject = res.Content.ReadAsStringAsync<AccessToken>().GetAwaiter.G;
                    var resultString = res.Content.ReadAsStringAsync().Result;
                    var accessToken = JsonConvert.DeserializeObject<AccessToken>(resultString);
                    return accessToken;
                }
                else
                {
                    throw new Exception("Error occured during getting access token");
                }
            }
        }

        public static List<OrderModel> GetClientPurchasedProducts(int clientId, string tokenKey)
        {
            var url = $@"http://localhost:51790/api/order/?{clientId}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
                var jsonResult = client.GetStringAsync(url).GetAwaiter().GetResult();
                var clientOrderList = JsonConvert.DeserializeObject<List<OrderModel>>(jsonResult);

                return clientOrderList;
            }
        }
    }
}
