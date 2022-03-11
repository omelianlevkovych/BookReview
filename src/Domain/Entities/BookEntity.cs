using Domain.Entities.Interfaces;

namespace Domain.Entities
{
    public class BookEntity : EntityBase, ISoftDelete
    {
        public string Name { get; set; }
        public bool SoftDeleted { get; set; }
    }
}
