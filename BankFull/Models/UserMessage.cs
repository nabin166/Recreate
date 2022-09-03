using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public partial class UserMessage
    {

        [Key]
        public int Id { get; set; } 
        public int? UserId { get; set; }
        public int? MessageId { get; set; }

        public virtual tblMessage? tblMessage { get; set; }
        public virtual User? User { get; set; }
    }
}
