using Layer.Core.DTOs;
using Layer.Core.Models;

namespace Layer.Core.Repositories
{
    public interface ICustomerCampaignsRepository : IGenericRepository<CustomerCampaigns>
    {
        Task<List<CustomerCampaignsDto>> GetCampaignsByCustomerNo(int customerNo, int channelId);

    }
}