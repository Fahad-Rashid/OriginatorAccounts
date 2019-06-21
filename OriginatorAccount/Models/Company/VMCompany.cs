using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OriginatorAccount.Models.Company
{
    public class VMCompany
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Landline { get; set; }
        public string Mobile { get; set; }
        public string FaxNo { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
        public long NTN { get; set; }
        public long STN { get; set; }
    }
}