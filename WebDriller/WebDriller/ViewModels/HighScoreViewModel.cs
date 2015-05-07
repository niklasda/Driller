using Driller.Logic.Interfaces.ViewModels;

namespace Driller.ViewModels
{
    public class HighScoreViewModel : IHighScoreViewModel
    {
        public string Name { get; set; }

        public int Score { get; set; }

    }
}
