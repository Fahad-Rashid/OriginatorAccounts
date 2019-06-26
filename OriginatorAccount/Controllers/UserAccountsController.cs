using BLL.Company;
using BLL.User;
using BLL.UserSubAccount;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.UserSubAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class UserAccountsController : Controller
    {
        public ActionResult Manage()
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            ViewBag.Users = new UserHandler().GetUsersForAdmin((long)user.CompanyId).UserSelectListItem();
            ViewBag.RoleId = user.RoleId;
            ViewBag.Companies = new CompanyHandler().GetCompanies().CompanySelectListItem();
            return PartialView("~/Views/UserAccounts/_Manage.cshtml");
        }
        public ActionResult GetUserSubAccounts(long Id, long CompanyId)
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            List<VMUserSubAccount> InnerModel = new List<VMUserSubAccount>();
            if (CompanyId != 0 && CompanyId > 0)
            {
                ViewBag.Users = new UserHandler().GetUsersForSuperAdmin().UserSelectListItem();
                InnerModel = new UserSubAccountHandler().GetUserSubAccountById(Id, (long)CompanyId).ToVMUserSubAccountList();
            }
            else
            {
                ViewBag.Users = new UserHandler().GetUsersForAdmin((long)user.CompanyId).UserSelectListItem();
                InnerModel = new UserSubAccountHandler().GetUserSubAccountById(Id, (long)user.CompanyId).ToVMUserSubAccountList();
            }
            ViewBag.Companies = new CompanyHandler().GetCompanies().CompanySelectListItem();
            ViewBag.RoleId = user.RoleId;
            VMUserSubAccountParent Model = new VMUserSubAccountParent { UserId = Id, UserSubAccounts = InnerModel };
            return PartialView("~/Views/UserAccounts/_Manage.cshtml", Model);
        }

        public ActionResult UpdateUserSubAccounts(string id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                string[] UsersAccountList = id.Split(',');
                var SelectedUserId = UsersAccountList[UsersAccountList.Length - 1];
                UsersAccountList = UsersAccountList.Take(UsersAccountList.Count() - 1).ToArray();

                string DefaultToAccountNumber = null;
                string DefaultFromAccountNumber = null;
                List<string> ToAssociatedAccountNumber = new List<string>();
                List<string> FromAssociatedAccountNumber = new List<string>();
                long CompanyId = (long)user.CompanyId;

                foreach (var item in UsersAccountList)
                {
                    var parts = item.Split('|');
                    if (parts[0] == "TA")
                    {
                        ToAssociatedAccountNumber.Add(parts[1]);
                    }
                    else if (parts[0] == "FA")
                    {
                        FromAssociatedAccountNumber.Add(parts[1]);
                    }
                    else if (parts[0] == "DT")
                    {
                        DefaultToAccountNumber = parts[1];
                    }
                    else if (parts[0] == "DF")
                    {
                        DefaultFromAccountNumber = parts[1];
                    }
                }

                new UserSubAccountHandler().UpdateUserSubAccount(Convert.ToInt64(SelectedUserId), DefaultToAccountNumber, DefaultFromAccountNumber, ToAssociatedAccountNumber, FromAssociatedAccountNumber, user.Id, CompanyId);
                return JavaScript("showMessage('success', 'Updated Successfully','bottom-right','UserAccounts', 'Manage')");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to Updated, Please contact to Administrator','bottom-right','UserAccounts', 'Manage')");
            }
        }
    }
}