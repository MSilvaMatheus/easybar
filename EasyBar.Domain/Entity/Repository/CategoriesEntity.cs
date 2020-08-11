using FluentValidation;
using System;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class CategoriesEntity : EntityBase<CategoriesEntity>
    {
        public string Name { get; set; }

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
            RuleFor(catergories => catergories.Name)
               .NotNull()
               .NotEmpty()
               .MaximumLength(60)
               .WithMessage("Nome da categoria não pode ser em branco ou conter mais de 60 caracteres");
        }
    }
}
