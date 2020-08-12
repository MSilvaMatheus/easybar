using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.Interfaces.Repository;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Infrastructure.Utility;

namespace EasyBar.Service
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public IResult Delete(string guid)
        {
            if (!Util.IsGuid(guid))
            {
                return new ValidateResult(null, false, "A identificação fornecida está inválida");
            }

            var tableEntity = _tableRepository.Get(guid);
            _tableRepository.Delete(tableEntity);
            return new ValidateResult(null, true, "Mesa deletada com sucesso");
        }

        public IResult GetAll() => new ValidateResult(_tableRepository.GetAll(), true, "Consulta Realizada com sucesso");
      
        public IResult Get(int number) => new ValidateResult(_tableRepository.Get(number), true, "Consulta Realizada com sucesso");

        public IResult Save(TableDto tableDto)
        {
            TableEntity table = new TableEntity(tableDto.Number);

            if (_tableRepository.Get(table) != null)
            {
                return new ValidateResult(table, false, "Mesa informada já existe");
            }

            table.Validate();

            if (table.Invalid)
            {
                return new ValidateResult(table.Notifications, false, "Problemas ao cadastrar a Mesa");
            }

            _tableRepository.Add(table);
            return new ValidateResult(table, true, "Mesa cadastrada com sucessso");
        }

        public IResult Update(TableDto tableDto)
        {
            if (!Util.IsGuid(tableDto.Identification))
            {
                return new ValidateResult(null, false, "A identificação fornecida está inválida");
            }

            TableEntity categories = _tableRepository.Get(tableDto.Identification);

            categories.SetNumber(tableDto.Number);

            categories.Validate();

            if (categories.Invalid)
            {
                return new ValidateResult(categories.Notifications, false, "Problemas ao atualizar a Mesa");
            }

            _tableRepository.Update(categories);
            return new ValidateResult(categories, true, "Mesa atualizada com sucessso");
        }
    }
}
