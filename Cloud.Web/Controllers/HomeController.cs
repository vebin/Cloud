using System.Web.Mvc;

namespace Cloud.Web.Controllers
{
    public class HomeController : CloudControllerBase
    {

        public ActionResult Index()
        {
            ViewBag.Controller = "cloud.manager.GetNamespaceEp";
            ViewBag.Jump = "/apimanager/manager/edit";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }

        public ActionResult Call()
        {
            ViewBag.Controller = "cloud.userInfo.CallEp";
            ViewBag.Jump = "#";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
        public ActionResult Info()
        {
            ViewBag.Controller = "cloud.userInfo.InfoEp";
            ViewBag.Jump = "#";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
    }
}