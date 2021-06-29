using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PomagajLokalnieApp.Pages.Admin.ViewModels;
using Services.Admin;

namespace PomagajLokalnieApp.Pages.Admin
{
    public class CreateOfferType : PageModel
    {
        private readonly IAdminService _service;
        private readonly IMapper _mapper;

        public CreateOfferType(IAdminService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [BindProperty]
        public AddOfferTypeViewModel AddOfferTypeViewModel { get; set; }
        
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            var mapOffer = _mapper.Map<OfferType>(AddOfferTypeViewModel);
            await _service.AddOfferType(mapOffer);
            
            return RedirectToPage("IndexOfferType");
        }
    }
}