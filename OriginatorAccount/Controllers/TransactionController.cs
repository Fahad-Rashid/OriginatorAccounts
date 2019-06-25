using BLL.Transaction;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class TransactionController : Controller
    {
        public ActionResult AddTransaction()        {            try            {                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;                if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");
                
                ViewBag.FromAssociated = new BLL.Transaction.TransactionHandler().GetFromAssociatedOfCurrentUser(user.Id).UserSubAccountSelectListItem();

                ViewBag.ToAssociated = new BLL.Transaction.TransactionHandler().GetToAssociatedOfCurrentUser(user.Id).UserSubAccountSelectListItem();                var DefaultTo = new BLL.Transaction.TransactionHandler().GetDefaultToAccountNumber(user.Id);                var DefaultFrom = new BLL.Transaction.TransactionHandler().GetDefaultFromAccountNumber(user.Id);                VMTransaction transaction = new VMTransaction { DefaultFrom = DefaultFrom, DefaultTo = DefaultTo };                return PartialView("~/Views/Transaction/_AddTransaction.cshtml", transaction);            }            catch (Exception ex)            {                tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;                if(user.RoleId == 1)
                {
                    return JavaScript("showMessage('error', 'You Dont have any associated Accounts','bottom-right','User', 'Manage')");
                }
                else if(user.RoleId == 2)
                {
                    return JavaScript("showMessage('error', 'You Dont have any associated Accounts','bottom-right','Account', 'Manage')");
                }
                else if (user.RoleId == 3)
                {
                    return JavaScript("showMessage('error', 'You Dont have any associated Accounts','bottom-right','User', 'Manage')");
                }
                else
                {
                    return JavaScript("showMessage('error', 'You Dont have any associated Accounts','bottom-right','user', 'RedirectToLogin')");
                }

            }        }        [HttpPost]        public ActionResult AddTransaction(VMTransaction VMTransaction)        {            try            {                if (ModelState.IsValid)                {                    tblUser user = Session[WebUtil.CURRENT_USER] as tblUser;                    if (!(user != null)) return RedirectToAction("RedirectToLogin", "user");                    tblAccountTransaction Table = (VMTransaction).TotblTransaction();                    Table.CompanyId = user.CompanyId;                    Table.CreatedBy = user.Id;                    Table.CreatedDate = DateTime.Now;                    new TransactionHandler().AddTransaction(Table);                    return JavaScript("showMessage('success', 'Transaction added Successfully','bottom-right','Transaction', 'AddTransaction')");                }                else                {                    return JavaScript("showMessage('error', 'All fields are required, Please try again','bottom-right','Transaction', 'AddTransaction')");                }            }            catch (Exception ex)            {                return JavaScript("showMessage('error', 'Failed to Add Transaction, Please Contact to Administrator','bottom-right','Transaction', 'AddTransaction')");            }        }
    }
}