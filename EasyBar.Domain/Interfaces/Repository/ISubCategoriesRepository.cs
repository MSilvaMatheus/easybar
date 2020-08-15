using EasyBar.Domain.Entity.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBar.Domain.Interfaces.Repository
{
    public interface ISubCategoriesRepository
    {
        Task<SubCategoriesEntity> Add(SubCategoriesEntity categoriesEntity);
        void Update(SubCategoriesEntity categoriesEntity);
        void Delete(SubCategoriesEntity categoriesEntity);
        IQueryable<SubCategoriesEntity> GetAll();
        SubCategoriesEntity Get(SubCategoriesEntity categoriesEntity);
        SubCategoriesEntity Get(string guid);
        SubCategoriesEntity GetByCategoriesName(string categoriesName);
    }
}
