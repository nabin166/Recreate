using System;
using System.Collections.Generic;

namespace BankFull.Models
{
    public partial class BankDetail
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? Address { get; set; }
        public string? AmountIn { get; set; }
        public string? AmountOut { get; set; }
        public string? TransactionLimit { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
