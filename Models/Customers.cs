namespace Layer.Core.Models
{
    public class Customers : BaseEntity
    {
        public int CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public bool CardStatus { get; set; }
        public string Segment { get; set; }
        public ICollection<CustomerCampaigns> CustomerCampaigns { get; set; }
    }
}
