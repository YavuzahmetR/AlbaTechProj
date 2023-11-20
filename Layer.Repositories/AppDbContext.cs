using Layer.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Layer.Repositories
{
    public class AppDbContext : DbContext
    {
        //public AppDbContext()
        //{
        //}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Campaigns> Campaigns { get; set; }
        public DbSet<CampaignChannels> CampaignChannels { get; set; }
        public DbSet<Channels> Channels { get; set; }
        public DbSet<Parameters> Parameters { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomerCampaigns> CustomerCampaigns { get; set; }
        public DbSet<User> Users { get; set; }

        public override int SaveChanges()
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                entityReference.UpdatedBy = Users.First().Name;
                                break;
                            }
                    }
                }
            }
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries())
            {

                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;
                                entityReference.UpdatedDate = DateTime.Now;
                                entityReference.UpdatedBy = Users.First().Name;
                                break;


                            }
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
