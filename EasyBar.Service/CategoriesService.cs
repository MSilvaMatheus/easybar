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

            if (_categoriesRepository.Get(categories) != null)
            {
                return new ValidateResult(categories, false, "Categoria informada já existe");
            }

            categories.Validate();
           
            if (categories.Invalid)
            {
                return new ValidateResult(categories.Notifications, false, "Problemas ao cadastrar a Categoria");
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
