using System;
using System.Collections.Generic;
using System.Text;

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

        public OrderEntity(string Item, int Quantity, decimal Value) {
            this.Item = Item;
            this.Quantity =  Quantity;
            this.Value = Value;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

    }
}
