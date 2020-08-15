using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;

namespace EasyBar.Service.Interface
{
    public interface IItemService
    {
        IResult Save(ItemDto itemDto);
        IResult Update(ItemDto itemDto);
        IResult Delete(string guid);
        IResult GetAll();
        IResult Get(string name);
    }
}
