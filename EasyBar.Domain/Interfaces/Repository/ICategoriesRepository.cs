using EasyBar.Domain.Entity.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBar.Domain.Interfaces.Repository
{
    public interface ICategoriesRepository
    {
        Task<CategoriesEntity> Add(CategoriesEntity categoriesEntity);
        void Update(CategoriesEntity categoriesEntity);
        void Delete(CategoriesEntity categoriesEntity);
        IQueryable<CategoriesEntity> GetAll();
        CategoriesEntity Get(CategoriesEntity categoriesEntity);
        CategoriesEntity Get(string guid);
    }
}
