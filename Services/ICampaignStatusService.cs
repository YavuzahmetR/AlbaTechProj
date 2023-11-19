using Layer.Core.Models;

namespace Layer.Core.Services
{
    public interface ICampaignStatusService : IService<Campaigns>
    {
        void CampaignStatusToTrue(int id);
        void CampaignStatusToFalse(int id);
    }
}
