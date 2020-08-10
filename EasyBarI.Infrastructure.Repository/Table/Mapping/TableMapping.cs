using EasyBar.Domain.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBarI.Infrastructure.Repository.Table.Mapping
{
    public class TableMapping : IEntityTypeConfiguration<TableEntity>
    {
        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            builder.ToTable("Table");

            builder.HasKey(table => table.Id).IsClustered(true);
            builder.Property(table => table.Number).HasColumnName("Number").IsRequired();

        }
    }
}
