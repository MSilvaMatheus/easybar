using EasyBar.Domain.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBarI.Infrastructure.Repository.Item.Mapping
{
    public class ItemMapping : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(item => item.Id).IsClustered(true);
            builder.Property(item => item.Name).HasColumnName("Quantity").IsRequired();
            builder.Property(item => item.Value).HasColumnName("FKConsumer").IsRequired();
            builder.Property(item => item.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(item => item.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();

            builder.Ignore(item => item.CascadeMode);

            builder.HasOne(item => item.Categories)
                   .WithMany(categories => categories.Item)
                   .HasForeignKey(item => item.ForeignKeyCategories);
        }
    }
}
