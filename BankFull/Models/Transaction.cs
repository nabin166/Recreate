using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public partial class Transaction
    {
     
        public int Id { get; set; }
        public string? Date { get; set; }
        [Display(Name = "Debit Amount")]
        public decimal? DrAmount { get; set; }
        [Display(Name = "Credit Amount")]
        public decimal? CrAmount { get; set; }
        public int? MessageId { get; set; }

        


        public virtual tblMessage TblMessage { get; set; }
    }
}
