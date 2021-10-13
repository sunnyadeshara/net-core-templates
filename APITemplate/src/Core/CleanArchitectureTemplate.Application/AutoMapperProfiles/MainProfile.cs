using AutoMapper;
using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.DTOs.Product;
using CleanArchitectureTemplate.Domain;

namespace CleanArchitectureTemplate.Application.AutoMapperProfiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryListDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductListDTO>().ReverseMap();
        }
    }
}
