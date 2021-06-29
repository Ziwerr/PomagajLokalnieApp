using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Admin
{
    public interface IAdminService
    {
        IQueryable<Data.Models.Company> GetCompanies();
        Task AddCompany(Data.Models.Company company);
        Task DeleteCompany(int id);
        IQueryable<OfferType> GetOfferTypes();
        Task AddOfferType(OfferType offerType);
        Task DeleteOfferType(int id);
        IQueryable<User> GetUsers();
        Task AddUser(User user);
        Task DeleteUser(int id);
    }
}