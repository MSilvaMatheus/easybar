using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;

namespace EasyBar.Service
{
    public class CategoriesService : ICategoriesService
    {
        public CategoriesService()
        {

        }

        public IResult Delete(CategoriesDto categoriesDto)
        {
            throw new System.NotImplementedException();
        }

        public IResult GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IResult Save(CategoriesDto categoriesDto)
        {
            CategoriesEntity categories = new CategoriesEntity(categoriesDto.Name);
            var validateResult = categories.Validate(categories);

            if (!validateResult.IsValid)
            {
                return new ValidateResult(null, false, validateResult.ToString());
            }

            return new ValidateResult(null, true, "oi");

        }

        public IResult Update(CategoriesDto categoriesDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
