using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;

namespace EasyBar.Service.Interface
{
    public interface ICategoriesService
    {
        IResult Save(CategoriesDto categoriesDto); 
        IResult Update(CategoriesDto categoriesDto); 
        IResult Delete(string guid);
        IResult GetAll();       
    }
}
