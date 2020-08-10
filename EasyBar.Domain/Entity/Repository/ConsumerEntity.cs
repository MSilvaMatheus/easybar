using System;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class ConsumerEntity : EntityBase
    {
        public long PhoneNumber { get; set; }
        public string ForeignKeyTable { get; set; }

        public virtual TableEntity Table { get; set; }
        public virtual ICollection<OrderEntity> Order { get; set; }

        public ConsumerEntity(long phoneNumber)
        {
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}