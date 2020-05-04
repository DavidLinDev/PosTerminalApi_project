using System.Collections.Generic;
using System.Threading.Tasks;
using CoreLayer;
using CoreLayer.Models;
using CoreLayer.Services;

namespace ServiceLayer
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Product>> GetAllWithProduct()
        {
            return await _unitOfWork.Products
               .GetAllWithProductsAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Products
                            .GetWithProductsByIdAsync(id);
        }
        public async Task<Product> GetProductByCode(string codeName)
        {
            return await _unitOfWork.Products
                            .GetWithProductsByCodeAsync(codeName);
        }
        public async Task<Product> CreateProduct(Product newProduct)
        {
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.CommitAsync();
            return newProduct;
        }
        public async Task UpdateProduct(Product productToBeUpdated, Product product)
        {
            if (product.Id != 0)
            productToBeUpdated.Id = product.Id;
            if (product.CodeName != null)
            productToBeUpdated.CodeName = product.CodeName;
            if (product.UnitPrice != 0)
            productToBeUpdated.UnitPrice = product.UnitPrice;
            if (product.DiscountQtyBase != 0)
            productToBeUpdated.DiscountQtyBase = product.DiscountQtyBase;
            if (product.UnitDiscount != 0)
            productToBeUpdated.UnitDiscount = product.UnitDiscount;
            if (product.FarmProducer != null)
            productToBeUpdated.FarmProducer = product.FarmProducer;
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteProduct(Product product)
        {
            _unitOfWork.Products.Remove(product);
            await _unitOfWork.CommitAsync();
        }
    }
}
