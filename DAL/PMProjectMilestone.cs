//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PMProjectMilestone
    {
        public long Id { get; set; }
        public Nullable<long> ProjectId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<decimal> Budget { get; set; }
        public string MSStatus { get; set; }
        public Nullable<decimal> TeamBudget { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> TeamStartDate { get; set; }
        public Nullable<long> CompanyId { get; set; }
        public string Display { get; set; }
        public Nullable<int> ClientHours { get; set; }
        public Nullable<int> CompanyHour { get; set; }
        public Nullable<int> BaRaId { get; set; }
        public string SrsPath { get; set; }
        public string FsPath { get; set; }
        public string Analyst { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
