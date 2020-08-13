using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Interfaces.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBarI.Infrastructure.Repository.Item.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public ItemRepository(DataBaseContext dataBaseContext) => _dataBaseContext = dataBaseContext;

        public Task<ItemEntity> Add(ItemEntity itemEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ItemEntity itemEntity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ItemEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ItemEntity> GetByCategories(string guidCategories)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ItemEntity itemEntity)
        {
            throw new System.NotImplementedException();
        }
    }
}
