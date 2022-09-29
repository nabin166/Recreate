using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankFull.Models
{
    public partial class Transaction
    {
     
        public int Id { get; set; }
        public string? Date { get; set; }
        public int? DrAmount { get; set; }
        public int? CrAmount { get; set; }
        public int? MessageId { get; set; }

        


        public virtual tblMessage TblMessage { get; set; }
    }
}
