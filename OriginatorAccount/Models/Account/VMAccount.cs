using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OriginatorAccount.Models.Account
{
    public class VMAccount
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Source { get; set; }


    }
}