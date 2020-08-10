using EasyBar.Domain.Entity.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyBarI.Infrastructure.Repository.Consumer.Mapping
{
    public class ConsumerMapping : IEntityTypeConfiguration<ConsumerEntity>
    {
        public void Configure(EntityTypeBuilder<ConsumerEntity> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
