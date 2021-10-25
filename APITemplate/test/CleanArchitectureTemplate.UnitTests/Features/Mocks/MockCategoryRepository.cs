using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Domain;
using Moq;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.UnitTests.Features.Mocks
{
    public static class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Category 1",
                    Description = "Category 1 Description"
                },
                new Category
                {
                    Id = 2,
                    Name = "Category 2",
                    Description = "Category 2 Description"
                }
            };

            var mockRepo = new Mock<ICategoryRepository>();

            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(categories);

            mockRepo.Setup(x => x.Add(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                categories.Add(category);
                return category;
            });

            return mockRepo;
        }
    }
}