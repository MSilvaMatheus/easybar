using EasyBar.Domain.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBarI.Infrastructure.Repository.Order.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
