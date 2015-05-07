using Driller.Logic.Interfaces.Settings;
using Driller.Logic.Interfaces.ViewModels;
using JetBrains.Annotations;

namespace Driller.ViewModels
{
    [UsedImplicitly]
    public class StartViewModel : BaseViewModel, IStartViewModel
    {
        public StartViewModel(IConfig configuration)
            : base(configuration)
        {
        }
    }
}
