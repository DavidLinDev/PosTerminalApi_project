using System;
using System.Threading.Tasks;
using CoreLayer.Repositories;

namespace CoreLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        Task<int> CommitAsync();
    }
}
