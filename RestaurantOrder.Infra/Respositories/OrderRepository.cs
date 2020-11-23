using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Entities;
using RestaurantOrder.Domain.Interfaces.Repositories;
using RestaurantOrder.Infra.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantOrder.Infra.Respositories
{
    public class OrderRepository : BaseRepository, IRepositoryOrder
    {
        public OrderRepository(RestaurantOrderContext context) : base(context)
        {
        }
        public async Task<IList<Order>> GetAllOrders() => await _context.Orders.OrderBy(o => o.Id).ToArrayAsync();

        public async Task<Order> GetById(int orderId) =>
            await _context.Orders
                .Where(o => o.Id == orderId)
                .FirstOrDefaultAsync();

        public void Add(Order order) => base.Add(order);

        public void Update(Order order) => base.Update(order);

        public void Delete(Order order) => base.Delete(order);
    }
}
