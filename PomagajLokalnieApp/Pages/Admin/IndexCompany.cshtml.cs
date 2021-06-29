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
    public class IndexCompany : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _service;

        public IndexCompany(IMapper mapper, IAdminService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public ICollection<CompanyViewModel> CompanyCollection { get; set; }
        
        public void OnGet()
        {
            var companies = _service.GetCompanies();
            var mapCompany = _mapper.Map<ICollection<CompanyViewModel>>(companies);
            CompanyCollection = mapCompany;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _service.DeleteCompany(id);
            return RedirectToPage("Index");
        }
    }
}