using CleanArchitectureTemplate.Application.DTOs.Category;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Queries
{
    public class GetCategoryListRequest : IRequest<List<CategoryListDTO>>
    {
    }
}
