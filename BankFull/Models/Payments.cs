using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public class Payments
    {
        [Key]
        public int Id { get; set; }
      
        public decimal Payment { get; set; }
        public int? UserId { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public string Datetime { get; set; } = DateTime.Now.ToString();
        public decimal? Rate { get; set; } 
        public string? AdminBank { get; set; }
        public virtual User? User { get; set; }
    }
}
