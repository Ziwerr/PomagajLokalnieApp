using System.Linq;
using Data.Models;

namespace Services.Client
{
    public interface IClientService
    {
        IQueryable<Offer> GetOffers();
        IQueryable<OfferType> GetOfferTypes();
        void BuyOffer(string name, int offerId);
        string GetOfferTypeName(int id);
        User GetUser(string login);
    }
}