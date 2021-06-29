using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Company
{
    public class BusinessmanService : IBusinessmanService
    {
        private readonly IAppDbContext _dbContext;

        public BusinessmanService(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Offer> GetOffers()
        {
            return _dbContext.Offers.AsQueryable();
        }
        public IQueryable<OfferType> GetOfferTypes()
        {
            return _dbContext.OfferTypes.AsQueryable();
        }

        public string GetOfferTypeName(int id)
        {
            return GetOfferTypes().ToList().FirstOrDefault(x => x.Id == id).Name;
        }

        public async Task AddOffer(Offer offer)
        {
            var offerTypeId = _dbContext.OfferTypes.FirstOrDefault(x => x.Id == offer.OfferTypeId).Id;
            var newOffer = new Offer
            {
                Name = offer.Name,
                Description = offer.Description,
                OfferTypeId = offerTypeId,
                Price = offer.Price,
                SoftDelete = false
            };
            
            await _dbContext.Offers.AddAsync(newOffer);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteOffer(int id)
        {
            var offer = await GetOffers().FirstOrDefaultAsync(x=>x.Id == id);
            
            _dbContext.Offers.Remove(offer);
            await _dbContext.SaveChangesAsync();
        }
    }
}