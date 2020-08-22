using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;

namespace EasyBar.Service.Interface
{
    public interface IConsumerService
    {
        IResult Save(ConsumerDto consumerDto);
        IResult Update(ConsumerDto consumerDto);
        IResult Delete(string guid);
        IResult GetAll();
        IResult Get(long number);
    }
}
