using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Seeds
{
    internal class CampaignSeed : IEntityTypeConfiguration<Campaigns>
    {
        private Parameters parameterGeneral = new Parameters() { ParameterCode = "General" };
        private Parameters parameterCustomer = new Parameters() { ParameterCode = "CustomerSpecial" };
        public void Configure(EntityTypeBuilder<Campaigns> builder)
        {
            builder.HasData(new Campaigns
            {
                Id = 1,
                Name = "Test Kampanya 1",
                Status = true,
                Priority = 10,
                CampaignType = parameterGeneral.ParameterCode,
                CreatedDate = DateTime.Now,
                StartDate = new DateTime(23, 1, 12),
                EndDate = new DateTime(23, 6, 12),

            });
            builder.HasData(new Campaigns
            {
                Id = 2,
                Name = "Test Kampanya 2",
                Status = false,
                Priority = 20,
                CampaignType = parameterCustomer.ParameterCode,
                CreatedDate = DateTime.Now,
                StartDate = new DateTime(23, 8, 15),
                EndDate = new DateTime(23, 9, 15),

            });
            builder.HasData(new Campaigns
            {
                Id = 3,
                Name = "Test Kampanya 3",
                Status = true,
                Priority = 30,
                CampaignType = parameterGeneral.ParameterCode,
                CreatedDate = DateTime.Now,
                StartDate = new DateTime(22, 3, 12),
                EndDate = new DateTime(23, 4, 12),

            });
            builder.HasData(new Campaigns
            {
                Id = 4,
                Name = "Test Kampanya 4",
                Status = false,
                Priority = 40,
                CampaignType = parameterCustomer.ParameterCode,
                CreatedDate = DateTime.Now,
                StartDate = new DateTime(23, 6, 20),
                EndDate = new DateTime(23, 9, 10),

            });
        }
    }
}
