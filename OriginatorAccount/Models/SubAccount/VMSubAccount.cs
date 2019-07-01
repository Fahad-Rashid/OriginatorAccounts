using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OriginatorAccount.Models.SubAccount
{
    public class VMSubAccount
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string SubAccountName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public long AccountId { get; set; }
        public long TypeId { get; set; }
        public string AccountNumber { get; set; }
        public string SubTypeName { get; set; }


    }
}