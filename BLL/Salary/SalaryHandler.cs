using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Salary
{
   public class SalaryHandler
    {
        public tblSalary GetSalaryOfEmployee(long EmployeeId)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblSalaries
                        where data.EmployeeId == EmployeeId
                        //orderby data.CreatedDate
                        select data).FirstOrDefault();
            }
        }
    }
}
