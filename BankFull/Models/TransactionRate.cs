using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public class TransactionRate
    {
        [Key]
        public int Id { get; set; }
        public decimal Rate { get; set; }   
        public string Date { get; set; }

    }
}
