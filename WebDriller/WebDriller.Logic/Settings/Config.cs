using Driller.Logic.Interfaces.Settings;
using JetBrains.Annotations;

namespace Driller.Logic.Settings
{
    [UsedImplicitly]
    public class Config : IConfig
    {
        public string AppName
        {
            get { return "Driller"; }
        }

        public string AzureApplicationKey
        {
            get { return "obsolete"; }
        }

        public string AzureServiceUri
        {
            get { return "https://nolongeravailable.net/"; }
        }
    }
}