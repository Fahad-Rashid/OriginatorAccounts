﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Transaction
{
   public class TransactionHandler
    {
        public void AddTransaction(tblAccountTransaction AccountTransaction)
                {
                    var SubId = Convert.ToInt64(item);
                    var d = (from data in db.tblSubAccounts
                             where data.Id == SubId
                             select data).FirstOrDefault();
                    List.Add(d);
                }
                return List;
                {
                    var SubId = Convert.ToInt64(item);
                    var d = (from data in db.tblSubAccounts
                             where data.Id == SubId
                             select data).FirstOrDefault();
                    List.Add(d);
                }
                return List;

        public string GetDefaultToAccountNumber(long id)
                                              where data.Id == SubAccountId
                                              select data.AccountNumber).FirstOrDefault();
        public string GetDefaultFromAccountNumber(long id)
                                              where data.Id == SubAccountId
                                              select data.AccountNumber).FirstOrDefault();
    }
}