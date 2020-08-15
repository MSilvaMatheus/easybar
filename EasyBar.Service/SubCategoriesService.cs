using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.Interfaces.Repository;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Infrastructure.Utility;

namespace EasyBar.Service
{
    public class SubCategoriesService : ISubCategoriesService
    {
        private readonly ISubCategoriesRepository _subCategoriesRepository;

        public SubCategoriesService(ISubCategoriesRepository subCategoriesRepository)
        {
            _subCategoriesRepository = subCategoriesRepository;
        }

        public IResult Delete(string guid)
        {
            if (!Util.IsGuid(guid))
            {
                return new ValidateResult(null, false, "A identificação fornecida está inválida");
            }

            var tableEntity = _subCategoriesRepository.Get(guid);
            _subCategoriesRepository.Delete(tableEntity);
            return new ValidateResult(null, true, "SubCategoria deletada com sucesso");
        }

        public IResult GetByCategoriesName(string categorieName) => new ValidateResult(_subCategoriesRepository.GetByCategoriesName(categorieName), true, "Consulta Realizada com sucesso"); 

        public IResult GetAll() => new ValidateResult(_subCategoriesRepository.GetAll(), true, "Consulta Realizada com sucesso");

        public IResult Save(SubCategoriesDto subCategoriesDto)
        {
            SubCategoriesEntity table = new SubCategoriesEntity(subCategoriesDto.Name, subCategoriesDto.Categories);

            if (_subCategoriesRepository.Get(table) != null)
            {
                return new ValidateResult(table, false, "Mesa informada já existe");
            }

            table.Validate();

            if (table.Invalid)
            {
                return new ValidateResult(table.Notifications, false, "Problemas ao cadastrar a SubCategoria");
            }

            _subCategoriesRepository.Add(table);
            return new ValidateResult(table, true, "SubCategoria cadastrada com sucessso");
        }

        public IResult Update(SubCategoriesDto subCategoriaDto)
        {
            if (!Util.IsGuid(subCategoriaDto.Identification))
            {
                return new ValidateResult(null, false, "A identificação fornecida está inválida");
            }

            SubCategoriesEntity subCategories = _subCategoriesRepository.Get(subCategoriaDto.Identification);

            subCategories.SetName(subCategoriaDto.Name);
            subCategories.SetCategories(subCategoriaDto.Categories);

            subCategories.Validate();

            if (subCategories.Invalid)
            {
                return new ValidateResult(subCategories.Notifications, false, "Problemas ao atualizar a Mesa");
            }

            _subCategoriesRepository.Update(subCategories);
            return new ValidateResult(subCategories, true, "SubCategoria atualizada com sucessso");
        }
    }
}
