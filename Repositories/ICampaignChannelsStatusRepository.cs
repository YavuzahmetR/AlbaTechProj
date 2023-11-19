using Layer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Core.Repositories
{
    public interface ICampaignChannelsStatusRepository : IGenericRepository<CampaignChannels>
    {
        void ChangeChannelStatusToTrue(int id);
        void ChangeChannelStatusToFalse(int id);
    }
}
