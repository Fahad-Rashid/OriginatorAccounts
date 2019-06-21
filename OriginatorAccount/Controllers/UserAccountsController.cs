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
            ViewBag.Users = new UserHandler().GetUsers().UserSelectListItem();
            List<VMUserSubAccount> InnerModel = new List<VMUserSubAccount>();
            VMUserSubAccountParent model = new VMUserSubAccountParent() { UserId = 0, UserSubAccounts = InnerModel };
            return PartialView("~/Views/UserAccounts/_Manage.cshtml");
        }
        public ActionResult GetUserSubAccounts(long Id)
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            ViewBag.Users = new UserHandler().GetUsers().UserSelectListItem();
            List<VMUserSubAccount> InnerModel = new UserSubAccountHandler().GetUserSubAccountById(Id).ToVMUserSubAccountList();
            VMUserSubAccountParent Model = new VMUserSubAccountParent { UserId = Id, UserSubAccounts = InnerModel };
            return PartialView("~/Views/UserAccounts/_Manage.cshtml", Model);
        }

        public ActionResult UpdateUserSubAccounts(string id)
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            string[] UsersAccountList = id.Split(',');
            var SelectedUserId = UsersAccountList[UsersAccountList.Length - 1];
            UsersAccountList = UsersAccountList.Take(UsersAccountList.Count() - 1).ToArray();

            long DefaultToId = 0;
            long DefaultFromId = 0;

            foreach (var item in UsersAccountList)
            {
                if (item.Contains('F'))
                {
                    DefaultFromId = Convert.ToInt64(item.Substring(2));
                }
                else if (item.Contains('T'))
                {
                    DefaultToId = Convert.ToInt64(item.Substring(2));
                }
            }
            new UserSubAccountHandler().UpdateUserSubAccount(user.Id ,Convert.ToInt64(SelectedUserId), DefaultToId, DefaultFromId);
            return RedirectToAction("GetUserSubAccounts");
            //, model.UserId
        }
    }
}