using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OriginatorAccount.Models.UserSubAccount
{
    public class VMUserSubAccountParent
    {
        public IEnumerable<VMUserSubAccount> UserSubAccounts { get; set; }
        public long UserId { get; set; }
    }
}