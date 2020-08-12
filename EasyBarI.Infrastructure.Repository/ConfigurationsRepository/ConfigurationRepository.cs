using EasyBar.Domain.Interfaces.Repository;
using EasyBarI.Infrastructure.Repository.Categories.Repository;
using EasyBarI.Infrastructure.Repository.Table.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyBarI.Infrastructure.Repository.ConfigurationsRepository
{
    public static class ConfigurationRepository
    {
        public static void ConfigurationContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(context => context.UseMySQL(configuration.GetConnectionString("EasyBar")));
        }

        public static void DependencyResolverRepository(this IServiceCollection service)
        {
            service.AddScoped<ICategoriesRepository, CategoriesRepository>();
            service.AddScoped<ITableRepository, TableRepository>();
        }
    }
}
