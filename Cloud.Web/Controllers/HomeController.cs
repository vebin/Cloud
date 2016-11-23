using System.Web.Mvc;
using Cloud.ApiManagerServices.Manager;

namespace Cloud.Web.Controllers
{
    public class HomeController : CloudControllerBase
    {
        private readonly IManagerAppService _managerAppService;

        public HomeController(IManagerAppService managerAppService)
        {
            _managerAppService = managerAppService;
        }

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
            _managerAppService.UpdateApiManager();
            ViewBag.Controller = "cloud.manager.GetNamespaceEp";
            ViewBag.Jump = "/apimanager/manager/edit";
            return View("~/Areas/ApiManager/Views/Manager/List.cshtml");
        }
    }
}