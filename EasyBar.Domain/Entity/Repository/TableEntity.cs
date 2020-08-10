namespace EasyBar.Domain.Entity.Repository
{
    public class TableEntity : EntityBase<TableEntity>
    {
        public int Number { get; set; }

        public virtual ConsumerEntity Consumer { get; set; }

        public TableEntity(int number)
        {
            Number = number;
        }
    }
}
