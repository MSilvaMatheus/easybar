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

            builder.HasKey(categories => categories.Id).IsClustered(true);
            builder.Property(categories => categories.Name).HasColumnName("Name").IsRequired();
            builder.Property(categories => categories.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(categories => categories.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();

            builder.Ignore(categories => categories.Invalid);
            builder.Ignore(categories => categories.Notifications);
            builder.Ignore(categories => categories.Valid);
            builder.Ignore(categories => categories.IsExist);           
        }
    }
}
