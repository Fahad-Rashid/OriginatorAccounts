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
        public void AddTransaction(tblAccountTransaction AccountTransaction)        {            using (OriginatorEntities db = new OriginatorEntities())            {                tblSubAccount FoundFromAccount = (from data in db.tblSubAccounts                                        where data.AccountNumber == AccountTransaction.DefaultFrom                                        select data).FirstOrDefault();                tblSubAccount FoundToAccount = (from data in db.tblSubAccounts
                                                  where data.AccountNumber == AccountTransaction.DefaultTo
                                                  select data).FirstOrDefault();                FoundFromAccount.Amount = FoundFromAccount.Amount - AccountTransaction.Amount;                FoundFromAccount.ModifiedBy = AccountTransaction.CreatedBy;                FoundFromAccount.ModifiedDate = DateTime.Now;                FoundToAccount.Amount = FoundToAccount.Amount + AccountTransaction.Amount;                FoundToAccount.ModifiedBy = AccountTransaction.CreatedBy;                FoundToAccount.ModifiedDate = DateTime.Now;                db.tblAccountTransactions.Add(AccountTransaction);                db.SaveChanges();            }        }        public List<tblSubAccount> GetFromAssociatedOfCurrentUser(long id, long CompanyId)        {            using (OriginatorEntities db = new OriginatorEntities())            {                var FromAssociatedIds = (from data in db.tblUserSubAccounts                                         where data.UserId == id && data.CompanyId == CompanyId                                         select data.FromAssociatedId).FirstOrDefault();                List<tblSubAccount> List = new List<tblSubAccount>();                var TestIds = FromAssociatedIds.Split(',');                var Ids = TestIds.Where(x => !string.IsNullOrEmpty(x)).ToArray();                foreach (var item in Ids)
                {
                    var SubId = Convert.ToInt64(item);
                    var d = (from data in db.tblSubAccounts
                             where data.Id == SubId
                             select data).FirstOrDefault();
                    List.Add(d);
                }
                return List;            }        }        public List<tblSubAccount> GetToAssociatedOfCurrentUser(long id, long CompanyId)        {            using (OriginatorEntities db = new OriginatorEntities())            {                var ToAssociatedIds = (from data in db.tblUserSubAccounts                                         where data.UserId == id && data.CompanyId == CompanyId                                         select data.ToAssociatedId).FirstOrDefault();                List<tblSubAccount> List = new List<tblSubAccount>();                var TestIds = ToAssociatedIds.Split(',');                var Ids = TestIds.Where(x => !string.IsNullOrEmpty(x)).ToArray();                foreach (var item in Ids)
                {
                    var SubId = Convert.ToInt64(item);
                    var d = (from data in db.tblSubAccounts
                             where data.Id == SubId
                             select data).FirstOrDefault();
                    List.Add(d);
                }
                return List;            }        }

        public string GetDefaultToAccountNumber(long id, long CompanyId)        {            using (OriginatorEntities db = new OriginatorEntities())            {                var SubAccountId = (from data in db.tblUserSubAccounts                                    where data.UserId == id && data.CompanyId == CompanyId                                    select data.DefaultToId).FirstOrDefault();                var DefaultToAccountNumber = (from data in db.tblSubAccounts
                                              where data.Id == SubAccountId
                                              select data.AccountNumber).FirstOrDefault();                return DefaultToAccountNumber;            }        }
        public string GetDefaultFromAccountNumber(long id, long CompanyId)        {            using (OriginatorEntities db = new OriginatorEntities())            {                var SubAccountId = (from data in db.tblUserSubAccounts                                    where data.UserId == id && data.CompanyId == CompanyId                                    select data.DefaultFromId).FirstOrDefault();                var DefaultFromAccountNumber = (from data in db.tblSubAccounts
                                              where data.Id == SubAccountId
                                              select data.AccountNumber).FirstOrDefault();                return DefaultFromAccountNumber;            }        }
    }
}
