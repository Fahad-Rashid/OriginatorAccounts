using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Employee
{
   public class EmployeeHandler
    {

        public List<ORViewEmployeeData> GetEmployees()
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ORViewEmployeeDatas
                        where data.IsDeleted != true
                        select data).ToList();
            }
        }
        public List<ORViewEmployeeData> GetEmployees(long CompanyId)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ORViewEmployeeDatas
                        where data.CompanyId == CompanyId && data.IsDeleted != true
                        select data).ToList();
            }
        }
        public void AddEmployee(DAL.Employee e, tblSalary s)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                db.Employees.Add(e);
                db.SaveChanges();
                s.EmployeeId = e.ID;
                db.tblSalaries.Add(s);
                db.SaveChanges();
            }
        }
        public DAL.Employee GetEmployee(long Id)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return(from data in db.Employees
                       where data.ID == Id
                       select data).FirstOrDefault();
            }
        }


        public void UpdateEmployee(long EmployeeId, DAL.Employee e, tblSalary s)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                DAL.Employee found = db.Employees.Find(EmployeeId);
                if (!string.IsNullOrWhiteSpace(e.FirstName)) found.FirstName = e.FirstName;
                if (!string.IsNullOrWhiteSpace(e.LastName)) found.LastName = e.LastName;
                if (!string.IsNullOrWhiteSpace(e.Designation)) found.Designation = e.Designation;
                if (!string.IsNullOrWhiteSpace(e.ImageUrl)) found.ImageUrl = e.ImageUrl;
                if (e.ModifiedBy != null && e.ModifiedBy > 0) found.ModifiedBy = e.ModifiedBy;
                if (!string.IsNullOrWhiteSpace(e.ModifiedDate.ToString())) found.ModifiedDate = e.ModifiedDate;

                // Get Latest Salary
                // If Latest salary is equal to parameter wali salary then then you dont want to change anything
                // other wise add new entry to salary table 
                db.SaveChanges();
            }
        }

        public void DeleteEmployee(long Employeeid, long DeletedBy)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                DAL.Employee found = db.Employees.Find(Employeeid);
                found.DeletedDate = DateTime.Now;
                found.IsDeleted = true;
                found.DeletedBy = DeletedBy;
                db.SaveChanges();
            }
        }


    }
}
