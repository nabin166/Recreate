﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public partial class BankDetail
    {
        public BankDetail()
        {
            TblMessages = new HashSet<tblMessage>();
        }
        public int Id { get; set; }

        [MinLength(1)]
        [MaxLength(30)]
        [Required]
        [Display(Name = "Bank Name")]
        public string? Name { get; set; }
        [Required]
        public string? AccountNumber { get; set; }
        [Required]
        public string? AccountName { get; set; }
        [Required]
        public string? Address { get; set; }
       // public string? AmountIn { get; set; }
       // public string? AmountOut { get; set; }
        public string? TransactionLimit { get; set; }
        [Required]
        public int? UserId { get; set; }


        public virtual ICollection<tblMessage> TblMessages { get; set; }
        public virtual User? User { get; set; }
    }
}
