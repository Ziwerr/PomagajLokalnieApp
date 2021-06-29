using Data.Models;

namespace PomagajLokalnieApp.Pages.Businessman.ViewModel
{
    public class OfferViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OfferTypeName { get; set; }
        public decimal Price { get; set; }
        public bool SoftDelete { get; set; }
        
    }
    
}