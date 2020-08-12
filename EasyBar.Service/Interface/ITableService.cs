using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;

namespace EasyBar.Service.Interface
{
    public interface ITableService
    {
        IResult Save(TableDto tableDto); 
        IResult Update(TableDto tableDto); 
        IResult Delete(string guid);
        IResult GetAll();
        IResult Get(int number);
    }
}
