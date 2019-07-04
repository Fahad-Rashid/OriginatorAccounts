using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OriginatorAccount.Models.Transaction
{
    public class VMTransaction
    {
        public long TransactionId { get; set; }        [Required]        public string Description { get; set; }        [Required]        public decimal Amount { get; set; }        public string DefaultFrom { get; set; }        public string DefaultTo { get; set; }


    }
}