namespace Layer.Core.DTOs
{
    public abstract class BaseEntityDto
    {
        public int Id { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
