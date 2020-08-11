using EasyBar.Domain.Entity.Repository;
using EasyBarI.Infrastructure.Repository.Categories.Mapping;
using EasyBarI.Infrastructure.Repository.Consumer.Mapping;
using EasyBarI.Infrastructure.Repository.Item.Mapping;
using EasyBarI.Infrastructure.Repository.Order.Mapping;
using EasyBarI.Infrastructure.Repository.Table.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EasyBarI.Infrastructure.Repository
{
    public class DataBaseContext : DbContext
    {
        public DbSet<TableEntity> Tables { get; set; }
        public DbSet<CategoriesEntity> Categories { get; set; }
        public DbSet<ConsumerEntity> Consumers { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<ItemEntity> Items { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TableMapping());
            modelBuilder.ApplyConfiguration(new OrderMapping());
            modelBuilder.ApplyConfiguration(new ConsumerMapping());
            modelBuilder.ApplyConfiguration(new CategoriesMapping());
            modelBuilder.ApplyConfiguration(new ItemMapping());
        }
    }
}
