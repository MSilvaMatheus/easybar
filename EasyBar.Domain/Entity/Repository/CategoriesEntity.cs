using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class CategoriesEntity : EntityBase
    {
        public string Name { get; private set; }

        public bool IsExist { get; private set; }

        public virtual ICollection<ItemEntity> Item { get; set; }

        public CategoriesEntity()
        {

        }
        public CategoriesEntity(string name)
        {
            Name = name;
            CreatedAt = CreatedAt == DateTime.MinValue ? DateTime.Now : CreatedAt;
            UpdatedAt = DateTime.Now;
            IsExist = false;
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(Name, nameof(Name), "O Nome da categoria não pode estar em branco")
               .HasMaxLen(Name, 60, nameof(Name), "O Nome da categoria deve ter no máximo 60 caracteres"));
        }

        public CategoriesEntity(CategoriesEntity categoriesEntity)
        {           
            Name = categoriesEntity.Name;
            CreatedAt = categoriesEntity.CreatedAt;
            UpdatedAt = categoriesEntity.UpdatedAt;
            IsExist = true;                                   
        }
    }
}
