using System;
using System.Linq;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Client
{
    public class ClientService : IClientService
    {
        private readonly IAppDbContext _dbContext;

        public ClientService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IQueryable<Offer> GetOffers()
        {
            return _dbContext.Offers.AsQueryable().Where(x=>x.SoftDelete==false);
        }
        
        private IQueryable<OfferType> GetOfferTypes()
        {
            return _dbContext.OfferTypes.AsQueryable();
        }

        public User GetUser(string login)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Login == login);
        }
        
        public string GetOfferTypeName(int id)
        {
            return GetOfferTypes().ToList().FirstOrDefault(x => x.Id == id).Name;
        }

        public void BuyOffer(string name, int offerId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Login == name);
            var offer = _dbContext.Offers.FirstOrDefault(x => x.Id == offerId);
                
            if (user.AccountBalance >= offer.Price)
            {
                user.AccountBalance -= offer.Price;
                offer.SoftDelete = true;
                var voucher = new Voucher()
                {
                    ExpirationDate = DateTime.Now.AddDays(90),
                    CurrentAmount = offer.Price,
                    StartAmount = offer.Price,
                    OfferId = offerId
                };
                
                _dbContext.Vouchers.Add(voucher);
                _dbContext.SaveChangesAsync();
            }
        }

        public IQueryable<Voucher> GetVoucher(string name)
        {
           return _dbContext.Vouchers.AsQueryable();
        }
        
    }
}