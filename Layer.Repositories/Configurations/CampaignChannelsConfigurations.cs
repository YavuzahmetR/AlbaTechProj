using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Configurations
{
    internal class CampaignChannelsConfigurations : IEntityTypeConfiguration<CampaignChannels>
    {
        public void Configure(EntityTypeBuilder<CampaignChannels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CampaignsId).IsRequired();
            builder.Property(x => x.ChannelsId).IsRequired();
            builder.HasOne(x => x.Channels).WithMany(x => x.CampaignChannels).HasForeignKey(x => x.ChannelsId);
            builder.HasOne(x => x.Campaigns).WithMany(x => x.CampaignChannels).HasForeignKey(x => x.CampaignsId);
        }
    }

}
