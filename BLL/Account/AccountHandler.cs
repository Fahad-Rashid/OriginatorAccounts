using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Account
{
   public class AccountHandler
    {
        public List<tblAccount> GetAccounts()
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblAccounts
                        where data.IsDeleted != true
                        select data).ToList();
            }
        }

        public void AddAccount(tblAccount Account)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                db.tblAccounts.Add(Account);
                db.SaveChanges();
            }
        }

        public tblAccount GetAccountById(long Id)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblAccounts
                        where data.Id == Id
                        select data).FirstOrDefault();
            }
        }

        public void UpdateAccount(long id, tblAccount account)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                tblAccount found = db.tblAccounts.Find(id);
                if (!string.IsNullOrWhiteSpace(account.AccountName)) found.AccountName = account.AccountName;
                if (!string.IsNullOrWhiteSpace(account.Description)) found.Description = account.Description;
                if (!string.IsNullOrWhiteSpace(account.Amount.ToString())) found.Amount = account.Amount;
                if (!string.IsNullOrWhiteSpace(account.Source.ToString())) found.Source = account.Source;
                if (account.CompanyId != null && account.CompanyId > 0) found.CompanyId = account.CompanyId;
                if (account.ModifiedBy != null && account.ModifiedBy > 0) found.ModifiedBy = account.ModifiedBy;
                if (!string.IsNullOrWhiteSpace(account.ModifiedDate.ToString())) found.ModifiedDate = account.ModifiedDate;
                db.SaveChanges();
            }
        }

        public void DeleteAccount(long Id, long DeletedBy, DateTime DeletedDate)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                tblAccount found = db.tblAccounts.Find(Id);
                found.DeletedBy = DeletedBy;
                found.DeletedDate = DeletedDate;
                found.IsDeleted = true;
                db.SaveChanges();
            }
        }
    }
}
