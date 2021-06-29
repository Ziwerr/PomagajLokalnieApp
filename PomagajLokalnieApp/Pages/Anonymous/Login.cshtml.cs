using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PomagajLokalnieApp.Pages.Annonymous.ViewModels;
using Services.Anonymous;

namespace PomagajLokalnieApp.Pages.Anonymous
{
    public class Login : PageModel
    {
        private readonly IAnonymousService _service;
        private readonly IMapper _mapper;

        public Login(IAnonymousService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        public void OnGet()
        {
            
        }
        
        [BindProperty] 
        public LoginDto LoginDto { get; set; }
        
        public async Task<IActionResult> OnPost()
        {
            if(await _service.Login(LoginDto))
            {
                var signInUser = await _service.GetUserFromLogin(LoginDto);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, GetPrincipal(signInUser));
                if (signInUser.Roles=="Admin")
                {
                    return RedirectToPage("/Admin/IndexUser");
                }
                if (signInUser.Roles=="Company")
                {
                    return RedirectToPage("/Businessman/IndexOffer");
                }
                return RedirectToPage("/Client/IndexOfferForClient");
            }
            return RedirectToPage("Login");
        }
        
        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("Login");
        }
        
        public static ClaimsPrincipal GetPrincipal(User user)
        {
            var claims = new[] 
            {
                new Claim(ClaimTypes.Name,user.Login), 
                new Claim(ClaimTypes.Role, user.Roles)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); 
         
            return new ClaimsPrincipal(identity);
        }
    }
}