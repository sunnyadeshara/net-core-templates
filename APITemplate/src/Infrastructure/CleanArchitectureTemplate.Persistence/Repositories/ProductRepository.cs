using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Domain;

namespace CleanArchitectureTemplate.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly CleanArchitectureTemplateDbContext _dbContext;

        public ProductRepository(CleanArchitectureTemplateDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
