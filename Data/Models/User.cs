using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class User 
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public decimal AccountBalance { get; set; }
    }
}