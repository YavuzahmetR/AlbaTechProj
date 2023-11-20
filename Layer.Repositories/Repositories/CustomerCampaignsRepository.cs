using Layer.Core.DTOs;
using Layer.Core.Models;
using Layer.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Layer.Repositories.Repositories
{
    public class CustomerCampaignsRepository : GenericRepository<CustomerCampaigns>, ICustomerCampaignsRepository
    {
        public CustomerCampaignsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<CustomerCampaignsDto>> GetCampaignsByCustomerNo(int customerNo, int channelId)
        {
            var customerCampaigns = await _context.CustomerCampaigns.Where(cc => cc.Customers.CustomerNo == customerNo).Select(
                cc => new CustomerCampaignsDto { CampaignsId = cc.CampaignsId, CustomersId = cc.CustomersId }).ToListAsync();
            if (customerCampaigns == null || customerCampaigns.Count == 0)
            {
                throw new Exception("Müşteri numarasına uygun kampanya bulunamadı.");
            }
            return customerCampaigns;
        }
    }
}
