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
           
            UserMessages = new HashSet<UserMessage>();
            Paymentss = new HashSet<Payments>();
        }
        
        public int Id { get; set; }
        [MinLength(4)]
        [MaxLength(30)]
        [Required]
        public string? Name { get; set; }
        [MaxLength(30)]
        [Required]
        public string? Address { get; set; }
        //[DataType()]

        [MaxLength(30)]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public Boolean? Status { get; set; }
        public int? RoleId { get; set; }
        
        [Required]
        public string? Password { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<BankDetail> BankDetails { get; set; }
        
        public virtual ICollection<UserMessage> UserMessages { get; set; }
        public virtual ICollection<Payments> Paymentss { get; set; }
    }
}
