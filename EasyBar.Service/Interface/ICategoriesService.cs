using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;

namespace EasyBar.Service.Interface
{
    public interface ICategoriesService
    {
        IResult Save(CategoriesDto categoriesDto); 
        IResult Update(CategoriesDto categoriesDto); 
        IResult Delete(CategoriesDto categoriesDto);
        IResult GetAll();       
    }
}
