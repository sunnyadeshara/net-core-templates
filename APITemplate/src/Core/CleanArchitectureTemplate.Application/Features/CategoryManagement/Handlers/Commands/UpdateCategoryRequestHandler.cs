using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands;
using CleanArchitectureTemplate.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Commands
{
    public class UpdateCategoryRequestHandler : IRequestHandler<UpdateCategoryRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CategoryDTO);

            category = await _categoryRepository.Update(category);

            return Unit.Value;
        }
    }
}
