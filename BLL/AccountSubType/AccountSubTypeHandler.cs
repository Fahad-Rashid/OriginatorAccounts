using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AccountSubType
{
   public class AccountSubTypeHandler
    {
        public List<tblAccountSubType> GetAccountSubTypes(long CompanyId)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblAccountSubTypes
                        where data.IsDeleted != true && data.CompanyId == CompanyId
                        select data).ToList();
            }
        }
        public tblAccountSubType GetAccountSubTypeById(long Id, long CompanyId)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblAccountSubTypes
                        where data.Id == Id && data.CompanyId == CompanyId
                        select data).FirstOrDefault();
            }
        }



        public void AddAccountSubType(tblAccountSubType AccountSubType)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                db.tblAccountSubTypes.Add(AccountSubType);
                db.SaveChanges();
            }
        }

        public void UpdateAccountSubType(long id, tblAccountSubType AccountSubType)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                tblAccountSubType found = db.tblAccountSubTypes.Find(id);
                if (!string.IsNullOrWhiteSpace(AccountSubType.TypeName)) found.TypeName = AccountSubType.TypeName;
                if (!string.IsNullOrWhiteSpace(AccountSubType.SubTypeName)) found.SubTypeName = AccountSubType.SubTypeName;
                if (AccountSubType.CompanyId != null && AccountSubType.CompanyId > 0) found.CompanyId = AccountSubType.CompanyId;
                if (AccountSubType.ModifiedBy != null && AccountSubType.ModifiedBy > 0) found.ModifiedBy = AccountSubType.ModifiedBy;
                if (!string.IsNullOrWhiteSpace(AccountSubType.ModifiedDate.ToString())) found.ModifiedDate = AccountSubType.ModifiedDate;

                db.SaveChanges();
            }
        }

        public void DeleteAccountSubType(long Id, long DeletedBy)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                tblAccountSubType found = db.tblAccountSubTypes.Find(Id);
                found.DeletedBy = DeletedBy;
                found.DeletedDate = DateTime.Now;
                found.IsDeleted = true;
                db.SaveChanges();
            }
        }

    }
}
