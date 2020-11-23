using Microsoft.EntityFrameworkCore;
using RestaurantOrder.Infra.Context;

namespace RestaurantOrder.Infra.Respositories
{
    public class BaseRepository
    {
        protected readonly RestaurantOrderContext _context;

        public BaseRepository(RestaurantOrderContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected virtual void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        protected virtual void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        protected virtual void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
