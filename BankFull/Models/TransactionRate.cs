using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public class TransactionRate
    {
        [Key]
        public int Id { get; set; }
        public float Rate { get; set; }
        [DataType(DataType.Date)]
         [DisplayFormat (DataFormatString =  "{0: yyyy.MM-dd}", ApplyFormatInEditMode = true )]
        public string Date { get; set; }

    }
}
