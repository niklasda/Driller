using System.Web.Mvc;
using Driller.Logic.Interfaces.ViewModels;
using StructureMap;

namespace Driller.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Start()
        {
            var model = ObjectFactory.GetInstance<IStartViewModel>();
            return View(model);
        }

        public ActionResult About()
        {
            var model = ObjectFactory.GetInstance<IAboutViewModel>();
            return View(model);
        }
        
        public ActionResult Help()
        {
            var model = ObjectFactory.GetInstance<IHelpViewModel>();
            return View(model);
        }
    }
}
