using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class ItemEntity : EntityBase
    {
        public int Name { get; set; }
        public decimal Value { get; set; }

        public string ForeignKeySubCategories { get; set; }

        public virtual SubCategoriesEntity SubCategories { get; set; }

        public virtual ICollection<OrderEntity> Order { get; set; }

        public ItemEntity()
        {

        }
    }
}
