using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;

namespace EasyBar.Service.Interface
{
    public interface ISubCategoriesService
    {
        IResult Save(SubCategoriesDto tableDto);
        IResult Update(SubCategoriesDto tableDto);
        IResult Delete(string guid);
        IResult GetAll();
        IResult Get(string name);
    }
}
