using System.Linq;
using Data.Models;

namespace Services.Client
{
    public interface IClientService
    {
        IQueryable<Offer> GetOffers();
        void BuyOffer(string name, int offerId);
        string GetOfferTypeName(int id);
        User GetUser(string login);
        IQueryable<Voucher> GetVoucher(string name);
    }
}