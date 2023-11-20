using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Seeds
{
    internal class ParameterSeed : IEntityTypeConfiguration<Parameters>
    {
        public void Configure(EntityTypeBuilder<Parameters> builder)
        {
            builder.HasData(new Parameters
            {
                Id = 1,
                GroupCode = "GeneralCampaigns",
                ParameterCode = "Public",
                ParameterValue = "Genel Kampanya",
                Description = "Description1"

            });
            builder.HasData(new Parameters
            {
                Id = 2,
                GroupCode = "CustomerCampaigns",
                ParameterCode = "Private",
                ParameterValue = "Müşteri Bazlı Kampanya",
                Description = "Description2"

            });
        }
    }
}
