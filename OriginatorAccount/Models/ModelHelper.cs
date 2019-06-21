﻿using DAL;
using OriginatorAccount.Models.Account;
using OriginatorAccount.Models.AccountSubType;
using OriginatorAccount.Models.Company;
using OriginatorAccount.Models.SubAccount;
using OriginatorAccount.Models.Transaction;
using OriginatorAccount.Models.User;
using OriginatorAccount.Models.UserSubAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Models
{
    public static class ModelHelper
    {
        #region Select List Item
        public static List<SelectListItem> RoleSelectListItem(this IEnumerable<tblRole> job)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in job)
            {
                items.Add(new SelectListItem { Text = c.RoleName, Value = Convert.ToString(c.Id) });
            }
            return items;
        }
        public static List<SelectListItem> CompanySelectListItem(this IEnumerable<tblCompany> job)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in job)
            {
                items.Add(new SelectListItem { Text = c.Name, Value = Convert.ToString(c.Id) });
            }
            return items;
        }
        public static List<SelectListItem> AccountTypeSelectListItem(this IEnumerable<tblAccountType> job)
        public static List<SelectListItem> AccountSelectListItem(this IEnumerable<tblAccount> job)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in job)
            {
                items.Add(new SelectListItem { Text = c.AccountName, Value = Convert.ToString(c.Id) });
            }
            return items;
        }
        public static List<SelectListItem> AccountSubTypeSelectListItem(this IEnumerable<tblAccountSubType> job)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in job)
            {
                items.Add(new SelectListItem { Text = c.SubTypeName, Value = Convert.ToString(c.Id) });
            }
            return items;
        }
        public static List<SelectListItem> UserSelectListItem(this IEnumerable<ViewUser> job)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in job)
            {
                items.Add(new SelectListItem { Text = c.UserName, Value = Convert.ToString(c.Id) });
            }
            return items;
        }
        #endregion

        #region User
        public static tblUser TotblUser(this VMUser model)
        {
            tblUser table = new tblUser();
            table.UserName = model.UserName;
            table.Email = model.Email;
            table.Password = model.Password;
            table.Address = model.Address;
            table.CNIC = model.CNIC;
            table.CompanyId = model.CompanyId;
            table.RoleId = model.RoleId;
            table.PhoneNo = model.PhoneNo;
            return table;
        }
        public static VMUser ToVMUser(this ViewUser entity)
        {
            VMUser model = new VMUser();
            model.Id = entity.Id;
            model.UserName = entity.UserName;
            model.Email = entity.Email;
            model.PhoneNo = entity.PhoneNo;
            model.Password = entity.Password;
            model.Company = entity.Company;
            model.RoleName = entity.Role;
            model.RoleId = (long)entity.RoleId;
            model.CompanyId = (long)entity.CompanyId;
            model.CNIC = entity.CNIC;
            return model;
        }
        public static List<VMUser> ToVMUserList(this IEnumerable<ViewUser> entityList)
        {
            List<VMUser> modellist = new List<VMUser>();
            foreach (var entity in entityList)
            {
                modellist.Add(entity.ToVMUser());
            }
            modellist.TrimExcess();
            return modellist;
        }
        #endregion

        #region Account
        public static tblAccount TotblAccount(this VMAccount model)
        {
            tblAccount table = new tblAccount();
            table.Id = model.Id;
            table.AccountName = model.AccountName;
            table.Description = model.Description;
            table.Amount = model.Amount;
            table.Source = model.Source;
            return table;
        }
        public static VMAccount ToVMAccount(this tblAccount entity)
        {
            VMAccount model = new VMAccount();
            model.Id = entity.Id;
            model.AccountName = entity.AccountName;
            model.Amount = (decimal)entity.Amount;
            model.Description = entity.Description;
            model.Source = entity.Source;
            return model;
        }
        public static List<VMAccount> ToVMAccountList(this IEnumerable<tblAccount> entityList)
        {
            List<VMAccount> modellist = new List<VMAccount>();
            foreach (var entity in entityList)
            {
                modellist.Add(entity.ToVMAccount());
            }
            modellist.TrimExcess();
            return modellist;
        }
        #endregion

        #region SubAccount
        public static tblSubAccount TotblSubAccount(this VMSubAccount model)
        {
            tblSubAccount entity = new tblSubAccount();
            entity.SubAccountName = model.SubAccountName;
            entity.Description = model.Description;
            entity.Amount = model.Amount;
            entity.AccountId = model.AccountId;
            entity.CompanyId = model.CompanyId;
            entity.TypeId = model.TypeId;
            entity.AccountNumber = model.AccountNumber;
            return entity;
        }
        public static VMSubAccount ToVMSubAccount(this ViewSubAccount entity)
        {
            VMSubAccount model = new VMSubAccount();
            model.Id = entity.Id;
            model.AccountName = entity.ParentAccount;
            model.CompanyName = entity.Company;
            model.SubAccountName = entity.SubAccountName;
            model.Description = entity.Description;
            model.Amount = (decimal)entity.Amount;
            model.AccountId = (long)entity.AccountId;
            model.CompanyId = (long)entity.CompanyId;
            model.TypeId = (long)entity.TypeId;
            model.AccountNumber = entity.AccountNumber;
            model.SubTypeName = entity.SubtypeName;
            return model;
        }
        public static List<VMSubAccount> ToVMSubAccountList(this IEnumerable<ViewSubAccount> entityList)
        {
            List<VMSubAccount> modellist = new List<VMSubAccount>();
            foreach (var entity in entityList)
            {
                modellist.Add(entity.ToVMSubAccount());
            }
            modellist.TrimExcess();
            return modellist;
        }
        #endregion

        #region Company
        public static tblCompany TotblCompany(this VMCompany model)
        #endregion

        #region Account SubType
       
        #endregion

        #region User SubAccount
        public static tblUserSubAccount TotblUserSubAccount(this VMUserSubAccount model)
        public static List<tblUserSubAccount> TotblUserSubAccountList(this IEnumerable<VMUserSubAccount> modellist)
        public static VMUserSubAccount ToVMUserSubAccount(this SPGetUserAccounts_Result entity)
        #endregion

        #region Transaction
        public static tblAccountTransaction TotblTransaction(this VMTransaction model)
        {
            tblAccountTransaction table = new tblAccountTransaction();
            table.Description = model.Description;
            table.DefaultTo = model.DefaultTo;
            table.DefaultFrom = model.DefaultFrom;
            table.Amount = model.Amount;
            return table;
        }
        public static List<SelectListItem> UserSubAccountSelectListItem(this IEnumerable<tblSubAccount> job)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in job)
            {
                items.Add(new SelectListItem { Text = c.SubAccountName, Value = c.AccountNumber });
            }
            return items;
        }
        #endregion

    }
}