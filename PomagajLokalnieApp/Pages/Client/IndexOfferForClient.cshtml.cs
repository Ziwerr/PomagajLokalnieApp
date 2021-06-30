using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PomagajLokalnieApp.Pages.Businessman.ViewModel;
using Services.Client;

namespace PomagajLokalnieApp.Pages.Client
{
    [Authorize(Roles = "Client")]
    public class IndexOfferForClient : PageModel
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public IndexOfferForClient(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [BindProperty] 
        public ICollection<OfferViewModel> OfferCollection { get; } = new List<OfferViewModel>();

        [BindProperty]
        public decimal Ammount { get; set; }

        public ICollection<Voucher> VoucherAmmount { get; set; }
        
        public void OnGet()
        {
            var offers = _clientService.GetOffers().ToList();
            Ammount = _clientService.GetUser(HttpContext.User.Identity?.Name).AccountBalance;
            VoucherAmmount = _clientService.GetVoucher(HttpContext.User.Identity.Name).ToList();
            foreach (var offer in offers)
            { 
                var offerTypeName = _clientService.GetOfferTypeName(offer.OfferTypeId);
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
        
        public IActionResult OnPostBuy(string name, int id)
        {
            _clientService.BuyOffer(name, id);
            return RedirectToPage("IndexOfferForClient");
        }
    }
}