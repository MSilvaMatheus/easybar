using FluentValidation;
using System;

namespace EasyBar.Domain.Entity.Repository
{
    public abstract class EntityBase<T> : AbstractValidator<T> where T: class
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
