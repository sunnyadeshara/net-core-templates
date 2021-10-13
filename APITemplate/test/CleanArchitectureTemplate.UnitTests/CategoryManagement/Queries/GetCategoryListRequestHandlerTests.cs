using AutoMapper;
using CleanArchitectureTemplate.Application.AutoMapperProfiles;
using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Queries;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Queries;
using CleanArchitectureTemplate.UnitTests.Mocks;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.CategoryManagement.Queries
{
    public class GetCategoryListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepo;

        public GetCategoryListRequestHandlerTests()
        {
            _mockRepo = MockCategoryRepository.GetCategoryRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MainProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCategoryListTest()
        {
            var handler = new GetCategoryListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetCategoryListRequest(), CancellationToken.None);

            Assert.IsType<List<CategoryListDTO>>(result);
            Assert.Equal(2, result.Count);
        }
    }
}
