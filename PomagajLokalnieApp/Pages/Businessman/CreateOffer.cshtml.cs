using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PomagajLokalnieApp.Pages.Businessman.ViewModel;
using Services.Company;

namespace PomagajLokalnieApp.Pages.Businessman
{
    [Authorize(Roles = "Company")]
    public class CreateOffer : PageModel
    {
        private readonly IBusinessmanService _businessmanService;
        private readonly IMapper _mapper;

        public CreateOffer(IBusinessmanService businessmanService, IMapper mapper)
        {
            _businessmanService = businessmanService;
            _mapper = mapper;
        }
        
        [BindProperty]
        public CreateOfferViewModel CreateOfferViewModel { get; set; }
        public List<SelectListItem> Options { get; set; }
        
        public void OnGet()
        {
            Options = _businessmanService.GetOfferTypes().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            var mapOffer = _mapper.Map<Offer>(CreateOfferViewModel);
            await _businessmanService.AddOffer(mapOffer);
            
            return RedirectToPage("IndexOffer");
        }
    }
}