using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreLayer.Models;
using CoreLayer.Repositories;

namespace DataLayer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(TerminalDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Order>> GetAllWithOrdersAsync()
        {
            return await TerminalDbContext.Orders
                .ToListAsync();
        }
        public async Task<Order> GetWithOrdersByIdAsync(int id)
        {
            return await TerminalDbContext.Orders
                .SingleOrDefaultAsync(m => m.Id == id); 
        }
                                
        private TerminalDbContext TerminalDbContext
        {
            get { return Context as TerminalDbContext; }
        }
    }
}
