using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreLayer.Models;
using CoreLayer.Repositories;

namespace DataLayer.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private TerminalDbContext TerminalDbContext
        {
            get { return Context as TerminalDbContext; }
        }
        public ProductRepository(TerminalDbContext context)
           : base(context)
        { }
        public async Task<IEnumerable<Product>> GetAllWithProductsAsync()
        {
            return await TerminalDbContext.Products
                .ToListAsync();
        }
        public async Task<Product> GetWithProductsByIdAsync(int id)
        {
            return await TerminalDbContext.Products
               .SingleOrDefaultAsync(m => m.Id == id);
        }
        public async Task<Product> GetWithProductsByCodeAsync(string codeName)
        {
            return await TerminalDbContext.Products
                          .SingleOrDefaultAsync(m => m.CodeName == codeName);
        }
    }
}
