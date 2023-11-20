using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;

namespace Layer.Service.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Campaigns, CampaignsDto>().ReverseMap();
            CreateMap<Customers, CustomersDto>().ReverseMap();
            CreateMap<Channels, ChannelsDto>().ReverseMap();
            CreateMap<CampaignChannels, CampaignChannelsDto>().ReverseMap();
            CreateMap<CustomerCampaigns, CustomerCampaignsDto>().ReverseMap();
            CreateMap<Customers, CustomersDto>().ReverseMap();
            CreateMap<Parameters, ParametersDto>().ReverseMap();
            CreateMap<CampaignsUpdateDto, Campaigns>().ReverseMap();
            CreateMap<Campaigns, SimpleCampaignDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
