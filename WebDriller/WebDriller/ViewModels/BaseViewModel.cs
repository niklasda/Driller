using Driller.Logic.Interfaces.Settings;

namespace Driller.ViewModels
{
    public class BaseViewModel 
    {
        protected BaseViewModel(IConfig configuration)
        {
            Configuration = configuration;
        }

        public IConfig Configuration { get; private set; }
    }
}
