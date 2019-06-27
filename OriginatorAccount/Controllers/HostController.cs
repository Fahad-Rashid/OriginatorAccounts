using BLL.User;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class HostController : Controller
    {
        public ActionResult Index()
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            ViewBag.CompanyName = new UserHandler().GetUserById(user.Id).Company;
            return View();
        }
    }
}