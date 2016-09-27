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
    }
}