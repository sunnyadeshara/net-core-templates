using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Handlers;
using CleanArchitectureTemplate.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Commands
{
    public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CategoryDTO);

            category = await _categoryRepository.Add(category);

            return category.Id;
        }
    }
}
