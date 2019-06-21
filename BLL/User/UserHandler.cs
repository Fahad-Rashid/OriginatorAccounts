using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.User
{
   public class UserHandler
    {
        public tblUser GetUser(string loginid, string password)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                return (from u in db.tblUsers
                        where u.Email.Equals(loginid) && u.Password.Equals(password)
                        select u).FirstOrDefault();
            }
        }
        public ViewUser GetUserById(long Id)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ViewUsers
                        where data.Id == Id
                        select data).FirstOrDefault();
            }
        }

        public List<ViewUser> GetUsers()
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ViewUsers
                        where data.IsDeleted != true
                        select data).ToList();
            }
        }

        public void AddUser(tblUser user)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                db.tblUsers.Add(user);
                db.SaveChanges();
            }
        }

        public void UpdateUser(long id, tblUser user)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                tblUser found = db.tblUsers.Find(id);
                if (!string.IsNullOrWhiteSpace(user.UserName)) found.UserName = user.UserName;
                if (!string.IsNullOrWhiteSpace(user.Email)) found.Email = user.Email;
                if (!string.IsNullOrWhiteSpace(user.Password)) found.Password = user.Password;
                if (!string.IsNullOrWhiteSpace(user.PhoneNo)) found.PhoneNo = user.PhoneNo;
                if (!string.IsNullOrWhiteSpace(user.Address)) found.Address = user.Address;
                if (!string.IsNullOrWhiteSpace(user.CNIC)) found.CNIC = user.CNIC;
                if (user.RoleId != null && user.RoleId > 0) found.RoleId = user.RoleId;
                if (user.CompanyId != null && user.CompanyId > 0) found.CompanyId = user.CompanyId;
                if (user.ModifiedBy != null && user.ModifiedBy > 0) found.ModifiedBy = user.ModifiedBy;
                if (!string.IsNullOrWhiteSpace(user.ModifiedDate.ToString())) found.ModifiedDate = user.ModifiedDate;
                db.SaveChanges();
            }
        }

        public void DeleteUser(long Id, long DeletedBy, DateTime DeletedDate)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                tblUser found = db.tblUsers.Find(Id);
                found.DeletedBy = DeletedBy;
                found.DeletedDate = DeletedDate;
                found.IsDeleted = true;
                db.SaveChanges();
            }
        }


    }
}
