using EasyBar.Domain.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBarI.Infrastructure.Repository.SubCategories.Mapping
{
    public class SubCategoriesMapping : IEntityTypeConfiguration<SubCategoriesEntity>
    {
        public void Configure(EntityTypeBuilder<SubCategoriesEntity> builder)
        {
            builder.ToTable("SubCategories");

            builder.HasKey(subCategories => subCategories.Id).IsClustered(true);
            builder.Property(subCategories => subCategories.Name).HasColumnName("Name").IsRequired();
            builder.Property(subCategories => subCategories.ForeignKeyCategories).HasColumnName("FkCategories").IsRequired();
            builder.Property(subCategories => subCategories.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(subCategories => subCategories.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();

            builder.Ignore(subCategories => subCategories.Invalid);
            builder.Ignore(subCategories => subCategories.Notifications);
            builder.Ignore(subCategories => subCategories.Valid);
            builder.Ignore(subCategories => subCategories.IsExist);

            builder.HasOne(subCategories => subCategories.Categories)
                .WithMany(categories => categories.SubCategories)
                .HasForeignKey(consumer => consumer.ForeignKeyCategories);
        }
    }
}
