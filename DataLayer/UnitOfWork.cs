using System.Threading.Tasks;
using CoreLayer;
using CoreLayer.Repositories;
using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TerminalDbContext _context;
        private ProductRepository _productRepository;
        private OrderRepository _orderRepository;

        public UnitOfWork(TerminalDbContext context)
        {
            this._context = context;
        }

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
