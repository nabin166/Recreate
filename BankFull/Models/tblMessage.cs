using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankFull.Models
{
    public partial class tblMessage
    {
        public tblMessage()
        {
            UserMessages = new HashSet<UserMessage>();
            Assigns = new HashSet<Assign>();
        }
        public int Id { get; set; }
        public string? Bank { get; set; }
        public int? Amount { get; set; }
        public string? Date { get; set; }
        public string? DocumentPath { get; set; }
        public string? Messages { get; set; }
       
        [NotMapped]

        public IFormFile Document { get; set; } 


        public virtual ICollection<Assign> Assigns { get; set; }
        
        public virtual ICollection<UserMessage> UserMessages { get; set; }
    }
}
