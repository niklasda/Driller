using Driller.Logic.Interfaces.Settings;
using Driller.Logic.Interfaces.ViewModels;
using JetBrains.Annotations;

namespace Driller.ViewModels
{
    [UsedImplicitly]
    public class HelpViewModel : BaseViewModel, IHelpViewModel
    {
        public HelpViewModel(IConfig configuration)
            : base(configuration)
        {
        }
    }
}
