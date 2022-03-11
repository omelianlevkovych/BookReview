namespace Domain.Entities.Interfaces
{
    public interface ISoftDelete
    {
        public bool SoftDeleted { get; set; }
    }
}
