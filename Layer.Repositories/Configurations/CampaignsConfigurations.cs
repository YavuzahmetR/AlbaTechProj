using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Configurations
{
    internal class CampaignsConfigurations : IEntityTypeConfiguration<Campaigns>
    {
        public void Configure(EntityTypeBuilder<Campaigns> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Priority).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CampaignType).IsRequired();

        }
    }
}
