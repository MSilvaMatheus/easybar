using EasyBar.Domain.Interfaces.Repository;

namespace EasyBarI.Infrastructure.Repository.SubCategories.Repository
{
    public class SubCategoriesRepository : ISubCategoriesRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public SubCategoriesRepository(DataBaseContext dataBaseContext) => _dataBaseContext = dataBaseContext;
    }
}
