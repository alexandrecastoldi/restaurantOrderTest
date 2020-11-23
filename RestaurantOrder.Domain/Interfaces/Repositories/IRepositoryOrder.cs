using RestaurantOrder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrder.Domain.Interfaces.Repositories
{
    public interface IRepositoryOrder
    {
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        Task<Order> GetById(int orderId);
        Task<IList<Order>> GetAllOrders();

    }
}
