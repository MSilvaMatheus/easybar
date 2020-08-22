using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Interfaces.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBarI.Infrastructure.Repository.Consumer.Repository
{  
    public class ConsumerRepository : IConsumerRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public ConsumerRepository(DataBaseContext dataBaseContext) => _dataBaseContext = dataBaseContext;

        public async Task<ConsumerEntity> Add(ConsumerEntity consumer)
        {
            await _dataBaseContext.Consumers.AddAsync(consumer);
            await _dataBaseContext.SaveChangesAsync();

            return consumer;
        }

        public void Delete(ConsumerEntity consumer)
        {
            _dataBaseContext.Consumers.Remove(consumer);
            _dataBaseContext.SaveChangesAsync();
        }

        public ConsumerEntity Get(ConsumerEntity consumer)
            => _dataBaseContext.Consumers.FirstOrDefault(c => c.CPF == consumer.CPF);

        public ConsumerEntity Get(string guid)
            => _dataBaseContext.Consumers.FirstOrDefault(c => c.Id == guid);

        public ConsumerEntity Get(long number)
            => _dataBaseContext.Consumers.FirstOrDefault(c => c.PhoneNumber == number);

        public IQueryable<ConsumerEntity> GetAll()
            => _dataBaseContext.Consumers.AsQueryable();

        public void Update(ConsumerEntity consumer)
        {
            _dataBaseContext.Consumers.Update(consumer);
            _dataBaseContext.SaveChangesAsync();
        }
    }
}
