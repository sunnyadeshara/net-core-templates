using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryListDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDTO>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAll();

            return _mapper.Map<List<CategoryListDTO>>(categories);
        }
    }
}
