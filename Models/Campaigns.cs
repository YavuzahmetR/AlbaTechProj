namespace Layer.Core.Models
{
    public class Campaigns : BaseEntity
    {
        public string Name { get; set; }//
        public DateTime StartDate { get; set; }//
        public DateTime EndDate { get; set; }//
        public bool Status { get; set; }
        public int Priority { get; set; }// //
        public string CampaignParameter { get; set; }
        public string CampaignType { get; set; } //
        public ICollection<CampaignChannels> CampaignChannels { get; set; }
        public ICollection<CustomerCampaigns> CustomerCampaigns { get; set; }


    }
}
