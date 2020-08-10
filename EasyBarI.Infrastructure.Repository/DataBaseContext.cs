using EasyBar.Domain.Entity.Repository;
using EasyBarI.Infrastructure.Repository.Consumer.Mapping;
using EasyBarI.Infrastructure.Repository.Order.Mapping;
using EasyBarI.Infrastructure.Repository.Table.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EasyBarI.Infrastructure.Repository
{
    public class DataBaseContext : DbContext
    {
        public DbSet<TableEntity> TableEntitys { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TableMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new ConsumerMapping());
        }
    }
}
