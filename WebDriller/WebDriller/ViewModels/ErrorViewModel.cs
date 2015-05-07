using Driller.Logic.Interfaces.Settings;
using Driller.Logic.Interfaces.ViewModels;
using JetBrains.Annotations;

namespace Driller.ViewModels
{
    [UsedImplicitly]
    public class ErrorViewModel : BaseViewModel, IErrorViewModel
    {
        public ErrorViewModel(IConfig configuration)
            : base(configuration)
        {
        }

        public string Message { get; set; }
    }
}
