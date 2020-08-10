using Microsoft.EntityFrameworkCore;

namespace EasyBarI.Infrastructure.Repository
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }


    }
}
