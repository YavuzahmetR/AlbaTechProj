using Layer.Core.Models;
using Layer.Core.Repositories;
using Layer.Core.Services;
using Layer.Core.UnitOfWork;

namespace Layer.Service.Services
{
    public class CampaignStatusService : GenericService<Campaigns>, ICampaignStatusService
    {
        private readonly ICampaignsStatusRepository _campaignsStatus;
        public CampaignStatusService(IGenericRepository<Campaigns> repository, IUnitOfWork unitofwork, ICampaignsStatusRepository campaignsStatus) : base(repository, unitofwork)
        {
            _campaignsStatus = campaignsStatus;
        }

        public void CampaignStatusToFalse(int id)
        {
            _campaignsStatus.CampaignStatusToFalse(id);
        }

        public void CampaignStatusToTrue(int id)
        {
            _campaignsStatus.CampaignStatusToTrue(id);
        }
    }
}
