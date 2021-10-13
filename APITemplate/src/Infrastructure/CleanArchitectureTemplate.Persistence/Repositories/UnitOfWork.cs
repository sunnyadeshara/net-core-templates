using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Domain;
using System;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CleanArchitectureTemplateDbContext _context;
        private IGenericRepository<Category> _categoryRepository;
        private IGenericRepository<Product> _productRepository;

        public UnitOfWork(CleanArchitectureTemplateDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Category> CategoryRepository => _categoryRepository ?? new GenericRepository<Category>(_context);

        public IGenericRepository<Product> ProductRepository => _productRepository ?? new GenericRepository<Product>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
