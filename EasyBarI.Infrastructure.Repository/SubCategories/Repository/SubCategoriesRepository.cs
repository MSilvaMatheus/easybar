using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBarI.Infrastructure.Repository.SubCategories.Repository
{
    public class SubCategoriesRepository : ISubCategoriesRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public SubCategoriesRepository(DataBaseContext dataBaseContext) => _dataBaseContext = dataBaseContext;

        public async Task<SubCategoriesEntity> Add(SubCategoriesEntity categoriesEntity)
        {
            await _dataBaseContext.SubCategories.AddAsync(categoriesEntity);
            await _dataBaseContext.SaveChangesAsync();

            return categoriesEntity;
        }

        public void Delete(SubCategoriesEntity categoriesEntity)
        {
            _dataBaseContext.SubCategories.Remove(categoriesEntity);
            _dataBaseContext.SaveChanges();
        }

        public SubCategoriesEntity Get(SubCategoriesEntity categoriesEntity)
            => _dataBaseContext.SubCategories.FirstOrDefault(c => c.Name == categoriesEntity.Name);

        public SubCategoriesEntity Get(string guid)
            => _dataBaseContext.SubCategories.FirstOrDefault(c => c.Id == guid);

        public IQueryable<SubCategoriesEntity> GetAll()
            => _dataBaseContext.SubCategories.ToList().AsQueryable();

        public SubCategoriesEntity GetByCategoriesName(string categoriesName)
            => _dataBaseContext.SubCategories.Include(c => c.Categories).FirstOrDefault();

        public void Update(SubCategoriesEntity categoriesEntity)
        {
            _dataBaseContext.SubCategories.Update(categoriesEntity);
            _dataBaseContext.SaveChangesAsync();
        }
    }
}
