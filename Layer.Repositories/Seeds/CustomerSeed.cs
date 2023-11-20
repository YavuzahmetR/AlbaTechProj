using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Layer.Repositories.Seeds
{
    internal class CustomerSeed : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasData(new Customers
            {
                Id = 1,
                CustomerName = "Customer1",
                CustomerNo = 1000

            });
            builder.HasData(new Customers
            {
                Id = 2,
                CustomerName = "Customer2",
                CustomerNo = 1001

            });
            builder.HasData(new Customers
            {
                Id = 3,
                CustomerName = "Customer3",
                CustomerNo = 1002

            });
            builder.HasData(new Customers
            {
                Id = 4,
                CustomerName = "Customer4",
                CustomerNo = 1003

            });
        }
    }
}
