using AutoMapper;
using CleanArchitectureTemplate.Application.AutoMapperProfiles;
using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.DTOs.Product;
using CleanArchitectureTemplate.Application.DTOs.Product.Validators;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Handlers.Commands;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Responses;
using CleanArchitectureTemplate.UnitTests.Mocks;
using FluentValidation;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchitectureTemplate.UnitTests.ProductManagement.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ProductDTO> _validator;
        private readonly Mock<ICategoryRepository> _mockCategoryRepo;
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductDTO _productDTO;

        public CreateProductCommandHandlerTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MainProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _mockCategoryRepo = MockCategoryRepository.GetCategoryRepository();
            _mockRepo = MockProductRepository.GetProductRepository();

            _validator = new ProductDTOValidator(_mockCategoryRepo.Object);

            _productDTO = new ProductDTO
            {
                Name = "Product 3",
                Description = "Product 3 Description",
                CategoryId = 1
            };
        }

        [Fact]
        public async Task CreateProductTest()
        {
            var handler = new CreateProductCommandHandler(_mockRepo.Object, _validator, _mapper);

            var result = await handler.Handle(new CreateProductCommand() { ProductDTO = _productDTO }, CancellationToken.None);

            Assert.IsType<BaseCommandResponse>(result);
            Assert.True(result.IsSuccessful);

            var products = await _mockRepo.Object.GetAll();

            Assert.True(products.Count == 3);
        }
    }
}