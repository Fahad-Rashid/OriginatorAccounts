using BLL.MonthlyHR;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class MonthlyHRController : Controller
    {
        // GET: MonthlyHR
        public ActionResult Manage()
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            return PartialView("~/Views/MonthlyHR/_Manage.cshtml");
        }
        public ActionResult GetMonthlyHR(string id)
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            ViewBag.Month = id;
            string currentYear = DateTime.Now.Year.ToString();
            List<VMMonthlyHR> ModelList = new MonthlyHRHandler().GetMonthlyHR(id, currentYear).ToVMMonthlyHRList();
            return PartialView("~/Views/MonthlyHR/_Manage.cshtml", ModelList);
        }
        public ActionResult UpdateAttandance(long id)
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            string currentYear = DateTime.Now.Year.ToString();
            VMMonthlyHR Model = new MonthlyHRHandler().GetMonthlyHRAttandace(id).ToVMMonthlyHR();
            return PartialView("~/Views/MonthlyHR/_UpdateAttandance.cshtml", Model);
        }

        [HttpPost]
        public ActionResult UpdateAttandance(VMMonthlyHR model)
        {
            tblMonthlyHR entity = (model).TotblMonthlyHRAttandance();
            return View();
        }


    }
}