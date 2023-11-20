using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Configurations
{
    internal class ChannelsConfigurations : IEntityTypeConfiguration<Channels>
    {
        public void Configure(EntityTypeBuilder<Channels> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ChannelType).IsRequired();
        }
    }

}
