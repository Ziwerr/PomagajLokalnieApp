using System.ComponentModel.DataAnnotations;

namespace PomagajLokalnieApp.Pages.Admin.ViewModels.User
{
    public class CreateUserViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
    }
}