using Layer.Core.Models;
using Layer.Core.Repositories;

namespace Layer.Repositories.Repositories
{
    public class CampaignStatusRepository : GenericRepository<Campaigns>, ICampaignsStatusRepository
    {
        private readonly AppDbContext _context;
        public CampaignStatusRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void CampaignStatusToFalse(int id)
        {
            Campaigns c = _context.Campaigns.Find(id);
            c.Status = false;
            _context.SaveChanges();
        }

        public void CampaignStatusToTrue(int id)
        {
            Campaigns c = _context.Campaigns.Find(id);
            c.Status = true;
            _context.SaveChanges();
        }
    }
}
