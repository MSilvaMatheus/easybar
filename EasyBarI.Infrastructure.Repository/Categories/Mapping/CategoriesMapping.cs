using EasyBar.Domain.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBarI.Infrastructure.Repository.Categories.Mapping
{
    public class CategoriesMapping : IEntityTypeConfiguration<CategoriesEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriesEntity> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(item => item.Id).IsClustered(true);
            builder.Property(item => item.Name).HasColumnName("Quantity").IsRequired();
            builder.Property(item => item.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(item => item.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();
        }
    }
}
