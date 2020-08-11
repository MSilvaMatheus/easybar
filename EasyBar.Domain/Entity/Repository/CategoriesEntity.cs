using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class CategoriesEntity : EntityBase
    {
        public string Name { get; private set; }

        public virtual ICollection<ItemEntity> Item { get; set; }

        public CategoriesEntity()
        {

        }
        public CategoriesEntity(string name)
        {
            //Id = Guid.NewGuid().ToString();
            Name = name;
            CreatedAt = CreatedAt == DateTime.MinValue ? DateTime.Now : CreatedAt;
            UpdatedAt = DateTime.Now;         
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(Name, nameof(Name), "O Nome da categoria não pode estar em branco")
               .HasMaxLen(Name, 60, nameof(Name), "O Nome da categoria deve ter no máximo 60 caracteres"));
        }
    }
}
