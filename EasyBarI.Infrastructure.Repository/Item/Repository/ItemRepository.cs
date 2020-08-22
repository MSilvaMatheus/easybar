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

        public async Task<ItemEntity> Add(ItemEntity itemEntity)
        {
            await _dataBaseContext.Items.AddAsync(itemEntity);
            await _dataBaseContext.SaveChangesAsync();

            return itemEntity;
        }

        public void Delete(ItemEntity itemEntity)
        {
            _dataBaseContext.Items.Remove(itemEntity);
            _dataBaseContext.SaveChanges();
        }

        public IQueryable<ItemEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<ItemEntity> GetByCategories(string guidCategories)
        {
            throw new System.NotImplementedException();
        }

        public ItemEntity Get(ItemEntity item)
            => _dataBaseContext.Items.FirstOrDefault(i => i.Name == item.Name);

        public ItemEntity Get(string guid)
            => _dataBaseContext.Items.FirstOrDefault(i => i.Id == guid);

        public void Update(ItemEntity itemEntity)
        {
            _dataBaseContext.Items.Update(itemEntity);
            _dataBaseContext.SaveChangesAsync();
        }
    }
}
