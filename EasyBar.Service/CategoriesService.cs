using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.Interfaces.Repository;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Infrastructure.Utility;

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
            if (!Util.IsGuid(guid))
            {
                return new ValidateResult(null, false, "A identificação fornecida está inválida");
            }

            var categoriesEntity = _categoriesRepository.Get(guid);
            _categoriesRepository.Delete(categoriesEntity);
            return new ValidateResult(null, true, "Categoria deletada com sucesso");
        }

        public IResult GetAll() => new ValidateResult(_categoriesRepository.GetAll(), true, "Categoria(s) cadastradas");
     
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
            if (!Util.IsGuid(categoriesDto.Identification))
            {
                return new ValidateResult(null, false, "A identificação fornecida está inválida");
            }

            var categories = _categoriesRepository.Get(categoriesDto.Identification);

            categories.SetName(categoriesDto.Name);

            categories.Validate();

            if (categories.Invalid)
            {
                return new ValidateResult(categories.Notifications, false, "Problemas ao atualizar a Categoria");
            }

            _categoriesRepository.Update(categories);
            return new ValidateResult(categories, true, "Categoria atualizada com sucessso");
        }
    }
}
