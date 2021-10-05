using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var category = await _categoryRepository.Get(request.Id);

            if (category == null)
            {
                response.IsSuccessful = false;
                response.Message = "Category does not exist";
            }

            await _categoryRepository.Delete(category);

            response.IsSuccessful = true;
            response.Message = "Category deletion successful";

            return response;
        }
    }
}
