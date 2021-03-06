using AutoMapper;
using CleanArchitectureTemplate.Application.AutoMapperProfiles;
using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Commands;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Responses;
using CleanArchitectureTemplate.UnitTests.Features.Mocks;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.Features.CategoryManagement.Commands
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICategoryRepository> _mockRepo;
        private readonly CategoryDTO _categoryDTO;

        public CreateCategoryCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MainProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockRepo = MockCategoryRepository.GetCategoryRepository();

            _categoryDTO = new CategoryDTO
            {
                Name = "Category 3",
                Description = "Category 3 Description"
            };
        }

        [Fact]
        public async Task CreateCategoryTest()
        {
            var handler = new CreateCategoryCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreateCategoryCommand() { CategoryDTO = _categoryDTO }, CancellationToken.None);

            Assert.IsType<BaseCommandResponse>(result);
            Assert.True(result.IsSuccessful);

            var categories = await _mockRepo.Object.GetAll();

            Assert.True(categories.Count == 3);
        }
    }
}
