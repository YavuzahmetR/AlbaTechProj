using Layer.Core.Models;
using Layer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Repositories.Repositories
{
    public class CampaignChannelStatusRepository : GenericRepository<CampaignChannels>, ICampaignChannelsStatusRepository
    {
        private readonly AppDbContext _context;
        public CampaignChannelStatusRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void ChangeChannelStatusToFalse(int id)
        {
            CampaignChannels cc = _context.CampaignChannels.Find(id);
            cc.Status = false;
            _context.SaveChanges();
        }

        public void ChangeChannelStatusToTrue(int id)
        {

            CampaignChannels cc = _context.CampaignChannels.Find(id);
            cc.Status = true;
            _context.SaveChanges();
        }
    }
}
