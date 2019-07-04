using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.MonthlyHR
{
   public class MonthlyHRHandler
    {
        public List<ORViewMonthlyHRData> GetMonthlyHR(string Month, string CurrentYear)
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ORViewMonthlyHRDatas
                        where data.Monthh == Month && data.Yearr == CurrentYear
                        select data).ToList();
            }
        }
        public ORViewMonthlyHRData GetMonthlyHRAttandace(long EmployeeId)
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.ORViewMonthlyHRDatas
                        where data.EmployeeId == EmployeeId
                        select data).FirstOrDefault();
            }
        }

        public void UpdateAttandance()
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {

            }
        }
    }
}
