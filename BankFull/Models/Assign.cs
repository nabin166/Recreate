using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public class Assign
    {
        [Key]
        public int Id { get; set; }

        public int Receiver_Name { get; set; }
        public int Received_Amount { get; set; }

        public int Messageid { get; set; }
        
        public virtual tblMessage TblMessage { get; set; } = null!;



    }
}
