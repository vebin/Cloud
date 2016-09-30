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


        public ActionResult FriendException()
        {
            ViewBag.Controller = "cloud.exceptionManager.FriendExceptionEp";
            ViewBag.Jump = "/apimanager/NetMonitorEntity/FlushAll";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult NotFriendException()
        {
            ViewBag.Controller = "cloud.exceptionManager.NotFriendExceptionEp";
            ViewBag.Jump = "/apimanager/NetMonitorEntity/FlushAll";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
        public ActionResult InvalidOperationException()
        {
            ViewBag.Controller = "cloud.exceptionManager.InvalidOperationExceptionEp";
            ViewBag.Jump = "/apimanager/NetMonitorEntity/FlushAll";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult NotInvalidOperationException()
        {
            ViewBag.Controller = "cloud.exceptionManager.NotInvalidOperationExceptionEp";
            ViewBag.Jump = "/apimanager/NetMonitorEntity/FlushAll";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
    }
}