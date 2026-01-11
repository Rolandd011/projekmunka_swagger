using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Backend.Models;

namespace MyApp.Backend.Configuration
{
    public class CategoryConfiguraton : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("Category");

            entity.HasKey(x => x.Id);


            entity.Property(x => x.Name)
                  .HasMaxLength(50)
                  .IsRequired();
        }
    }
}
