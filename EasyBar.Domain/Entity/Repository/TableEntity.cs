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
    }
}
