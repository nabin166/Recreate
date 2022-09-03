using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public class Assign
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Receiver Name :" )]
        [StringLength(100)]
        public string? Receiver_Name { get; set; }
       
        public int Received_Amount { get; set; }

       
        public int Messageid { get; set; }
        
        public virtual tblMessage TblMessage { get; set; } = null!;





    }
}
