using BLL.Company;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Manage()
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            List<VMCompany> Users = new BLL.Company.CompanyHandler().GetCompanies().ToVMCompanyList();
            return PartialView("~/Views/Company/_Manage.cshtml", Users);
        }
        public ActionResult AddCompany()
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                return PartialView("~/Views/Company/_AddCompany.cshtml");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','Company', 'Manage')");
            }
        }
        [HttpPost]
        public ActionResult AddCompany(VMCompany VMcompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    tblCompany Table = (VMcompany).TotblCompany();
                    Table.CreatedBy = user.Id;
                    Table.CreatedDate = DateTime.Now;
                    new CompanyHandler().AddCompany(Table);
                    return JavaScript("showMessage('success', 'Company added Successfully','bottom-right','Company', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','Company', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to Add Company, Please Contact to Administrator','bottom-right','Company', 'Manage')");
            }
        }
        public ActionResult DeleteCompany(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                new CompanyHandler().DeleteCompany(Id, user.Id);
                return JavaScript("showMessage('success', 'Company Deleted Successfully','bottom-right','Company', 'Manage')");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to delete Company, Please Contact to Administrator','bottom-right','Company', 'Manage')");
            }

        }
        public ActionResult UpdateCompany(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                VMCompany model = new CompanyHandler().GetCompanyById(Id).ToVMCompany();
                return PartialView("~/Views/Company/_UpdateCompany.cshtml", model);
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','Company', 'Manage')");
            }
        }
        [HttpPost]
        public ActionResult UpdateCompany(VMCompany VMCompany)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    tblCompany Table = (VMCompany).TotblCompany();
                    Table.ModifiedBy = user.Id;
                    Table.ModifiedDate = DateTime.Now;
                    new CompanyHandler().UpdateCompany(VMCompany.Id, Table);
                    return JavaScript("showMessage('success', 'Company updated Successfully','bottom-right','Company', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','Company', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to update Company, Please Contact to Administrator','bottom-right','Company', 'Manage')");
            }
        }
    }
}