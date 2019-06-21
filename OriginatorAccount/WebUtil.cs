using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OriginatorAccount
{
    public class WebUtil
    {
        public static readonly int ADMIN_ROLE;
        public static readonly int ACCOUNTANT_ROLE;
        public static readonly int PARTNERS_ROLE;
        public static readonly int EMPLOYEE_ROLE;
        public static readonly string CURRENT_USER;
        public static readonly string MY_COOKIE;
        public static bool IsInRole(int id)
        {
           tblUser cu = (tblUser)HttpContext.Current.Session[WebUtil.CURRENT_USER];
            return cu.RoleId != null && cu.RoleId == id;
        }
        //public bool IsInRole(int id)
        //{
        //    return Role != null && Role.Id == id;
        //}
        static WebUtil()
        {
            CURRENT_USER = "CurrentUser";
            ADMIN_ROLE = 1;
            ACCOUNTANT_ROLE = 2;
            PARTNERS_ROLE = 3;
            EMPLOYEE_ROLE = 4;
            MY_COOKIE = "Info";
        }
    }
}