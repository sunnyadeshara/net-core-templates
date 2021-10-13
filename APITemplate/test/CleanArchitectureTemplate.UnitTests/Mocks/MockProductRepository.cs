using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Domain;
using Moq;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.UnitTests.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Product 1 Description"
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Product 2 Description"
                }
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(products);

            mockRepo.Setup(x => x.Add(It.IsAny<Product>())).ReturnsAsync((Product product) => 
            {
                products.Add(product);
                return product;
            });

            return mockRepo;
        }
    }
}
