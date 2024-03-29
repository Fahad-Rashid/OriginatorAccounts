﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SubAccount
{
   public class SubAccountHandler
    {
        public decimal? GetAmountOfSubAccount(string AccountNumber)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblSubAccounts
                         where data.AccountNumber == AccountNumber
                         select data.Amount).FirstOrDefault();
            }
        }

        //public decimal? GetAmountOfInitialCashAccountOfCompany(long CompanyId)
        //{
        //    using(OriginatorEntities db = new OriginatorEntities())
        //    {
        //        return (from data in db.tblSubAccounts
        //                where data.CompanyId == CompanyId && data.SubAccountName == "Initial Cash"
        //                select data.Amount).FirstOrDefault();
        //    }
        //}

        public List<ViewSubAccount> GetSubAccounts(long CompanyId)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ViewSubAccounts
                        where data.IsDeleted != true && data.CompanyId == CompanyId
                        select data).ToList();
            }
        }

        public ViewSubAccount GetSubAccountById(long id, long CompanyId)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ViewSubAccounts
                        where data.Id == id && data.CompanyId == CompanyId
                        select data).FirstOrDefault();
            }
        }

        public void AddSubAccount(tblSubAccount subaccount)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                db.tblSubAccounts.Add(subaccount);
                var InitialCashSubAccount = (from data in db.tblSubAccounts
                        where data.CompanyId == subaccount.CompanyId && data.SubAccountName == "Initial Cash"
                        select data).FirstOrDefault();
                InitialCashSubAccount.Amount = InitialCashSubAccount.Amount - subaccount.Amount;
                db.SaveChanges();
            }
        }

        public void UpdateSubAccount(long id, tblSubAccount SubAccount)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                tblSubAccount found = db.tblSubAccounts.Find(id);
                if (!string.IsNullOrWhiteSpace(SubAccount.SubAccountName)) found.SubAccountName = SubAccount.SubAccountName;
                if (!string.IsNullOrWhiteSpace(SubAccount.Description)) found.Description = SubAccount.Description;
                if (!string.IsNullOrWhiteSpace(SubAccount.Amount.ToString())) found.Amount = SubAccount.Amount;
                if (!string.IsNullOrWhiteSpace(SubAccount.AccountNumber)) found.AccountNumber = SubAccount.AccountNumber;
                if (SubAccount.CompanyId != null && SubAccount.CompanyId > 0) found.CompanyId = SubAccount.CompanyId;
                if (SubAccount.TypeId != null && SubAccount.TypeId > 0) found.TypeId = SubAccount.TypeId;
                if (SubAccount.AccountId != null && SubAccount.AccountId > 0) found.AccountId = SubAccount.AccountId;
                if (SubAccount.ModifiedBy != null && SubAccount.ModifiedBy > 0) found.ModifiedBy = SubAccount.ModifiedBy;
                if (!string.IsNullOrWhiteSpace(SubAccount.ModifiedDate.ToString())) found.ModifiedDate = SubAccount.ModifiedDate;
                db.SaveChanges();
            }
        }

        public void DeleteSubAccount(long Id, long DeletedBy, DateTime DeletedDate)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                tblSubAccount found = db.tblSubAccounts.Find(Id);
                found.DeletedBy = DeletedBy;
                found.DeletedDate = DeletedDate;
                found.IsDeleted = true;
                db.SaveChanges();
            }
        }
    }
}
