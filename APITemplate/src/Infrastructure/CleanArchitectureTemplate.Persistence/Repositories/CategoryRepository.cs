using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Domain;

namespace CleanArchitectureTemplate.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly CleanArchitectureTemplateDbContext _dbContext;

        public CategoryRepository(CleanArchitectureTemplateDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
