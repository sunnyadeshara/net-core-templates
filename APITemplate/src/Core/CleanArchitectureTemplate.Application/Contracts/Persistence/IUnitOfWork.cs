using CleanArchitectureTemplate.Domain;
using System;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        Task Save();
    }
}
