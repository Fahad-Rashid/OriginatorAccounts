using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OriginatorAccount.Models.Employee
{
    public class VMEmployee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public HttpPostedFileBase ImageUrl { get; set; }
        public float Salary { get; set; }
        public string Designation { get; set; }


    }
}