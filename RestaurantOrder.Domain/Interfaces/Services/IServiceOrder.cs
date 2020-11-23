using RestaurantOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder.Domain.Interfaces.Services
{
    public interface IServiceOrder
    {
        Task<Order> CreateOrder(string orderInput);
        Task<Order> Update(int id, Order order);
        void Delete(int id);
        Task<Order> RecoverById(int id);
        Task<IEnumerable<Order>> RecoverAllOrders();
    }
}
