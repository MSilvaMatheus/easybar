using EasyBar.Domain.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBarI.Infrastructure.Repository.Consumer.Mapping
{
    public class ConsumerMapping : IEntityTypeConfiguration<ConsumerEntity>
    {
        public void Configure(EntityTypeBuilder<ConsumerEntity> builder)
        {
            builder.ToTable("Consumer");

            builder.HasKey(consumer => consumer.Id).IsClustered(true);
            builder.Property(consumer => consumer.PhoneNumber).HasColumnName("PhoneNumber").IsRequired();
            builder.Property(consumer => consumer.ForeignKeyTable).HasColumnName("FkTable").IsRequired();
            builder.Property(consumer => consumer.CreatedAt).HasColumnName("CreatedAt").IsRequired();
            builder.Property(consumer => consumer.UpdatedAt).HasColumnName("UpdatedAt").IsRequired();
            builder.Ignore(consumer => consumer.CascadeMode);
            builder.HasOne(consumer => consumer.Table)
                .WithOne(table => table.Consumer)
                .HasForeignKey<ConsumerEntity>(consumer => consumer.ForeignKeyTable);
        }
    }
}
