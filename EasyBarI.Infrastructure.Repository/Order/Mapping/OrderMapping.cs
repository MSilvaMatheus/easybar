using EasyBar.Domain.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBarI.Infrastructure.Repository.Order.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(order => order.Id).IsClustered(true);
            builder.Property(order => order.Quantity).HasColumnName("Quantity").IsRequired();
            builder.Property(order => order.ForeignKeyConsumer).HasColumnName("FKConsumer").IsRequired();
            builder.Property(order => order.ForeignKeyItem).HasColumnName("FKItem").IsRequired();
            builder.Property(order => order.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(order => order.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();

            builder.Ignore(order => order.Invalid);
            builder.Ignore(order => order.Notifications);
            builder.Ignore(order => order.Valid);

            builder.HasOne(x => x.Consumer)
                   .WithMany(y => y.Order)
                   .HasForeignKey(order => order.ForeignKeyConsumer);

            builder.HasOne(order => order.Item)
                .WithMany(item => item.Order)
                .HasForeignKey(order => order.ForeignKeyItem);
        }
    }
}
