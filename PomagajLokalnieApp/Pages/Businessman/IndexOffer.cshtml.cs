using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PomagajLokalnieApp.Pages.Businessman.ViewModel;
using Services.Company;

namespace PomagajLokalnieApp.Pages.Businessman
{
    [Authorize(Roles = "Company")]
    public class IndexOffer : PageModel
    {
        private readonly IBusinessmanService _businessmanService;

        public IndexOffer(IBusinessmanService businessmanService)
        {
            _businessmanService = businessmanService;
        }

        [BindProperty] 
        public ICollection<OfferViewModel> OfferCollection { get; } = new List<OfferViewModel>();
        
        public async Task OnGet()
        {
            var offers = _businessmanService.GetOffers().ToList();

            foreach (var offer in offers)
            {
                var offerTypeName = _businessmanService.GetOfferTypeName(offer.OfferTypeId);
                OfferViewModel offerViewModel = new OfferViewModel
                {
                    Id = offer.Id,
                    Description = offer.Description,
                    Name = offer.Name,
                    OfferTypeName = offerTypeName,
                    Price = offer.Price,
                    SoftDelete = offer.SoftDelete
                };
                OfferCollection.Add(offerViewModel);
            }
        }
        
        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _businessmanService.DeleteOffer(id);
            return RedirectToPage("IndexOffer");
        }
    }
}