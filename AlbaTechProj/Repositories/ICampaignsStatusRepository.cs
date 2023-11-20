using Layer.Core.Models;

namespace Layer.Core.Repositories
{
    public interface ICampaignsStatusRepository : IGenericRepository<Campaigns>
    {
        void CampaignStatusToTrue(int id);
        void CampaignStatusToFalse(int id);
    }
}
