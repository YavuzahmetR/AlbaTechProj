namespace Layer.Core.DTOs
{
    public class ChannelsDto : BaseEntityDto
    {
        public string ChannelType { get; set; }//
    }
    public class ChannelsUpdateDto
    {
        public string ChannelType { get; set; }
        public UserDto UpdatedBy { get; set; }
    }
}
