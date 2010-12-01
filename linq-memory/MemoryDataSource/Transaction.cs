using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace boring.bank.datasource
{
    public partial class Transaction
    {
        public int? Id { get; set; }
        public decimal Amount { get; set; }
        public string Title { get; set; }
        public DateTime ValueDate { get; set; }
        public string Currency { get; set; }
        public Client CreditClient { get; set; }
        public Client DebitClient { get; set; }
    }
}
