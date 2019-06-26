using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OriginatorAccount.Models.User
{
    public class VMUser
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public string Company { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

        public HttpPostedFileBase ImageUrl { get; set; }

    }
}