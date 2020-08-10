using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class ItemEntity : EntityBase<ItemEntity>
    {
        public int Name { get; set; }
        public decimal Value { get; set; }

        public string ForeignKeyCategories { get; set; }

        public virtual CategoriesEntity Categories { get; set; }

        public virtual ICollection<OrderEntity> Order { get; set; }

        public ItemEntity()
        {

        }
    }
}
