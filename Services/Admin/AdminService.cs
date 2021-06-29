using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IAppDbContext _dbContext;
        public AdminService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Data.Models.Company> GetCompanies()
        {
            return _dbContext.Companies.AsQueryable();
        }

        public async Task AddCompany(Data.Models.Company company)
        {
            var newCompany = new Data.Models.Company
            {
                Name = company.Name,
                BankAccount = company.BankAccount,
                NIP = company.NIP,
            };
            await _dbContext.Companies.AddAsync(newCompany);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteCompany(int id)
        {
            var company = await GetCompanies().FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Companies.Remove(company);
            await _dbContext.SaveChangesAsync();
        }
        
        public IQueryable<OfferType> GetOfferTypes()
        {
            return _dbContext.OfferTypes.AsQueryable();
        }
        
        public async Task AddOfferType(OfferType offerType)
        {
            var newOffer = new OfferType
            {
                Name = offerType.Name,
                Description = offerType.Description
            };
            await _dbContext.OfferTypes.AddAsync(newOffer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOfferType(int id)
        {
            var offerType = await GetOfferTypes().FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.OfferTypes.Remove(offerType);
            await _dbContext.SaveChangesAsync();
        }
        
        public IQueryable<User> GetUsers()
        {
            return _dbContext.Users.AsQueryable();
        }
        
        public async Task AddUser(User user)
        {
            var newUser = new User
            {
                Login = user.Login,
                Password = user.Password,
                Roles = user.Roles
            };
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteUser(int id)
        {
            var user = await GetUsers().FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}