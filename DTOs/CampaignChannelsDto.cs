namespace Layer.Core.DTOs
{
    public class CampaignChannelsDto : BaseEntityDto
    {
        public int CampaignsId { get; set; }//
        public int ChannelsId { get; set; }//
        public bool Status { get; set; }
        public string CampaignName { get; set; }
        //
        public string ChannelType { get; set; }
        public string LanguageCode { get; set; }

        public string Description { get; set; }
        public DateTime ActionStartTime { get; set; }
        public DateTime ActionEndTime { get; set; }
    }
    public class CampaignChannelsUpdateDto
    {
        public int CampaignsId { get; set; }//
        public int ChannelsId { get; set; }//
        public bool Status { get; set; }
        public string CampaignName { get; set; }
        //
        public string ChannelType { get; set; }
        public string LanguageCode { get; set; }

        public string Description { get; set; }
        public DateTime ActionStartTime { get; set; }
        public DateTime ActionEndTime { get; set; }
        public UserDto UpdatedBy { get; set; }
    }
}
