namespace Layer.Core.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
