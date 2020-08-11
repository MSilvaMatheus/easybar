using System;

namespace EasyBar.Domain.Entity.Repository
{
    public class OrderEntity : EntityBase
    {
        public int Quantity { get; set; }

        public string ForeignKeyConsumer { get; set; }

        public string ForeignKeyItem { get; set; }

        public virtual ConsumerEntity Consumer { get; set; }

        public virtual ItemEntity Item { get; set; }
        public OrderEntity()
        {

        }
        public OrderEntity(ItemEntity item, int quantity, decimal value) 
        {
            Item = item;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
