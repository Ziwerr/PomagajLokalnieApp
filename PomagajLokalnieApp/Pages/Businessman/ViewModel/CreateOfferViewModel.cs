using System.Collections.Generic;
using Data.Models;

namespace PomagajLokalnieApp.Pages.Businessman.ViewModel
{
    public class CreateOfferViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int OfferTypeId { get; set; }
        public string OfferTypeName { get; set; }
        public decimal Price { get; set; }
    }
}