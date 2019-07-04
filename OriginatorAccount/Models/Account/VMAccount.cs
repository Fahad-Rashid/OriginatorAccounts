using OriginatorAccount.CustomAnnotation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginatorAccount.Models.Account
{
    public class VMAccount
    {
        public long Id { get; set; }
        [Required]
        public string AccountName { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }


    }
}