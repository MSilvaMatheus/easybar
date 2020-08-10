using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class ItemEntity : EntityBase
    {
        public int Name { get; set; }
        public decimal Value { get; set; }

        public virtual CategoriesEntity CategoriesEntity { get; set; }

        public virtual ICollection<OrderEntity> Order { get; set; }

        public ItemEntity()
        {

        }
    }
}
