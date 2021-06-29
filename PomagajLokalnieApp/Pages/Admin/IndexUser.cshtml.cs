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
using PomagajLokalnieApp.Pages.Admin.ViewModels.User;
using Services;
using Services.Admin;

namespace PomagajLokalnieApp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexUser : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _service;

        public IndexUser(IMapper mapper, IAdminService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public ICollection<UserViewModel> UserCollection { get; set; }
        
        public void OnGet()
        {
            var users = _service.GetUsers();
            var mapUsers = _mapper.Map<ICollection<UserViewModel>>(users);
            UserCollection = mapUsers;
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _service.DeleteUser(id);
            return RedirectToPage("IndexUser");
        }
    }
}