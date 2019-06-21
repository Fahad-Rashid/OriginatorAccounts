using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Transaction
{
   public class TransactionHandler
    {
        public void AddTransaction(tblAccountTransaction AccountTransaction)        {            using (OriginatorEntities db = new OriginatorEntities())            {                db.tblAccountTransactions.Add(AccountTransaction);                db.SaveChanges();            }        }        public List<tblSubAccount> GetFromAssociatedOfCurrentUser(long id)        {            using (OriginatorEntities db = new OriginatorEntities())            {                var FromAssociatedIds = (from data in db.tblUserSubAccounts                                         where data.UserId == id                                         select data.FromAssociatedId).FirstOrDefault();                List<tblSubAccount> List = new List<tblSubAccount>();                var TestIds = FromAssociatedIds.Split(',');                var Ids = TestIds.Where(x => !string.IsNullOrEmpty(x)).ToArray();                foreach (var item in Ids)
                {
                    var SubId = Convert.ToInt64(item);
                    var d = (from data in db.tblSubAccounts
                             where data.Id == SubId
                             select data).FirstOrDefault();
                    List.Add(d);
                }
                return List;            }        }        public List<tblSubAccount> GetToAssociatedOfCurrentUser(long id)        {            using (OriginatorEntities db = new OriginatorEntities())            {                var ToAssociatedIds = (from data in db.tblUserSubAccounts                                         where data.UserId == id                                         select data.ToAssociatedId).FirstOrDefault();                List<tblSubAccount> List = new List<tblSubAccount>();                var TestIds = ToAssociatedIds.Split(',');                var Ids = TestIds.Where(x => !string.IsNullOrEmpty(x)).ToArray();                foreach (var item in Ids)
                {
                    var SubId = Convert.ToInt64(item);
                    var d = (from data in db.tblSubAccounts
                             where data.Id == SubId
                             select data).FirstOrDefault();
                    List.Add(d);
                }
                return List;            }        }

        public string GetDefaultToAccountNumber(long id)        {            using (OriginatorEntities db = new OriginatorEntities())            {                var SubAccountId = (from data in db.tblUserSubAccounts                                    where data.UserId == id                                    select data.DefaultToId).FirstOrDefault();                var DefaultToAccountNumber = (from data in db.tblSubAccounts
                                              where data.Id == SubAccountId
                                              select data.AccountNumber).FirstOrDefault();                return DefaultToAccountNumber;            }        }
        public string GetDefaultFromAccountNumber(long id)        {            using (OriginatorEntities db = new OriginatorEntities())            {                var SubAccountId = (from data in db.tblUserSubAccounts                                    where data.UserId == id                                    select data.DefaultFromId).FirstOrDefault();                var DefaultFromAccountNumber = (from data in db.tblSubAccounts
                                              where data.Id == SubAccountId
                                              select data.AccountNumber).FirstOrDefault();                return DefaultFromAccountNumber;            }        }
    }
}
