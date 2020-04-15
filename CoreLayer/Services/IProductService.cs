using System.Collections.Generic;
using System.Threading.Tasks;
using CoreLayer.Models;

namespace CoreLayer.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllWithProduct();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByCode(string codeName);
        Task<Product> CreateProduct(Product newProduct);
        Task UpdateProduct(Product productToBeUpdated, Product product);
        Task DeleteProduct(Product product);
    }
}
