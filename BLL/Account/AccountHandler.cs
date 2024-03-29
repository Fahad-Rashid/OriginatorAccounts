﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Account
{
   public class AccountHandler
    {
        public List<string> GetAllAccountNames()
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblAccounts
                        select data.AccountName).ToList();
            }
        }


        public List<ORViewAccountData> GetAccounts(long CompanyId)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ORViewAccountDatas
                        where data.IsDeleted != true && data.CompanyId == CompanyId && data.AccountName != "Initial Cash"
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

        public ORViewAccountData GetAccountById(long Id, long CompanyId)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ORViewAccountDatas
                        where data.Id == Id && data.CompanyId == CompanyId
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
