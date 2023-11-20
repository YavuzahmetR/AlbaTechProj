using AutoMapper;
using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Repositories;
using Layer.Core.Services;
using Layer.Core.UnitOfWork;
using Layer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Layer.Service.Services
{
    public class CampaignService : GenericService<Campaigns>, ICampaignsService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerCampaignsRepository _customerCampaignsRepository;
        private readonly AppDbContext _context;

        public CampaignService(
           IMapper mapper,
    IGenericRepository<Campaigns> repository,
    IUnitOfWork unitOfWork,
    ICustomerCampaignsRepository customerCampaignsRepository,
    AppDbContext context)
            : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _customerCampaignsRepository = customerCampaignsRepository;
            _context = context;
        }

        public async Task<List<SimpleCampaignDto>> GetSimpleCampaignsByCustomerNo(int customerNo, int channelId)
        {


            var customerCampaigns = await _customerCampaignsRepository.GetCampaignsByCustomerNo(customerNo, channelId);
            var campaignIds = customerCampaigns.Select(cc => cc.CampaignsId).ToList();

            var campaigns = await Where(c => campaignIds.Contains(c.Id) && c.Status && c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now).ToListAsync();
            if (campaigns == null)
            {
                return null;
            }

            var generalCampaigns = await Where(c => c.CampaignType == "Genel Kampanya" && c.Status && c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now).ToListAsync();


            var result = campaigns.Union(generalCampaigns).ToList();

            var campaignChannels = await _context.CampaignChannels.Include(c => c.Campaigns).Where(c => c.ChannelsId == channelId).ToListAsync();
            var campaignChannleIds = campaignChannels.Select(cc => cc.CampaignsId).ToList();


            var x = result.Where(d => campaignChannleIds.Contains(d.Id) && d.Status).ToList();

            var x_Map = _mapper.Map<List<SimpleCampaignDto>>(x);
            var response = ResponseDto<List<SimpleCampaignDto>>.Success(x_Map, 200);
            return response.Data;
        }
    }
}
