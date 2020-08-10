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
            builder.Property(order => order.Item).HasColumnName("Item").IsRequired();
            builder.Property(order => order.Quantity).HasColumnName("Quantity").IsRequired();
            builder.Property(order => order.Value).HasColumnName("Value").IsRequired();
            builder.Property(order => order.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(order => order.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();
            builder.HasOne(x => x.Consumer)
                   .WithMany(y => y.Order)
                   .HasForeignKey();
        }
    }
}
