using EasyBar.Domain.TransferObjects;
using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class ItemEntity : EntityBase
    {
        public string Name { get; private set; }

        public decimal Value { get; private set; }

        public string ForeignKeySubCategories { get; private set; }

        public virtual SubCategoriesEntity SubCategories { get; private set; }

        public virtual ICollection<OrderEntity> Order { get; private set; }

        public ItemEntity()
        {

        }

        public ItemEntity(ItemDto itemDto)
        {
            Name = itemDto.Name;
            Value = itemDto.Value;
            ForeignKeySubCategories = itemDto.SubCategories;
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
               .IsNotNullOrEmpty(Name, nameof(Name), "O Nome do item não pode estar em branco")
               .HasMaxLen(Name, 60, nameof(Name), "O Nome do item deve ter no máximo 80 caracteres")
               .IsGuid(ForeignKeySubCategories, "SubCategories", "SubCategoria inválida")
               .IsGreaterThan(Value, 0, nameof(Value), "O item não pode possuir um valor igual ou menor que 0(zero)"));
        }

        public void SetName(string name) => Name = name;

        public void SetValue(decimal value) => Value = value;

        public void SetSubCategories(string subCategories)
        {
            ForeignKeySubCategories = subCategories;
            UpdatedAt = DateTime.Now;
        }
    }
}
