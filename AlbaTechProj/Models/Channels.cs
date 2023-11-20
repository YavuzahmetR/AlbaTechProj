namespace Layer.Core.Models
{
    public class Channels : BaseEntity
    {
        public ICollection<CampaignChannels> CampaignChannels { get; set; }
        public string ChannelType { get; set; }//

    }
}
