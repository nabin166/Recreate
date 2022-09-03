using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public partial class User
    {
        public User()
        {
            BankDetails = new HashSet<BankDetail>();
            Transactions = new HashSet<Transaction>();
            UserMessages = new HashSet<UserMessage>();
        }
        
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        //[DataType()]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Boolean? Status { get; set; }
        public int? RoleId { get; set; }
        public string? Password { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<BankDetail> BankDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<UserMessage> UserMessages { get; set; }
    }
}
