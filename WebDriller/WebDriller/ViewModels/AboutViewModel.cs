using Driller.Logic.Interfaces.Settings;
using Driller.Logic.Interfaces.ViewModels;
using JetBrains.Annotations;

namespace Driller.ViewModels
{
    [UsedImplicitly]
    public class AboutViewModel : BaseViewModel, IAboutViewModel
    {
        public AboutViewModel(IConfig configuration)
            : base(configuration)
        {
        }
    }
}
