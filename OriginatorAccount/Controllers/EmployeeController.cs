using BLL.Employee;
using BLL.Salary;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Manage()
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            List<VMEmployee> ModelList = new List<VMEmployee>();
            if (user.RoleId == 5)
            {
                ModelList = new EmployeeHandler().GetEmployees().ToVMEmployeeList();
            }
            else
            {
                ModelList = new EmployeeHandler().GetEmployees((long)user.CompanyId).ToVMEmployeeList();
            }

            return PartialView("~/Views/Employee/_Manage.cshtml", ModelList);
        }

        public ActionResult AddEmployee()
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                return PartialView("~/Views/Employee/_AddEmployee.cshtml");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','User', 'Manage')");
            }
        }

        [HttpPost]
        public ActionResult AddEmployee(VMEmployee Employee)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    Employee e = new Employee();
                    long uno = DateTime.Now.Ticks;
                    if (Employee.ImageUrl != null)
                    {
                        HttpPostedFileBase file = Employee.ImageUrl;
                        if (!string.IsNullOrWhiteSpace(file.FileName))
                        {
                            string url = $"~/DataImages/Employee/{uno}{file.FileName.Substring(file.FileName.LastIndexOf("."))}";
                            string path = Request.MapPath(url);
                            file.SaveAs(path);
                            e.ImageUrl = url;
                        }
                    }
                    e.CompanyId = user.CompanyId;
                    e.FirstName = Employee.FirstName;
                    e.LastName = Employee.LastName;
                    e.Designation = Employee.Designation;
                    e.CreatedBy = user.Id;
                    e.CreatedDate = DateTime.Now;
                    tblSalary s = new tblSalary();
                    s.Salary = Employee.Salary;
                    s.CreatedBy = user.CreatedBy;
                    s.CreatedDate = DateTime.Now;
                    s.EmployeeId = 0;
                    new EmployeeHandler().AddEmployee(e,s);
                    return JavaScript("showMessage('success', 'Employee added Successfully','bottom-right','Employee', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','Employee', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to Add Employee, Please Contact to Administrator','bottom-right','Employee', 'Manage')");
            }
        }

        public ActionResult UpdateEmployee(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                DAL.Employee tblEmployee = new EmployeeHandler().GetEmployee(Id);
                DAL.tblSalary tblSalary = new SalaryHandler().GetSalaryOfEmployee(Id);
                VMEmployee Model = new VMEmployee { Id = Id, Designation = tblEmployee.Designation, FirstName = tblEmployee.FirstName, LastName = tblEmployee.LastName, Salary = (float)tblSalary.Salary};
                return PartialView("~/Views/Employee/_UpdateEmployee.cshtml", Model);
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','Employee', 'Manage')");
            }
        }

        [HttpPost]
        public ActionResult UpdateEmployee(VMEmployee Employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    DAL.Employee e = new Employee();
                    long uno = DateTime.Now.Ticks;
                    if (Employee.ImageUrl != null)
                    {
                        HttpPostedFileBase file = Employee.ImageUrl;
                        if (!string.IsNullOrWhiteSpace(file.FileName))
                        {
                            string url = $"~/DataImages/Employee/{uno}{file.FileName.Substring(file.FileName.LastIndexOf("."))}";
                            string path = Request.MapPath(url);
                            file.SaveAs(path);
                            e.ImageUrl = url;
                        }
                    }
                    e.FirstName = Employee.FirstName;
                    e.LastName = Employee.LastName;
                    e.Designation = Employee.Designation;
                    e.ModifiedBy = user.ModifiedBy;
                    e.ModifiedDate = DateTime.Now;
                    tblSalary s = new tblSalary();
                    s.Salary = Employee.Salary;
                    new EmployeeHandler().UpdateEmployee(Employee.Id, e, s);
                    return JavaScript("showMessage('success', 'Employee updated Successfully','bottom-right','Employee', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','Employee', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to update Employee, Please Contact to Administrator','bottom-right','Employee', 'Manage')");
            }
        }

        public ActionResult DeleteEmployee(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                new EmployeeHandler().DeleteEmployee(Id, user.Id);
                return JavaScript("showMessage('success', 'Employee Deleted Successfully','bottom-right','Employee', 'Manage')");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to delete Account, Please Contact to Administrator','bottom-right','Employee', 'Manage')");
            }

        }

    }
}