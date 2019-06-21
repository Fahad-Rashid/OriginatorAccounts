using BLL.Account;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Manage()
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            List<VMAccount> model = new AccountHandler().GetAccounts().ToVMAccountList();
            return PartialView("~/Views/Account/_Manage.cshtml", model);
        }

        public ActionResult AddAccount()
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                return PartialView("~/Views/Account/_AddAccount.cshtml");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','User', 'Manage')");
            }
        }
        [HttpPost]
        public ActionResult AddAccount(VMAccount Account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    tblAccount Table = (Account).TotblAccount();
                    Table.CreatedBy = user.Id;
                    Table.CreatedDate = DateTime.Now;
                    new AccountHandler().AddAccount(Table);
                    return JavaScript("showMessage('success', 'Account added Successfully','bottom-right','Account', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','Account', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to Add Account, Please Contact to Administrator','bottom-right','Account', 'Manage')");
            }
        }

        public ActionResult UpdateAccount(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                VMAccount model = new AccountHandler().GetAccountById(Id).ToVMAccount();
                return PartialView("~/Views/Account/_UpdateAccount.cshtml", model);
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','Account', 'Manage')");
            }
        }

        [HttpPost]
        public ActionResult UpdateAccount(VMAccount Account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    tblAccount Table = (Account).TotblAccount();
                    Table.ModifiedBy = user.Id;
                    Table.ModifiedDate = DateTime.Now;
                    new AccountHandler().UpdateAccount(Account.Id, Table);
                    return JavaScript("showMessage('success', 'Account updated Successfully','bottom-right','Account', 'Manage')");
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

        public ActionResult DeleteAccount(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                DateTime DeletedDate = DateTime.Now;
                new AccountHandler().DeleteAccount(Id, user.Id, DeletedDate);
                return JavaScript("showMessage('success', 'Account Deleted Successfully','bottom-right','Account', 'Manage')");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to delete Account, Please Contact to Administrator','bottom-right','Account', 'Manage')");
            }

        }
    }
}