using CleanArchitectureTemplate.Domain.Common;

namespace CleanArchitectureTemplate.Domain
{
    public class Product : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
