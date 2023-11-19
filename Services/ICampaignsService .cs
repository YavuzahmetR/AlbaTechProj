using Layer.Core.DTOs;
using Layer.Core.Models;

namespace Layer.Core.Services
{
    public interface ICampaignsService : IService<Campaigns>
    {
        Task<List<SimpleCampaignDto>> GetSimpleCampaignsByCustomerNo(int customerNo, int channelId);

    }

}
