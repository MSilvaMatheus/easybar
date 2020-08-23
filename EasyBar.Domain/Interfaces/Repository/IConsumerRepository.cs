using EasyBar.Domain.Entity.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBar.Domain.Interfaces.Repository
{
    public interface IConsumerRepository
    {
        Task<ConsumerEntity> Add(ConsumerEntity consumer);
        void Update(ConsumerEntity consumer);
        void Delete(ConsumerEntity consumer);
        IQueryable<ConsumerEntity> GetAll();
        ConsumerEntity Get(ConsumerEntity consumer);
        ConsumerEntity Get(string guid);
        ConsumerEntity Get(long number);

        bool Exists(long cpf);
    }
}
