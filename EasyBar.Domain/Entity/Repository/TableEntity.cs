using Flunt.Validations;

namespace EasyBar.Domain.Entity.Repository
{
    public class TableEntity : EntityBase
    {
        public int Number { get; set; }

        public virtual ConsumerEntity Consumer { get; set; }

        public TableEntity()
        {

        }
        public TableEntity(int number)
        {
            Number = number;
        }

        public void SetNumber(int number)
        {
            Number = number;
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
              .IsGreaterThan(Number, 0, nameof(Number), "O valor informado no número da mesa está incorreto"));
        }
    }
}
