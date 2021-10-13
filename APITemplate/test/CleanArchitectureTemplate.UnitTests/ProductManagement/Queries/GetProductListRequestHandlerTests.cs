using AutoMapper;
using CleanArchitectureTemplate.Application.AutoMapperProfiles;
using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.DTOs.Product;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Handlers.Queries;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Queries;
using CleanArchitectureTemplate.UnitTests.Mocks;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.ProductManagement.Queries
{
    public class GetProductListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockRepo;

        public GetProductListRequestHandlerTests()
        {
            _mockRepo = MockProductRepository.GetProductRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MainProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductListTest()
        {
            var handler = new GetProductListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetProductListRequest(), CancellationToken.None);

            Assert.IsType<List<ProductListDTO>>(result);
            Assert.Equal(2, result.Count);
        }
    }
}