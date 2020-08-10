using System;

namespace EasyBar.Domain.Entity.Repository
{
    public class OrderEntity : EntityBase
    {

        public string Item { get; set; }

        public int Quantity { get; set; }

        public decimal Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        //Key region

        public ConsumerEntity Consumer { get; set; }

        //End Key region

        public OrderEntity(string item, int quantity, decimal value) 
        {
            Item = item;
            Quantity = quantity;
            Value = value;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
