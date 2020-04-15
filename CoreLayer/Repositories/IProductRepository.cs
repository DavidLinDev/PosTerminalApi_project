using System.Collections.Generic;
using System.Threading.Tasks;
using CoreLayer.Models;

namespace CoreLayer.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllWithProductsAsync();
        Task<Product> GetWithProductsByIdAsync(int id);
        Task<Product> GetWithProductsByCodeAsync(string codeName);
    }
}
