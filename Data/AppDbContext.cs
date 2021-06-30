using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DatabaseFacade DatabaseFacade { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User {Id = 1, Login = "Admin", Password = "Admin", Roles = "Admin", AccountBalance = 1000},
                    new User {Id = 2, Login = "Company", Password = "Company", Roles = "Company", AccountBalance = 1000},
                    new User {Id = 3, Login = "Client", Password = "Client", Roles = "Client", AccountBalance = 1000});
        }
    }
}