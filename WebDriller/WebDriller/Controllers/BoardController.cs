using System.Web.Mvc;
using Driller.Logic.Interfaces.GamePlay;
using Driller.Logic.Interfaces.ViewModels;
using StructureMap;

namespace Driller.Controllers
{
    public class BoardController : Controller
    {
        public ActionResult Play()
        {
            var svc = ObjectFactory.GetInstance<IGameService>();
            IGameState game = svc.StartNew();

            //CurrentGame.TheGame = game;

            var model = ObjectFactory.GetInstance<IPlayViewModel>();
           
            return View(model);
        }
    }
}
