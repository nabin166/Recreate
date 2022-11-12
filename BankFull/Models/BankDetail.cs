using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public partial class BankDetail
    {
        private string? accountNumber;
        

        public BankDetail()
        {
            TblMessages = new HashSet<tblMessage>();
        }
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(30)]
        [Required]
        [Display(Name = "बैंक नाम")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Account Number")]
        public string? AccountNumber { get => accountNumber; set => accountNumber = value; }
        [Required]
        [Display(Name = "खातावाला नाम")]
        public string? AccountName { get; set; }
        [Required]
        public string? Address { get; set; }
        // public string? AmountIn { get; set; }
        // public string? AmountOut { get; set; }
       // [Display(Name = "Transaction Limit")]
      //  public string TransactionLimit { get; set; }

        public int? UserId { get; set; }

        public  virtual string CheckName { get => Name +"("+ AccountNumber+")";  } 
        public virtual ICollection<tblMessage> TblMessages { get; set; }
        public virtual User? User { get; set; }
    }
}
