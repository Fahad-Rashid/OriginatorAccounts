using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OriginatorAccount.Models.UserSubAccount
{
    public class VMUserSubAccount
    {
        public long Id { get; set; }
        public string AccountNumber { get; set; }
        public string SubAccountName { get; set; }
        public long DefaultToId { get; set; }
        public long DefaultFromId { get; set; }
        public string ToAssociatedId { get; set; }
        public string FromAssociatedId { get; set; }
    }
}