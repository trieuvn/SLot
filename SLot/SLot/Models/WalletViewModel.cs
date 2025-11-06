using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SLot.Models
{
    public class WalletViewModel
    {
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }

    public class Transaction
    {
        public string Type { get; set; } // "Nạp tiền vào Ví", "Rút tiền",...
        public decimal Amount { get; set; }
        public string DateTime { get; set; }
    }
}