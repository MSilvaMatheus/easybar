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
            builder.Property(item => item.Name).HasColumnName("Name").IsRequired();
            builder.Property(item => item.Value).HasColumnName("Value").IsRequired();
            builder.Property(item => item.ForeignKeySubCategories).HasColumnName("FkSubCategories").IsRequired();
            builder.Property(item => item.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(item => item.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();

            builder.Ignore(item => item.Invalid);
            builder.Ignore(item => item.Notifications);
            builder.Ignore(item => item.Valid);

            builder.HasOne(item => item.SubCategories)
                   .WithMany(categories => categories.Items)
                   .HasForeignKey(item => item.ForeignKeySubCategories);
        }
    }
}
