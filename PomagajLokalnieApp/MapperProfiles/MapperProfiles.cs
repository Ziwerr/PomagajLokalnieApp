using AutoMapper;
using Data.Models;
using PomagajLokalnieApp.Pages.Admin.ViewModels;
using PomagajLokalnieApp.Pages.Admin.ViewModels.User;
using PomagajLokalnieApp.Pages.Annonymous.ViewModels;
using PomagajLokalnieApp.Pages.Businessman.ViewModel;
using Services.Anonymous;

namespace PomagajLokalnieApp.MapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Company, CompanyViewModel>();
            CreateMap<AddCompanyViewModel, Company>();
            
            CreateMap<OfferType, OfferTypeViewModel>();
            CreateMap<AddOfferTypeViewModel, OfferType>();
            
            CreateMap<User, UserViewModel>();
            CreateMap<CreateUserViewModel, User>();
            
            CreateMap<LoginDto, User>();

            CreateMap<CreateOfferViewModel, Offer>();
        }
    }
}