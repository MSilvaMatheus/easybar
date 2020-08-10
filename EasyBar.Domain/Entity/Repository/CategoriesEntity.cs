using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class CategoriesEntity : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<ItemEntity> Item { get; set; }

        public CategoriesEntity()
        {

        }
    }
}
