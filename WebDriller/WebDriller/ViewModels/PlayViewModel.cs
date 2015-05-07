using Driller.Logic.Interfaces.Settings;
using Driller.Logic.Interfaces.ViewModels;
using JetBrains.Annotations;

namespace Driller.ViewModels
{
    [UsedImplicitly]
    public class PlayViewModel : BaseViewModel, IPlayViewModel
    {
        public PlayViewModel(IConfig configuration)
            : base(configuration)
        {
        }
    }
}
