using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Data.Models;

namespace Services.Company
{
    public interface IBusinessmanService
    {
        IQueryable<Offer> GetOffers();
        Task AddOffer(Offer offer);
        Task DeleteOffer(int id);
        IQueryable<OfferType> GetOfferTypes();
        string GetOfferTypeName(int id);
    }
}