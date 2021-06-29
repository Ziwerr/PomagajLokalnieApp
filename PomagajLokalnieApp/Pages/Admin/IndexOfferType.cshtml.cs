using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PomagajLokalnieApp.Pages.Admin.ViewModels;
using Services;
using Services.Admin;

namespace PomagajLokalnieApp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexOfferType : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _service;

        public IndexOfferType(IMapper mapper, IAdminService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public ICollection<OfferTypeViewModel> OfferTypeCollection { get; set; }
        
        public void OnGet()
        {
            var offersTypes = _service.GetOfferTypes();
            var mapOffers = _mapper.Map<ICollection<OfferTypeViewModel>>(offersTypes);
            OfferTypeCollection = mapOffers;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _service.DeleteOfferType(id);
            return RedirectToPage("IndexOfferType");
        }
    }
}