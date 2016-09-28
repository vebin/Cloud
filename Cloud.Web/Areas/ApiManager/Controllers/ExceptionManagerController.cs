using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cloud.Web.Areas.ApiManager.Controllers
{
    public class ExceptionManagerController : Controller
    {
        // GET: ApiManager/ExceptionManager
        public ActionResult Index()
        {
            ViewBag.Controller = "cloud.exceptionManager.GetNamespaceEp";
            ViewBag.Jump = "/apimanager/manager/edit";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
    }
}