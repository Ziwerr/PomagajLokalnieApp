using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Offer")]
        public int OfferId { get; set; }
        public decimal StartAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
        [ForeignKey("User")] 
        public int UserId { get; set; }
    }
}