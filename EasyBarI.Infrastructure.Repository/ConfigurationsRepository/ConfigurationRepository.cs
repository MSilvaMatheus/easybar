using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyBarI.Infrastructure.Repository.ConfigurationsRepository
{
    public static class ConfigurationRepository
    {
        public static void ConfigurationContext(this IServiceCollection services)
        {
            services.AddDbContext<DataBaseContext>(contexto => contexto.UseSqlServer("teste"));
        }
    }
}
