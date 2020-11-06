using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class OrderMockRepository : IOrderRepository
    {
        private static IProductRepository productRepository = new ProductMockRepository();

        private static List<OrderModel> orderModelList = new List<OrderModel>
        {
            new OrderModel
            {
                Id = 1,
                Client = new ClientModel
                {
                    Id = 1,
                    Name = "Tomasz Test",
                    Tim = "622229512",
                    Address = new AddressModel
                    {
                        StreetName = "Testowa 1",
                        City = "Bydgoszcz",
                        PostalCode = "85112"
                    }
                },
                Products = new List<ProductModel>
                {
                    productRepository.Get(1),
                    productRepository.Get(3),
                },
                TotalPrice = 9999
            },
            new OrderModel
            {
                Id = 2,
                Client = new ClientModel
                {
                    Id = 1,
                    Name = "Tomasz Test",
                    Tim = "622229512",
                    Address = new AddressModel
                    {
                        StreetName = "Testowa 1",
                        City = "Bydgoszcz",
                        PostalCode = "85112"
                    }
                },
                Products = new List<ProductModel>
                {
                    productRepository.Get(2)
                },
                TotalPrice = 9999
            }
        };

        public IEnumerable<OrderModel> GetAllOrders()
        {
            return orderModelList;
        }

        public IEnumerable<OrderModel> GetClientOrders(int clientId)
        {
            return orderModelList.Where(x => x.Client.Id == clientId);
        }

        public AddOrderModel AddOrder(AddOrderModel addOrderModel)
        {
            var orderModel = CreateOrderModel(addOrderModel);
            orderModelList.Add(orderModel);
            return addOrderModel;
        }

        private OrderModel CreateOrderModel(AddOrderModel addOrderModel)
        {
            var orderModel = new OrderModel
            {
                Id = GenerateOrderId(),
                Client = addOrderModel.Client,
                Products = addOrderModel.Products,
                TotalPrice = GetTotalPrice(addOrderModel.Products)
            };
            return orderModel;
        }

        private int GenerateOrderId()
        {
            return orderModelList.Max(x => x.Id) + 1;
        }

        private double GetTotalPrice(List<ProductModel> products)
        {
            var url = @"http://localhost:52833/api/OrdersTotalPrice";
            var contentJson = JsonConvert.SerializeObject(products);
            var buffer = System.Text.Encoding.UTF8.GetBytes(contentJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                var res = client.PostAsync(url, byteContent).GetAwaiter().GetResult();
                if (res.IsSuccessStatusCode)
                {
                    var resultString = res.Content.ReadAsStringAsync().Result;
                    return Convert.ToDouble(resultString, CultureInfo.InvariantCulture);
                }
                else
                {
                    throw new Exception("Error occured during getting total price of products.");
                }
            }            
        }
    }
}
