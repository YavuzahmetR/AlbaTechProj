namespace Layer.Core.Models
{
    public class CampaignChannels : BaseEntity
    {
        public int CampaignsId { get; set; }//
        public int ChannelsId { get; set; }
        public string CampaignName { get; set; }
        //
        public string ChannelType { get; set; }
        public bool Status { get; set; }
        public string LanguageCode { get; set; }
        
        public string Description { get; set; }
        public DateTime ActionStartTime { get; set; }
        public DateTime ActionEndTime { get; set; }

        public Campaigns Campaigns { get; set; }
        public Channels Channels { get; set; }

    }
}
