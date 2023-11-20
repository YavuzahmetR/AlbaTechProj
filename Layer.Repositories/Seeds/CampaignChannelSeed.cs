using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Seeds
{
    internal class CampaignChannelSeed : IEntityTypeConfiguration<CampaignChannels>
    {
        public void Configure(EntityTypeBuilder<CampaignChannels> builder)
        {
            builder.HasData(new CampaignChannels
            {
                Id = 1,
                CampaignsId = 1,
                ChannelsId = 1,
                Status = true,
                CreatedDate = DateTime.Now,

            });
            builder.HasData(new CampaignChannels
            {
                Id = 2,
                CampaignsId = 1,
                ChannelsId = 2,
                Status = false,
                CreatedDate = DateTime.Now,

            });
            builder.HasData(new CampaignChannels
            {
                Id = 3,
                CampaignsId = 2,
                ChannelsId = 1,
                Status = true,
                CreatedDate = DateTime.Now,

            });
            builder.HasData(new CampaignChannels
            {
                Id = 4,
                CampaignsId = 4,
                ChannelsId = 3,
                Status = false,
                CreatedDate = DateTime.Now,

            });

        }
    }
}
