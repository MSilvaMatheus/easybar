using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.Interfaces.Repository;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;

namespace EasyBar.Service
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public IResult Delete(string guid)
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

            _categoriesRepository.Add(categories);

            return new ValidateResult(categories, true, "Categoria cadastrada com sucessso");
        }

        public IResult Update(CategoriesDto categoriesDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
