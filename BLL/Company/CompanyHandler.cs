﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Company
{
   public class CompanyHandler
    {
        public List<tblCompany> GetCompanies()
        {
            using(OriginatorEntities db = new OriginatorEntities())
            {
                return (from data in db.tblCompanies
                        where data.IsDeleted != true
                        select data).ToList();
            }
        }
        public tblCompany GetCompanyById(long Id)
        {
    }
}