using CleanArchitectureTemplate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureTemplate.Persistence.Configurations.Entities
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Category 1",
                    Description = "Category 1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Category 2",
                    Description = "Category 2"
                }
            );
        }
    }
}
