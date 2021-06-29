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

    }
}