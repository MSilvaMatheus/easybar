using EasyBar.Domain.Entity.Repository;
using EasyBar.Domain.Entity.Validation;
using EasyBar.Domain.Interfaces;
using EasyBar.Domain.Interfaces.Repository;
using EasyBar.Domain.TransferObjects;
using EasyBar.Service.Interface;
using Infrastructure.Utility;

namespace EasyBar.Service
{
    public class ConsumerService : IConsumerService
    {
        private readonly IConsumerRepository _consumerRepository;
        public ConsumerService(IConsumerRepository consumerRepository)
        {
            _consumerRepository = consumerRepository;
        }

        public IResult Delete(string guid)
        {
            if (!Util.IsGuid(guid))
                return new ValidateResult(null, false, "A identificação fornecida está inválida");

            ConsumerEntity consumer = _consumerRepository.Get(guid);
            _consumerRepository.Delete(consumer);

            return new ValidateResult(null, true, "Clinte deletado com sucesso");
        }

        public IResult Get(long number)
        {
            throw new System.NotImplementedException();
        }

        public IResult GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IResult Save(ConsumerDto consumerDto)
        {
            ConsumerEntity consumer = new ConsumerEntity(consumerDto);

            if (_consumerRepository.Get(consumer) != null)
                return new ValidateResult(consumer, false, "Cliente informado ja está vinculado a uma mesa");

            consumer.Validate();

            if (consumer.Invalid)
                return new ValidateResult(consumer.Notifications, false, "Problemas ao cadastrar o cliente");

            _consumerRepository.Add(consumer);
            return new ValidateResult(consumer, true, "Cliente cadastrado com sucessso");
        }

        public IResult Update(ConsumerDto consumerDto)
        {
            ConsumerEntity consumer = _consumerRepository.Get(consumerDto.Identification);

            consumer.SetPhoneNumer(consumerDto.PhoneNumber);
            consumer.SetCpf(consumerDto.CPF);
            consumer.SetTable(consumerDto.Table);

            consumer.Validate();

            if (consumer.Invalid)
                return new ValidateResult(consumer.Notifications, false, "Problemas ao atualizar os dados do cliente");

            _consumerRepository.Update(consumer);
            return new ValidateResult(consumer, true, "Cliente atualizado com sucessso");
        }
    }
}
