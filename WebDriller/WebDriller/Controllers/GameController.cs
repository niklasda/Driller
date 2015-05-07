using System.Web.Mvc;
using Driller.Logic.Comm;
using Driller.Logic.Interfaces.Comm;
using Driller.Logic.Interfaces.GamePlay;
using StructureMap;

namespace Driller.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController()
            : this(ObjectFactory.GetInstance<IGameService>())
        {
        }

        public GameController(IGameService gameService)
        {
            _gameService = gameService; 
        }

        [HttpPost]
        public JsonResult Ping(MessageFromClient message)
        {
            IMessageResponse response = new MessageResponse();
            if (_gameService != null) // todo: wrong check, need gamestate
            {
                response = _gameService.Do(message);
            }
            else
            {
                response.Success = false;
                response.MessageFromServer = "No game in progress!";
            }

            return Json(response, JsonRequestBehavior.AllowGet); 
        }
    }
}
