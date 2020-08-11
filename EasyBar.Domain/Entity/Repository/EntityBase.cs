using Flunt.Notifications;
using System;

namespace EasyBar.Domain.Entity.Repository
{
    public abstract class EntityBase: Notifiable
    {
        public string Id { get; private set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
