using CleanArchitectureTemplate.Application.Contracts.Persistence;
using Moq;

namespace CleanArchitectureTemplate.UnitTests.Mocks
{
    public static class MockRepositories
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            return null;
        }

        public static Mock<IProductRepository> GetProductRepository()
        {
            return null;
        }
    }
}
