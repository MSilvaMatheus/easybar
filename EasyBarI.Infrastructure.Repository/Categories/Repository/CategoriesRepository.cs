using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Interfaces.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBarI.Infrastructure.Repository.Categories.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public CategoriesRepository(DataBaseContext dataBaseContext) => _dataBaseContext = dataBaseContext;

        public async Task<CategoriesEntity> Add(CategoriesEntity categoriesEntity) 
        {           
            await _dataBaseContext.Categories.AddAsync(categoriesEntity);
            await _dataBaseContext.SaveChangesAsync();
               
            return categoriesEntity;
        }

        public void Delete(CategoriesEntity categoriesEntity)
        { 
            _dataBaseContext.Categories.Remove(categoriesEntity);
            _dataBaseContext.SaveChanges();
        }

        public CategoriesEntity Get(CategoriesEntity categoriesEntity)
            => _dataBaseContext.Categories.FirstOrDefault(c => c.Name == categoriesEntity.Name);

        public CategoriesEntity Get(string guid) 
            => _dataBaseContext.Categories.FirstOrDefault(c => c.Id == guid);

        public IQueryable<CategoriesEntity> GetAll() 
            => _dataBaseContext.Categories.ToList().AsQueryable();

        public void Update(CategoriesEntity categoriesEntity)
        { 
            _dataBaseContext.Categories.Update(categoriesEntity);
            _dataBaseContext.SaveChangesAsync();
        }

    }
}
