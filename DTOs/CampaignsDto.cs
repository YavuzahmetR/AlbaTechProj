namespace Layer.Core.DTOs
{
    public class CampaignsDto : BaseEntityDto
    {
        public string Name { get; set; }//
        public DateTime StartDate { get; set; }//
        public DateTime EndDate { get; set; }//
        public bool Status { get; set; }
        public int Priority { get; set; }// //
        public string CampaignType { get; set; } //
        public string CampaignParameter { get; set; }//

    }
    public class CampaignsUpdateDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }//
        public DateTime EndDate { get; set; }//
        public bool Status { get; set; }
        public int Priority { get; set; }// //
        public string CampaignType { get; set; } //
        public UserDto UpdatedBy { get; set; }
    }
}
