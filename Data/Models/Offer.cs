using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("OfferType")]
        public int OfferTypeId{ get; set; }
        public decimal Price { get; set; }
        public bool SoftDelete { get; set; }
    }
}