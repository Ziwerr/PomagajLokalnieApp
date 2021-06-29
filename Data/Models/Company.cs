using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Company 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string BankAccount { get; set; }
        public bool SoftDelete { get; set; }
    }
}