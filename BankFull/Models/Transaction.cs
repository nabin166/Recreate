using System;
using System.Collections.Generic;

namespace BankFull.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public int? DrAmount { get; set; }
        public int? CrAmount { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
