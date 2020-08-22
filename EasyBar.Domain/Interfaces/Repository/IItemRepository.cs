using EasyBar.Domain.Entity.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBar.Domain.Interfaces.Repository
{
    public interface IItemRepository
    {
        Task<ItemEntity> Add(ItemEntity itemEntity);
        void Update(ItemEntity itemEntity);
        void Delete(ItemEntity itemEntity);
        IQueryable<ItemEntity> GetAll();
        IQueryable<ItemEntity> GetByCategories(string guidCategories);
        ItemEntity Get(ItemEntity item);
        ItemEntity Get(string guid);
    }
}
