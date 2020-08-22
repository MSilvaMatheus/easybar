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
        public ConsumerEntity(long phoneNumber, long cpf, string fkTable)
        {
            PhoneNumber = phoneNumber;
            CPF = cpf;
            ForeignKeyTable = fkTable;
        }
    }
}