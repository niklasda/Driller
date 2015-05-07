using Driller.Logic.Interfaces.Settings;

namespace Driller.Logic.Interfaces.ViewModels
{
    public interface IBaseViewModel
    {
        IConfig Configuration { get;  }
    }
}