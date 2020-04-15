using System.Collections.Generic;
using System.Threading.Tasks;
using CoreLayer;
using CoreLayer.Models;
using CoreLayer.Services;

namespace ServiceLayer
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(Order newOrder)
        {
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.CommitAsync();
            return newOrder;
        }

        public async Task DeleteOrder(Order order)
        {
            _unitOfWork.Orders.Remove(order);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetAllWithOrder()
        {
            return await _unitOfWork.Orders
                .GetAllWithOrdersAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _unitOfWork.Orders
                .GetWithOrdersByIdAsync(id);
        }
        public async Task UpdateOrder(Order orderToBeUpdated, Order order)
        {
            orderToBeUpdated.OrderedProducts = order.OrderedProducts;
            orderToBeUpdated.Amount = order.Amount;
            orderToBeUpdated.Date = order.Date;
            await _unitOfWork.CommitAsync();
        }
    }
}
