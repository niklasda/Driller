using System.Collections.Generic;
using Driller.Logic.Interfaces.Settings;
using Driller.Logic.Interfaces.ViewModels;

namespace Driller.ViewModels
{
    public class LeaderboardViewModel : BaseViewModel, ILeaderboardViewModel
    {
        public LeaderboardViewModel(IConfig configuration)
            : base(configuration)
        {
        }

        public IEnumerable<IHighScoreViewModel> HighScoreViewModels { get; set; }

    }
}
