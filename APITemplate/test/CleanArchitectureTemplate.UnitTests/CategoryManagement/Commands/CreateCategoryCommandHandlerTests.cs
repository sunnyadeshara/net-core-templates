using AutoMapper;
using CleanArchitectureTemplate.Application.AutoMapperProfiles;
using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.DTOs.Category.Validators;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Commands;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Responses;
using CleanArchitectureTemplate.UnitTests.Mocks;
using FluentValidation;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.CategoryManagement.Commands
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryDTO> _validator;
        private readonly Mock<ICategoryRepository> _mockRepo;
        private readonly CategoryDTO _categoryDTO;

        public CreateCategoryCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MainProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _validator = new CategoryDTOValidator();

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
            var handler = new CreateCategoryCommandHandler(_mockRepo.Object, _validator, _mapper);

            var result = await handler.Handle(new CreateCategoryCommand() { CategoryDTO = _categoryDTO }, CancellationToken.None);

            Assert.IsType<BaseCommandResponse>(result);
            Assert.True(result.IsSuccessful);
        }
    }
}
