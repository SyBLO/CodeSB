using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceDT.Server.Models;
using ServiceDT.Shared.Models;

namespace ServiceDT.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {             

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<SuiviBE> SuiviBEs { get; set; }
        public DbSet<ActionItem> ActionItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<ActionItem>()
                  //.HasNoKey()
                  .HasOne(d => d.SuiviBE)
                  .WithMany(d => d.ActionItems);
        }


    }
}