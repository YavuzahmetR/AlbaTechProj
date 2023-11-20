using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Seeds
{
    internal class CustomerCampaignSeed : IEntityTypeConfiguration<CustomerCampaigns>
    {
        public void Configure(EntityTypeBuilder<CustomerCampaigns> builder)
        {
            builder.HasData(new CustomerCampaigns
            {
                Id = 1,
                CustomersId = 1,
                CampaignsId = 4,
                CreatedDate = DateTime.Now,



            });
            builder.HasData(new CustomerCampaigns
            {
                Id = 2,
                CustomersId = 2,
                CampaignsId = 3,
                CreatedDate = DateTime.Now,


            });
            builder.HasData(new CustomerCampaigns
            {
                Id = 3,
                CustomersId = 3,
                CampaignsId = 3,
                CreatedDate = DateTime.Now,


            });
            builder.HasData(new CustomerCampaigns
            {
                Id = 4,
                CustomersId = 4,
                CampaignsId = 2,
                CreatedDate = DateTime.Now,


            });

        }
    }
}
