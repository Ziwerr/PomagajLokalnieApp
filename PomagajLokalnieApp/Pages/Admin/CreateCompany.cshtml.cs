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
    public class CreateCompany : PageModel
    {
        private readonly IAdminService _service;
        private readonly IMapper _mapper;

        public CreateCompany(IAdminService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [BindProperty]
        public AddCompanyViewModel AddCompanyViewModel { get; set; }
        
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            var mapCompany = _mapper.Map<Company>(AddCompanyViewModel);
            await _service.AddCompany(mapCompany);
            
            return RedirectToPage("IndexCompany");
        }
    }
}