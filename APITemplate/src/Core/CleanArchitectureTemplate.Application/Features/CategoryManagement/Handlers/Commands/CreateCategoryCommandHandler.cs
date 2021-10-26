using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Responses;
using CleanArchitectureTemplate.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var category = _mapper.Map<Category>(request.CategoryDTO);

            category = await _categoryRepository.Add(category);

            response.IsSuccessful = true;
            response.Message = "Category creation successful";
            response.Id = category.Id;

            return response;
        }
    }
}