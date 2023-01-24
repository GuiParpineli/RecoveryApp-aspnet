using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RecoveryApp_ASPNET.Models;
using RecoveryApp_ASPNET.Models.PlanModel;
using RecoveryApp_ASPNET.Models.PlanModel.CaseModel;

namespace RecoveryApp_ASPNET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Plan> Plans { get;set; }
        public DbSet<PlanCase> PlanCases { get; set; }
        public DbSet<Missappropriation> Missappropriations { get; set; }
        public DbSet<Sinistro> Sinistros { get; set; }
        public DbSet<TechnicalSupport> TechnicalSupports { get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasOne(a => a.Address)
                .WithMany(a => a.Customers);


            builder.Entity<PlanCase>()
                .HasKey(p => new { p.PlanId, p.CaseId });

            new DbInitializer(builder).Seed();
        }
    }
}
