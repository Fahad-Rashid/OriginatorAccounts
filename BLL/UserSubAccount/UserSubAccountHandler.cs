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

        public void UpdateUserSubAccount(long UserId, string DTaccount, string DFaccount, List<string> TAaccount, List<string> FAaccount, long CurrentUser)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                long GetDefaultToAccount = (from data in db.tblSubAccounts
                                            where data.AccountNumber == DTaccount
                                            select data.Id).FirstOrDefault();
                long GetDefaultFromAccount = (from data in db.tblSubAccounts
                                            where data.AccountNumber == DFaccount
                                              select data.Id).FirstOrDefault();
                List<long> IdsOfToAssociatedAccounts = new List<long>();
                List<long> IdsOfFromAssociatedAccounts = new List<long>();

                foreach (var item in TAaccount)
                {
                    long Id = (from data in db.tblSubAccounts
                               where data.AccountNumber == item
                               select data.Id).FirstOrDefault();
                    IdsOfToAssociatedAccounts.Add(Id);
                }
                foreach (var a in FAaccount)
                {
                    long Id = (from data in db.tblSubAccounts
                               where data.AccountNumber == a
                               select data.Id).FirstOrDefault();
                    IdsOfFromAssociatedAccounts.Add(Id);
                }

                List<long> NewIdsOfToAssociated = IdsOfToAssociatedAccounts.Distinct().ToList();
                List<long> NewIdsOfFromAssociated = IdsOfFromAssociatedAccounts.Distinct().ToList();
                
                string FinalToAssociatedAccounts = string.Join(",", NewIdsOfToAssociated.Select(n => n.ToString()).ToArray());
                string FinalFromAssociatedAccounts = string.Join(",", NewIdsOfFromAssociated.Select(n => n.ToString()).ToArray());

                string ToAssociatedId = ',' + FinalToAssociatedAccounts + ',';
                string FromAssociatedId = ',' + FinalFromAssociatedAccounts + ',';




                tblUserSubAccount found = (from data in db.tblUserSubAccounts
                                         where data.UserId == UserId
                                         select data).FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(GetDefaultToAccount.ToString())) found.DefaultToId = GetDefaultToAccount;
                if (!string.IsNullOrWhiteSpace(GetDefaultFromAccount.ToString())) found.DefaultFromId = GetDefaultFromAccount;
                if (!string.IsNullOrWhiteSpace(ToAssociatedId)) found.ToAssociatedId = ToAssociatedId;
                if (!string.IsNullOrWhiteSpace(FromAssociatedId)) found.FromAssociatedId = FromAssociatedId;
                if (CurrentUser > 0) found.ModifiedBy = CurrentUser;
                found.ModifiedDate = DateTime.Now;

                db.SaveChanges();
            }
        }


    }
}
