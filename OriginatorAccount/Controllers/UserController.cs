using BLL.Company;
using BLL.Role;
using BLL.User;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class UserController : Controller
    {
       public ActionResult Manage()
        {
            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
            List<VMUser> Users = new UserHandler().GetUsers().ToVMUserList();
            return PartialView("~/Views/User/_ManageUser.cshtml", Users);
        }
        public ActionResult AddUser()
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                ViewBag.Roles = new RoleHandler().GetRoles().RoleSelectListItem();
                if(user.RoleId == 5)
                {
                    ViewBag.Companies = new CompanyHandler().GetCompanies().CompanySelectListItem();
                }
                return PartialView("~/Views/User/_AddUser.cshtml");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','User', 'Manage')");
            }
        }
        [HttpPost]
        public ActionResult AddUser(VMUser VMuser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    tblUser Table = (VMuser).TotblUser();
                    
                    if(user.RoleId == 5)
                    {
                        Table.CompanyId = VMuser.CompanyId;
                    }
                    else
                    {
                        Table.CompanyId = user.CompanyId;
                    }
                    Table.CreatedBy = user.Id;
                    Table.CreatedDate = DateTime.Now;
                    new UserHandler().AddUser(Table);
                    return JavaScript("showMessage('success', 'User added Successfully','bottom-right','User', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','User', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to Add User, Please Contact to Administrator','bottom-right','User', 'Manage')");
            }
        }
        public ActionResult UpdateUser(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                VMUser model = new UserHandler().GetUserById(Id).ToVMUser();
                ViewBag.Roles = new RoleHandler().GetRoles().RoleSelectListItem();
                if (user.RoleId == 5)
                {
                    ViewBag.Companies = new CompanyHandler().GetCompanies().CompanySelectListItem();
                }
                return PartialView("~/Views/User/_UpdateUser.cshtml", model);
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','User', 'Manage')");
            }
        }

        [HttpPost]
        public ActionResult UpdateUser(VMUser VMuser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                    tblUser Table = (VMuser).TotblUser();
                    if(user.RoleId == 5)
                    {
                        Table.CompanyId = VMuser.CompanyId;
                    }
                    else
                    {
                        Table.CompanyId = VMuser.CompanyId;
                    }
                    Table.ModifiedBy = user.Id;
                    Table.ModifiedDate = DateTime.Now;
                    new UserHandler().UpdateUser(VMuser.Id, Table);
                    return JavaScript("showMessage('success', 'User updated Successfully','bottom-right','User', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','User', 'Manage')");
                }
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to update User, Please Contact to Administrator','bottom-right','User', 'Manage')");
            }
        }


        public ActionResult DeleteUser(long Id)
        {
            try
            {
                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;
                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                DateTime DeletedDate = DateTime.Now;
                new UserHandler().DeleteUser(Id, user.Id, DeletedDate);
                return JavaScript("showMessage('success', 'User Deleted Successfully','bottom-right','User', 'Manage')");
            }
            catch (Exception ex)
            {
                return JavaScript("showMessage('error', 'Failed to delete User, Please Contact to Administrator','bottom-right','User', 'Manage')");
            }
            
        }



        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            tblUser currentUser = new UserHandler().GetUser(model.LoginId, model.Password);
            if (currentUser != null)
            {
                    Session.Add(WebUtil.CURRENT_USER, currentUser);
                    //if (model.RememberMe)// if remember me checkbox is checked
                    //{
                    //    if (Request.Browser.Cookies)//it's used to tell if two requests came from the same browser — keeping a user logged-in
                    //    {
                    //        HttpCookie c = new HttpCookie(WebUtil.MY_COOKIE);
                    //        c.Expires = DateTime.Today.AddDays(3);
                    //        c.Value = $"{currentUser.Email},{currentUser.Password}";
                    //        Response.SetCookie(c);
                    //    }
                    //}
                    return RedirectToAction("Index", "Host");
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            //HttpCookie temp = Request.Cookies[WebUtil.MY_COOKIE];
            //if (temp != null)
            //{
            //    temp.Expires = DateTime.Now;
            //    Response.SetCookie(temp);
            //}

            return RedirectToAction("login");
        }
        public ActionResult RedirectToLogin()
        {
            return PartialView("~/Views/User/_RedirectToLogin.cshtml");
        }
    }
}