using CleanArchitectureTemplate.Domain.Common;

namespace CleanArchitectureTemplate.Domain
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
