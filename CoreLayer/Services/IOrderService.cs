using System.Collections.Generic;
using System.Threading.Tasks;
using CoreLayer.Models;

namespace CoreLayer.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllWithOrder();
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order newOrder);
        Task UpdateOrder(Order orderToBeUpdated, Order order);
        Task DeleteOrder(Order order);
    }
}
