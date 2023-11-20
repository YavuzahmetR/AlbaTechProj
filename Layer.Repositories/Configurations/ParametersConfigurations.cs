using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Configurations
{
    internal class ParametersConfigurations : IEntityTypeConfiguration<Parameters>
    {
        public void Configure(EntityTypeBuilder<Parameters> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.ParameterValue).IsRequired();
            builder.Property(x => x.ParameterCode).IsRequired();
            builder.Property(x => x.GroupCode).IsRequired();
        }
    }

}
