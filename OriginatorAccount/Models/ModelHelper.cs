using DAL;
using OriginatorAccount.Models.Account;
using OriginatorAccount.Models.AccountSubType;
using OriginatorAccount.Models.Company;
using OriginatorAccount.Models.Employee;
using OriginatorAccount.Models.HR;
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
        public static List<SelectListItem> AccountTypeSelectListItem(this IEnumerable<tblAccountType> job)        {            List<SelectListItem> items = new List<SelectListItem>();            foreach (var c in job)            {                items.Add(new SelectListItem { Text = c.TypeName, Value = Convert.ToString(c.Id) });            }            return items;        }
        public static List<SelectListItem> AccountSelectListItem(this IEnumerable<ORViewAccountData> job)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var c in job)
            {
                items.Add(new SelectListItem { Text = c.AccountName + " " + c.Description, Value = Convert.ToString(c.Id) });
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
            table.Source = model.Source;
            return table;
        }
        public static VMAccount ToVMAccount(this ORViewAccountData entity)
        {
            VMAccount model = new VMAccount();
            model.Id = entity.Id;
            model.AccountName = entity.AccountName;
            model.Description = entity.Description;
            model.Source = entity.Source;
            return model;
        }
        public static List<VMAccount> ToVMAccountList(this IEnumerable<ORViewAccountData> entityList)
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
        public static tblCompany TotblCompany(this VMCompany model)        {            tblCompany table = new tblCompany();            table.Name = model.Name;            table.Street = model.Street;            table.City = model.City;            table.Country = model.Country;            table.Landline = model.Landline;            table.Mobile = model.Mobile;            table.FaxNo = model.FaxNo;            table.Website = model.Website;            table.NTN = model.NTN;            table.STN = model.STN;            return table;        }        public static VMCompany ToVMCompany(this tblCompany entity)        {            VMCompany model = new VMCompany();            model.Id = entity.Id;            model.Name = entity.Name;            model.Street = entity.Street;            model.City = entity.City;            model.Country = entity.Country;            model.Landline = entity.Landline;            model.Mobile = entity.Mobile;            model.FaxNo = entity.FaxNo;            model.Website = entity.Website;            //model.NTN = (long)entity.NTN;            //model.STN = (long)entity.STN;            return model;        }        public static List<VMCompany> ToVMCompanyList(this IEnumerable<tblCompany> entityList)        {            List<VMCompany> modellist = new List<VMCompany>();            foreach (var entity in entityList)            {                modellist.Add(entity.ToVMCompany());            }            modellist.TrimExcess();            return modellist;        }
        #endregion

        #region Account SubType
               public static tblAccountSubType TotblAccountSubType(this VMAccountSubType model)        {            tblAccountSubType table = new tblAccountSubType();            table.TypeName = model.TypeName;            table.SubTypeName = model.SubTypeName;            return table;        }        public static VMAccountSubType ToVMAccountSubType(this tblAccountSubType entity)        {            VMAccountSubType model = new VMAccountSubType();            model.Id = entity.Id;            model.TypeName = entity.TypeName;            model.SubTypeName = entity.SubTypeName;            return model;        }        public static List<VMAccountSubType> ToVMVMAccountSubTypeList(this IEnumerable<tblAccountSubType> entityList)        {            List<VMAccountSubType> modellist = new List<VMAccountSubType>();            foreach (var entity in entityList)            {                modellist.Add(entity.ToVMAccountSubType());            }            modellist.TrimExcess();            return modellist;        }
        #endregion

        #region User SubAccount
        public static tblUserSubAccount TotblUserSubAccount(this VMUserSubAccount model)        {            tblUserSubAccount entity = new tblUserSubAccount();            entity.Id = model.Id;            entity.DefaultToId = model.DefaultToId;            entity.DefaultFromId = model.DefaultFromId;            entity.ToAssociatedId = model.ToAssociatedId;            entity.FromAssociatedId = model.FromAssociatedId;            return entity;        }
        public static List<tblUserSubAccount> TotblUserSubAccountList(this IEnumerable<VMUserSubAccount> modellist)        {            List<tblUserSubAccount> entitylist = new List<tblUserSubAccount>();            foreach (var model in modellist)            {                entitylist.Add(model.TotblUserSubAccount());            }            entitylist.TrimExcess();            return entitylist;        }
        public static VMUserSubAccount ToVMUserSubAccount(this SPGetUserAccounts_Result entity)        {            VMUserSubAccount model = new VMUserSubAccount();            model.DefaultToId = entity.DefaultTo;            model.DefaultFromId = entity.DefaultFrom;            model.ToAssociatedId = entity.ToAccoiciated.ToString();            model.FromAssociatedId = entity.FromAccoiciated.ToString();            model.AccountNumber = entity.AccountNumber;            model.SubAccountName = entity.SubAccountName;            return model;        }        public static List<VMUserSubAccount> ToVMUserSubAccountList(this IEnumerable<SPGetUserAccounts_Result> entityList)        {            List<VMUserSubAccount> modellist = new List<VMUserSubAccount>();            foreach (var entity in entityList)            {                modellist.Add(entity.ToVMUserSubAccount());            }            modellist.TrimExcess();            return modellist;        }
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

        #region Employee
        public static VMEmployee ToVMEmployee(this ORViewEmployeeData entity)
        {
            VMEmployee model = new VMEmployee();
            model.Id = entity.ID;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            model.Salary = (float)entity.Salary;
            model.Designation = entity.Designation;
            return model;
        }
        public static List<VMEmployee> ToVMEmployeeList(this IEnumerable<ORViewEmployeeData> entitylist)        {            List<VMEmployee> modellist = new List<VMEmployee>();            foreach (var entity in entitylist)            {                modellist.Add(entity.ToVMEmployee());            }            modellist.TrimExcess();            return modellist;        }
        #endregion

        #region MonthlyHR
        public static VMMonthlyHR ToVMMonthlyHR(this ORViewMonthlyHRData entity)
        {
            VMMonthlyHR model = new VMMonthlyHR();
            model.Id = entity.ID;
            model.EmployeeName = entity.EmployeeName;
            model.Year = entity.Yearr;
            model.Month = entity.Monthh;
            model.Description = entity.Description;
            model.Tax = (float)entity.Tax;
            model.EOB = (float)entity.EOB;
            model.Misc = (float)entity.Misc;
            model.Advance = (float)entity.Advance;
            model.EmployeeId = (long)entity.EmployeeId;
            model.LecturePerDay = entity.LecturePerDay;
            model.One = (bool)entity.C1st;
            model.Two = (bool)entity.C2nd;
            model.Three = (bool)entity.C3rd;
            model.Four = (bool)entity.C4th;
            model.Five = (bool)entity.C5th;
            model.Six = (bool)entity.C6th;
            model.Seven = (bool)entity.C7th;
            model.Eight = (bool)entity.C8th;
            model.Nine = (bool)entity.C9th;
            model.Ten = (bool)entity.C10th;
            model.Eleven = (bool)entity.C11th;
            model.Twelve = (bool)entity.C12th;
            model.Thirteen = (bool)entity.C13th;
            model.Fourteen = (bool)entity.C14th;
            model.Fifteen = (bool)entity.C15th;
            model.sixteen = (bool)entity.C16th;
            model.Seventeen = (bool)entity.C17th;
            model.Eighteen = (bool)entity.C18th;
            model.Ninteen = (bool)entity.C19th;
            model.Twenty = (bool)entity.C20th;
            model.TwentyOne = (bool)entity.C21th;
            model.TwentyTwo = (bool)entity.C22th;
            model.TwentyThree = (bool)entity.C23th;
            model.TwentyFour = (bool)entity.C24th;
            model.TwentyFive = (bool)entity.C25th;
            model.TwentySix = (bool)entity.C26th;
            model.TwentySeven = (bool)entity.C27th;
            model.TwentyEight = (bool)entity.C28th;
            model.TwentyNine = (bool)entity.C29th;
            model.Thirty = (bool)entity.C30th;
            model.ThirtyOne = (bool)entity.C31th;
            return model;
        }
        public static List<VMMonthlyHR> ToVMMonthlyHRList(this IEnumerable<ORViewMonthlyHRData> entitylist)        {            List<VMMonthlyHR> modellist = new List<VMMonthlyHR>();            foreach (var entity in entitylist)            {                modellist.Add(entity.ToVMMonthlyHR());            }            modellist.TrimExcess();            return modellist;        }

        public static DAL.tblMonthlyHR TotblMonthlyHRAttandance(this VMMonthlyHR model)
        {
            tblMonthlyHR entity = new tblMonthlyHR();
            entity.ID = entity.ID;
            entity.C1st = model.One;
            entity.C2nd = model.Two;
            entity.C3rd = model.Three;
            entity.C4th = model.Four;
            entity.C5th = model.Five;
            entity.C6th = model.Six;
            entity.C7th = model.Seven;
            entity.C8th = model.Eight;
            entity.C9th = model.Nine;
            entity.C10th = model.Ten;
            entity.C11th = model.Eleven;
            entity.C12th = model.Twelve;
            entity.C13th = model.Thirteen;
            entity.C14th = model.Fourteen;
            entity.C15th = model.Fifteen;
            entity.C16th = model.sixteen;
            entity.C17th = model.Seventeen;
            entity.C18th = model.Eighteen;
            entity.C19th = model.Ninteen;
            entity.C20th = model.Twenty;
            entity.C21th = model.TwentyOne;
            entity.C22th = model.TwentyTwo;
            entity.C23th = model.TwentyThree;
            entity.C24th = model.TwentyFour;
            entity.C25th = model.TwentyFive;
            entity.C26th = model.TwentySix;
            entity.C27th = model.TwentySeven;
            entity.C28th = model.TwentyEight;
            entity.C29th = model.TwentyNine;
            entity.C30th = model.Thirty;
            entity.C31th = model.ThirtyOne;
            return entity;
        }


        #endregion
    }
}