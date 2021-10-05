using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Queries
{
    public class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest, CategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.Get(request.Id);

            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
