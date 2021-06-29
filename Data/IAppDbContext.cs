using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Data
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Offer> Offers { get; set; }
        DbSet<OfferType> OfferTypes { get; set; }
        DbSet<Voucher> Vouchers { get; set; }
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
    }
}