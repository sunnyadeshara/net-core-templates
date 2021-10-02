using CleanArchitectureTemplate.Application.DTOs.Common;

namespace CleanArchitectureTemplate.Application.DTOs.Product
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
