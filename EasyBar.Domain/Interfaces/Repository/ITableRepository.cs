using EasyBar.Domain.Entity.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBar.Domain.Interfaces.Repository
{
    public interface ITableRepository
    {
        Task<TableEntity> Add(TableEntity tableEntity);
        void Update(TableEntity tableEntity);
        void Delete(TableEntity tableEntity);
        IQueryable<TableEntity> GetAll();
        TableEntity Get(TableEntity tableEntity);
        TableEntity Get(string guid);
        TableEntity Get(int number);
    }
}
