using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public partial class AdminBank
    {
        private string? accountNumber;
        [Key]
        public int Id { get; set; }
       
        [Display(Name = "Bank Address")]
        [Required]
        
        public string Address { get; set; }

        [Display(Name = "Bank Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Ammount ")]
        public decimal Ammount { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public string? AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string CheckName { get => Name + "(" + AccountNumber + ")"; }

    }
}
