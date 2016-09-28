using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Dependency;
using Cloud.Redis.Framework;

namespace Cloud.Web.Areas.ApiManager.Controllers
{
    public class NetMonitorEntityController : Controller
    {
        // GET: ApiManager/NetMonitorEntity
        public ActionResult Index()
        {
            ViewBag.Controller = "cloud.auditInfo.GetNamespaceEp";
            ViewBag.Jump = "/apimanager/manager/edit";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult SqlServer()
        {
            ViewBag.Controller = "cloud.netMonitor.GetNamespaceEp";
            ViewBag.Jump = "/apimanager/manager/edit";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
        public ActionResult Redis()
        {
            ViewBag.Controller = "cloud.redisManager.GetNamespaceEp";
            ViewBag.Jump = "/apimanager/manager/edit";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
        public ActionResult RedisBase()
        {
            ViewBag.Controller = "cloud.redisManager.GetNamespaceBaseEp";
            ViewBag.Jump = "/apimanager/manager/edit";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult Remove()
        {
            ViewBag.Controller = "cloud.redisManager.RemoveEp";
            ViewBag.Jump = "/apimanager/NetMonitorEntity/FlushAll";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult FlushAll(string url)
        {
            if (url == "Confirm")
            {
                IocManager.Instance.Resolve<RedisHelper>().FlushDb();
            }
            ViewBag.Controller = "cloud.redisManager.GetNamespaceEp";
            ViewBag.Jump = "/apimanager/NetMonitorEntity/edit";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
    }
}