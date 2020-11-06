using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IOrderRepository
    {
        AddOrderModel AddOrder(AddOrderModel addOrderModel);
        IEnumerable<OrderModel> GetAllOrders();
        IEnumerable<OrderModel> GetClientOrders(int clientId);
    }
}