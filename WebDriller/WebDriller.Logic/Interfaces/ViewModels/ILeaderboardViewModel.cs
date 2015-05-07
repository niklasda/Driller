using System.Collections.Generic;

namespace Driller.Logic.Interfaces.ViewModels
{
    public interface ILeaderboardViewModel : IBaseViewModel
    {
        IEnumerable<IHighScoreViewModel> HighScoreViewModels { get; set; }
    }
}