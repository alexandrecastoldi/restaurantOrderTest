using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Domain.Entities;

namespace RestaurantOrder.Infra.Context
{
    public class RestaurantOrderContext : DbContext
    {
        public RestaurantOrderContext(DbContextOptions<RestaurantOrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

    }
}
