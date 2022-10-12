using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankFull.Models
{
    public partial class tblMessage
    {
        public tblMessage()
        {
            UserMessages = new HashSet<UserMessage>();

            Transactions = new HashSet<Transaction>();
         
        }
        public int Id { get; set; }
        //  public string? Bank { get; set; }
       
        
        public int? BankId { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        [Required]
        public string? Date { get; set; }
        [Display(Name = "Document Path")]

        public string? DocumentPath { get; set; }
        [Required]
        public string? Messages { get; set; }
        public Boolean completed { get; set; }
       
     //   [NotMapped]

    //    public IFormFile Document { get; set; }

        public virtual BankDetail? BankDetail { get; set; }
    
        public virtual ICollection<Transaction> Transactions { get; set; }
        
        public virtual ICollection<UserMessage> UserMessages { get; set; }
    }
}
