﻿using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace EasyBar.Domain.Entity.Repository
{
    public class CategoriesEntity : EntityBase
    {
        public string Name { get; private set; }

        public bool IsExist { get; private set; }

        public virtual ICollection<SubCategoriesEntity> SubCategories { get; set; }

        public CategoriesEntity()
        {

        }

        public CategoriesEntity(string name)
        {
            Name = name;            
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

        public void SetName(string name)
        {
            Name = name;
            UpdatedAt = DateTime.Now;
        }     
    }
}
