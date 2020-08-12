using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Interfaces.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBarI.Infrastructure.Repository.Table.Repository
{
    public class TableRepository : ITableRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public TableRepository(DataBaseContext dataBaseContext) => _dataBaseContext = dataBaseContext;

        public async Task<TableEntity> Add(TableEntity tableEntity)
        {
            await _dataBaseContext.Tables.AddAsync(tableEntity);
            await _dataBaseContext.SaveChangesAsync();

            return tableEntity;
        }

        public void Delete(TableEntity tableEntity)
        {
            _dataBaseContext.Tables.Remove(tableEntity);
            _dataBaseContext.SaveChangesAsync(); 
        }

        public TableEntity Get(TableEntity tableEntity) => _dataBaseContext.Tables.FirstOrDefault(t => t.Number == tableEntity.Number);

        public TableEntity Get(string guid) => _dataBaseContext.Tables.FirstOrDefault(t => t.Id == guid);

        public TableEntity Get(int number) => _dataBaseContext.Tables.FirstOrDefault(t => t.Number == number);

        public IQueryable<TableEntity> GetAll() => _dataBaseContext.Tables.ToList().AsQueryable();
 
        public void Update(TableEntity tableEntity)
        {
            _dataBaseContext.Tables.Update(tableEntity);
            _dataBaseContext.SaveChangesAsync();
        }
    }
}
