using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PomagajLokalnieApp.Pages.Admin.ViewModels;
using PomagajLokalnieApp.Pages.Admin.ViewModels.User;
using Services.Admin;

namespace PomagajLokalnieApp.Pages.Admin
{
    public class CreateUser : PageModel
    {
        private readonly IAdminService _service;
        private readonly IMapper _mapper;

        public CreateUser(IAdminService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        [BindProperty]
        public CreateUserViewModel CreateUserViewModel { get; set; }
        
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            var mapUser = _mapper.Map<User>(CreateUserViewModel);
            await _service.AddUser(mapUser);
            
            return RedirectToPage("IndexUser");
        }
    }
}