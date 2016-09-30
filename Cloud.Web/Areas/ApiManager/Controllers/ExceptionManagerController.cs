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
            ViewBag.Controller = "cloud.exception.GetNamespaceEp";
            ViewBag.Jump = "/apimanager/ExceptionManager/details";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }


        public ActionResult FriendException()
        {
            ViewBag.Controller = "cloud.exception.FriendExceptionEp";
            ViewBag.Jump = "/apimanager/ExceptionManager/details";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult NotFriendException()
        {
            ViewBag.Controller = "cloud.exception.NotFriendExceptionEp";
            ViewBag.Jump = "/apimanager/ExceptionManager/details";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
        public ActionResult InvalidOperationException()
        {
            ViewBag.Controller = "cloud.exception.InvalidOperationExceptionEp";
            ViewBag.Jump = "/apimanager/ExceptionManager/details";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult NotInvalidOperationException()
        {
            ViewBag.Controller = "cloud.exception.NotInvalidOperationExceptionEp";
            ViewBag.Jump = "/apimanager/ExceptionManager/details";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult Details(string url)
        {
            ViewBag.detailsUrl = "cloud.exception.GetDetailsEp";
            return View("~/Areas/ApiManager/Views/Manager/Details.cshtml");
        }

    }
}