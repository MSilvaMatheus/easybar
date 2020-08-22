using EasyBar.Domain.TransferObjects;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class ConsumerEntity : EntityBase
    {
        public long PhoneNumber { get; set; }
        public long CPF { get; set; }
        public string ForeignKeyTable { get; private set; }

        public virtual TableEntity Table { get; set; }
        public virtual ICollection<OrderEntity> Order { get; set; }

        public ConsumerEntity()
        {

        }
        public ConsumerEntity(ConsumerDto consumerDto)
        {
            PhoneNumber = consumerDto.PhoneNumber;
            CPF = consumerDto.CPF;
            ForeignKeyTable = consumerDto.Table;
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
              .IsGreaterThan(PhoneNumber, 0, nameof(PhoneNumber), "N�mero do telefone informado inv�lido")
              .HasMaxLen(PhoneNumber.ToString(), 11, nameof(PhoneNumber), "N�mero do telefone deve conter no maximo 11 caracteres")
              .IsGuid(ForeignKeyTable, "Table", "Mesa inv�lida")
              .IsGreaterThan(CPF, 0, nameof(CPF), "CPF informado inv�lido"));
        }

        public void SetPhoneNumer(long phoneNumber) => PhoneNumber = phoneNumber;
        public void SetCpf(long cpf) => CPF = cpf;
        public void SetTable(string table)
        {
            ForeignKeyTable = table;
            UpdatedAt = DateTime.Now;
        }
    }
}