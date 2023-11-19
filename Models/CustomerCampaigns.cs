namespace Layer.Core.Models
{
    public class CustomerCampaigns : BaseEntity
    {
        public Campaigns Campaigns { get; set; }
        public int CampaignsId { get; set; }
        public Customers Customers { get; set; }
        public int CustomersId { get; set; }  

    }
}
