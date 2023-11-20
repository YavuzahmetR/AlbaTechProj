using Layer.Core.Models;
using Layer.Core.Repositories;
using Layer.Core.Services;
using Layer.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Service.Services
{
    public class CampaignChannelStatusService : GenericService<CampaignChannels>, ICampaignChannelsStatusService
    {
        private readonly ICampaignChannelsStatusRepository _channelsStatusRepository;
        public CampaignChannelStatusService(IGenericRepository<CampaignChannels> repository, IUnitOfWork unitofwork, ICampaignChannelsStatusRepository channelsStatusRepository) : base(repository, unitofwork)
        {
            _channelsStatusRepository = channelsStatusRepository;
        }

        public void ChangeChannelStatusToFalse(int id)
        {
            _channelsStatusRepository.ChangeChannelStatusToFalse(id);
        }

        public void ChangeChannelStatusToTrue(int id)
        {
            _channelsStatusRepository.ChangeChannelStatusToTrue(id);
        }
    }
}
