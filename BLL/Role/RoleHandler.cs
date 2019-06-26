using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Role
{
   public class RoleHandler
    {
        public List<tblRole> GetRoles()
        {
            using (OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblRoles
                        where data.RoleName != "SuperAdmin"
                        select data).ToList();
            }
        }
    }
}
