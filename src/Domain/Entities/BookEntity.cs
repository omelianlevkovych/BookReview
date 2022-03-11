namespace Domain.Entities
{
    public class BookEntity : EntityBase
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
