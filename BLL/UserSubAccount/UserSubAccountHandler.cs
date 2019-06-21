using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserSubAccount
{
   public class UserSubAccountHandler
    {
        public List<SPGetUserAccounts_Result> GetUserSubAccountById(long Id)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.SPGetUserAccounts(Id)
                        select data).ToList();
            }
        }

        public void UpdateUserSubAccount(long ModifiedBy ,long UserId ,long DefaultToId, long DefaultFromId)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {

                //List<tblUserSubAccount> found = (from data in db.tblUserSubAccounts
                //                                 where data.UserId == UserId
                //                                 select data).ToList();
                //foreach (var item in found)
                //{
                //    item.DefaultTo = false;
                //    item.DefaultFrom = false;
                //    item.ModifiedBy = ModifiedBy;
                //    item.ModifiedDate = DateTime.Now;
                //}

                //tblUserSubAccount foundDefaultTo = (from data in db.tblUserSubAccounts
                //                                 where data.UserId == UserId && data.SubTypeId == DefaultToId
                //                                 select data).FirstOrDefault();
                //if(foundDefaultTo != null)
                //{
                //    foundDefaultTo.DefaultTo = true;
                //    foundDefaultTo.ModifiedBy = ModifiedBy;
                //    foundDefaultTo.ModifiedDate = DateTime.Now;
                //}
                //else
                //{

                //}




                //foreach (var table in tablelist)
                //{
                //    tblUserSubAccount found = db.tblUserSubAccounts.Find(table.Id);
                //    if (!string.IsNullOrWhiteSpace(table.AccountName)) found.AccountName = table.AccountName;
                //    if (!string.IsNullOrWhiteSpace(table.AccountNumber)) found.AccountNumber = table.AccountNumber;
                //    if (!string.IsNullOrWhiteSpace(table.DefaultFrom.ToString())) found.DefaultFrom = table.DefaultFrom;
                //    if (!string.IsNullOrWhiteSpace(table.DefaultTo.ToString())) found.DefaultTo = table.DefaultTo;
                //    if (!string.IsNullOrWhiteSpace(table.FromAssociated.ToString())) found.FromAssociated = table.FromAssociated;
                //    if (!string.IsNullOrWhiteSpace(table.ToAssociated.ToString())) found.ToAssociated = table.ToAssociated;
                //}
                db.SaveChanges();
            }
        }


    }
}
