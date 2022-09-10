using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public class TransactionRate
    {
        [Key]
        public int Id { get; set; }
        public float Rate { get; set; }
       
        
        public string Date { get; set; }

    }
}
