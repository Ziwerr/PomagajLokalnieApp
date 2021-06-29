using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Anonymous;

namespace PomagajLokalnieApp.Pages.Anonymous
{
    public class Register : PageModel
    {
        private readonly IAnonymousService _anonymousService;

        public Register(IAnonymousService anonymousService, IMapper mapper)
        {
            _anonymousService = anonymousService;
        }

        [BindProperty] 
        public RegisterDto RegisterDto{ get; set; }
        public List<SelectListItem> Options { get; set; }

        
        public async Task<IActionResult> OnPost()
        {
            await _anonymousService.Register(RegisterDto);
            return RedirectToPage("Login");
        }
    }
}