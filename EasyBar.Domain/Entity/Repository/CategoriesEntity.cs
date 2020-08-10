using FluentValidation;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class CategoriesEntity : EntityBase<CategoriesEntity>
    {
        public string Name { get; set; }

        public virtual ICollection<ItemEntity> Item { get; set; }

        public CategoriesEntity(string name)
        {
            Name = name;

            RuleFor(catergories => catergories.Name)
               .NotNull()
               .NotEmpty()
               .MaximumLength(60)
               .WithMessage("Nome da categoria não pode ser em branco ou conter mais de 60 caracteres");
        }
    }
}
