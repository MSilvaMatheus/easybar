using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class SubCategoriesEntity : EntityBase
    {
        public string Name { get; private set; }

        public bool IsExist { get; private set; }

        public string ForeignKeyCategories { get; set; }

        public virtual CategoriesEntity Categories { get; set; }

        public virtual ICollection<ItemEntity> Items { get; set; }

        public SubCategoriesEntity(string name)
        {
            Name = name;
            IsExist = false;
        }

        public SubCategoriesEntity(SubCategoriesEntity categoriesEntity)
        {
            Name = categoriesEntity.Name;
            CreatedAt = categoriesEntity.CreatedAt;
            UpdatedAt = categoriesEntity.UpdatedAt;
            IsExist = true;
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(Name, nameof(Name), "O Nome da sub categoria não pode estar em branco")
               .HasMaxLen(Name, 60, nameof(Name), "O Nome sub categoria deve ter no máximo 60 caracteres"));
        }

        public void SetName(string name)
        {
            Name = name;
            UpdatedAt = DateTime.Now;
        }
    }
}
