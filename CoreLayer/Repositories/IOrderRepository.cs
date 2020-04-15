using System.Collections.Generic;
using System.Threading.Tasks;
using CoreLayer.Models;

namespace CoreLayer.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllWithOrdersAsync();
        Task<Order> GetWithOrdersByIdAsync(int id);
    }
}