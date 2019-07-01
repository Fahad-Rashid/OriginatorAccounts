using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Company
{
   public class CompanyHandler
    {
        public List<tblCompany> GetCompanies()
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblCompanies
                        where data.IsDeleted != true
                        select data).ToList();
            }
        }
        public tblCompany GetCompanyById(long Id)        {            using (OriginatorEntities db = new OriginatorEntities())            {                return (from data in db.tblCompanies                        where data.Id == Id                        select data).FirstOrDefault();            }        }        public void AddCompany(tblCompany company)        {            using (OriginatorEntities db = new OriginatorEntities())            {                db.tblCompanies.Add(company);                db.SaveChanges();                tblAccount Account = new tblAccount { AccountName = "Initial Cash", CompanyId = company.Id, Description = "Initial Cash Account", Source = "Cash", CreatedDate = DateTime.Now, CreatedBy = company.CreatedBy };                db.tblAccounts.Add(Account);                db.SaveChanges();                tblSubAccount SubAccount = new tblSubAccount { SubAccountName = "Initial Cash", Description = "Initial Cash SubAccount", Amount = 0, AccountId = Account.Id, AccountNumber = "Initial Cash " + company.Name, CompanyId = company.Id, CreatedBy = company.CreatedBy, CreatedDate = DateTime.Now, TypeId = 8  };                db.tblSubAccounts.Add(SubAccount);                db.SaveChanges();            }        }        public void UpdateCompany(long id, tblCompany company)
        {            using (OriginatorEntities db = new OriginatorEntities())            {                tblCompany found = db.tblCompanies.Find(id);                if (!string.IsNullOrWhiteSpace(company.Name)) found.Name = company.Name;                if (!string.IsNullOrWhiteSpace(company.Street)) found.Street = company.Street;                if (!string.IsNullOrWhiteSpace(company.City)) found.City = company.City;                if (!string.IsNullOrWhiteSpace(company.Country)) found.Country = company.Country;                if (!string.IsNullOrWhiteSpace(company.Landline)) found.Landline = company.Landline;                if (!string.IsNullOrWhiteSpace(company.Mobile)) found.Mobile = company.Mobile;                if (!string.IsNullOrWhiteSpace(company.FaxNo)) found.FaxNo = company.FaxNo;                if (!string.IsNullOrWhiteSpace(company.Website)) found.Website = company.Website;                if (!string.IsNullOrWhiteSpace(company.NTN.ToString())) found.NTN = company.NTN;                if (!string.IsNullOrWhiteSpace(company.STN.ToString())) found.STN = company.STN;                if (company.ModifiedBy != null && company.ModifiedBy > 0) found.ModifiedBy = company.ModifiedBy;                if (!string.IsNullOrWhiteSpace(company.ModifiedDate.ToString())) found.ModifiedDate = company.ModifiedDate;                db.SaveChanges();            }        }        public void DeleteCompany(long Id, long DeletedBy)        {            using (OriginatorEntities db = new OriginatorEntities())            {                tblCompany found = db.tblCompanies.Find(Id);                found.DeletedBy = DeletedBy;                found.DeletedDate = DateTime.Now;                found.IsDeleted = true;                db.SaveChanges();            }        }
    }
}
