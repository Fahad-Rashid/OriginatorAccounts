using BLL.Account;
using BLL.AccountSubType;
using BLL.Company;
using BLL.SubAccount;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.SubAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class SubAccountController : Controller
    {
        public ActionResult Manage()
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            List<VMSubAccount> model = new SubAccountHandler().GetSubAccounts().ToVMSubAccountList();
            return PartialView("~/Views/SubAccount/_Manage.cshtml", model);
        }

        public ActionResult AddSubAccount()
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                ViewBag.Accounts = new AccountHandler().GetAccounts().AccountSelectListItem();
                //ViewBag.Companies = new CompanyHandler().GetCompanies().CompanySelectListItem();
                ViewBag.SubTypes = new AccountSubTypeHandler().GetAccountSubTypes().AccountSubTypeSelectListItem();
                return PartialView("~/Views/SubAccount/_AddSubAccount.cshtml");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','SubAccount', 'Manage')");
            }
        }
        [HttpPost]
        public ActionResult AddSubAccount(VMSubAccount SubAccount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    tblSubAccount Table = (SubAccount).TotblSubAccount();
                    Table.CompanyId = user.CompanyId;
                    Table.CreatedBy = user.Id;
                    Table.CreatedDate = DateTime.Now;
                    new SubAccountHandler().AddSubAccount(Table);
                    return JavaScript("showMessage('success', 'SubAccount added Successfully','bottom-right','SubAccount', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','SubAccount', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to Add SubAccount, Please Contact to Administrator','bottom-right','SubAccount', 'Manage')");
            }
        }

        public ActionResult UpdateSubAccount(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                ViewBag.Accounts = new AccountHandler().GetAccounts().AccountSelectListItem();
                //ViewBag.Companies = new CompanyHandler().GetCompanies().CompanySelectListItem();
                ViewBag.SubTypes = new AccountSubTypeHandler().GetAccountSubTypes().AccountSubTypeSelectListItem();
                VMSubAccount model = new SubAccountHandler().GetSubAccountById(Id).ToVMSubAccount();
                return PartialView("~/Views/SubAccount/_UpdateSubAccount.cshtml", model);
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','SubAccount', 'Manage')");
            }
        }

        [HttpPost]
        public ActionResult UpdateSubAccount(VMSubAccount SubAccount)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    tblSubAccount Table = (SubAccount).TotblSubAccount();
                    Table.CompanyId = user.CompanyId;
                    Table.ModifiedBy = user.Id;
                    Table.ModifiedDate = DateTime.Now;
                    new SubAccountHandler().UpdateSubAccount(SubAccount.Id, Table);
                    return JavaScript("showMessage('success', 'Account updated Successfully','bottom-right','SubAccount', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','Account', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to update Account, Please Contact to Administrator','bottom-right','Account', 'Manage')");
            }
        }

        public ActionResult DeleteSubAccount(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                DateTime DeletedDate = DateTime.Now;
                new SubAccountHandler().DeleteSubAccount(Id, user.Id, DeletedDate);
                return JavaScript("showMessage('success', 'SubAccount Deleted Successfully','bottom-right','SubAccount', 'Manage')");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to delete SubAccount, Please Contact to Administrator','bottom-right','SubAccount', 'Manage')");
            }

        }

    }
}