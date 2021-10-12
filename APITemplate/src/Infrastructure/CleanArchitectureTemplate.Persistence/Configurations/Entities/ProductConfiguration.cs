using CleanArchitectureTemplate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTemplate.Persistence.Configurations.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Product 1",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Product 2",
                    CategoryId = 2
                }
            );
        }
    }
}
