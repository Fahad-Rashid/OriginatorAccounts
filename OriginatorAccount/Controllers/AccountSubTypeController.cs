﻿using BLL.AccountSubType;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.AccountSubType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class AccountSubTypeController : Controller
    {
        public ActionResult Manage()        {            tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;            if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");            List<VMAccountSubType> AccountSubType = new AccountSubTypeHandler().GetAccountSubTypes().ToVMVMAccountSubTypeList();            return PartialView("~/Views/AccountSubType/_Manage.cshtml", AccountSubType);        }        public ActionResult AddAccountSubType()        {            try            {                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                return PartialView("~/Views/AccountSubType/_AddAccountSubType.cshtml");            }            catch (Exception ex)            {                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','AccountSubType', 'Manage')");            }        }        [HttpPost]        public ActionResult AddAccountSubType(VMAccountSubType VMAccountSubType)        {            try            {                if (ModelState.IsValid)                {                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");                    tblAccountSubType Table = (VMAccountSubType).TotblAccountSubType();                    Table.CompanyId = user.CompanyId;                    Table.CreatedBy = user.Id;                    Table.CreatedDate = DateTime.Now;                    new AccountSubTypeHandler().AddAccountSubType(Table);                    return JavaScript("showMessage('success', 'Account Sub Type added Successfully','bottom-right','AccountSubType', 'Manage')");                }                else                {                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','AccountSubType', 'Manage')");                }            }            catch (Exception ex)            {                return JavaScript("showMessage('error', 'Failed to Add Account Sub Type, Please Contact to Administrator','bottom-right','AccountSubType', 'Manage')");            }        }        public ActionResult DeleteAccountSubType(long Id)        {            try            {                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");                new AccountSubTypeHandler().DeleteAccountSubType(Id, user.Id);                return JavaScript("showMessage('success', 'Account Sub Type Deleted Successfully','bottom-right','AccountSubType', 'Manage')");            }            catch (Exception ex)            {                return JavaScript("showMessage('error', 'Failed to delete Account Sub Type, Please Contact to Administrator','bottom-right','AccountSubType', 'Manage')");            }        }        public ActionResult UpdateAccountSubType(long Id)        {            try            {                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");                VMAccountSubType model = new AccountSubTypeHandler().GetAccountSubTypeById(Id).ToVMAccountSubType();                return PartialView("~/Views/AccountSubType/_UpdateAccountSubType.cshtml", model);            }            catch (Exception ex)            {                return JavaScript("showMessage('error', 'Something went wrong','bottom-right','AccountSubType', 'Manage')");            }        }        [HttpPost]        public ActionResult UpdateAccountSubType(VMAccountSubType VMAccountSubType)        {            try            {                if (ModelState.IsValid)                {                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");                    tblAccountSubType Table = (VMAccountSubType).TotblAccountSubType();                    Table.CompanyId = user.CompanyId;                    Table.ModifiedBy = user.Id;                    Table.ModifiedDate = DateTime.Now;                    new AccountSubTypeHandler().UpdateAccountSubType(VMAccountSubType.Id, Table);                    return JavaScript("showMessage('success', 'Account Sub Type updated Successfully','bottom-right','AccountSubType', 'Manage')");                }                else                {                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','AccountSubType', 'Manage')");                }            }            catch (Exception ex)            {                return JavaScript("showMessage('error', 'Failed to update Account Sub Type, Please Contact to Administrator','bottom-right','AccountSubType', 'Manage')");            }        }
    }
}