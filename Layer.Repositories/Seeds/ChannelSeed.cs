using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Seeds
{
    internal class ChannelSeed : IEntityTypeConfiguration<Channels>
    {
        public void Configure(EntityTypeBuilder<Channels> builder)
        {
            builder.HasData(new Channels
            {
                Id = 1,
                ChannelType = "MOBIL"
            });
            builder.HasData(new Channels
            {
                Id = 2,
                ChannelType = "WEB"
            });
            builder.HasData(new Channels
            {
                Id = 3,
                ChannelType = "EMAIL"
            });
            builder.HasData(new Channels
            {
                Id = 4,
                ChannelType = "SMS"
            });
        }
    }
}
