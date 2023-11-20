using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Configurations
{
    internal class CustomerCampaignsConfigurations : IEntityTypeConfiguration<CustomerCampaigns>
    {
        public void Configure(EntityTypeBuilder<CustomerCampaigns> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CampaignsId).IsRequired();
            builder.Property(x => x.CustomersId).IsRequired();
            builder.HasOne(x => x.Customers).WithMany(x => x.CustomerCampaigns).HasForeignKey(x => x.CustomersId);
            builder.HasOne(x => x.Campaigns).WithMany(x => x.CustomerCampaigns).HasForeignKey(x => x.CampaignsId);
            //builder.Property(x = x.)
        }
    }
}
