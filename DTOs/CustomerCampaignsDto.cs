namespace Layer.Core.DTOs
{
    public class CustomerCampaignsDto : BaseEntityDto
    {
        public int CampaignsId { get; set; }
        public int CustomersId { get; set; }
    }
    public class CustomerCampaignsUpdateDto
    {
        public int CampaignsId { get; set; }
        public int CustomersId { get; set; }
        public UserDto UpdatedBy { get; set; }
    }
}
