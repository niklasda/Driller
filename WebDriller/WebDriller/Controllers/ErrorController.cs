using System;
using System.Web.Mvc;
using Driller.Logic.Interfaces.ViewModels;
using StructureMap;

namespace Driller.Controllers
{
    public class ErrorController : Controller
    {
        private const string ErrorViewName = "Error";
        private const string NotFoundViewName = "NotFound";

        public ActionResult Index()
        {
            return View(ErrorViewName);
        }

        public ActionResult NotFound(string aspxerrorpath)
        {
            var model = ObjectFactory.GetInstance<IErrorViewModel>();
            model.Message = aspxerrorpath;

            return View(NotFoundViewName, model);
        }

        public void Test()
        {
            throw new Exception("Test");
        }
    }
}
