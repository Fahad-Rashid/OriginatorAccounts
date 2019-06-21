﻿using BLL.AccountSubType;
using DAL;
using OriginatorAccount.Models;
using OriginatorAccount.Models.AccountSubType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OriginatorAccount.Controllers
{
    public class AccountSubTypeController : Controller
    {
        public ActionResult Manage()
                return PartialView("~/Views/AccountSubType/_AddAccountSubType.cshtml");
    }
}