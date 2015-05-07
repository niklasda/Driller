using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Driller.Logic.DataModels;
using Driller.Logic.Interfaces;
using Driller.Logic.Interfaces.ViewModels;
using Driller.ViewModels;
using StructureMap;

namespace Driller.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly ILeaderboardService _leaderboardService;
        
        public LeaderboardController()
            : this(ObjectFactory.GetInstance<ILeaderboardService>())
        {
        }

        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        public async Task<ActionResult> Index()
        {
            IList<HighScore> scores = await _leaderboardService.GetLeaderboard();

            var highScoreViewModels = scores.Select(x => new HighScoreViewModel { Name = x.Name, Score = x.Score });

            var model = ObjectFactory.GetInstance<ILeaderboardViewModel>();
            model.HighScoreViewModels = highScoreViewModels;

            return View(model);
        }
    }
}
