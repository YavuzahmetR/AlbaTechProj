namespace Layer.Core.DTOs
{
    public class CustomersDto : BaseEntityDto
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
    }
    public class CustomersUpdateDto
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public UserDto UpdatedBy { get; set; }
    }
}
